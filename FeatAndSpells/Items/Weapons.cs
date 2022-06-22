using Kingmaker.AI.Blueprints;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;
using static FeatAndSpells.Main;
using static FeatAndSpells.Blueprints.Items;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Enums;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Equipment;

namespace FeatAndSpells.Items {
    public class Weapons {

        private static BlueprintWeaponEnchantment RovagugRelicGrasshopperEnchament = BlueprintTools.GetBlueprint<BlueprintWeaponEnchantment>("64c84d64f7f310b41b5e720de1f22459");
        private static BlueprintBuff GraspOfDevotionBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("3b0ddc2ea9b74e9d9dde9b94bb8665f2"); 
        private static BlueprintWeaponType LionsClawType = BlueprintTools.GetBlueprint<BlueprintWeaponType>("7460c899a3e17994391c9f596738978b");

        private static BlueprintUnit StauntonBoss = ResourcesLibrary.TryGetBlueprint<BlueprintUnit>("88f8535a8db0154488d5e72d74e0e466");
        private static BlueprintUnit Darrazand = ResourcesLibrary.TryGetBlueprint<BlueprintUnit>("819a27486581bb64cbcc4b8437ecd228");
        private static BlueprintUnit EchoOfDeskari_ForFight = ResourcesLibrary.TryGetBlueprint<BlueprintUnit>("e0cb4338cb6e72146a8a35794a0034be");

        private static BlueprintSharedVendorTable C3_ExoticTrader = ResourcesLibrary.TryGetBlueprint<BlueprintSharedVendorTable>("9c597a1f92dde2f4f8adb27ee5730188");
        private static BlueprintSharedVendorTable C4_StoryTeller = ResourcesLibrary.TryGetBlueprint<BlueprintSharedVendorTable>("9edaf8d72271d2e45a5f9a4c7362cc1a");
        private static BlueprintSharedVendorTable C5_ExoticTrader = ResourcesLibrary.TryGetBlueprint<BlueprintSharedVendorTable>("73895d43f46b45079e19d1afcb96efdd");

        private static BlueprintItemEquipmentShoulders CloakOfTheWinterWolf = ResourcesLibrary.TryGetBlueprint<BlueprintItemEquipmentShoulders>("77491022ca26d194fbee5e04395ae967");

        private static BlueprintWeaponEnchantment DeterrenceEnchament = BlueprintTools.GetBlueprint<BlueprintWeaponEnchantment>("b856958abad701340ac9ad9e1f60e55e");
        


        public static void Handler() {
            //CarsomyrNewWeaponType();
            AddKingMakerItems();
            CreateHolyDeterrence();
            CreateLongbowRudeStopper();
            Create1hOverThrow();
            CreateCarsomyr3();
            CreateCarsomyr5();
            CreateCarsomyr6();

        }
        //public static BlueprintItemWeapon Deterrence = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("0c56fef95e47d684b87dc774e818a38a"); // tästä +3 holy versio c3
        //public static BlueprintItemWeapon RudeStopper = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("69e9559be15752d4093aa84e77f57e55"); // täst long bowi kopio, storytellerille, 
        //public static BlueprintItemWeapon Overthrow = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("03731ae7545b93245b16ddf18b2ce3ba"); // tästä 1h flail versio
        private static void CarsomyrNewWeaponType() {
            var CarsomyrWeaponType = LionsClawType.CreateCopy<BlueprintWeaponType>(FASContext, "CarsomyrWeaponType", bp => {
                bp.Category = Kingmaker.Enums.WeaponCategory.Greatsword;
                bp.m_BaseDamage.m_Dice = DiceType.D6;
                bp.m_BaseDamage.m_Rolls = 2;
            });
        }

        private static void AddKingMakerItems() {

            CloakOfTheWinterWolf.m_Enchantments = CloakOfTheWinterWolf.m_Enchantments.AppendToArray(Resistance3.ToReference<BlueprintEquipmentEnchantmentReference>());
            CloakOfTheWinterWolf.SetName(FASContext, "Cloak of the Winter Wolf +3 Resistance");
            CloakOfTheWinterWolf.SetDescription(FASContext, "Whenever the wearer of this cloak makes a successful bite {g|Encyclopedia:Attack}attack{/g}, it deals additional {g|Encyclopedia:Dice}1d6{/g} cold {g|Encyclopedia:Damage}damages{/g} and trips the target. It also grants +3 resistances");


            C3_ExoticTrader.AddComponent<LootItemsPackFixed>(loot => {
                loot.m_Item = new LootItem() {
                    m_Type = LootItemType.Item,
                    m_Item = CloakOfTheWinterWolf.ToReference<BlueprintItemReference>(),
                    m_Loot = null
                };
                loot.m_Count = 1;
            });
        }

