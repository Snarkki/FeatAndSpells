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
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.RuleSystem;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;

namespace FeatAndSpells.Classes {
    public class Ranger
    {


        public static void ChangeHandler() {
            ChangeFreeBooter();
            ChangeMasterSpy();
        }

        public static void ChangeMasterSpy() {

            //var SpycraftAbility = Blueprints.Abilities.FreebooterBaneAbility.CreateCopy(FASContext, "SpycraftAbility", bp => {
            //    bp.SetName(FASContext, "Spycraft");
            //    bp.SetDescription(FASContext, "At 1st level, the espionage expert can, as a {g|Encyclopedia:Move_Action}move action{/g}, indicate an enemy in combat and rally her allies to focus on that target. The freebooter and her allies gain a +1 {g|Encyclopedia:Bonus}bonus{/g} on weapon {g|Encyclopedia:Attack}attack{/g} and {g|Encyclopedia:Damage}damage rolls{/g} against the target. At 5th level and every 5 levels thereafter (10th, 15th, and 20th level), the bonus increases by 1. The Spycrafts's bane lasts until the target dies or the masterspy selects a new target.");
            //    var comp = bp.GetComponents<AddFacts>();
            //});


            //var Spycraft = FreeBootersBane.CreateCopy(FASContext, "Spycraft", bp => {
            //    bp.SetName(FASContext, "Spycraft");
            //    bp.SetDescription(FASContext, "At 1st level, the espionage expert can, as a {g|Encyclopedia:Move_Action}move action{/g}, indicate an enemy in combat and rally her allies to focus on that target. The freebooter and her allies gain a +1 {g|Encyclopedia:Bonus}bonus{/g} on weapon {g|Encyclopedia:Attack}attack{/g} and {g|Encyclopedia:Damage}damage rolls{/g} against the target. At 5th level and every 5 levels thereafter (10th, 15th, and 20th level), the bonus increases by 1. The Spycrafts's bane lasts until the target dies or the masterspy selects a new target.");
            //    var comp = bp.GetComponents<AddFacts>().First();
            //    comp.m_Facts = new BlueprintUnitFactReference[] { SpycraftAbility.ToReference<BlueprintUnitFactReference>() };
            //});

            MasterSpyArchetype.AddFeatures = MasterSpyArchetype.AddFeatures.AppendToArray(
                Helpers.CreateLevelEntry(1, FreeBootersBane)
                );
            }
            public static void ChangeFreeBooter() {

            var lvl5 = KiArrowsFeatureLvl5.GetComponent<WeaponDamageOverride>();
            lvl5.Formula = new DiceFormula { m_Dice = DiceType.D10, m_Rolls = 1 };

            var lvl8 = KiArrowsFeatureLvl8.GetComponent<WeaponDamageOverride>();
            lvl8.Formula = new DiceFormula { m_Dice = DiceType.D12, m_Rolls = 1 };

            var lvl12 = KiArrowsFeatureLvl12.GetComponent<WeaponDamageOverride>();
            lvl5.Formula = new DiceFormula { m_Dice = DiceType.D10, m_Rolls = 1 };

            var lvl16 = KiArrowsFeatureLvl16.GetComponent<WeaponDamageOverride>();
            lvl16.Formula = new DiceFormula { m_Dice = DiceType.D8, m_Rolls = 2 };

            var lvl20 = KiArrowsFeatureLvl20.GetComponent<WeaponDamageOverride>();
            lvl20.Formula = new DiceFormula { m_Dice = DiceType.D10, m_Rolls = 2 };

            //var FreeArrowsFeatureLvl5 = Helpers.CreateBlueprint<BlueprintFeature>("FreeArrowsFeatureLvl5", bp => {

            var FreeBooterArcheryFeature = Helpers.CreateBlueprint<BlueprintFeature>(FASContext, "FreeBooterArcheryFeature", bp => {
                bp.SetName(FASContext, "Freebooter Archery");
                bp.SetDescription(FASContext, "At 5th level, freebooters damage with bows grow up by one level. For example, a short bow normally deals 1d6 damage, but using this ability it will deal 1d8 damage.");
                bp.m_Icon = KiArrows.Icon;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = RangerClass.ToReference<BlueprintCharacterClassReference>();
                    c.Level = 5;
                    c.m_Archetypes = RangerClass.m_Archetypes.AppendToArray(FreebooterArchetype.ToReference<BlueprintArchetypeReference>());
                    c.BeforeThisLevel = false;
                    c.m_Feature = KiArrowsFeatureLvl5.ToReference<BlueprintFeatureReference>();
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = RangerClass.ToReference<BlueprintCharacterClassReference>();
                    c.Level = 8;
                    c.m_Archetypes = RangerClass.m_Archetypes.AppendToArray(FreebooterArchetype.ToReference<BlueprintArchetypeReference>());
                    c.BeforeThisLevel = false;
                    c.m_Feature = KiArrowsFeatureLvl8.ToReference<BlueprintFeatureReference>();
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = RangerClass.ToReference<BlueprintCharacterClassReference>();
                    c.Level = 12;
                    c.m_Archetypes = RangerClass.m_Archetypes.AppendToArray(FreebooterArchetype.ToReference<BlueprintArchetypeReference>());
                    c.BeforeThisLevel = false;
                    c.m_Feature = KiArrowsFeatureLvl12.ToReference<BlueprintFeatureReference>();
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = RangerClass.ToReference<BlueprintCharacterClassReference>();
                    c.Level = 16;
                    c.m_Archetypes = RangerClass.m_Archetypes.AppendToArray(FreebooterArchetype.ToReference<BlueprintArchetypeReference>());
                    c.BeforeThisLevel = false;
                    c.m_Feature = KiArrowsFeatureLvl16.ToReference<BlueprintFeatureReference>();
                });
                bp.AddComponent<AddFeatureOnClassLevel>(c => {
                    c.m_Class = RangerClass.ToReference<BlueprintCharacterClassReference>();
                    c.Level = 20;
                    c.m_Archetypes = RangerClass.m_Archetypes.AppendToArray(FreebooterArchetype.ToReference<BlueprintArchetypeReference>());
                    c.BeforeThisLevel = false;
                    c.m_Feature = KiArrowsFeatureLvl20.ToReference<BlueprintFeatureReference>();
                });
            });

