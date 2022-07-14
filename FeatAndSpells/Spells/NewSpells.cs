using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeatAndSpells.Blueprints;
using static FeatAndSpells.Blueprints.Archetypes;
using static FeatAndSpells.Blueprints.Features;
using static FeatAndSpells.Blueprints.FeatureSelections;
using static FeatAndSpells.Blueprints.Abilities;
using TabletopTweaks.Core.Utilities;
using Kingmaker.Blueprints.Classes;
using static FeatAndSpells.Main;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.RuleSystem;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Craft;
using Kingmaker.Utility;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.Enums.Damage;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.UI.UnitSettings.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.ResourceLinks;
using FeatAndSpells.NewContent.Spells;

namespace FeatAndSpells.Spells {
    public class NewSpells {
        //static public BlueprintAbility strong_jaw;
        //static public BlueprintAbility deadly_juggernaut;
        //static public BlueprintBuff deadly_juggernaut_buff;


        static public void HandleNewSpells() {
            //createFleshwormInfestation()
            //createDazeMass
            //createSmiteAbomination()
            //createLocateWeakness()
            //createWeaponOfAwe()
            // createFluidForm();
            CreateGreaterScare();
            createFreezingSphere();
            CreateFlurryOfSnowBalls();
            CreateCountlessEyes();
            CreateAspectOfEagle();
            CreateIceBolt();
            CreateFireBolt();
            CreateDeitysHolyShield();
            
            // siirretty MCE versioon
            CreateDeadlyJuggernaut();

            CreateOmaLongArm();
            CreateAuraOfDoom();
            CreateSavageMaw();
            CreateBoneFists();
            AddCommunalBarkSkin();
            AddCommunalDeathWard();
            AddCommunalEcholocation();
            AddCommunalFreedomOfMovement();
            AddCommunalShieldOfFaith();
            AddMassAid();
            AddMassBlur();
            AddMassHeroism();

        }

        private static void CreateGreaterScare() {

            var HDCheck = Helpers.Create<ContextActionDealDamage>(c => {
                c.DamageType = new DamageTypeDescription {
                    Type = DamageType.Energy,
                    Energy = DamageEnergyType.Cold
                };
                c.Duration = new ContextDurationValue() {
                    m_IsExtendable = true,
                    DiceCountValue = new ContextValue(),
                    BonusValue = new ContextValue()
                };
                c.Value = new ContextDiceValue {
                    DiceType = DiceType.D6,
                    DiceCountValue = new ContextValue() {
                        ValueType = ContextValueType.Rank,
                    },
                    BonusValue = new ContextValue { }
                };
                c.IsAoE = true;
                c.HalfIfSaved = true;

            });

            var ScareComp = Scare.GetComponent<AbilityEffectRunAction>();
            var ScareAction = ScareComp.Actions.Actions.OfType<Conditional>().First();
            var ScareConditionChecker = ScareAction.ConditionsChecker.Conditions.OfType<ContextConditionHitDice>().First();
            ScareConditionChecker.HitDice = 12;

            var GreaterScare = Scare.CreateCopy<BlueprintAbility>(FASContext, "GreaterScare", bp => {
                bp.SetName(FASContext, "Scare, Greater");
                bp.SetDescription(FASContext, "All targeted living creatures of become frightened. " +
                    "If a creature succeeds at a {g|Encyclopedia:Saving_Throw}Will save{/g}, " +
                    "it is instead shaken for 1 {g|Encyclopedia:Combat_Round}round{/g}. Scare dispels remove fear.");

                var newScareComp = bp.GetComponent<AbilityEffectRunAction>();
                var GreaterScareAction = newScareComp.Actions.Actions.OfType<Conditional>().First();
                var GreaterScareConditionChecker = GreaterScareAction.ConditionsChecker.Conditions.OfType<ContextConditionHitDice>().First();
                GreaterScareConditionChecker.HitDice = 99;


            });
            GreaterScare.AddToSpellList(SpellTools.SpellList.WizardSpellList, 6);
            GreaterScare.AddToSpellList(SpellTools.SpellList.WitchSpellList, 6);
            GreaterScare.AddToSpellList(SpellTools.SpellList.DruidSpellList, 6);
            GreaterScare.AddToSpellList(SpellTools.SpellList.ShamanSpelllist, 6);
        }

