using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeatAndSpells.Blueprints;
using static FeatAndSpells.Blueprints.Archetypes;
using static FeatAndSpells.Blueprints.Features;
using static FeatAndSpells.Blueprints.FeatureSelections;
using static FeatAndSpells.Blueprints.SpellBooks;
using static FeatAndSpells.Blueprints.CharacterClasses;
using TabletopTweaks.Core.Utilities;
using Kingmaker.Blueprints.Classes;
using static FeatAndSpells.Main;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Designers.Mechanics.Facts;

namespace FeatAndSpells.Classes {
    public class Slayer
    {
        public static void ChangeHandler() {
            AddSniper();
        }


        public static void AddSniper()
        {

            var RangedWeaponTraining = Helpers.CreateBlueprint<BlueprintFeature>(FASContext, "RangedWeaponTraining", bp => {
                bp.SetName(FASContext, "Ranged Weapon Specialist");
                bp.SetDescription(FASContext, "Your experience with using ranged weapons give your attacks with ranged weapons (bows & thrown) +1 damage to every attack. Additional ranks give additional +1 dmg");
                bp.m_Icon = FighterWeaponTraining.Icon;
                bp.AddComponent<WeaponGroupAttackBonus>(bp => {
                    bp.WeaponGroup = Kingmaker.Blueprints.Items.Weapons.WeaponFighterGroup.Bows;
                    bp.AttackBonus = 1;
                });
                bp.AddComponent<WeaponGroupAttackBonus>(bp => {
                    bp.WeaponGroup = Kingmaker.Blueprints.Items.Weapons.WeaponFighterGroup.Thrown;
                    bp.AttackBonus = 1;
                });
                bp.AddComponent<WeaponGroupDamageBonus>(bp => {
                    bp.WeaponGroup = Kingmaker.Blueprints.Items.Weapons.WeaponFighterGroup.Bows;
                    bp.DamageBonus = 1;
                });
                bp.AddComponent<WeaponGroupDamageBonus>(bp => {
                    bp.WeaponGroup = Kingmaker.Blueprints.Items.Weapons.WeaponFighterGroup.Thrown;
                    bp.DamageBonus = 1;
                });
                bp.Ranks = 6;
            });

            var SniperArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(FASContext, "SniperArchetype", bp => {
                bp.SetName(FASContext, "Marksman");
                bp.SetDescription(FASContext, "Marksman specialize in using ranged and thrown weapons to overwhelm their enemies. They gain additional damage bonuses with ranged weapons ");

                bp.ClassSkills = new StatType[]
                {
                    StatType.SkillThievery,
                    StatType.SkillUseMagicDevice
                };

                //var HamperedConfig = DebilitatingInjuryHamperedEffectBuff.GetComponent<ContextRankConfig>();
                //HamperedConfig.m_Class = HamperedConfig.m_Class.AppendToArray(ShamanClass.ToReference<BlueprintCharacterClassReference>());
                //HamperedConfig.m_AdditionalArchetypes = HamperedConfig.m_AdditionalArchetypes.AppendToArray(ShadowFangArchetype.ToReference<BlueprintArchetypeReference>());

                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, SlayerStudyTarget),
                    Helpers.CreateLevelEntry(5, SlayerStudyTarget),
                    Helpers.CreateLevelEntry(7, SlayerStudyTargetSwift),
                    Helpers.CreateLevelEntry(10, SlayerStudyTarget),
                    Helpers.CreateLevelEntry(14, Quarry),
                    Helpers.CreateLevelEntry(15, SlayerStudyTarget),
                    Helpers.CreateLevelEntry(19, QuarryUpgrade),
                    Helpers.CreateLevelEntry(20, SlayerStudyTarget),
                };

                bp.AddFeatures = new LevelEntry[] {
                    //Helpers.CreateLevelEntry(1, SneakAttack),
                    Helpers.CreateLevelEntry(1, RangedWeaponTraining),
                    Helpers.CreateLevelEntry(4, DebilitatingInjury),
                    Helpers.CreateLevelEntry(5, RangedWeaponTraining),
                    Helpers.CreateLevelEntry(10, RangedWeaponTraining),
                    Helpers.CreateLevelEntry(15, RangedWeaponTraining),
                    Helpers.CreateLevelEntry(20, RangedWeaponTraining, SneakAttack)
                };

                //bp.AddFeatures = new LevelEntry[] {
                //    Helpers.CreateLevelEntry(1, SneakAttack),
                //    Helpers.CreateLevelEntry(3, VitalStrikeFeature),
                //    Helpers.CreateLevelEntry(8, VitalStrikeFeatureImproved),
                //    Helpers.CreateLevelEntry(14, VitalStrikeFeatureGreater),
                //};
            });

            var DisorientedConfig = Blueprints.Buffs.DebilitatingInjuryDisorientedEffectBuff.GetComponent<ContextRankConfig>();
            DisorientedConfig.m_Class = DisorientedConfig.m_Class.AppendToArray(SlayerClass.ToReference<BlueprintCharacterClassReference>());
            DisorientedConfig.m_AdditionalArchetypes = DisorientedConfig.m_AdditionalArchetypes.AppendToArray(SniperArchetype.ToReference<BlueprintArchetypeReference>());

            var BewilderedConfig = Buffs.DebilitatingInjuryBewilderedEffectBuff.GetComponent<ContextRankConfig>();
            BewilderedConfig.m_Class = BewilderedConfig.m_Class.AppendToArray(SlayerClass.ToReference<BlueprintCharacterClassReference>());
            BewilderedConfig.m_AdditionalArchetypes = BewilderedConfig.m_AdditionalArchetypes.AppendToArray(SniperArchetype.ToReference<BlueprintArchetypeReference>());

            SlayerClass.m_Archetypes = SlayerClass.m_Archetypes.AppendToArray(SniperArchetype.ToReference<BlueprintArchetypeReference>());
            SlayerClass.Progression.UIGroups = SlayerClass.Progression.UIGroups.AppendToArray(
                //Helpers.CreateUIGroup(
                //    RowdyVitalDamage
                //),
               Helpers.CreateUIGroup(
                    RangedWeaponTraining
                )
               //Helpers.CreateUIGroup(
               //     VitalStrikeFeature,
               //     VitalStrikeFeatureImproved,
               //     VitalStrikeFeatureGreater
               // )
            );
            FASContext.Logger.LogHeader("Changed Sniper");
        }
        }
    }
