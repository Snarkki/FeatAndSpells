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

namespace FeatAndSpells.Abilities {
    internal class OtherChanges {

        public static BlueprintBuff AscendentsummonBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("3db4a1f9ffa46e7469f817bced1a0df2");
        public static BlueprintFeature AnimalCompanionSmilodonUpgrade = BlueprintTools.GetBlueprint<BlueprintFeature>("f1e949c3d93fc234da255b94629c5b3a");
        

        public static void OtherChangesHandler() {
            AddHealBoost();
            updateHexes();
            UpdateMythicProgressionHandler();
            buffAscendentSummon();
            AddFeatChanges();
            AnimalCompanionChange();
        }

        private static void AnimalCompanionChange() {
            AnimalCompanionSmilodonUpgrade.RemoveComponents<ChangeUnitSize>();
            AnimalCompanionSmilodonUpgrade.RemoveComponents<AddFacts>();
            AnimalCompanionSmilodonUpgrade.AddComponent<WeaponSizeChange>(c => {
                c.SizeCategoryChange = 1;
                c.CheckWeaponCategory = false;
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