        private static void CreateOmaLongArm() {

            //var icon = AssetLoader.Image2Sprite.Create($"{Context.ModEntry.Path}Assets{Path.DirectorySeparatorChar}Abilities{Path.DirectorySeparatorChar}Icon_LongArm.png");
            var icon = AssetLoader.LoadInternal(FASContext, folder: "Abilities", file: "Icon_LongArm.png");
            var LongArmBuff = Helpers.CreateBlueprint<BlueprintBuff>(FASContext, "LongArmBuff", bp => {
                bp.SetName(FASContext, "Long Arm");
                bp.SetDescription(FASContext, "Your arms temporarily grow in length, increasing your reach with those limbs by 5 feet.");
                bp.m_Icon = icon;
                bp.m_Flags = BlueprintBuff.Flags.IsFromSpell;
                bp.AddComponent(Helpers.Create<AddStatBonus>(c => {
                    c.Stat = StatType.Reach;
                    c.Descriptor = ModifierDescriptor.Enhancement;
                    c.Value = 5;
                }));
            });
            var applyBuff = Helpers.Create<ContextActionApplyBuff>(bp => {
                bp.IsFromSpell = true;
                bp.m_Buff = LongArmBuff.ToReference<BlueprintBuffReference>();
                bp.DurationValue = new ContextDurationValue() {
                    Rate = DurationRate.Minutes,
                    BonusValue = new ContextValue() {
                        ValueType = ContextValueType.Rank
                    },
                    DiceCountValue = new ContextValue(),
                    DiceType = DiceType.One
                };
            });
            var LongArmAbility = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "LongArmAbility", bp => {
                bp.SetName(FASContext, "Long Arm");
                bp.SetDescription(FASContext, "Your arms temporarily grow in length, increasing your reach with those limbs by 5 feet.");
                bp.LocalizedDuration = Helpers.CreateString(FASContext, "LongArmAbility.Duration", "1 minute/level");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Extend | Metamagic.Heighten | Metamagic.Quicken | Metamagic.CompletelyNormal;
                bp.Range = AbilityRange.Personal;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Self;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.m_Icon = icon;
                bp.ResourceAssetIds = new string[0];
                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { applyBuff }
                    };
                }));
                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Transmutation;
                }));
                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Buff;
                    c.SavingThrow = CraftSavingThrow.None;
                    c.AOEType = CraftAOE.None;
                }));
            });

            LongArmAbility.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 1);
            LongArmAbility.AddToSpellList(SpellTools.SpellList.InquisitorSpellList, 1);
        }


        static void createFreezingSphere() {
            var icon = AssetLoader.LoadInternal(FASContext, "Abilities", "FreezingSphere.png");
            //var icon = Resources.GetBlueprint<BlueprintAbility>("9f10909f0be1f5141bf1c102041f93d9");
            //KineticFistBlizzardBlast
            var SnowProjectile = BlueprintTools.GetBlueprint<BlueprintProjectile>("8927afa172e0fc54484a29fa0c4c40c4");
            var RayWeapon = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("f6ef95b1f7bb52b408a5b345a330ffe8");
            var SnowballBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("f767ee03a6cb62943b59bacbd8ced2e0");

            var dealDamage = Helpers.Create<ContextActionDealDamage>(c => {
                c.DamageType = new DamageTypeDescription {
                    Type = DamageType.Energy,
                    Energy = DamageEnergyType.Cold
                };
                c.Duration = new ContextDurationValue() {
                    m_IsExtendable = true,
                    DiceCountValue = new ContextValue(),
                    BonusValue = new ContextValue()
                };
                c.Value = new ContextDiceValue {
                    DiceType = DiceType.D6,
                    DiceCountValue = new ContextValue() {
                        ValueType = ContextValueType.Rank,
                    },
                    BonusValue = new ContextValue { }
                };
                c.IsAoE = true;
                c.HalfIfSaved = true;

            });


            var StaggerCheck = Helpers.Create<ContextActionConditionalSaved>(c => {
                c.Succeed = Helpers.CreateActionList();
                c.Failed = Helpers.CreateActionList(
                                 new ContextActionApplyBuff() {
                                     m_Buff = SnowballBuff.ToReference<BlueprintBuffReference>(),
                                     Permanent = false,
                                     UseDurationSeconds = false,
                                     DurationValue = new ContextDurationValue() {
                                         Rate = DurationRate.Rounds,
                                         DiceType = DiceType.Zero,
                                         m_IsExtendable = true,
                                         DiceCountValue = new ContextValue() {
                                             ValueType = ContextValueType.Simple,
                                             Value = 0,
                                             ValueRank = AbilityRankType.Default,
                                             ValueShared = AbilitySharedValue.Damage,
                                             Property = Kingmaker.UnitLogic.Mechanics.Properties.UnitProperty.None,
                                         },
                                         BonusValue = new ContextValue() {
                                             ValueType = ContextValueType.Simple,
                                             Value = 1,
                                             ValueRank = AbilityRankType.Default,
                                             ValueShared = AbilitySharedValue.Damage,
                                             Property = Kingmaker.UnitLogic.Mechanics.Properties.UnitProperty.None,
                                         },
                                     },
                                     DurationSeconds = 0,
                                     IsFromSpell = false,
                                     IsNotDispelable = false,
                                     ToCaster = false,
                                     AsChild = false,
                                     SameDuration = false,
                                 }
                           );
            });



            var FreezingSphere = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "FreezingSphere", bp => {
                bp.SetName(FASContext, "Freezing Sphere ");
                bp.SetDescription(FASContext, "Freezing sphere creates a frigid globe of cold energy that streaks from your fingertips to the location you select," +
                    " where it explodes in a 40-foot-radius burst, dealing 1d{BalanceFixes.getDamageDieString(DiceType.D6)} points of cold damage per caster level " +
                    "to each creature in the area and is staggered for 1d4 rounds.");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Empower | Metamagic.Quicken | Metamagic.Maximize | Metamagic.Quicken | Metamagic.Bolstered | Metamagic.Selective;
                bp.Range = AbilityRange.Long;
                bp.SpellResistance = true;
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = true;
                bp.CanTargetFriends = true;
                bp.ActionBarAutoFillIgnored = true;
                bp.EffectOnAlly = AbilityEffectOnUnit.Harmful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Directional;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.m_Icon = icon;
                bp.ResourceAssetIds = new string[0];
                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Reflex;
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { dealDamage, StaggerCheck }
                    };
                }));

                bp.AddComponent(Helpers.Create<ContextRankConfig>(c => {
                    c.m_UseMax = true;
                    c.m_Min = 1;
                    c.m_Max = 20;
                }));
                bp.AddComponent(Helpers.Create<AbilityTargetsAround>(c => {
                    c.m_Radius.m_Value = 25;
                    c.m_TargetType = TargetType.Any;
                    c.m_SpreadSpeed.m_Value = 25;
                }));
                bp.AddComponent(Helpers.Create<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[]
                    {
                        SnowProjectile.ToReference<BlueprintProjectileReference>()
                    };
                    c.m_LineWidth = 5.Feet();
                    c.m_Length = 0.Feet();
                    c.Type = AbilityProjectileType.Cone;
                }));
                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Evocation;
                }));
                bp.AddComponent(Helpers.Create<CantripComponent>(c => {
                }));
                bp.AddComponent(Helpers.Create<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Cold;
                }));
                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { dealDamage }
                    };
                }));
                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Damage;
                    c.SavingThrow = CraftSavingThrow.Reflex;
                    c.AOEType = CraftAOE.AOE;
                }));
            });
            FreezingSphere.AddToSpellList(SpellTools.SpellList.WizardSpellList, 7);
            FreezingSphere.AddToSpellList(SpellTools.SpellList.WitchSpellList, 7);
            FreezingSphere.AddToSpellList(SpellTools.SpellList.DruidSpellList, 7);
            FreezingSphere.AddToSpellList(SpellTools.SpellList.ShamanSpelllist, 7);


        }

        static void CreateFlurryOfSnowBalls() {
            var icon = AssetLoader.LoadInternal(FASContext, "Abilities", "KineticFistBlizzardBlast.png");
            //var icon = Resources.GetBlueprint<BlueprintAbility>("9f10909f0be1f5141bf1c102041f93d9");
            //KineticFistBlizzardBlast
            var SnowProjectile = BlueprintTools.GetBlueprint<BlueprintProjectile>("79a66a3766ae87146beb6000a73e8213");
            var RayWeapon = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("f6ef95b1f7bb52b408a5b345a330ffe8");

            var dealDamage = Helpers.Create<ContextActionDealDamage>(c => {
                c.DamageType = new DamageTypeDescription {
                    Type = DamageType.Energy,
                    Energy = DamageEnergyType.Cold
                };
                c.Duration = new ContextDurationValue() {
                    m_IsExtendable = true,
                    DiceCountValue = new ContextValue(),
                    BonusValue = new ContextValue()
                };
                c.Value = new ContextDiceValue {
                    DiceType = DiceType.D8,
                    DiceCountValue = new ContextValue() {
                        ValueType = ContextValueType.Rank,
                    },
                    BonusValue = new ContextValue { }
                };
                c.IsAoE = true;
                c.HalfIfSaved = true;

            });

            var FlurryOFSnowBalls = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "FlurryOFSnowBalls", bp => {
                bp.SetName(FASContext, "Flurry Of SnowBalls ");
                bp.SetDescription(FASContext, "You send a flurry of snowballs hurtling at your foes.\n"
                                                + $"Any creature in the area takes 1d6 points of cold damage per level from being pelted with the icy spheres.");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Empower | Metamagic.Quicken | Metamagic.Maximize | Metamagic.Quicken | Metamagic.Bolstered | Metamagic.Selective;
                bp.Range = AbilityRange.Projectile;
                bp.SpellResistance = true;
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = true;
                bp.CanTargetFriends = true;
                bp.ActionBarAutoFillIgnored = true;
                bp.EffectOnAlly = AbilityEffectOnUnit.Harmful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Directional;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.m_Icon = icon;
                bp.ResourceAssetIds = new string[0];
                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.SavingThrowType = SavingThrowType.Reflex;
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { dealDamage }
                    };
                }));

                bp.AddComponent(Helpers.Create<ContextRankConfig>(c => {
                    c.m_UseMax = true;
                    c.m_Min = 1;
                    c.m_Max = 20;
                    c.m_StartLevel = 3;
                    c.m_StepLevel = 4;
                }));
                bp.AddComponent(Helpers.Create<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[]
                    {
                        SnowProjectile.ToReference<BlueprintProjectileReference>()
                    };
                    c.m_LineWidth = 5.Feet();
                    c.m_Length = 20.Feet();
                    c.Type = AbilityProjectileType.Cone;
                }));
                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Evocation;
                }));
                bp.AddComponent(Helpers.Create<CantripComponent>(c => {
                }));
                bp.AddComponent(Helpers.Create<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Cold;
                }));
                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { dealDamage }
                    };
                }));
                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Damage;
                    c.SavingThrow = CraftSavingThrow.Reflex;
                    c.AOEType = CraftAOE.AOE;
                }));
            });
            FlurryOFSnowBalls.AddToSpellList(SpellTools.SpellList.WizardSpellList, 2);
            FlurryOFSnowBalls.AddToSpellList(SpellTools.SpellList.WitchSpellList, 2);
            FlurryOFSnowBalls.AddToSpellList(SpellTools.SpellList.DruidSpellList, 2);
            FlurryOFSnowBalls.AddToSpellList(SpellTools.SpellList.ShamanSpelllist, 2);
        }




        static void CreateCountlessEyes() {
            var icon = AssetLoader.LoadInternal(FASContext, "Abilities", "BurstOfGloryNegative.png");

            var CountlessEyesBuff = Helpers.CreateBlueprint<BlueprintBuff>(FASContext, "CountlessEyesBuff", bp => {
                bp.SetName(FASContext, "Countless Eyes");
                bp.SetDescription(FASContext, "The target sprouts extra eyes all over its body, including on the back of its head. It gains all-around vision and cannot be flanked. The eyes also gives a competence bonus to perception and trickery rolls");
                bp.m_Icon = icon;
                bp.TickEachSecond = false;
                bp.Frequency = DurationRate.Minutes;
                bp.Stacking = StackingType.Replace;
                bp.AddComponent(Helpers.Create<ContextRankConfig>(a => {
                    a.m_UseMax = true;
                    a.m_Max = 20;
                }));
                bp.AddComponent(Helpers.Create<AddContextStatBonus>(c => {
                    c.Value = 3;
                    c.Multiplier = 1;
                    c.Stat = StatType.SkillPerception;
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Value = new ContextValue() {
                        ValueType = ContextValueType.Rank
                    };
                }));
                bp.AddComponent(Helpers.Create<AddContextStatBonus>(c => {
                    c.Value = 3;
                    c.Multiplier = 1;
                    c.Stat = StatType.SkillThievery;
                    c.Descriptor = ModifierDescriptor.Competence;
                    c.Value = new ContextValue() {
                        ValueType = ContextValueType.Rank
                    };
                }));
                bp.AddComponent(Helpers.Create<AddMechanicsFeature>(c => {
                    c.m_Feature = AddMechanicsFeature.MechanicsFeatureType.CannotBeFlanked;
                }));
            });

            var applyBuff = Helpers.Create<ContextActionApplyBuff>(bp => {
                bp.IsFromSpell = true;
                bp.m_Buff = CountlessEyesBuff.ToReference<BlueprintBuffReference>();
                bp.DurationValue = new ContextDurationValue() {
                    Rate = DurationRate.Hours,
                    BonusValue = new ContextValue() {
                        ValueType = ContextValueType.Rank
                    },
                    DiceCountValue = new ContextValue(),
                    DiceType = DiceType.One
                };
            });
            var CountlessEyesAbility = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "CountlessEyesAbility", bp => {
                bp.SetName(FASContext, "Countless Eyes");
                bp.SetDescription(FASContext, "The target sprouts extra eyes all over its body, including on the back of its head. It gains all-around vision and cannot be flanked. The eyes also gives a competence bonus to perception and trickery rolls");
                bp.LocalizedDuration = Helpers.CreateString(FASContext, "CountlessEyesAbility.Duration", "1 hour/level");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Extend | Metamagic.Heighten | Metamagic.Quicken;
                bp.Range = AbilityRange.Touch;
                bp.CanTargetFriends = true;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;

                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Touch;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.m_Icon = icon;
                bp.ResourceAssetIds = new string[0];
                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { applyBuff }
                    };
                }));
                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Transmutation;
                }));
                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Buff;
                    c.SavingThrow = CraftSavingThrow.None;
                    c.AOEType = CraftAOE.None;
                }));
            });
            CountlessEyesAbility.AddToSpellList(SpellTools.SpellList.AlchemistSpellList, 3);
            CountlessEyesAbility.AddToSpellList(SpellTools.SpellList.BloodragerSpellList, 3);
            CountlessEyesAbility.AddToSpellList(SpellTools.SpellList.InquisitorSpellList, 3);
            CountlessEyesAbility.AddToSpellList(SpellTools.SpellList.WizardSpellList, 3);
            CountlessEyesAbility.AddToSpellList(SpellTools.SpellList.WitchSpellList, 3);
        }


        static void CreateAspectOfEagle() {

            var icon = AssetLoader.LoadInternal(FASContext, "Abilities", "BowSpirit.png");



            var AspectOfEagleBuff = Helpers.CreateBlueprint<BlueprintBuff>(FASContext, "AspectOfEagleBuff", bp => {
                bp.SetName(FASContext, "Aspect of the Eagle");
                bp.SetDescription(FASContext, "You take on an aspect of a eagle. Your eyes become wide and raptor-like, " +
                    "and you grow feathers on the sides of your head. " +
                    "You gain a +15 competence {g|Encyclopedia:Bonus}bonus{/g} on {g|Encyclopedia:Perception}Perception checks{/g}," +
                    " +6 enchantment bonus to dexterity, and a +1 competence bonus on ranged attacks{/g}," +
                    " and the critical multiplier for your bows and crossbows becomes 19–20/×3.\n" +
                    "This effect does not stack with any other effect that expands the threat range of a weapon, such as the Improved Critical {g|Encyclopedia:Feat}feat{/g} or a keen weapon.");
                bp.m_Icon = icon;
                bp.TickEachSecond = false;
                bp.Frequency = DurationRate.Minutes;
                bp.Stacking = StackingType.Replace;
                bp.AddComponent(Helpers.Create<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Polymorph;
                }));
                bp.AddComponent(Helpers.Create<AttackTypeAttackBonus>(c => {
                    c.Type = WeaponRangeType.Ranged;
                    c.AttackBonus = 1;
                    c.Value = 1;
                    c.Descriptor = ModifierDescriptor.Competence;
                }));

                bp.AddComponent(Helpers.Create<AddStatBonus>(c => {
                    c.Value = 6;
                    c.Stat = StatType.Dexterity;
                    c.Descriptor = ModifierDescriptor.Enhancement;
                }));
                bp.AddComponent(Helpers.Create<AddStatBonus>(c => {
                    c.Value = 15;
                    c.Stat = StatType.SkillPerception;
                    c.Descriptor = ModifierDescriptor.Competence;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeCriticalMultiplierIncrease>(c => {
                    c.m_WeaponType = Blueprints.Items.CompositeLongbow.ToReference<BlueprintWeaponTypeReference>();
                    c.AdditionalMultiplier = 1;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeCriticalMultiplierIncrease>(c => {
                    c.m_WeaponType = Blueprints.Items.CompositeShortbow.ToReference<BlueprintWeaponTypeReference>();
                    c.AdditionalMultiplier = 1;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeCriticalMultiplierIncrease>(c => {
                    c.m_WeaponType = Blueprints.Items.Longbow.ToReference<BlueprintWeaponTypeReference>();
                    c.AdditionalMultiplier = 1;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeCriticalMultiplierIncrease>(c => {
                    c.m_WeaponType = Blueprints.Items.Shortbow.ToReference<BlueprintWeaponTypeReference>();
                    c.AdditionalMultiplier = 1;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeCriticalMultiplierIncrease>(c => {
                    c.m_WeaponType = Blueprints.Items.LightCrossbow.ToReference<BlueprintWeaponTypeReference>();
                    c.AdditionalMultiplier = 1;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeCriticalMultiplierIncrease>(c => {
                    c.m_WeaponType = Blueprints.Items.HeavyCrossbow.ToReference<BlueprintWeaponTypeReference>();
                    c.AdditionalMultiplier = 1;
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeCriticalEdgeIncrease>(c => {
                    c.m_WeaponType = Blueprints.Items.CompositeLongbow.ToReference<BlueprintWeaponTypeReference>();
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeCriticalEdgeIncrease>(c => {
                    c.m_WeaponType = Blueprints.Items.CompositeShortbow.ToReference<BlueprintWeaponTypeReference>();
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeCriticalEdgeIncrease>(c => {
                    c.m_WeaponType = Blueprints.Items.Longbow.ToReference<BlueprintWeaponTypeReference>();
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeCriticalEdgeIncrease>(c => {
                    c.m_WeaponType = Blueprints.Items.Shortbow.ToReference<BlueprintWeaponTypeReference>();
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeCriticalEdgeIncrease>(c => {
                    c.m_WeaponType = Blueprints.Items.LightCrossbow.ToReference<BlueprintWeaponTypeReference>();
                }));
                bp.AddComponent(Helpers.Create<WeaponTypeCriticalEdgeIncrease>(c => {
                    c.m_WeaponType = Blueprints.Items.HeavyCrossbow.ToReference<BlueprintWeaponTypeReference>();
                }));
            });

            var applyBuff = Helpers.Create<ContextActionApplyBuff>(bp => {
                bp.IsFromSpell = true;
                bp.m_Buff = AspectOfEagleBuff.ToReference<BlueprintBuffReference>();
                bp.DurationValue = new ContextDurationValue() {
                    Rate = DurationRate.Minutes,
                    BonusValue = new ContextValue() {
                        ValueType = ContextValueType.Rank
                    },
                    DiceCountValue = new ContextValue(),
                    DiceType = DiceType.One
                };
            });
            var AspectOfEagleAbility = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "AspectOfEagleAbility", bp => {
                bp.SetName(FASContext, "Aspect of the Eagle");
                bp.SetDescription(FASContext, "You take on an aspect of a eagle. Your eyes become wide and raptor-like, " +
                    "and you grow feathers on the sides of your head. " +
                    "You gain a +15 competence {g|Encyclopedia:Bonus}bonus{/g} on {g|Encyclopedia:Perception}Perception checks{/g}," +
                    " +6 enchantment bonus to dexterity, and a +1 competence bonus on ranged attacks{/g}," +
                    " and the critical multiplier for your bows and crossbows becomes 19–20/×3.\n" +
                    "This effect does not stack with any other effect that expands the threat range of a weapon, such as the Improved Critical {g|Encyclopedia:Feat}feat{/g} or a keen weapon.");
                bp.LocalizedDuration = Helpers.CreateString(FASContext, "AspectOfEagleAbility.Duration", "1 minute/level");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Extend | Metamagic.Heighten | Metamagic.Quicken;
                bp.Range = AbilityRange.Personal;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Self;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.m_Icon = icon;
                bp.ResourceAssetIds = new string[0];
                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { applyBuff }
                    };
                }));
                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Transmutation;
                }));
                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Buff;
                    c.SavingThrow = CraftSavingThrow.None;
                    c.AOEType = CraftAOE.None;
                }));
            });
            AspectOfEagleAbility.AddToSpellList(SpellTools.SpellList.RangerSpellList, 4);
            AspectOfEagleAbility.AddToSpellList(SpellTools.SpellList.BardSpellList, 5);
            AspectOfEagleAbility.AddToSpellList(SpellTools.SpellList.DruidSpellList, 6);
            AspectOfEagleAbility.AddToSpellList(SpellTools.SpellList.ClericSpellList, 6);

        }

        static void CreateIceBolt() {

            var icon = BlueprintTools.GetBlueprint<BlueprintAbility>("9f10909f0be1f5141bf1c102041f93d9");
            var SnowProjectile = BlueprintTools.GetBlueprint<BlueprintProjectile>("81a8bff536bae184bacb3a58f0bc381a");
            var RayWeapon = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("f6ef95b1f7bb52b408a5b345a330ffe8");


            var dealDamage = Helpers.Create<ContextActionDealDamage>(c => {
                c.DamageType = new DamageTypeDescription {
                    Type = DamageType.Energy,
                    Energy = DamageEnergyType.Cold
                };
                c.Duration = new ContextDurationValue() {
                    m_IsExtendable = true,
                    DiceCountValue = new ContextValue(),
                    BonusValue = new ContextValue()
                };
                c.Value = new ContextDiceValue {
                    DiceType = DiceType.D3,
                    DiceCountValue = new ContextValue() {
                        Value = 0,
                        ValueType = ContextValueType.Rank,
                        ValueRank = default,
                        ValueShared = AbilitySharedValue.Damage,
                        Property = Kingmaker.UnitLogic.Mechanics.Properties.UnitProperty.None
                    },
                    BonusValue = new ContextValue {
                        Value = 0,
                        ValueType = ContextValueType.Simple,
                        ValueRank = AbilityRankType.DamageBonus
                    }
                };

            });

            var IceBoltAbility = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "IceBoltAbility", bp => {
                bp.SetName(FASContext, "Ice Bolt");
                bp.SetDescription(FASContext, "You launch a small Ice bolt as a ranged {g|Encyclopedia:TouchAttack}touch attack{/g}. " +
                    "The Ice bolt deals {g|Encyclopedia:Dice}1d4{/g} points of {g|Encyclopedia:Energy_Damage}Ice damage{/g} per {g|Encyclopedia:Caster_Level} two caster levels{/g}");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Empower | Metamagic.Quicken | Metamagic.Maximize | Metamagic.Quicken | Metamagic.Bolstered;
                bp.Range = AbilityRange.Close;
                bp.SpellResistance = true;
                bp.CanTargetEnemies = true;
                bp.ActionBarAutoFillIgnored = true;
                bp.EffectOnAlly = AbilityEffectOnUnit.Harmful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Directional;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.m_Icon = icon.Icon;
                bp.ResourceAssetIds = new string[0];
                bp.AddComponent(Helpers.Create<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[]
                    {
                        SnowProjectile.ToReference<BlueprintProjectileReference>()
                    };
                    c.m_LineWidth = 5.Feet();
                    c.NeedAttackRoll = true;
                    c.UseMaxProjectilesCount = true;
                    c.DelayBetweenProjectiles = 0.2f;
                    c.m_Weapon = RayWeapon.ToReference<BlueprintItemWeaponReference>();
                }));
                bp.AddComponent(Helpers.Create<ContextRankConfig>(c => {
                    c.m_BaseValueType = ContextRankBaseValueType.CasterLevel;
                    c.m_Progression = ContextRankProgression.AsIs;
                    c.m_StartLevel = 0;
                    c.m_StepLevel = 0;
                    c.m_Min = 0;
                    c.m_Max = 5;
                    c.m_UseMax = true;

                }));
                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Evocation;
                }));
                bp.AddComponent(Helpers.Create<CantripComponent>(c => {
                }));
                bp.AddComponent(Helpers.Create<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Cold;
                }));
                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { dealDamage }
                    };
                }));
                bp.AddComponent(Helpers.Create<ActionPanelLogic>(c => {
                    c.Priority = 15;
                    c.AutoCastConditions = new ConditionsChecker {
                        Operation = Operation.Or
                    };
                }));
                bp.AddComponent(Helpers.Create<ContextRankConfig>(c => {
                    c.m_UseMax = true;
                    c.m_Max = 10;
                    c.m_Progression = ContextRankProgression.OnePlusDiv2;
                }));
                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Damage;
                    c.SavingThrow = CraftSavingThrow.None;
                    c.AOEType = CraftAOE.None;
                }));
            });
            IceBoltAbility.AddToSpellList(SpellTools.SpellList.WizardSpellList, 0);
            IceBoltAbility.AddToSpellList(SpellTools.SpellList.WitchSpellList, 0);
            IceBoltAbility.AddToSpellList(SpellTools.SpellList.BardSpellList, 0);
            IceBoltAbility.AddToSpellList(SpellTools.SpellList.ClericSpellList, 0);
            IceBoltAbility.AddToSpellList(SpellTools.SpellList.ShamanSpelllist, 0);
        }

        static void CreateFireBolt() {
            var icon = BlueprintTools.GetBlueprint<BlueprintAbility>("42a65895ba0cb3a42b6019039dd2bff1");

            var MoltenProjectile = BlueprintTools.GetBlueprint<BlueprintProjectile>("49c812020338e90479b54cfc5b1f6305");
            var RayWeapon = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("f6ef95b1f7bb52b408a5b345a330ffe8");

            var dealDamage = Helpers.Create<ContextActionDealDamage>(c => {
                c.DamageType = new DamageTypeDescription {
                    Type = DamageType.Energy,
                    Energy = DamageEnergyType.Fire
                };
                c.Duration = new ContextDurationValue() {
                    m_IsExtendable = true,
                    DiceCountValue = new ContextValue(),
                    BonusValue = new ContextValue()
                };
                c.Value = new ContextDiceValue {
                    DiceType = DiceType.D3,
                    DiceCountValue = new ContextValue() {
                        Value = 0,
                        ValueType = ContextValueType.Rank,
                        ValueRank = default,
                        ValueShared = AbilitySharedValue.Damage,
                        Property = Kingmaker.UnitLogic.Mechanics.Properties.UnitProperty.None
                    },
                    BonusValue = new ContextValue {
                        Value = 0,
                        ValueType = ContextValueType.Simple,
                        ValueRank = AbilityRankType.DamageBonus
                    }
                };

            });

            var FireBoltAbility = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "FireBoltAbility", bp => {
                bp.SetName(FASContext, "Fire Bolt");
                bp.SetDescription(FASContext, "You launch a small fire bolt as a ranged {g|Encyclopedia:TouchAttack}touch attack{/g}. " +
                    "The fire bolt deals {g|Encyclopedia:Dice}1d4{/g} points of {g|Encyclopedia:Energy_Damage}fire damage{/g} per {g|Encyclopedia:Caster_Level} two caster levels{/g}");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Empower | Metamagic.Quicken | Metamagic.Maximize | Metamagic.Quicken | Metamagic.Bolstered;
                bp.Range = AbilityRange.Medium;
                bp.SpellResistance = true;
                bp.CanTargetEnemies = true;
                bp.ActionBarAutoFillIgnored = true;
                bp.EffectOnAlly = AbilityEffectOnUnit.Harmful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Directional;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.m_Icon = icon.Icon;
                bp.ResourceAssetIds = new string[0];
                bp.AddComponent(Helpers.Create<AbilityDeliverProjectile>(c => {
                    c.m_Projectiles = new BlueprintProjectileReference[]
                    {
                        MoltenProjectile.ToReference<BlueprintProjectileReference>()
                    };
                    c.m_LineWidth = 5.Feet();
                    c.NeedAttackRoll = true;
                    c.UseMaxProjectilesCount = true;
                    c.DelayBetweenProjectiles = 0.2f;
                    c.m_Weapon = RayWeapon.ToReference<BlueprintItemWeaponReference>();
                }));
                bp.AddComponent(Helpers.Create<ContextRankConfig>(c => {
                    c.m_BaseValueType = ContextRankBaseValueType.CasterLevel;
                    c.m_Progression = ContextRankProgression.AsIs;
                    c.m_StartLevel = 0;
                    c.m_StepLevel = 0;
                    c.m_Min = 0;
                    c.m_Max = 5;
                    c.m_UseMax = true;
                }));
                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Evocation;
                }));
                bp.AddComponent(Helpers.Create<CantripComponent>(c => {
                }));
                bp.AddComponent(Helpers.Create<SpellDescriptorComponent>(c => {
                    c.Descriptor = SpellDescriptor.Fire;
                }));
                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { dealDamage }
                    };
                }));
                bp.AddComponent(Helpers.Create<ActionPanelLogic>(c => {
                    c.Priority = 15;
                    c.AutoCastConditions = new ConditionsChecker {
                        Operation = Operation.Or
                    };
                }));
                bp.AddComponent(Helpers.Create<ContextRankConfig>(c => {
                    c.m_UseMax = true;
                    c.m_Max = 10;
                    c.m_Progression = ContextRankProgression.OnePlusDiv2;
                }));
                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Damage;
                    c.SavingThrow = CraftSavingThrow.None;
                    c.AOEType = CraftAOE.None;
                }));
            });
            FireBoltAbility.AddToSpellList(SpellTools.SpellList.WizardSpellList, 0);
            FireBoltAbility.AddToSpellList(SpellTools.SpellList.WitchSpellList, 0);
            FireBoltAbility.AddToSpellList(SpellTools.SpellList.BardSpellList, 0);
            FireBoltAbility.AddToSpellList(SpellTools.SpellList.ClericSpellList, 0);
            FireBoltAbility.AddToSpellList(SpellTools.SpellList.ShamanSpelllist, 0);
        }
        static void CreateDeitysHolyShield() {
            var icon = AssetLoader.LoadInternal(FASContext, "Abilities", "BoneWard.png");

            var MageShieldBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("9c0fa9b438ada3f43864be8dd8b3e741");
            var applyBuff = Helpers.Create<ContextActionApplyBuff>(bp => {
                bp.IsFromSpell = true;
                bp.m_Buff = MageShieldBuff.ToReference<BlueprintBuffReference>();
                bp.DurationValue = new ContextDurationValue() {
                    Rate = DurationRate.Minutes,
                    BonusValue = new ContextValue() {
                        ValueType = ContextValueType.Rank
                    },
                    DiceCountValue = new ContextValue(),
                    DiceType = DiceType.One
                };
            });
            var DeitysHolyShieldAbility = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "DeitysHolyShieldAbility", bp => {
                bp.SetName(FASContext, "HolyShield");
                bp.SetDescription(FASContext, "Your connection to your deity creates a invisible shield of divine force, that protects you from attacks. It grants you immunity to magic missle and provides you +4 shield bonus. This effect is similar to wizards Shield spell.");
                bp.LocalizedDuration = Helpers.CreateString(FASContext, "HolyShield.Duration", "1 minute/level");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Extend | Metamagic.Heighten | Metamagic.Quicken;
                bp.Range = AbilityRange.Personal;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Self;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.m_Icon = icon;
                bp.ResourceAssetIds = new string[0];
                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { applyBuff }
                    };
                }));
                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Divination;
                }));
                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Buff;
                    c.SavingThrow = CraftSavingThrow.None;
                    c.AOEType = CraftAOE.None;
                }));
            });
            DeitysHolyShieldAbility.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 4);

        }
        static void CreateDeadlyJuggernaut() {
            //var sneakAttack = Resources.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");
            var DeadlyJuggernautAbility = DeadlyJuggernaut.AddDeadlyJuggernaut();

            DeadlyJuggernautAbility.AddToSpellList(SpellTools.SpellList.ClericSpellList, 3);
            DeadlyJuggernautAbility.AddToSpellList(SpellTools.SpellList.InquisitorSpellList, 3);
            DeadlyJuggernautAbility.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 3);
        }
        static void CreateAuraOfDoom() {


            var icon = AssetLoader.LoadInternal(FASContext, "Abilities", "AuraOfDoom.png");
            var ShakenBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("54754f00bb628d547a089d7c94ee3c68");
            var FrightenedBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("f08a7239aa961f34c8301518e71d4cdf");

            var DirgeOfDoomBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("85d52d9ef99b9d24180b48b8da7f29d8");
            var DirgeOfDoomArea = BlueprintTools.GetBlueprint<BlueprintAbilityAreaEffect>("476466903e6dcf1408c10a3c729fdc95");



            var AuraOfDoomArea = DirgeOfDoomArea.CreateCopy<BlueprintAbilityAreaEffect>(FASContext, "AuraOfDoomArea", area => {
                area.Size = 15.Feet();
                area.Shape = AreaEffectShape.Cylinder;
                area.SpellResistance = true;
                //bp.AddComponent<AddTargetAttackRollTrigger>(attack => {
                //    attack.OnlyHit = true;
                //    attack.ActionsOnAttacker = AuraActionsOnAttacker ;
                //    attack.ActionOnSelf = new ActionList { };
                //});
            });




            var AuraOfDoomBuff = DirgeOfDoomBuff.CreateCopy<BlueprintBuff>(FASContext, "AuraOfDoomBuff", bp => {
                bp.SetName(FASContext, "Aura Of Doom");
                bp.SetDescription(FASContext, "You emanate an almost palpable aura of horror(with 30 ft.radius).All enemies within this spell’s area, " +
                    "or that later enter the area, must make a Will save to avoid becoming shaken.A successful save suppresses the effect.");
                bp.m_Icon = icon;
                bp.TickEachSecond = false;
                bp.Frequency = DurationRate.Minutes;
                bp.Stacking = StackingType.Replace;
                bp.m_Flags = 0;
                bp.RemoveComponents<AddAreaEffect>();
                bp.AddComponent<AddAreaEffect>(area => {
                    area.m_AreaEffect = AuraOfDoomArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
                //bp.AddComponent<AddTargetAttackRollTrigger>(attack => {
                //    attack.OnlyHit = true;
                //    attack.ActionsOnAttacker = AuraActionsOnAttacker ;
                //    attack.ActionOnSelf = new ActionList { };
                //});
            });


            var AuraOfDoomAbility = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "AuraOfDoomAbility", bp => {
                bp.SetName(FASContext, "Aura Of Doom");
                bp.SetDescription(FASContext, "You emanate an almost palpable aura of horror(with 30 ft.radius).All enemies within this spell’s area, " +
                    "or that later enter the area, must make a Will save to avoid becoming shaken.A successful save suppresses the effect." );
                bp.LocalizedDuration = Helpers.CreateString(FASContext, "AuraOfDoomAbility.Duration", "10 minute/level");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Extend | Metamagic.Heighten | Metamagic.Quicken;
                bp.Range = AbilityRange.Personal;
                bp.OnlyForAllyCaster = false;
                bp.CanTargetPoint = false;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = true;
                bp.CanTargetSelf = true;
                bp.SpellResistance = false;
                bp.EffectOnAlly = AbilityEffectOnUnit.None;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Self;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.m_Icon = icon;
                bp.ResourceAssetIds = new string[0];
                bp.AddComponent<AbilityEffectRunAction>(run => {
                    run.Actions = Helpers.CreateActionList(
                        new ContextActionApplyBuff {
                            m_Buff = AuraOfDoomBuff.ToReference<BlueprintBuffReference>(),
                            Permanent = false,
                            IsFromSpell = true,
                            IsNotDispelable = false,
                            DurationValue = new ContextDurationValue() {
                                Rate = DurationRate.Minutes,
                                BonusValue = new ContextValue() {
                                    ValueType = ContextValueType.Rank,
                                    Value = 0,
                                    ValueRank = AbilityRankType.Default,
                                    ValueShared = AbilitySharedValue.Damage,
                                    Property = Kingmaker.UnitLogic.Mechanics.Properties.UnitProperty.None
                                },
                                DiceCountValue = new ContextValue() {
                                    ValueType = ContextValueType.Simple,
                                    Value = 0,
                                    ValueRank = AbilityRankType.Default,
                                    ValueShared = AbilitySharedValue.Damage,
                                    Property = Kingmaker.UnitLogic.Mechanics.Properties.UnitProperty.None
                                },
                                DiceType = DiceType.Zero,
                                m_IsExtendable = true,
                            }
                        }) ;
                });
                bp.AddComponent(Helpers.Create<ContextRankConfig>(c => {
                    c.m_Type = default;
                    c.m_BaseValueType = ContextRankBaseValueType.CasterLevel;
                    c.m_Progression = ContextRankProgression.AsIs;
                    c.m_UseMax = false;
                    c.m_Min = 0;
                    c.m_Max = 20;
                }));
                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Necromancy;
                }));
                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Buff;
                    c.SavingThrow = CraftSavingThrow.Will;
                    c.AOEType = CraftAOE.None;
                }));
            });
            //AuraOfDoomAbility.AddToSpellList(SpellTools.SpellList.ClericSpellList, 4);
            AuraOfDoomAbility.AddToSpellList(SpellTools.SpellList.InquisitorSpellList, 6);
            AuraOfDoomAbility.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 4);
        }

        static void CreateBoneFists() {
            var icon = AssetLoader.LoadInternal(FASContext, "Abilities", "BoneFists.png");

            var BonefistsBuff = Helpers.CreateBlueprint<BlueprintBuff>(FASContext, "BonefistsBuff", bp => {
                bp.SetName(FASContext, "Bonefists");
                bp.SetDescription(FASContext, "The bones of your targets’ joints grow thick and sharp, protruding painfully through the skin at the knuckles, elbows, shoulders, " +
                    "spine, and knees. The targets each gain a +1 bonus to natural armor and a +2 bonus on damage rolls with natural weapons.");
                bp.m_Icon = icon;
                bp.TickEachSecond = false;
                bp.Frequency = DurationRate.Minutes;
                bp.Stacking = StackingType.Replace;
                bp.AddComponent(Helpers.Create<AddContextStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.NaturalArmor;
                    c.Stat = StatType.AC;
                    c.Value = 1;
                }));
                bp.AddComponent(Helpers.Create<WeaponGroupDamageBonus>(c => {
                    c.WeaponGroup = WeaponFighterGroup.Natural;
                    c.DamageBonus = 2;
                }));
            });
            var applyBuff = Helpers.Create<ContextActionApplyBuff>(bp => {
                bp.IsFromSpell = true;
                bp.m_Buff = BonefistsBuff.ToReference<BlueprintBuffReference>();
                bp.DurationValue = new ContextDurationValue() {
                    Rate = DurationRate.Minutes,
                    BonusValue = new ContextValue() {
                        ValueType = ContextValueType.Rank
                    },
                    DiceCountValue = new ContextValue(),
                    DiceType = DiceType.One
                };
            });
            var BonefistsAbility = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "BonefistsAbility", bp => {
                bp.SetName(FASContext, "Bonefists");
                bp.SetDescription(FASContext, "The bones of your targets’ joints grow thick and sharp, protruding painfully through the skin at the knuckles, elbows, shoulders, " +
                    "spine, and knees. The targets each gain a +1 bonus to natural armor and a +2 bonus on damage rolls with natural weapons.");
                bp.LocalizedDuration = Helpers.CreateString(FASContext, "Bonefists.Duration", "1 minute/level");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Extend | Metamagic.Heighten | Metamagic.Quicken;
                bp.Range = AbilityRange.Personal;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Self;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.m_Icon = icon;
                bp.ResourceAssetIds = new string[0];
                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { applyBuff }
                    };
                }));
                bp.AddComponent(Helpers.Create<AbilityTargetsAround>(c => {
                    c.m_Radius.m_Value = 30.0f;
                    c.m_TargetType = TargetType.Ally;
                    c.m_Condition = new ConditionsChecker() { Conditions = Array.Empty<Condition>() };
                }));
                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Necromancy;
                }));
                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Buff;
                    c.SavingThrow = CraftSavingThrow.None;
                    c.AOEType = CraftAOE.None;
                }));
            });
            BonefistsAbility.AddToSpellList(SpellTools.SpellList.DruidSpellList, 2);
            BonefistsAbility.AddToSpellList(SpellTools.SpellList.WitchSpellList, 2);
        }

        static void CreateSavageMaw() {
            //var icon = AssetLoader.Image2Sprite.Create($"{ModSettings.ModEntry.Path}Assets{Path.DirectorySeparatorChar}Abilities{Path.DirectorySeparatorChar}Icon_ShadowEnchantment.png");
            var icon = AssetLoader.LoadInternal(FASContext, "Abilities", "SavageMaw.png");
            var biteWeapon = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("61bc14eca5f8c1040900215000cfc218");

            var SavageMawBuff = Helpers.CreateBlueprint<BlueprintBuff>(FASContext, "SavageMawBuff", bp => {
                bp.SetName(FASContext, "Savage Maw");
                bp.SetDescription(FASContext, "Your teeth extend and sharpen, transforming your mouth into a maw of razor - sharp fangs.You gain a secondary bite" +
                    " attack that deals 1d8 points of damage plus your Strength modifier.");
                bp.m_Icon = icon;
                bp.TickEachSecond = false;
                bp.Frequency = DurationRate.Minutes;
                bp.Stacking = StackingType.Replace;
                bp.AddComponent(Helpers.Create<AddAdditionalLimb>(c => {
                    c.m_Weapon = biteWeapon.ToReference<BlueprintItemWeaponReference>();
                    c.name = "Savage Maw";
                }));
            });
            var applyBuff = Helpers.Create<ContextActionApplyBuff>(bp => {
                bp.IsFromSpell = true;
                bp.m_Buff = SavageMawBuff.ToReference<BlueprintBuffReference>();
                bp.DurationValue = new ContextDurationValue() {
                    Rate = DurationRate.Minutes,
                    BonusValue = new ContextValue() {
                        ValueType = ContextValueType.Rank
                    },
                    DiceCountValue = new ContextValue(),
                    DiceType = DiceType.One
                };
            });
            var SavageMawAbility = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "SavageMawAbility", bp => {
                bp.SetName(FASContext, "Savage Maw");
                bp.SetDescription(FASContext, "Your teeth extend and sharpen, transforming your mouth into a maw of razor - sharp fangs.You gain a secondary bite" +
                    " attack that deals 1d8 points of damage plus your Strength modifier.");
                bp.LocalizedDuration = Helpers.CreateString(FASContext, "SavageMawAbility.Duration", "1 minute/level");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Extend | Metamagic.Heighten | Metamagic.Quicken;
                bp.Range = AbilityRange.Personal;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Self;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.m_Icon = icon;
                bp.ResourceAssetIds = new string[0];
                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { applyBuff }
                    };
                }));
                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Transmutation;
                }));
                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Buff;
                    c.SavingThrow = CraftSavingThrow.None;
                    c.AOEType = CraftAOE.None;
                }));
            });
            SavageMawAbility.AddToSpellList(SpellTools.SpellList.DruidSpellList, 2);
            SavageMawAbility.AddToSpellList(SpellTools.SpellList.ClericSpellList, 2);
            SavageMawAbility.AddToSpellList(SpellTools.SpellList.InquisitorSpellList, 2);
            SavageMawAbility.AddToSpellList(SpellTools.SpellList.MagusSpellList, 2);
            SavageMawAbility.AddToSpellList(SpellTools.SpellList.RangerSpellList, 2);
            SavageMawAbility.AddToSpellList(SpellTools.SpellList.HunterSpelllist, 2);
        }
        static void AddCommunalBarkSkin() {

            var applyBuff = Helpers.Create<Kingmaker.UnitLogic.Mechanics.Actions.ContextActionApplyBuff>(bp => {
                var BarkskinBuff = new BlueprintBuffReference[] {
                        ResourcesLibrary.TryGetBlueprint<BlueprintBuff>("533592a86adecda4e9fd5ed37a028432").ToReference<BlueprintBuffReference>()
                    };
                bp.IsFromSpell = true;

                bp.m_Buff = BarkskinBuff[0];
                bp.DurationValue = new ContextDurationValue() {
                    m_IsExtendable = true,
                    Rate = DurationRate.TenMinutes,
                    BonusValue = new ContextValue() {
                        //Value = 1
                        ValueType = ContextValueType.Rank
                    },
                    DiceCountValue = new ContextValue(),
                    //DiceType = DiceType.One
                };
            });
            var ComBarkAbility = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "ComBarkskinability", bp => {
                var Barkskin = ResourcesLibrary.TryGetBlueprint<BlueprintAbility>("5b77d7cc65b8ab74688e74a37fc2f553");
                bp.SetName(FASContext, "Communal Barkskin");
                bp.SetDescription(FASContext, "Communal barkskin gives barkskin to all party members. The effect grants a +2 enhancement bonus to the creature's existing natural armor bonus." +
                    "This enhancement bonus increases by 1 for every three caster levels above 3rd, to a maximum of + 5 at 12th level." +
                    "The enhancement bonus provided by barkskin stacks with the target's natural armor bonus, but not with other enhancement bonuses to natural armor." +
                    "A creature without natural armor has an effective natural armor bonus of + 0.");
                bp.LocalizedDuration = Helpers.CreateString(FASContext, "ComBarkSkin.Duration", "10 minute/level");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Extend | Metamagic.Heighten | Metamagic.Quicken | Metamagic.Reach | Metamagic.CompletelyNormal;
                bp.Range = AbilityRange.Touch;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = true;
                bp.CanTargetSelf = true;
                bp.m_Icon = Barkskin.m_Icon;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Touch;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.ResourceAssetIds = new string[0];


                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { applyBuff }
                    };

                }));


                bp.AddComponent(Helpers.Create<AbilityTargetsAround>(c => {
                    c.m_Radius.m_Value = 30.0f;
                    c.m_TargetType = TargetType.Ally;
                    c.m_Condition = new ConditionsChecker() { Conditions = Array.Empty<Condition>() };
                }));
                //
                bp.AddComponent(Helpers.Create<AbilitySpawnFx>(c => {
                    c.Anchor = AbilitySpawnFxAnchor.Caster;
                    c.PositionAnchor = AbilitySpawnFxAnchor.None;
                    c.OrientationAnchor = AbilitySpawnFxAnchor.None;
                    var prelink = new PrefabLink();
                    prelink.AssetId = "814caa282b28ef04e8b651551c782a88";
                    c.PrefabLink = prelink;
                }));

                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Transmutation;
                }));

                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Buff;
                    c.SavingThrow = CraftSavingThrow.None;
                    c.AOEType = CraftAOE.AOE;
                }));
            });
            ComBarkAbility.AddToSpellList(SpellTools.SpellList.AlchemistSpellList, 5);
            ComBarkAbility.AddToSpellList(SpellTools.SpellList.WitchSpellList, 7);
            ComBarkAbility.AddToSpellList(SpellTools.SpellList.DruidSpellList, 6);
            ComBarkAbility.AddToSpellList(SpellTools.SpellList.HunterSpelllist, 4);
            ComBarkAbility.AddToSpellList(SpellTools.SpellList.RangerSpellList, 4);
            ComBarkAbility.AddToSpellList(SpellTools.SpellList.ShamanSpelllist, 7);
        }
        static void AddCommunalDeathWard() {

            var applyBuff = Helpers.Create<Kingmaker.UnitLogic.Mechanics.Actions.ContextActionApplyBuff>(bp => {
                var DeathwardBuff = new BlueprintBuffReference[] {
                        BlueprintTools.GetBlueprint<BlueprintBuff>("a04d666d8b1f5a2419f1adc6874ae65a").ToReference<BlueprintBuffReference>()
                    };
                bp.IsFromSpell = true;

                bp.m_Buff = DeathwardBuff[0];
                bp.DurationValue = new ContextDurationValue() {
                    m_IsExtendable = true,
                    Rate = DurationRate.TenMinutes,
                    BonusValue = new ContextValue() {
                        //Value = 1
                        ValueType = ContextValueType.Rank
                    },
                    DiceCountValue = new ContextValue(),
                    //DiceType = DiceType.One
                };
            });
            var ComDeathwardAbility = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "ComDeathward", bp => {
                bp.SetName(FASContext, "Communal Deathward");
                bp.SetDescription(FASContext, "The party gains the effects of deathward: The subject gains a +4 morale bonus on saves against all death spells and magical death effects. " +
                    "The subject is immune to energy drain and any negative energy effects, including channeled negative energy. " +
                    "This spells does not remove negative levels that the subject has already gained and does not protect against other sorts of attacks, even if attacks might be lethal.");
                bp.LocalizedDuration = Helpers.CreateString(FASContext, "ComDeathward.Duration", "1 minute/level");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Extend | Metamagic.Heighten | Metamagic.Quicken | Metamagic.Reach | Metamagic.CompletelyNormal;
                bp.Range = AbilityRange.Touch;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = true;
                bp.CanTargetSelf = true;
                bp.m_Icon = Blueprints.Abilities.DeathWard.m_Icon;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Touch;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.ResourceAssetIds = new string[0];


                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { applyBuff }
                    };

                }));


                bp.AddComponent(Helpers.Create<AbilityTargetsAround>(c => {
                    c.m_Radius.m_Value = 30.0f;
                    c.m_TargetType = TargetType.Ally;
                    c.m_Condition = new ConditionsChecker() { Conditions = Array.Empty<Condition>() };
                }));

                bp.AddComponent(Helpers.Create<AbilitySpawnFx>(c => {
                    c.Anchor = AbilitySpawnFxAnchor.Caster;
                    c.PositionAnchor = AbilitySpawnFxAnchor.None;
                    c.OrientationAnchor = AbilitySpawnFxAnchor.None;
                    var prelink = new PrefabLink();
                    prelink.AssetId = "cbfe312cb8e63e240a859efaad8e467c";
                    c.PrefabLink = prelink;
                }));

                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Necromancy;
                }));

                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Buff;
                    c.SavingThrow = CraftSavingThrow.None;
                    c.AOEType = CraftAOE.AOE;
                }));
            });
            ComDeathwardAbility.AddToSpellList(SpellTools.SpellList.AlchemistSpellList, 6);
            ComDeathwardAbility.AddToSpellList(SpellTools.SpellList.WitchSpellList, 7);
            ComDeathwardAbility.AddToSpellList(SpellTools.SpellList.DruidSpellList, 8);
            ComDeathwardAbility.AddToSpellList(SpellTools.SpellList.ClericSpellList, 7);
            ComDeathwardAbility.AddToSpellList(SpellTools.SpellList.InquisitorSpellList, 6);
        }
        static void AddCommunalEcholocation() {

            var applyBuff = Helpers.Create<Kingmaker.UnitLogic.Mechanics.Actions.ContextActionApplyBuff>(bp => {
                var EcholocationBuff = new BlueprintBuffReference[] {
                        ResourcesLibrary.TryGetBlueprint<BlueprintBuff>("cbfd2f5279f5946439fe82570fd61df2").ToReference<BlueprintBuffReference>()
                    };
                bp.IsFromSpell = true;

                bp.m_Buff = EcholocationBuff[0];
                bp.DurationValue = new ContextDurationValue() {
                    m_IsExtendable = true,
                    Rate = DurationRate.TenMinutes,
                    BonusValue = new ContextValue() {
                        //Value = 1
                        ValueType = ContextValueType.Rank
                    },
                    DiceCountValue = new ContextValue(),
                    //DiceType = DiceType.One
                };
            });
            var ComEcholocationAbility = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "ComEcholocation", bp => {
                var Echolocation = ResourcesLibrary.TryGetBlueprint<BlueprintAbility>("20b548bf09bb3ea4bafea78dcb4f3db6");
                bp.SetName(FASContext, "Communal Echolocation");
                bp.SetDescription(FASContext, "Gives your party echolocation: You can perceive the world by creating high-pitched noises and listening to their echoes. This gives you blindsight to a range of 40 feet.");
                bp.LocalizedDuration = Helpers.CreateString(FASContext, "ComEcholocation.Duration", "10 minute/level");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Extend | Metamagic.Heighten | Metamagic.Quicken | Metamagic.Reach | Metamagic.CompletelyNormal;
                bp.Range = AbilityRange.Touch;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = true;
                bp.CanTargetSelf = true;
                bp.m_Icon = Echolocation.m_Icon;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Touch;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.ResourceAssetIds = new string[0];


                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { applyBuff }
                    };

                }));


                bp.AddComponent(Helpers.Create<AbilityTargetsAround>(c => {
                    c.m_Radius.m_Value = 30.0f;
                    c.m_TargetType = TargetType.Ally;
                    c.m_Condition = new ConditionsChecker() { Conditions = Array.Empty<Condition>() };
                }));
                //
                bp.AddComponent(Helpers.Create<AbilitySpawnFx>(c => {
                    c.Anchor = AbilitySpawnFxAnchor.Caster;
                    c.PositionAnchor = AbilitySpawnFxAnchor.None;
                    c.OrientationAnchor = AbilitySpawnFxAnchor.None;
                    var prelink = new PrefabLink();
                    prelink.AssetId = "3820884df0664b74a81db0eac62d6e8f";
                    c.PrefabLink = prelink;
                }));

                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Transmutation;
                }));

                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Buff;
                    c.SavingThrow = CraftSavingThrow.None;
                    c.AOEType = CraftAOE.AOE;
                }));
            });
            ComEcholocationAbility.AddToSpellList(SpellTools.SpellList.AlchemistSpellList, 6);
            ComEcholocationAbility.AddToSpellList(SpellTools.SpellList.WizardSpellList, 7);
            ComEcholocationAbility.AddToSpellList(SpellTools.SpellList.DruidSpellList, 5);
            ComEcholocationAbility.AddToSpellList(SpellTools.SpellList.BardSpellList, 6);
            ComEcholocationAbility.AddToSpellList(SpellTools.SpellList.HunterSpelllist, 5);
        }
        static void AddCommunalFreedomOfMovement() {
            var applyBuff = Helpers.Create<Kingmaker.UnitLogic.Mechanics.Actions.ContextActionApplyBuff>(bp => {
                var FreedomOfMovementBuff = new BlueprintBuffReference[] {
                        ResourcesLibrary.TryGetBlueprint<BlueprintBuff>("1533e782fca42b84ea370fc1dcbf4fc1").ToReference<BlueprintBuffReference>()
                    };
                bp.IsFromSpell = true;

                bp.m_Buff = FreedomOfMovementBuff[0];
                bp.DurationValue = new ContextDurationValue() {
                    m_IsExtendable = true,
                    Rate = DurationRate.TenMinutes,
                    BonusValue = new ContextValue() {
                        //Value = 1
                        ValueType = ContextValueType.Rank
                    },
                    DiceCountValue = new ContextValue(),
                    //DiceType = DiceType.One
                };
            });
            var ComFreedomOfMovement = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "ComFreedomOfMovementAbility", bp => {
                var FreedomOfMovement = BlueprintTools.GetBlueprint<BlueprintAbility>("4c349361d720e844e846ad8c19959b1e");
                bp.SetName(FASContext, "Communal Freedom of Movement");
                bp.SetDescription(FASContext, "This spell gives your party freedom of movement: This spell enables you or a creature you touch to move and attack normally for the duration of the spell," +
                    " even under the influence of magic that usually impedes movement, such as paralysis, solid fog, slow, and web. " +
                    "All combat maneuver checks made to grapple the target automatically fail.");
                bp.LocalizedDuration = Helpers.CreateString(FASContext, "ComFreedomOfMovement.Duration", "10 minute/level");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Extend | Metamagic.Heighten | Metamagic.Quicken | Metamagic.Reach | Metamagic.CompletelyNormal;
                bp.Range = AbilityRange.Touch;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = true;
                bp.CanTargetSelf = true;
                bp.m_Icon = FreedomOfMovement.m_Icon;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Touch;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.ResourceAssetIds = new string[0];


                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { applyBuff }
                    };

                }));


                bp.AddComponent(Helpers.Create<AbilityTargetsAround>(c => {
                    c.m_Radius.m_Value = 30.0f;
                    c.m_TargetType = TargetType.Ally;
                    c.m_Condition = new ConditionsChecker() { Conditions = Array.Empty<Condition>() };
                }));
                //
                bp.AddComponent(Helpers.Create<AbilitySpawnFx>(c => {
                    c.Anchor = AbilitySpawnFxAnchor.Caster;
                    c.PositionAnchor = AbilitySpawnFxAnchor.None;
                    c.OrientationAnchor = AbilitySpawnFxAnchor.None;
                    var prelink = new PrefabLink();
                    prelink.AssetId = "7a401ecd81c12364c92b7b6551031cdb";
                    c.PrefabLink = prelink;
                }));

                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Abjuration;
                }));

                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Buff;
                    c.SavingThrow = CraftSavingThrow.None;
                    c.AOEType = CraftAOE.AOE;
                }));
            });
            ComFreedomOfMovement.AddToSpellList(SpellTools.SpellList.ClericSpellList, 8);
            ComFreedomOfMovement.AddToSpellList(SpellTools.SpellList.BardSpellList, 6);
            ComFreedomOfMovement.AddToSpellList(SpellTools.SpellList.InquisitorSpellList, 6);
            ComFreedomOfMovement.AddToSpellList(SpellTools.SpellList.AlchemistSpellList, 6);
            ComFreedomOfMovement.AddToSpellList(SpellTools.SpellList.HunterSpelllist, 6);
            ComFreedomOfMovement.AddToSpellList(SpellTools.SpellList.ShamanSpelllist, 8);

        }
        static void AddCommunalShieldOfFaith() {
            var applyBuff = Helpers.Create<Kingmaker.UnitLogic.Mechanics.Actions.ContextActionApplyBuff>(bp => {
                var SoFbuff = new BlueprintBuffReference[] {
                        ResourcesLibrary.TryGetBlueprint<BlueprintBuff>("5274ddc289f4a7447b7ace68ad8bebb0").ToReference<BlueprintBuffReference>()
                    };
                bp.IsFromSpell = true;

                bp.m_Buff = SoFbuff[0];
                bp.DurationValue = new ContextDurationValue() {
                    m_IsExtendable = true,
                    Rate = DurationRate.Minutes,
                    BonusValue = new ContextValue() {
                        //Value = 1
                        ValueType = ContextValueType.Rank
                    },
                    DiceCountValue = new ContextValue(),
                    //DiceType = DiceType.One
                };
            });
            var ComSoFAbility = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "ComShieldOfFaithability", bp => {
                var ShieldOfFaith = ResourcesLibrary.TryGetBlueprint<BlueprintAbility>("183d5bb91dea3a1489a6db6c9cb64445");
                bp.SetName(FASContext, "Communal Shield Of Faith");
                bp.SetDescription(FASContext, "This spell grants shield of faith spell to party: This spell creates a shimmering, magical field around the target that averts and deflects attacks. " +
                    "The spell grants the subject a +2 deflection bonus to AC, with an additional +1 to the bonus for every six levels you have (maximum +5 deflection bonus at 18th level).");
                bp.LocalizedDuration = Helpers.CreateString(FASContext, "ComShieldofFaith.Duration", "1 minute/level");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Extend | Metamagic.Heighten | Metamagic.Quicken | Metamagic.Reach | Metamagic.CompletelyNormal;
                bp.Range = AbilityRange.Touch;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = true;
                bp.CanTargetSelf = true;
                bp.m_Icon = ShieldOfFaith.m_Icon;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Touch;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.ResourceAssetIds = new string[0];


                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { applyBuff }
                    };

                }));


                bp.AddComponent(Helpers.Create<AbilityTargetsAround>(c => {
                    c.m_Radius.m_Value = 30.0f;
                    c.m_TargetType = TargetType.Ally;
                    c.m_Condition = new ConditionsChecker() { Conditions = Array.Empty<Condition>() };
                }));
                //
                bp.AddComponent(Helpers.Create<AbilitySpawnFx>(c => {
                    c.Anchor = AbilitySpawnFxAnchor.Caster;
                    c.PositionAnchor = AbilitySpawnFxAnchor.None;
                    c.OrientationAnchor = AbilitySpawnFxAnchor.None;
                    var prelink = new PrefabLink();
                    prelink.AssetId = "6bebb42fd1a2ab9499d19f7a1dce3359";
                    c.PrefabLink = prelink;
                }));

                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Abjuration;
                }));

                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Buff;
                    c.SavingThrow = CraftSavingThrow.None;
                    c.AOEType = CraftAOE.AOE;
                }));
            });
            ComSoFAbility.AddToSpellList(SpellTools.SpellList.ClericSpellList, 6);
            ComSoFAbility.AddToSpellList(SpellTools.SpellList.InquisitorSpellList, 4);
            ComSoFAbility.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 4);
        }
        static void AddMassAid() {
            var applyBuff = Helpers.Create<Kingmaker.UnitLogic.Mechanics.Actions.ContextActionApplyBuff>(bp => {
                var AidBuff = new BlueprintBuffReference[] {
                        ResourcesLibrary.TryGetBlueprint<BlueprintBuff>("319b4679f25779e4e9d04360381254e1").ToReference<BlueprintBuffReference>()
                    };
                bp.IsFromSpell = true;

                bp.m_Buff = AidBuff[0];
                bp.DurationValue = new ContextDurationValue() {
                    m_IsExtendable = true,
                    Rate = DurationRate.Minutes,
                    BonusValue = new ContextValue() {
                        //Value = 1
                        ValueType = ContextValueType.Rank
                    },
                    DiceCountValue = new ContextValue(),
                    //DiceType = DiceType.One
                };
            });
            var MassAidAbility = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "MassAidAbility", bp => {
                var Aid = ResourcesLibrary.TryGetBlueprint<BlueprintAbility>("03a9630394d10164a9410882d31572f0");
                bp.SetName(FASContext, "Mass Aid");
                bp.SetDescription(FASContext, "Mass aid grants aid spell to party: Aid grants the target a +1 morale bonus on attack rolls and saves against fear effects, " +
                    "plus temporary hit points equal to 1d8 + }caster level " +
                    "(to a maximum of 1d8+10 temporary hit points at caster level 10th).");
                bp.LocalizedDuration = Helpers.CreateString(FASContext, "MassAid.Duration", "1 minute/level");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Extend | Metamagic.Heighten | Metamagic.Quicken | Metamagic.Reach | Metamagic.CompletelyNormal;
                bp.Range = AbilityRange.Touch;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = true;
                bp.CanTargetSelf = true;
                bp.m_Icon = Aid.m_Icon;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Touch;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.ResourceAssetIds = new string[0];


                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { applyBuff }
                    };

                }));


                bp.AddComponent(Helpers.Create<AbilityTargetsAround>(c => {
                    c.m_Radius.m_Value = 30.0f;
                    c.m_TargetType = TargetType.Ally;
                    c.m_Condition = new ConditionsChecker() { Conditions = Array.Empty<Condition>() };
                }));
                //
                bp.AddComponent(Helpers.Create<AbilitySpawnFx>(c => {
                    c.Anchor = AbilitySpawnFxAnchor.Caster;
                    c.PositionAnchor = AbilitySpawnFxAnchor.None;
                    c.OrientationAnchor = AbilitySpawnFxAnchor.None;
                    var prelink = new PrefabLink();
                    prelink.AssetId = "749bb96fb50ee5b4685645472d718465";
                    c.PrefabLink = prelink;
                }));

                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Enchantment;
                }));

                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Buff;
                    c.SavingThrow = CraftSavingThrow.None;
                    c.AOEType = CraftAOE.AOE;
                }));
            });
            MassAidAbility.AddToSpellList(SpellTools.SpellList.ClericSpellList, 6);
            MassAidAbility.AddToSpellList(SpellTools.SpellList.InquisitorSpellList, 5);
            MassAidAbility.AddToSpellList(SpellTools.SpellList.AlchemistSpellList, 5);
            MassAidAbility.AddToSpellList(SpellTools.SpellList.ShamanSpelllist, 6);
        }

        static void AddMassBlur() {
            var applyBuff = Helpers.Create<Kingmaker.UnitLogic.Mechanics.Actions.ContextActionApplyBuff>(bp => {
                var BlurBuff = new BlueprintBuffReference[] {
                        ResourcesLibrary.TryGetBlueprint<BlueprintBuff>("dd3ad347240624d46a11a092b4dd4674").ToReference<BlueprintBuffReference>()
                    };
                bp.IsFromSpell = true;

                bp.m_Buff = BlurBuff[0];
                bp.DurationValue = new ContextDurationValue() {
                    m_IsExtendable = true,
                    Rate = DurationRate.Minutes,
                    BonusValue = new ContextValue() {
                        //Value = 1
                        ValueType = ContextValueType.Rank
                    },
                    DiceCountValue = new ContextValue(),
                    //DiceType = DiceType.One
                };
            });
            var MassBlurAbility = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "MassBlurAbility", bp => {
                var Blur = ResourcesLibrary.TryGetBlueprint<BlueprintAbility>("14ec7a4e52e90fa47a4c8d63c69fd5c1");
                bp.SetName(FASContext, "Mass Blur");
                bp.SetDescription(FASContext, "This spell grants blur to party members: The subject's outline appears blurred, shifting, and wavering. This distortion grants the subject {g|Encyclopedia:Concealment}concealment{/g} (20% miss chance)." +
                    "\nA see invisibility {g|Encyclopedia:Spell}spell{/g} does not counteract the blur effect, but a true seeing spell does." +
                    "\nOpponents that cannot see the subject ignore the spell's effect (though fighting an unseen opponent carries {g|Encyclopedia:Penalty}penalties{/g} of its own).");
                bp.LocalizedDuration = Helpers.CreateString(FASContext, "MassBlur.Duration", "1 minute/level");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Extend | Metamagic.Heighten | Metamagic.Quicken | Metamagic.Reach | Metamagic.CompletelyNormal;
                bp.Range = AbilityRange.Touch;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = true;
                bp.CanTargetSelf = true;
                bp.m_Icon = Blur.m_Icon;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Touch;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.ResourceAssetIds = new string[0];


                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { applyBuff }
                    };

                }));


                bp.AddComponent(Helpers.Create<AbilityTargetsAround>(c => {
                    c.m_Radius.m_Value = 30.0f;
                    c.m_TargetType = TargetType.Ally;
                    c.m_Condition = new ConditionsChecker() { Conditions = Array.Empty<Condition>() };
                }));



                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Illusion;
                }));

                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Buff;
                    c.SavingThrow = CraftSavingThrow.None;
                    c.AOEType = CraftAOE.AOE;
                }));
            });
            MassBlurAbility.AddToSpellList(SpellTools.SpellList.WizardSpellList, 6);
            MassBlurAbility.AddToSpellList(SpellTools.SpellList.AlchemistSpellList, 6);
            MassBlurAbility.AddToSpellList(SpellTools.SpellList.MagusSpellList, 6);

        }

        static void AddMassHeroism() {
            var applyBuff = Helpers.Create<Kingmaker.UnitLogic.Mechanics.Actions.ContextActionApplyBuff>(bp => {
                var HeroismBuff = new BlueprintBuffReference[] {
                        ResourcesLibrary.TryGetBlueprint<BlueprintBuff>("87ab2fed7feaaff47b62a3320a57ad8d").ToReference<BlueprintBuffReference>()
                    };
                bp.IsFromSpell = true;

                bp.m_Buff = HeroismBuff[0];
                bp.DurationValue = new ContextDurationValue() {
                    m_IsExtendable = true,
                    Rate = DurationRate.TenMinutes,
                    BonusValue = new ContextValue() {
                        //Value = 1
                        ValueType = ContextValueType.Rank
                    },
                    DiceCountValue = new ContextValue(),
                    //DiceType = DiceType.One
                };
            });
            var MassHeroismAbility = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "MassHeroismAbility", bp => {
                var Heroism = BlueprintTools.GetBlueprint<BlueprintAbility>( "5ab0d42fb68c9e34abae4921822b9d63");
                bp.SetName(FASContext, "Mass Heroism");
                bp.SetDescription(FASContext, "This spell grants heroism to party members: This {g|Encyclopedia:Spell}spell{/g} imbues a single creature with great bravery and morale in battle. " +
                    "The target gains a +2 morale {g|Encyclopedia:Bonus}bonus{/g} on {g|Encyclopedia:Attack}attack rolls{/g}, " +
                    "{g|Encyclopedia:Saving_Throw}saves{/g}, and {g|Encyclopedia:Skills}skill checks{/g}");
                bp.LocalizedDuration = Helpers.CreateString(FASContext, "MassHeroism.Duration", "10 minute/level");
                bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
                bp.AvailableMetamagic = Metamagic.Extend | Metamagic.Heighten | Metamagic.Quicken | Metamagic.Reach | Metamagic.CompletelyNormal;
                bp.Range = AbilityRange.Touch;
                bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
                bp.EffectOnEnemy = AbilityEffectOnUnit.None;
                bp.CanTargetEnemies = false;
                bp.CanTargetFriends = true;
                bp.CanTargetSelf = true;
                bp.m_Icon = Heroism.m_Icon;
                bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Touch;
                bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
                bp.ResourceAssetIds = new string[0];


                bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
                    c.Actions = new ActionList {
                        Actions = new GameAction[] { applyBuff }
                    };

                }));


                bp.AddComponent(Helpers.Create<AbilityTargetsAround>(c => {
                    c.m_Radius.m_Value = 30.0f;
                    c.m_TargetType = TargetType.Ally;
                    c.m_Condition = new ConditionsChecker() { Conditions = Array.Empty<Condition>() };
                }));



                bp.AddComponent(Helpers.Create<SpellComponent>(c => {
                    c.School = SpellSchool.Illusion;
                }));

                bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
                    c.OwnerBlueprint = bp;
                    c.SpellType = CraftSpellType.Buff;
                    c.SavingThrow = CraftSavingThrow.None;
                    c.AOEType = CraftAOE.AOE;
                }));
            });
            MassHeroismAbility.AddToSpellList(SpellTools.SpellList.WitchSpellList, 7);
            MassHeroismAbility.AddToSpellList(SpellTools.SpellList.ShamanSpelllist, 7);
            MassHeroismAbility.AddToSpellList(SpellTools.SpellList.DruidSpellList, 7);
            MassHeroismAbility.AddToSpellList(SpellTools.SpellList.ClericSpellList, 7);
            MassHeroismAbility.AddToSpellList(SpellTools.SpellList.RangerSpellList, 4);
        }
    }
}


