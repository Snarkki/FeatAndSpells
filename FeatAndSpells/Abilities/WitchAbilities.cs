//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FeatAndSpells.Blueprints;
//using static FeatAndSpells.Blueprints.Archetypes;
//using static FeatAndSpells.Blueprints.Features;
//using static FeatAndSpells.Blueprints.FeatureSelections;
//using static FeatAndSpells.Blueprints.SpellBooks;
//using static FeatAndSpells.Blueprints.CharacterClasses;
//using TabletopTweaks.Core.Utilities;
//using Kingmaker.Blueprints.Classes;
//using static FeatAndSpells.Main;
//using Kingmaker.Blueprints;
//using HarmonyLib;
//using Kingmaker.UnitLogic.Abilities;
//using Kingmaker.UnitLogic.Abilities.Blueprints;
//using Kingmaker.Blueprints.Classes.Spells;
//using Kingmaker.Utility;
//using Kingmaker.Blueprints.Classes.Selection;
//using Kingmaker.UnitLogic.FactLogic;
//using Kingmaker.UnitLogic;
//using Kingmaker.EntitySystem.Entities;
//using Kingmaker.ResourceLinks;
//using Kingmaker.UnitLogic.ActivatableAbilities;
//using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;
//using Kingmaker.UnitLogic.Abilities.Components;
//using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
//using Kingmaker.ElementsSystem;

//namespace FeatAndSpells.Abilities {
//    public class WitchAbilities {

//        public static void WitchHandler() {
//            CreateCackleActivatable();
//            CreateIceTomb();
//        }

//        public static void CreateCackleActivatable() {
//            var cackle_feat = BlueprintTools.GetBlueprint<BlueprintFeature>("36f2467103d4635459d412fb418276f4");
//            var cackle = BlueprintTools.GetBlueprint<BlueprintAbility>("4bd01292a9bc4304f861a6a07f03b855");
//            var chant_feat = BlueprintTools.GetBlueprint<BlueprintFeature>("3f776576b5f27604a9dad54d361153af");
//            var chant = BlueprintTools.GetBlueprint<BlueprintAbility>("6cd07c80aabf2b248a11921090de9c17");
//            var sfx = new PrefabLink() { AssetId = "79665f3d500fdf44083feccf4cbfc00a" };

//            var consume_move = new ActivatableAbilityUnitCommand { Type = CommandType.Move };

//            var runCackle = cackle.GetComponent<AbilityEffectRunAction>().Actions;

//            var CacklePassiveArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(FASContext, "CacklePassiveArea", bp => {
//                bp.Shape = AreaEffectShape.Cylinder;
//                bp.AffectEnemies = true;
//                bp.U = true;

//                bp.AddComponent<AbilityAreaEffectRunAction>

//                if (unitEnter != null || unitExit != null || unitMove != null || unitRound != null) {
//                    AbilityAreaEffectRunAction runaction = new(); // runs actions that persist even when leaving
//                    runaction.UnitEnter = unitEnter ?? new ActionList();
//                    runaction.UnitExit = unitExit ?? new ActionList();
//                    runaction.UnitMove = unitMove ?? new ActionList();
//                    runaction.Round = unitRound ?? new ActionList();

//                    result.AddComponents(runaction);
//                }
//                size: 30.Feet(),
//                sfx: sfx,
//                unitEnter: null,
//                unitRound: runCackle
//                bp.Groups = new FeatureGroup[] { FeatureGroup.MythicAbility };
//            });


//            var cackle_addarea = Helper.CreateBlueprintAbilityAreaEffect(
//                "CacklePassiveArea",
//                shape: AreaEffectShape.Cylinder,
//                applyAlly: true,
//                applyEnemy: true,
//                size: 30.Feet(),
//                sfx: sfx,
//                unitEnter: null,
//                unitRound: runCackle
//                ).CreateAddAreaEffect();
//            var cackle_passiv = Helper.CreateBlueprintActivatableAbility(
//                "WitchHexCacklePassive",
//                "Cackle (passive)",
//                cackle.m_Description,
//                out BlueprintBuff cackle_buff,
//                icon: cackle.Icon,
//                //activationType: AbilityActivationType.WithUnitCommand,
//                //commandType: CommandType.Move,
//                deactivateWhenStunned: true,
//                deactivateWhenDead: true,
//                deactivateImmediately: false
//                ).SetComponents(
//                consume_move);
//            cackle_buff.SetComponents(cackle_addarea);

//            var runChant = chant.GetComponent<AbilityEffectRunAction>().Actions;
//            var chant_addarea = Helper.CreateBlueprintAbilityAreaEffect(
//                "ChantPassiveArea",
//                shape: AreaEffectShape.Cylinder,
//                applyAlly: true,
//                applyEnemy: true,
//                size: 30.Feet(),
//                sfx: sfx,
//                unitEnter: null,
//                unitRound: runChant
//                ).CreateAddAreaEffect();
//            var chant_passiv = Helper.CreateBlueprintActivatableAbility(
//                "ShamanHexChantPassive",
//                "Chant (passive)",
//                chant.m_Description,
//                out BlueprintBuff chant_buff,
//                icon: chant.Icon,
//                //activationType: AbilityActivationType.WithUnitCommand,
//                //commandType: CommandType.Move,
//                deactivateWhenStunned: true,
//                deactivateWhenDead: true,
//                deactivateImmediately: false
//                ).SetComponents(
//                consume_move);
//            chant_buff.SetComponents(chant_addarea);

//            Helper.AppendAndReplace(ref cackle_feat.GetComponent<AddFacts>().m_Facts, cackle_passiv.ToRef());
//            Helper.AppendAndReplace(ref chant_feat.GetComponent<AddFacts>().m_Facts, chant_passiv.ToRef());
//        }

