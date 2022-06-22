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
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Utility;

namespace FeatAndSpells.Classes {

    static class PaladinTemplar
    {

        public static void ChangeHandler() {
            AddTemplar();
        }


        public static void AddTemplar()
        {

            var TemplarSpellBook = BloodragerSpellBook.CreateCopy(FASContext, "TemplarSpellBook", bp => {
                bp.Name = Helpers.CreateString(FASContext, "TemplarSpellBook.Name", "Templar Spellbook");
                bp.m_SpellList = PaladinSpellList.ToReference<BlueprintSpellListReference>();
                bp.m_CharacterClass = CharacterClasses.PaladinClass.ToReference<BlueprintCharacterClassReference>();
                bp.IsArcane = false;
            });


            var TemplarArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(FASContext, "TemplarArchetype", bp => {
                bp.SetName(FASContext, "Templar");
                bp.SetDescription(FASContext, "Templars are Paladins who specialize in fighting.");
                bp.AddSkillPoints = 2;

                bp.m_ReplaceSpellbook = TemplarSpellBook.ToReference<BlueprintSpellbookReference>();

                bp.RemoveFeatures = new LevelEntry[] {
                };


                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(2, FighterFeatSelection),
                    //Helpers.CreateLevelEntry(3, FighterArmorTraining),
                     Helpers.CreateLevelEntry(4, FighterFeatSelection),
                    //Helpers.CreateLevelEntry(5, FighterWeaponTraining),
                     Helpers.CreateLevelEntry(6, FighterFeatSelection),
                   // Helpers.CreateLevelEntry(7, FighterArmorTraining),
                   // Helpers.CreateLevelEntry(9, FighterWeaponTrainingRankUp),
                     Helpers.CreateLevelEntry(10, FighterFeatSelection),
                  //  Helpers.CreateLevelEntry(11, FighterArmorTraining),
                     Helpers.CreateLevelEntry(12, FighterFeatSelection),
                  // Helpers.CreateLevelEntry(13, FighterWeaponTrainingRankUp),
                     Helpers.CreateLevelEntry(6, FighterFeatSelection),
                  //  Helpers.CreateLevelEntry(15, FighterArmorTraining),
                  //  Helpers.CreateLevelEntry(17, FighterWeaponTrainingRankUp),
                     Helpers.CreateLevelEntry(20, FighterFeatSelection),
                };
            });

            PaladinClass.m_Archetypes = PaladinClass.m_Archetypes.AppendToArray(TemplarArchetype.ToReference<BlueprintArchetypeReference>());

            PaladinClass.Progression.UIGroups = PaladinClass.Progression.UIGroups.AppendToArray(
                //Helpers.CreateUIGroup(
                //    FighterArmorTraining
                //                ),
                //Helpers.CreateUIGroup(
                //    FighterWeaponTraining,
                //    FighterWeaponTrainingRankUp
                //),
                 Helpers.CreateUIGroup(
                    FighterFeatSelection
                )
            );
            FASContext.Logger.LogHeader("Changed Templar");

        }
    }
}

