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

namespace FeatAndSpells.Classes {
    public class Fighter {

        private static BlueprintFeature AuraOfCowardiceFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(FASContext, "AuraOfCowardiceFeature");
        public static void ChangeHandler() {
            ChangeArmigerWarrior();
        }


        public static void ChangeArmigerWarrior() {
            Progressions.OrderOfNailProgression.m_Classes =Progressions.OrderOfNailProgression.m_Classes.AppendToArray(
                new BlueprintProgression.ClassWithLevel() {
                    m_Class = CharacterClasses.FighterClass.ToReference<BlueprintCharacterClassReference>()
                });

            ArmigerArchetype.AddSkillPoints = 2;
            ArmigerArchetype.AddFeatures = ArmigerArchetype.AddFeatures.AppendToArray(
                    Helpers.CreateLevelEntry(1, FighterFeatSelection),
                    Helpers.CreateLevelEntry(5, AuraOfCowardiceFeature),
                    Helpers.CreateLevelEntry(10, FighterFeatSelection, ThugFrighteningFeature)
                );

            FASContext.Logger.LogHeader("Changed armiger warrior");
        }
    }
}