//        public static void CreateIceTomb() {
//            var IcyPrison = ResourcesLibrary.TryGetBlueprint<BlueprintAbility>("65e8d23aef5e7784dbeb27b1fca40931");
//            var WitchMajorHex = Helper.ToRef<BlueprintFeatureReference>("8ac781b33e380c84aa578f1b006dd6c5");
//            var Staggered = Helper.ToRef<BlueprintBuffReference>("df3950af5a783bd4d91ab73eb8fa0fd3");
//            var IcyPrisonParalyzedBuff = Helper.ToRef<BlueprintBuffReference>("6f0e450771cc7d446aea798e1fef1c7a");

//            var icetomb_cooldown = Helper.CreateBlueprintBuff("WitchHexIceTombCooldownBuff", "", "").Flags(hidden: true);

//            var icetomb_debuff = Helper.CreateBlueprintBuff(
//                "WitchHexIceTombBuff",
//                "Frozen",
//                "A storm of ice and freezing wind enveloped the creature.",
//                fxOnStart: Helper.GetPrefabLink("21b65d177b9db1d4ca4961de15645d95") //IcyPrisonParalyzedBuff
//                ).SetComponents(
//                Helper.CreateAddCondition(UnitCondition.Paralyzed),
//                Helper.CreateAddCondition(UnitCondition.Unconscious)
//                ).Flags(isFromSpell: true, harmful: true);

//            var runaction = Helper.CreateAbilityEffectRunAction(
//                SavingThrowType.Fortitude,
//                Helper.CreateContextActionApplyBuff(icetomb_cooldown, 1, DurationRate.Days),
//                Helper.CreateContextActionDealDamage(DamageEnergyType.Cold, Helper.CreateContextDiceValue(dice: DiceType.D6, diceCount: 3, bonus: 0), halfIfSaved: true),
//                Helper.CreateContextActionConditionalSaved(
//                    failed: Helper.CreateContextActionApplyBuff(icetomb_debuff, Helper.CreateContextDurationValue(diceRank: AbilityRankType.Default, rate: DurationRate.Minutes), false, false),
//                    succeed: Helper.CreateContextActionApplyBuff(Staggered, Helper.CreateContextDurationValue(diceCount: 1, dice: DiceType.D4), false, false)
//                    )
//                );

//            var icetomb_ab = Helper.CreateBlueprintAbility(
//                "WitchHexIceTombAbility",
//                "Ice Tomb",
//                "A storm of ice and freezing wind envelops the creature, which takes 3d8 points of cold damage (Fortitude half). If the target fails its save, it is paralyzed and unconscious for 1 minute/level. A successful save destroys the ice freeing the creature, which is staggered for 1d4 rounds. Whether or not the target’s saving throw is successful, it cannot be the target of this hex again for 1 day.",
//                IcyPrison.Icon,
//                AbilityType.Supernatural,
//                CommandType.Standard,
//                AbilityRange.Medium,
//                Resource.Strings.MinutesPerLevel,
//                Resource.Strings.FortitudePartial
//                ).SetComponents(
//                runaction,
//                Helper.CreateAbilityTargetHasFact(true, icetomb_cooldown.ToRef2()),
//                Helper.CreateSpellDescriptorComponent(SpellDescriptor.Hex | SpellDescriptor.Cold | SpellDescriptor.Paralysis)
//                ).TargetEnemy();

//            var icetomb = Helper.CreateBlueprintFeature(
//                "WitchHexIceTombFeature",
//                icetomb_ab.m_DisplayName,
//                icetomb_ab.m_Description,
//                IcyPrison.Icon,
//                FeatureGroup.WitchHex
//                ).SetComponents(
//                Helper.CreateAddFacts(icetomb_ab.ToRef2()),
//                Helper.CreatePrerequisiteFeature(WitchMajorHex)
//                );

//            Helper.AddHex(icetomb, false);
//        }

//        public static BlueprintAbilityAreaEffect CreateBlueprintAbilityAreaEffect(string name, bool applyEnemy = false, bool applyAlly = false, AreaEffectShape shape = AreaEffectShape.Cylinder, Feet size = default, PrefabLink sfx = null, BlueprintBuffReference buffWhileInside = null, ActionList unitEnter = null, ActionList unitExit = null, ActionList unitMove = null, ActionList unitRound = null) {
//            if (!applyAlly && !applyEnemy)
//                throw new ArgumentException("area must effect either allies or enemies");

//            string guid = Parse(name);

//            var result = new BlueprintAbilityAreaEffect();
//            result.name = name;
//            result.Shape = shape;
//            result.Size = size;
//            result.Fx = sfx ?? new PrefabLink();

//            if (applyEnemy && applyAlly)
//                result.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Any;
//            else if (applyEnemy)
//                result.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Enemy;
//            else if (applyAlly)
//                result.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Ally;

//            if (buffWhileInside != null) {
//                AbilityAreaEffectBuff areabuff = new(); // applies buff while inside
//                areabuff.Condition = new ConditionsChecker();
//                areabuff.CheckConditionEveryRound = false;
//                areabuff.m_Buff = buffWhileInside;

//                result.SetComponents(areabuff);
//            }

//            if (unitEnter != null || unitExit != null || unitMove != null || unitRound != null) {
//                AbilityAreaEffectRunAction runaction = new(); // runs actions that persist even when leaving
//                runaction.UnitEnter = unitEnter ?? new ActionList();
//                runaction.UnitExit = unitExit ?? new ActionList();
//                runaction.UnitMove = unitMove ?? new ActionList();
//                runaction.Round = unitRound ?? new ActionList();

//                result.AddComponents(runaction);
//            }

//            AddAsset(result, guid);
//            return result;
//        }

//    }
//}
