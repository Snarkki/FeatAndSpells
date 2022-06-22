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

    public class Magus {

        public static void ChangeHandler() {
            ChangeSkills();
            ChangeSwordSaint();
        }

        private static void ChangeSkills() {
            MagusClass.SkillPoints = 5;
            MagusClass.ClassSkills = new StatType[] {
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

        public static void ChangeSwordSaint() {

            //SwordSaintArcheType.AddFeatures = new LevelEntry[] {
            //        , CannyDefense, SwordSaintChosenWeapon

            //    };

            SwordSaintArcheType.AddFeatures = SwordSaintArcheType.AddFeatures.AppendToArray(Helpers.CreateLevelEntry(1, ScaledFistAcBonus));
            MagusClass.Progression.UIGroups = MagusClass.Progression.UIGroups.AppendToArray(
                   Helpers.CreateUIGroup(ScaledFistAcBonus)
                );
            FASContext.Logger.LogHeader("Changed SwordSaint");
        }
    }
}