// EI TOIMI
//static void createStrongJaw() {
//    var icon = AssetLoader.LoadInternal(FASContext, "Abilities", "HuntingGround.png");


//    var StrongJawbuff = Helpers.CreateBlueprint<BlueprintBuff>(FASContext, "StrongJawBuff", bp => {
//        bp.SetName(FASContext, "Strong Jaw");
//        bp.SetDescription(FASContext, "Laying a hand upon an allied creature’s jaw, claws, tentacles, or other natural weapons," +
//             " you enhance the power of that creature’s natural attacks. Each natural attack that creature makes deals " +
//             "damage as if the creature were two sizes larger than it actually is.");
//        bp.m_Icon = icon;
//        bp.TickEachSecond = false;
//        bp.Frequency = DurationRate.Minutes;
//        bp.Stacking = StackingType.Replace;
//        bp.AddComponent(Helpers.Create<MeleeWeaponSizeChange>(c => {
//            c.SizeCategoryChange = 2;
//        }));
//    });


//    var applyBuff = Helpers.Create<ContextActionApplyBuff>(bp => {
//        bp.IsFromSpell = true;
//        bp.m_Buff = StrongJawbuff.ToReference<BlueprintBuffReference>();
//        bp.DurationValue = new ContextDurationValue() {
//            Rate = DurationRate.Minutes,
//            BonusValue = new ContextValue() {
//                ValueType = ContextValueType.Rank
//            },
//            DiceCountValue = new ContextValue(),
//            DiceType = DiceType.One
//        };
//    });
//    var applyBuffContext = Helpers.Create<ContextActionsOnPet>(bp => {
//        bp.Actions = new ActionList {
//            Actions = new GameAction[] { applyBuff }
//        };

