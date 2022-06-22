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

namespace FeatAndSpells.Classes {

    public class Oracle {

        
        
        
        public static void ChangeHandler() {
            ChangeSkills();

        }

        private static void ChangeSkills() {

            var AngelOfJusticeArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(FASContext, "AngelOfJusticeArchetype", bp => {
                bp.SetName(FASContext, "Angel Of Justice");
                bp.SetDescription(FASContext, "Although the gods work through many agents, perhaps none are more mysterious than oracles. These divine vessels are granted power without their choice, selected by providence to wield powers that even they do not fully understand. Unlike clerics, who draws their magic through devotion to a deity, oracles garner {g|Encyclopedia:Strength}strength{/g} and power from many sources, namely those patron deities who support their ideals. Instead of worshiping a single source, oracles tend to venerate all of the gods that share their beliefs. While some see the powers of the oracle as a gift, others view them as a curse, changing the life of the chosen in unforeseen ways.");


                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(2, WizardFeatSelection, OracleLifeMysteryFeature),
                    Helpers.CreateLevelEntry(5, WizardFeatSelection, OracleRevelationSelection),
                    Helpers.CreateLevelEntry(9, OracleRevelationSelection),
                    Helpers.CreateLevelEntry(10, WizardFeatSelection),
                    Helpers.CreateLevelEntry(13, OracleRevelationSelection),
                    Helpers.CreateLevelEntry(15, WizardFeatSelection),
                    Helpers.CreateLevelEntry(17, OracleRevelationSelection),
                    Helpers.CreateLevelEntry(20, WizardFeatSelection)
                };
            });


            OracleClass.m_Archetypes = OracleClass.m_Archetypes.AppendToArray(AngelOfJusticeArchetype.ToReference<BlueprintArchetypeReference>());

            OracleClass.Progression.UIGroups = OracleClass.Progression.UIGroups.AppendToArray(
                Helpers.CreateUIGroup(
                    WizardFeatSelection, OracleLifeMysteryFeature
                                )
            );
            FASContext.Logger.LogHeader("Changed AngelOfJusticeArchetype");
        }


    }
}