        private static void CreateHolyDeterrence() {

            var HolyDeterrence = Deterrence.CreateCopy<BlueprintItemWeapon>(FASContext, "HolyDeterrence", bp => {
                bp.SetName(FASContext, "Deterrence +3");
                bp.SetDescription(FASContext, "This +3 holy glaive grants the wielder a +5 competence {g|Encyclopedia:Bonus}bonus{/g} on {g|Encyclopedia:Persuasion}Persuasion{/g} {g|Encyclopedia:Skills}skill checks{/g} when used to intimidate.");
                bp.m_Enchantments = new BlueprintWeaponEnchantmentReference[] { 
                    Enhancement3.ToReference<BlueprintWeaponEnchantmentReference>(),
                    HolyEnch.ToReference<BlueprintWeaponEnchantmentReference>(),
                    DeterrenceEnchament.ToReference<BlueprintWeaponEnchantmentReference>()
                };
            });

            C3_ExoticTrader.AddComponent<LootItemsPackFixed>(loot => {
                loot.m_Item = new LootItem() {
                    m_Type = LootItemType.Item,
                    m_Item = HolyDeterrence.ToReference<BlueprintItemReference>(),
                    m_Loot = null
                };
                loot.m_Count = 1;
            });
        }

        private static void CreateLongbowRudeStopper() {

            var LongbowRudeStopper = RudeStopper.CreateCopy<BlueprintItemWeapon>(FASContext, "LongbowRudeStopper", bp => {
                bp.SetName(FASContext, "Rude Stopper Longbow +5");
                bp.SetDescription(FASContext, "Whenever the wielder of this +5 longbow lands a hit, the enemy must pass a {g|Encyclopedia:Saving_Throw}Will saving throw{/g} ({g|Encyclopedia:DC}DC{/g} 30) or become unable to cast {g|Encyclopedia:Spell}spells{/g} or {g|Encyclopedia:Attack}attack{/g} for 1 {g|Encyclopedia:Combat_Round}round{/g}. Affected enemy is immune to this effect for 3 rounds.");
                bp.m_Type = CompositeLongbow.ToReference<BlueprintWeaponTypeReference>();
                bp.m_Enchantments = bp.m_Enchantments.AppendToArray(
                    BaneOutsiderEvil.ToReference<BlueprintWeaponEnchantmentReference>()
                    );
            });

            C5_ExoticTrader.AddComponent<LootItemsPackFixed>(loot => {
                loot.m_Item = new LootItem() {
                    m_Type = LootItemType.Item,
                    m_Item = LongbowRudeStopper.ToReference<BlueprintItemReference>(),
                    m_Loot = null
                };
                loot.m_Count = 1;
            });
        }

        private static void Create1hOverThrow() {

            var SingleHandOverThrow = RudeStopper.CreateCopy<BlueprintItemWeapon>(FASContext, "SingleHandOverThrow", bp => {
                bp.SetName(FASContext, "Overthrow Longsword +5");
                bp.SetDescription(FASContext, "If the wielder of this +5 {g|Encyclopedia:Speed}speed{/g} flail has the Trip {g|Encyclopedia:Feat}feat{/g}, each {g|Encyclopedia:Combat_Round}round{/g} the first successful hit it lands also attempts to trip the target.:Combat_Round}round{/g}. Affected enemy is immune to this effect for 3 rounds.");
                bp.m_Type = Longsword.ToReference<BlueprintWeaponTypeReference>();
                bp.m_Enchantments = bp.m_Enchantments.AppendToArray(
                    BaneOutsiderEvil.ToReference<BlueprintWeaponEnchantmentReference>()
                    );
            });

            C5_ExoticTrader.AddComponent<LootItemsPackFixed>(loot => {
                loot.m_Item = new LootItem() {
                    m_Type = LootItemType.Item,
                    m_Item = SingleHandOverThrow.ToReference<BlueprintItemReference>(),
                    m_Loot = null
                };
                loot.m_Count = 1;
            });
        }

        private static void CreateCarsomyr3() {

            // +3 

            var GraspOfCarsomyr3 = RovagugRelicGrasshopperEnchament.CreateCopy<BlueprintWeaponEnchantment>(FASContext, "GraspOfCarsomyr3", bp => {
                bp.m_AllowNonContextActions = false;
                bp.m_EnchantmentCost = 1;
                bp.m_IdentifyDC = 5;
                var comp = bp.GetComponent<AddInitiatorAttackWithWeaponTrigger>();
                comp.CriticalHit = false;
                var actions = comp.Action.Actions.OfType<ContextActionDispelMagic>().First();
                actions.CheckBonus = 3;
                actions.OnlyTargetEnemyBuffs = true;

            });


            var Carsomyr3 = ColdIronGreatSword.CreateCopy<BlueprintItemWeapon>(FASContext, "Carsomyr3", bp => {
                bp.SetName(FASContext, "Carsomyr +3");
                bp.SetDescription(FASContext, "When this Holy +3 Greatsword hits, you try to dispel one buff from enemy.");
                bp.m_Cost = 50000;
                bp.CR = 15;
                bp.TrashLootTypes = new TrashLootType[0];
                bp.m_Icon = DevaGreatSword.Icon;
                bp.m_Enchantments = bp.m_Enchantments.AppendToArray(
                    Enhancement3.ToReference<BlueprintWeaponEnchantmentReference>(),
                    GraspOfCarsomyr3.ToReference<BlueprintWeaponEnchantmentReference>(),
                    HolyEnch.ToReference<BlueprintWeaponEnchantmentReference>()
                    );
            });


            C3_ExoticTrader.AddComponent<LootItemsPackFixed>(loot => {
                loot.m_Item = new LootItem() {
                    m_Type = LootItemType.Item,
                    m_Item = Carsomyr3.ToReference<BlueprintItemReference>(),
                    m_Loot = null
                };
                loot.m_Count = 1;
            });

        }