            //FreebooterArchetype.RecommendedAttributes = new StatType[]
            //    {
            //        StatType.Charisma
            //    };

            FreebooterArchetype.AddSkillPoints = 4;
            FreebooterArchetype.ClassSkills = FreebooterArchetype.ClassSkills.AppendToArray(
                StatType.SkillAthletics,
                StatType.SkillMobility,
                StatType.SkillUseMagicDevice
                );

           // FreebooterArchetype.m_ReplaceSpellbook = MAster.ToReference<BlueprintSpellbookReference>();

            FreebooterArchetype.AddFeatures = FreebooterArchetype.AddFeatures.AppendToArray(
                    Helpers.CreateLevelEntry(1, FavoredEnemySelection),
                    Helpers.CreateLevelEntry(5, FavoredEnemySelection, FavoredEnemyRankUp, FreeBooterArcheryFeature),
                    Helpers.CreateLevelEntry(10, FavoredEnemySelection, FavoredEnemyRankUp),
                    Helpers.CreateLevelEntry(15,  FavoredEnemySelection, FavoredEnemyRankUp),
                    Helpers.CreateLevelEntry(20, FavoredEnemySelection, FavoredEnemyRankUp)
                );

            FASContext.Logger.LogHeader("Changed Freebooter");

            RangerClass.Progression.UIGroups = RangerClass.Progression.UIGroups.AppendToArray(
                   //Helpers.CreateUIGroup(FavoredEnemySelection),
                   //Helpers.CreateUIGroup(FavoredEnemyRankUp),
                   Helpers.CreateUIGroup(FreeBooterArcheryFeature)
                );
        }

    }
}