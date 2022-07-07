using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static FeatAndSpells.Blueprints.Progressions;
using static FeatAndSpells.Blueprints.FeatureSelections;
using static FeatAndSpells.Blueprints.Features;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Designers.Mechanics.Facts;
using static FeatAndSpells.Main;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Mechanics.Actions;

namespace FeatAndSpells.Abilities {
    internal class OtherChanges {

        public static BlueprintBuff AscendentsummonBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("3db4a1f9ffa46e7469f817bced1a0df2");
        public static BlueprintBuff SickenedBuffSubstition = BlueprintTools.GetBlueprint<BlueprintBuff>("4e42460798665fd4cb9173ffa7ada323");
        public static BlueprintBuff Shaken = BlueprintTools.GetBlueprint<BlueprintBuff>("25ec6cb6ab1845c48a95f9c20b034220");
        public static BlueprintFeature AnimalCompanionSmilodonUpgrade = BlueprintTools.GetBlueprint<BlueprintFeature>("f1e949c3d93fc234da255b94629c5b3a");
        public static BlueprintFeatureSelection mythictalents = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("ba0e5a900b775be4a99702f1ed08914d");
        public static BlueprintFeatureSelection mythicextratalents = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("8a6a511c55e67d04db328cc49aaad2b8");

        public static void OtherChangesHandler() {
            AddHealBoost();
            updateHexes();
            UpdateMythicProgressionHandler();
            buffAscendentSummon();
            AddFeatChanges();
            AnimalCompanionChange();
            FixUnstoppable();
            AddTricksterFeats();
        }

        private static void AddTricksterFeats() {

            mythictalents.m_AllFeatures = mythictalents.m_AllFeatures.AppendToArray(
                TricksterAthleticsTier1Feature.ToReference<BlueprintFeatureReference>(),
                TricksterAthleticsTier2Feature.ToReference<BlueprintFeatureReference>(),
                TricksterAthleticsTier3Feature.ToReference<BlueprintFeatureReference>(),
                TricksterKnowledgeArcanaTier1Feature.ToReference<BlueprintFeatureReference>(),
                TricksterKnowledgeArcanaTier2Feature.ToReference<BlueprintFeatureReference>(),
                TricksterKnowledgeArcanaTier3Feature.ToReference<BlueprintFeatureReference>()
                );
            mythicextratalents.m_AllFeatures = mythictalents.m_AllFeatures.AppendToArray(
                TricksterAthleticsTier1Feature.ToReference<BlueprintFeatureReference>(),
                TricksterAthleticsTier2Feature.ToReference<BlueprintFeatureReference>(),
                TricksterAthleticsTier3Feature.ToReference<BlueprintFeatureReference>(),
                TricksterKnowledgeArcanaTier1Feature.ToReference<BlueprintFeatureReference>(),
                TricksterKnowledgeArcanaTier2Feature.ToReference<BlueprintFeatureReference>(),
                TricksterKnowledgeArcanaTier3Feature.ToReference<BlueprintFeatureReference>()
                );
        }

        private static void AnimalCompanionChange() {
            AnimalCompanionSmilodonUpgrade.RemoveComponents<ChangeUnitSize>();
            AnimalCompanionSmilodonUpgrade.RemoveComponents<AddFacts>();
            AnimalCompanionSmilodonUpgrade.AddComponent<WeaponSizeChange>(c => {
                c.SizeCategoryChange = 1;
                c.CheckWeaponCategory = false;
            });
        }

        private static void FixUnstoppable() {

            var contextRemove =  Helpers.Create<ContextActionRemoveSelf>();

            SickenedBuffSubstition.AddComponent<RemoveWhenCombatEnded>();
            SickenedBuffSubstition.m_Flags = BlueprintBuff.Flags.RemoveOnRest;
            SickenedBuffSubstition.AddComponent<CombatStateTrigger>(c => {
                c.CombatEndActions = new ActionList {
                    Actions = new GameAction[] { contextRemove }
                };
            });
            Shaken.AddComponent<RemoveWhenCombatEnded>();
            Shaken.AddComponent<CombatStateTrigger>(c => {
                c.CombatEndActions = new ActionList {
                    Actions = new GameAction[] { contextRemove }
                };
            });
        }

        private static void buffAscendentSummon() {
            var contextRank = AscendentsummonBuff.GetComponent<ContextRankConfig>();
            contextRank.m_Progression = ContextRankProgression.StartPlusDoubleDivStep;
        }

