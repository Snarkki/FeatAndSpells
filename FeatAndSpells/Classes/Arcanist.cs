using System;
using System.Collections.Generic;
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
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace FeatAndSpells.Classes {
    internal class Arcanist {

        public static void ChangeHandler() {
            ChangeBrownFur();
        }


        public static void ChangeBrownFur() {

            var ArcanistSpellMastery = Features.ScrollMasterry.CreateCopy(FASContext, "ArcanistSpellMastery", bp => {
                var comp = bp.GetComponent<ScrollSpecialization>();
                comp.m_SpecializedClass = CharacterClasses.ArcanistClass.ToReference<BlueprintCharacterClassReference>();
            });

            var comp = ScrollFocus.GetComponent<ContextRankConfig>();
            comp.m_Class = comp.m_Class.AppendToArray(ArcanistClass.ToReference<BlueprintCharacterClassReference>());

            ArcanistExploitSelection.m_AllFeatures = ArcanistExploitSelection.m_AllFeatures.AppendToArray(WizardFeatSelection.ToReference<BlueprintFeatureReference>());

            BrownFurArchetype.RemoveFeatures = new LevelEntry[] { };

            BrownFurArchetype.AddFeatures = BrownFurArchetype.AddFeatures.AppendToArray(
                Helpers.CreateLevelEntry(1, ScrollFocus),
                Helpers.CreateLevelEntry(5, Features.ScrollSpecialization),
                Helpers.CreateLevelEntry(10, ArcanistSpellMastery)
                );
            AlchemistClass.Progression.UIGroups = AlchemistClass.Progression.UIGroups.AppendToArray(
                   Helpers.CreateUIGroup(ScrollFocus, Features.ScrollSpecialization, ScrollMasterry)
                );
        }
    }
}