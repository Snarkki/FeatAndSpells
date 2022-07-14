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
using Kingmaker.Blueprints.Classes.Spells;

namespace FeatAndSpells.Classes {

    static class PaladinTemplar
    {

        public static void ChangeHandler() {
            AddTemplar();
        }


        public static void AddTemplar() {

               Blueprints.Abilities.FlameStrike.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 5);
            Blueprints.Abilities.CureLightWoundsMass.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 5);
            Blueprints.Abilities.BreakEnchantment.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 5);
            Blueprints.Abilities.RighteousMight.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 5);
            Blueprints.Abilities.TrueSeeing.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 5);
            Blueprints.Abilities.Banishment.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 5);
            Blueprints.Abilities.SacredNimbus.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 5);
            Blueprints.Abilities.SpellResistance.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 5);
            Blueprints.Abilities.CommandGreater.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 5);
            Blueprints.Abilities.StoneskinCommunal.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 5);


               Blueprints.Abilities.BlessingOfLuckAndResolveMass.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 6);
            Blueprints.Abilities.Harm.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 6);
               Blueprints.Abilities.Heal.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 6);
               Blueprints.Abilities.LitanyofMadness.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 6);
               Blueprints.Abilities.CureModerateWoundsMass.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 6);
               Blueprints.Abilities.DispelMagicGreater.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 6);
               Blueprints.Abilities.BladeBarrier.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 6);
               Blueprints.Abilities.InspiringRecovery.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 6);


               Blueprints.Abilities.Arbitrament.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 7);
               Blueprints.Abilities.CureSeriousWoundsMass.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 7);
               Blueprints.Abilities.SummonMonsterVIIBase.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 7);
               Blueprints.Abilities.Destruction.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 7);
               Blueprints.Abilities.RestorationGreater.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 7);
               Blueprints.Abilities.Blasphemy.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 7);
               Blueprints.Abilities.WavesOfEctasy.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 7);
               Blueprints.Abilities.HolyWord.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 7);
               Blueprints.Abilities.Resurrection.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 7);



               Blueprints.Abilities.HolyAura.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 8);
               Blueprints.Abilities.FireStorm.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 8);
               Blueprints.Abilities.ShieldOfLaw.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 8);
               Blueprints.Abilities.FrightfulAspect.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 8);
               Blueprints.Abilities.CureCriticalWoundsMass.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 8);
               Blueprints.Abilities.Stormbolts.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 8);
               Blueprints.Abilities.SummonMonsterVIIIBase.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 8);



                Blueprints.Abilities.OverwhelmingPresence.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 9);
                Blueprints.Abilities.HealMass.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 9);
                Blueprints.Abilities.WindsOfVengeance.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 9);
                Blueprints.Abilities.SummonMonsterIXBase.AddToSpellList(SpellTools.SpellList.PaladinSpellList, 9);



            var TemplarSpellBook = BloodragerSpellBook.CreateCopy(FASContext, "TemplarSpellBook", bp => {
                bp.Name = Helpers.CreateString(FASContext, "TemplarSpellBook.Name", "Templar Spellbook");
                bp.m_SpellList = PaladinSpellList.ToReference<BlueprintSpellListReference>();
                bp.m_CharacterClass = CharacterClasses.PaladinClass.ToReference<BlueprintCharacterClassReference>();
                bp.IsArcane = false;
            });

            SpellBooks.AngelIncorporateSpellbook.m_AllowedSpellbooks = SpellBooks.AngelIncorporateSpellbook.m_AllowedSpellbooks.AppendToArray(TemplarSpellBook.ToReference<BlueprintSpellbookReference>());




            var TemplarArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(FASContext, "TemplarArchetype", bp => {
                bp.SetName(FASContext, "Templar");
                bp.SetDescription(FASContext, "Templars are Paladins who specialize in fighting.");
                bp.AddSkillPoints = 2;

                bp.m_ReplaceSpellbook = TemplarSpellBook.ToReference<BlueprintSpellbookReference>();

                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(3, SelectionMercy),
                    Helpers.CreateLevelEntry(6, SelectionMercy),
                    Helpers.CreateLevelEntry(9, SelectionMercy),
                    Helpers.CreateLevelEntry(12, SelectionMercy),
                    Helpers.CreateLevelEntry(15, SelectionMercy),
                    Helpers.CreateLevelEntry(18, SelectionMercy),

                };


                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(2, FighterFeatSelection),
                    Helpers.CreateLevelEntry(3, FighterArmorTraining),
                     Helpers.CreateLevelEntry(4, FighterFeatSelection),
                    //Helpers.CreateLevelEntry(5, FighterWeaponTraining),
                     Helpers.CreateLevelEntry(6, FighterFeatSelection),
                    Helpers.CreateLevelEntry(7, FighterArmorTraining),
                   // Helpers.CreateLevelEntry(9, FighterWeaponTrainingRankUp),
                     Helpers.CreateLevelEntry(10, FighterFeatSelection),
                    Helpers.CreateLevelEntry(11, FighterArmorTraining),
                     Helpers.CreateLevelEntry(12, FighterFeatSelection),
                  // Helpers.CreateLevelEntry(13, FighterWeaponTrainingRankUp),
                     Helpers.CreateLevelEntry(14, FighterFeatSelection),
                    Helpers.CreateLevelEntry(15, FighterArmorTraining),
                  //  Helpers.CreateLevelEntry(17, FighterWeaponTrainingRankUp),
                     Helpers.CreateLevelEntry(20, FighterFeatSelection),
                };
            });

            PaladinClass.m_Archetypes = PaladinClass.m_Archetypes.AppendToArray(TemplarArchetype.ToReference<BlueprintArchetypeReference>());

            PaladinClass.Progression.UIGroups = PaladinClass.Progression.UIGroups.AppendToArray(
                Helpers.CreateUIGroup(
                    FighterArmorTraining
                               ),
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

