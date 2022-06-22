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

namespace FeatAndSpells.Classes {
    internal class Alchemist {

        public static void ChangeHandler() {
            ChangeSkills();
            ChangeVivisectionist();
        }

        private static void ChangeSkills() {
            AlchemistClass.SkillPoints = 5;
            AlchemistClass.ClassSkills = new StatType[] {
                StatType.SkillKnowledgeArcana,
                StatType.SkillKnowledgeWorld,
                StatType.SkillUseMagicDevice,
                StatType.SkillAthletics,
                StatType.SkillMobility,
                StatType.SkillPersuasion,
                StatType.SkillThievery,
                StatType.SkillStealth,
                StatType.SkillPerception };
        }

        public static void ChangeVivisectionist() {

            //SwordSaintArcheType.AddFeatures = new LevelEntry[] {
            //        , CannyDefense, SwordSaintChosenWeapon

            //    };

            VivisectionistArchetype.AddFeatures = VivisectionistArchetype.AddFeatures.AppendToArray(
                Helpers.CreateLevelEntry(1, ScaledFistAcBonus),
                Helpers.CreateLevelEntry(2, FinesseTraining)
                );
            AlchemistClass.Progression.UIGroups = AlchemistClass.Progression.UIGroups.AppendToArray(
                   Helpers.CreateUIGroup(ScaledFistAcBonus, ScaledFistAcBonus)
                );
            FASContext.Logger.LogHeader("Changed Alchemist");
        }
    }
}