        private static void AddHealBoost() {
            AddFeatureToLevelOne(clericClassProgress, HealingDomainGreaterFeature);
            AddFeatureToLevelOne(OracleProgression, HealingDomainGreaterFeature);
            AddFeatureToLevelOne(InquisitorProgression, HealingDomainGreaterFeature);
            AddFeatureToLevelOne(WitchProgression, HealingDomainGreaterFeature);
            AddFeatureToLevelOne(ShamanProgression, HealingDomainGreaterFeature);
            AddFeatureToLevelOne(DruidProgression, HealingDomainGreaterFeature);
            AddFeatureToLevelOne(BardProgression, HealingDomainGreaterFeature);
            AddFeatureToLevelOne(SkaldProgression, HealingDomainGreaterFeature);
        }

        private static void updateHexes() {
            //foreach (var ability in Blueprints.Hexes.HexList) {
            //    if (ability.ActionType == UnitCommand.CommandType.Standard) {
            //        ability.ActionType = UnitCommand.CommandType.Move;
            //    }
            //}

            WitchHexSelection.m_AllFeatures = WitchHexSelection.m_AllFeatures.AppendToArray(WizardFeatSelection.ToReference<BlueprintFeatureReference>());

        }
        private static void AddFeatChanges() {


            CraneStyle.RemoveComponents<PrerequisiteFeature>();
            CraneStyle.AddComponent<PrerequisiteFeature>(ab => {
                ab.Group = Prerequisite.GroupType.All;
                ab.CheckInProgression = false;
                ab.HideInUI = false;
                ab.m_Feature = DodgeFeature.ToReference<BlueprintFeatureReference>();
            });

            //var AbundantCastingPrepared = AbundantCasting.CreateCopy(FASContext, "AbundantCastingPrepared", bp => {
            //    bp.SetName(FASContext, "AbundantCastingPrepared");
            //    bp.SetDescription(FASContext, "Allows you to cast 3 more spells daily.");
            //    var comp = bp.GetComponent<AddSpellsPerDay>();
            //    comp.Amount = 3;
            //    bp.Groups = new FeatureGroup[] { FeatureGroup.Feat};
            //});


            //foreach (BlueprintProgression thisprog in Blueprints.Progressions.PreparedCasterList) {
            //    thisprog.LevelEntries = thisprog.LevelEntries.AppendToArray(
            //            Helpers.CreateLevelEntry(1, AbundantCasting)
            //        );
            //    FASContext.Logger.LogHeader("Added AbundantCastingPrepared to" + thisprog);
            //}
            //LevelEntry[] levelEntries = BasicFeatProgression.LevelEntries;
            //foreach (LevelEntry entry in levelEntries) {
            //    if (entry.Level == 1) {
            //        entry.Features.Add(BasicFeat);
            //    }
            //if (entry.Level == 7) {
            //    entry.Features.Add(TeamWorkFeat);
            //}
            //}
            //LevelEntry[] levelEntries = BasicFeatProgression.LevelEntries;
            //foreach (LevelEntry entry in levelEntries) {
            //    if (entry.Level == 1) {
            //        entry.Features.Add(BasicFeat);
            //    }
            //    if (entry.Level == 7) {
            //        entry.Features.Add(TeamWorkFeat);
            //    }
            //}
        }

        private static void UpdateMythicProgressionHandler() {
            UpdateMythicProgression(MythicCompanionProgression);
            UpdateMythicProgression(MythicStartingProgression);
            UpdateMythicProgression(AeonProgression);
            UpdateMythicProgression(AngelProgression);
            UpdateMythicProgression(AzataProgression);
            UpdateMythicProgression(DemonProgression);
            UpdateMythicProgression(DevilProgression);
            UpdateMythicProgression(GoldenDragonProgression);
            UpdateMythicProgression(LegendProgression);
            UpdateMythicProgression(LichProgression);
            UpdateMythicProgression(SwarmThatWalksProgression);
            UpdateMythicProgression(TricksterProgression);
        }

        private static void UpdateMythicProgression(BlueprintProgression progression) {
            int feats = 0;
            int abilities = 0;


            LevelEntry[] levelEntries = progression.LevelEntries;

            foreach (LevelEntry entry in levelEntries) {
                if (entry.Features.Count > 0) {
                    if (!entry.Features.Contains(MythicFeatSelection)) {
                        entry.Features.Add(MythicFeatSelection);
                        feats++;
                    }
                    if (!entry.Features.Contains(MythicAbilitySelection)) {
                        entry.Features.Add(MythicAbilitySelection);
                        abilities++;
                    }
                }
            }
        }

        private static void AddFeatureToLevelOne(BlueprintProgression bloodline, params BlueprintFeature[] requisites) {
            var levelOne = bloodline.LevelEntries.Where(entry => entry.Level == 1).First();
            foreach (var requisite in requisites) {
                if (!levelOne.m_Features.Contains(requisite.ToReference<BlueprintFeatureBaseReference>())) {
                    levelOne.m_Features.Add(requisite.ToReference<BlueprintFeatureBaseReference>());
                }
            }
        }
    }
}