//    });
//    var StrongJawAbility = Helpers.CreateBlueprint<BlueprintAbility>(FASContext, "StrongJawAbility", bp => {
//        bp.SetName(FASContext, "StrongJawAbility");
//        bp.SetDescription(FASContext, "Laying a hand upon an allied creature’s jaw, claws, tentacles, or other natural weapons," +
//             " you enhance the power of that creature’s natural attacks. Each natural attack that creature makes deals " +
//             "damage as if the creature were two sizes larger than it actually is.");
//        bp.LocalizedDuration = Helpers.CreateString(FASContext, "AspectOfEagleAbility.Duration", "1 minute/level");
//        bp.LocalizedSavingThrow = new Kingmaker.Localization.LocalizedString();
//        bp.AvailableMetamagic = Metamagic.Extend | Metamagic.Heighten | Metamagic.Quicken;
//        bp.Range = AbilityRange.Personal;
//        bp.EffectOnAlly = AbilityEffectOnUnit.Helpful;
//        bp.Animation = Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Self;
//        bp.ActionType = Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard;
//        bp.m_Icon = icon;
//        bp.ResourceAssetIds = new string[0];
//        bp.AddComponent(Helpers.Create<AbilityEffectRunAction>(c => {
//            c.Actions = new ActionList {
//                Actions = new GameAction[] { applyBuffContext }
//            };
//        }));
//        bp.AddComponent(Helpers.Create<SpellComponent>(c => {
//            c.School = SpellSchool.Transmutation;
//        }));
//        bp.AddComponent(Helpers.Create<CraftInfoComponent>(c => {
//            c.OwnerBlueprint = bp;
//            c.SpellType = CraftSpellType.Buff;
//            c.SavingThrow = CraftSavingThrow.None;
//            c.AOEType = CraftAOE.None;
//        }));
//    });
//    StrongJawAbility.AddToSpellList(SpellTools.SpellList.RangerSpellList, 4);
//    StrongJawAbility.AddToSpellList(SpellTools.SpellList.DruidSpellList, 6);
//    StrongJawAbility.AddToSpellList(SpellTools.SpellList.HunterSpelllist, 4);
//    StrongJawAbility.AddToSpellList(SpellTools.SpellList.InquisitorSpellList, 4);
//    StrongJawAbility.AddToSpellList(SpellTools.SpellList.ClericSpellList, 6);



//}