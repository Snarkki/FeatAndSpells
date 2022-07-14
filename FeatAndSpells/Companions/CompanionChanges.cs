using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;
using static FeatAndSpells.Blueprints.Units;
using static FeatAndSpells.Main;

namespace FeatAndSpells.Companions {
    public class CompanionChanges {

        public static BlueprintRace GnomeRace = BlueprintTools.GetBlueprint<BlueprintRace>("ef35a22c9a27da345a4528f0d5889157");
        public static BlueprintRace DwarfRace = BlueprintTools.GetBlueprint<BlueprintRace>("c4faf439f0e70bd40b5e36ee80d06be7");
        public static BlueprintPortrait ArushalaePortrait = BlueprintTools.GetBlueprint<BlueprintPortrait>("db413e67276547b40b1a6bb8178c6951");
        public static BlueprintRace AscendingSuccubus = BlueprintTools.GetBlueprint<BlueprintRace>("5e464d1d5fd0e7a4380b6ce60ef2c83b");
        public static BlueprintFeature SlowAndSteady = BlueprintTools.GetBlueprint<BlueprintFeature>("786588ad1694e61498e77321d4b07157");
        public static BlueprintFeature AirBorne = BlueprintTools.GetBlueprint<BlueprintFeature>("70cffb448c132fa409e49156d013b175");

        public static void CompanionHandler() {
            //ChangeRaces();
            ChangePCChar();
            CustomBackground();
            ChangeRegill();
            ChangeCamelia();
            ChangeDaeran(); 
            ChangeEmber();
            ChangeGreybor();
            ChangeLann();
            ChangeNenio();
            ChangeSeelah();
            ChangeWolfij();
            //ChangeArushalae();
        }


        private static void ChangePCChar() {
            BlueprintUnit StartGame_Player_Unit = BlueprintTools.GetBlueprint<BlueprintUnit>("4391e8b9afbb0cf43aeba700c089f56d");
            StartGame_Player_Unit.Strength = 11;
            StartGame_Player_Unit.Dexterity = 11;
            StartGame_Player_Unit.Constitution = 11;
            StartGame_Player_Unit.Intelligence = 11;
            StartGame_Player_Unit.Wisdom = 11;
            StartGame_Player_Unit.Charisma = 11;
        }

        private static void CustomBackground() {
            Blueprints.Features.BackgroundAcolyte.AddComponent(Helpers.Create<AddFacts>(c => {
                c.m_Facts = new BlueprintUnitFactReference[] {
                        Blueprints.Features.FauchardProfiency.ToReference<BlueprintUnitFactReference>(),
                        Blueprints.Features.GlaiveProfiency.ToReference<BlueprintUnitFactReference>()
                };
            }));

            Blueprints.Features.BackgroundAcolyte.AddComponent(Helpers.Create<AddBackgroundWeaponProficiency>(c => {
                c.Proficiency = Kingmaker.Enums.WeaponCategory.Glaive;
                c.StackBonusType = Kingmaker.Enums.ModifierDescriptor.Trait;
                c.StackBonus = new ContextValue() {
                    ValueType = ContextValueType.Simple,
                    Value = 1,
                    ValueRank = Kingmaker.Enums.AbilityRankType.Default,
                    ValueShared = Kingmaker.UnitLogic.Abilities.AbilitySharedValue.Damage,
                    Property = Kingmaker.UnitLogic.Mechanics.Properties.UnitProperty.None
                };
            }));

            Blueprints.Features.BackgroundAcolyte.AddComponent(Helpers.Create<AddBackgroundWeaponProficiency>(c => {
                c.Proficiency = Kingmaker.Enums.WeaponCategory.Fauchard;
                c.StackBonusType = Kingmaker.Enums.ModifierDescriptor.Trait;
                c.StackBonus = new ContextValue() {
                    ValueType = ContextValueType.Simple,
                    Value = 1,
                    ValueRank = Kingmaker.Enums.AbilityRankType.Default,
                    ValueShared = Kingmaker.UnitLogic.Abilities.AbilitySharedValue.Damage,
                    Property = Kingmaker.UnitLogic.Mechanics.Properties.UnitProperty.None
                };
            }));

            Blueprints.Features.BackgroundFarmhand.AddComponent(Helpers.Create<AddFacts>(c => {
                c.m_Facts = new BlueprintUnitFactReference[] {
                        Blueprints.Features.FauchardProfiency.ToReference<BlueprintUnitFactReference>(),
                        Blueprints.Features.GlaiveProfiency.ToReference<BlueprintUnitFactReference>()
                };
            }));

            Blueprints.Features.BackgroundFarmhand.AddComponent(Helpers.Create<AddBackgroundWeaponProficiency>(c => {
                c.Proficiency = Kingmaker.Enums.WeaponCategory.Glaive;
                c.StackBonusType = Kingmaker.Enums.ModifierDescriptor.Trait;
                c.StackBonus = new ContextValue() {
                    ValueType = ContextValueType.Simple,
                    Value = 1,
                    ValueRank = Kingmaker.Enums.AbilityRankType.Default,
                    ValueShared = Kingmaker.UnitLogic.Abilities.AbilitySharedValue.Damage,
                    Property = Kingmaker.UnitLogic.Mechanics.Properties.UnitProperty.None
                };
            }));

            Blueprints.Features.BackgroundFarmhand.AddComponent(Helpers.Create<AddBackgroundWeaponProficiency>(c => {
                c.Proficiency = Kingmaker.Enums.WeaponCategory.Fauchard;
                c.StackBonusType = Kingmaker.Enums.ModifierDescriptor.Trait;
                c.StackBonus = new ContextValue() {
                    ValueType = ContextValueType.Simple,
                    Value = 1,
                    ValueRank = Kingmaker.Enums.AbilityRankType.Default,
                    ValueShared = Kingmaker.UnitLogic.Abilities.AbilitySharedValue.Damage,
                    Property = Kingmaker.UnitLogic.Mechanics.Properties.UnitProperty.None
                };
            }));

            // MARTIAL

            Blueprints.Features.BackgroundMartialDisciple.AddComponent(Helpers.Create<AddFacts>(c => {
                c.m_Facts = new BlueprintUnitFactReference[] {
                        Blueprints.Features.EstocProfiency.ToReference<BlueprintUnitFactReference>(),
                };
            }));

            Blueprints.Features.BackgroundMartialDisciple.AddComponent(Helpers.Create<AddBackgroundWeaponProficiency>(c => {
                c.Proficiency = Kingmaker.Enums.WeaponCategory.Estoc;
                c.StackBonusType = Kingmaker.Enums.ModifierDescriptor.Trait;
                c.StackBonus = new ContextValue() {
                    ValueType = ContextValueType.Simple,
                    Value = 1,
                    ValueRank = Kingmaker.Enums.AbilityRankType.Default,
                    ValueShared = Kingmaker.UnitLogic.Abilities.AbilitySharedValue.Damage,
                    Property = Kingmaker.UnitLogic.Mechanics.Properties.UnitProperty.None
                };
            }));

        }