        private static void CreateCarsomyr5() {

            // +5 

            var GraspOfCarsomyr5 = RovagugRelicGrasshopperEnchament.CreateCopy<BlueprintWeaponEnchantment>(FASContext, "GraspOfCarsomyr5", bp => {
                bp.m_AllowNonContextActions = false;
                bp.m_EnchantmentCost = 1;
                bp.m_IdentifyDC = 5;
                var comp = bp.GetComponent<AddInitiatorAttackWithWeaponTrigger>();
                comp.CriticalHit = false;
                var actions = comp.Action.Actions.OfType<ContextActionDispelMagic>().First();
                actions.m_MaxSpellLevel.Value = 7;
                actions.CheckBonus = 4;
                actions.OnlyTargetEnemyBuffs = true;
            });


            var Carsomyr5 = ColdIronGreatSword.CreateCopy<BlueprintItemWeapon>(FASContext, "Carsomyr5", bp => {
                bp.SetName(FASContext, "Carsomyr +5");
                bp.SetDescription(FASContext, "When this Holy +5 Greatsword hits, you try to dispel one buff from enemy.");
                bp.m_Cost = 200000;
                bp.CR = 20;
                bp.TrashLootTypes = new TrashLootType[0];
                bp.m_Icon = DevaGreatSword.Icon;
                bp.m_Enchantments = bp.m_Enchantments.AppendToArray(
                    Enhancement5.ToReference<BlueprintWeaponEnchantmentReference>(),
                    GraspOfCarsomyr5.ToReference<BlueprintWeaponEnchantmentReference>(),
                    HolyEnch.ToReference<BlueprintWeaponEnchantmentReference>()
                    );
            });


            C5_ExoticTrader.AddComponent<LootItemsPackFixed>(loot => {
                loot.m_Item = new LootItem() {
                    m_Type = LootItemType.Item,
                    m_Item = Carsomyr5.ToReference<BlueprintItemReference>(),
                    m_Loot = null
                };
                loot.m_Count = 1;
            });
        }
        private static void CreateCarsomyr6() {

            var CarsomyrWeaponType = LionsClawType.CreateCopy<BlueprintWeaponType>(FASContext, "CarsomyrWeaponType", bp => {
                bp.Category = Kingmaker.Enums.WeaponCategory.Greatsword;
                bp.m_BaseDamage.m_Dice = DiceType.D6;
                bp.m_BaseDamage.m_Rolls = 2;
            });
            
            // +6 

            var GraspOfCarsomyr6 = RovagugRelicGrasshopperEnchament.CreateCopy<BlueprintWeaponEnchantment>(FASContext, "GraspOfCarsomyr6", bp => {
                bp.m_AllowNonContextActions = false;
                bp.m_EnchantmentCost = 1;
                bp.m_IdentifyDC = 5;
                var comp = bp.GetComponent<AddInitiatorAttackWithWeaponTrigger>();
                comp.CriticalHit = false;
                var actions = comp.Action.Actions.OfType<ContextActionDispelMagic>().First();
                actions.m_MaxSpellLevel.Value = 8;
                actions.CheckBonus = 10;
                actions.OnlyTargetEnemyBuffs = true;
            });

            var Carsomyr6 = ColdIronGreatSword.CreateCopy<BlueprintItemWeapon>(FASContext, "Carsomyr6", bp => {
                bp.SetName(FASContext, "Carsomyr +6");
                bp.SetDescription(FASContext, "When this Holy +6 Greatsword hits, you try to dispel one buff from enemy.");
                bp.m_Cost = 5000000;
                bp.CR = 25;
                bp.TrashLootTypes = new TrashLootType[0];
                bp.m_Icon = DevaGreatSword.Icon;
                bp.m_Type = CarsomyrWeaponType.ToReference<BlueprintWeaponTypeReference>();
                bp.m_Enchantments = bp.m_Enchantments.AppendToArray(
                    Enhancement6.ToReference<BlueprintWeaponEnchantmentReference>(),
                    GraspOfCarsomyr6.ToReference<BlueprintWeaponEnchantmentReference>(),
                    HolyEnch.ToReference<BlueprintWeaponEnchantmentReference>()
                    );
            });


            C5_ExoticTrader.AddComponent<LootItemsPackFixed>(loot => {
                loot.m_Item = new LootItem() {
                    m_Type = LootItemType.Item,
                    m_Item = Carsomyr6.ToReference<BlueprintItemReference>(),
                    m_Loot = null
                };
                loot.m_Count = 1;
            });
        }


    }
}