        private static void ChangeRegill() {
            Regill_Companion.Strength = 13;
            Regill_Companion.Dexterity = 18;
            Regill_Companion.Constitution = 14;
            Regill_Companion.Intelligence = 7;
            Regill_Companion.Wisdom = 10;
            Regill_Companion.Charisma = 16;
            //Regill_Companion.m_AddFacts = Regill_Companion.m_AddFacts.AppendToArray(AirBorne.ToReference<BlueprintUnitFactReference>());
            //Regill_Companion.m_Race = AscendingSuccubus.ToReference<BlueprintRaceReference>();
            //Regill_Companion.Alignment = Kingmaker.Enums.Alignment.LawfulGood;
            //Regill_Companion.Size = Kingmaker.Enums.Size.Medium;
        }

        private static void ChangeNenio() {
            Nenio_Companion.Strength = 8;
            Nenio_Companion.Dexterity = 16;
            Nenio_Companion.Constitution = 14;
            Nenio_Companion.Intelligence = 16;
            Nenio_Companion.Wisdom = 10;
            Nenio_Companion.Charisma = 8;
        }

        private static void ChangeCamelia() {
            Camelia_Companion.Strength = 13;
            Camelia_Companion.Dexterity = 16;
            Camelia_Companion.Constitution = 14;
            Camelia_Companion.Wisdom = 16;
            Camelia_Companion.Intelligence = 10;
            Camelia_Companion.Charisma = 12;
            Camelia_Companion.Body.m_Neck = null;
        }

        private static void ChangeSeelah() {
            Seelah_Companion.Strength = 16;
            Seelah_Companion.Dexterity = 13;
            Seelah_Companion.Constitution = 16;
            Seelah_Companion.Intelligence = 7;
            Seelah_Companion.Wisdom = 10;
            Seelah_Companion.Charisma = 16;
        }

        private static void ChangeWolfij() {
            Wolfij_Companion.Strength = 9;
            Wolfij_Companion.Dexterity = 17;
            Wolfij_Companion.Constitution = 14;
            Wolfij_Companion.Intelligence = 16;
            Wolfij_Companion.Wisdom = 12;
            Wolfij_Companion.Charisma = 8;
        }

        private static void ChangeDaeran() {
            Daeran_Companion.Strength = 10;
            Daeran_Companion.Dexterity = 16;
            Daeran_Companion.Constitution = 14;
            Daeran_Companion.Intelligence = 18;
            Daeran_Companion.Wisdom = 10;
            Daeran_Companion.Charisma = 16;
        }

        private static void ChangeGreybor() {
            SlowAndSteady.RemoveComponents<AddStatBonus>();
            SlowAndSteady.SetDescription(FASContext, "Dwarves speed is never modified by armor or encumbrance.");

            Greybor_Companion.Strength = 16;
            Greybor_Companion.Dexterity = 18;
            Greybor_Companion.Constitution = 14;
            Greybor_Companion.Intelligence = 10;
            Greybor_Companion.Wisdom = 12;
            Greybor_Companion.Charisma = 7;
        }

        private static void ChangeEmber() {
            Ember_Companion.Strength = 8;
            Ember_Companion.Dexterity = 16;
            Ember_Companion.Constitution = 14;
            Ember_Companion.Intelligence = 16;
            Ember_Companion.Wisdom = 13;
            Ember_Companion.Charisma = 10;
        }

        private static void ChangeLann() {
            Lann_Companion.Strength = 16;
            Lann_Companion.Dexterity = 16;
            Lann_Companion.Constitution = 12;
            Lann_Companion.Intelligence = 10;
            Lann_Companion.Wisdom = 17;
            Lann_Companion.Charisma = 10;
        }

        //private static void ChangeArushalae() {
        //    Arushalae_Companion.Strength = 16;
        //}
    }
}
