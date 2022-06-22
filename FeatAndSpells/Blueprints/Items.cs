
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;

namespace FeatAndSpells.Blueprints {
    public class Items {

        public static BlueprintArmorType BandedArmor = BlueprintTools.GetBlueprint<BlueprintArmorType>("da1b160cd13f16a429499b96636f6ed9");
        public static BlueprintArmorType FullPlate = BlueprintTools.GetBlueprint<BlueprintArmorType>("afd9065539b3ac5499eddca923654c4b");
        public static BlueprintArmorType HalfPlate = BlueprintTools.GetBlueprint<BlueprintArmorType>("a59bf41f441456a4e8b04b09cb889af8");
        public static BlueprintArmorType BreastPlate = BlueprintTools.GetBlueprint<BlueprintArmorType>("d326c3c61a84c6f40977c84fab41503d");
        public static BlueprintArmorType ChainMail = BlueprintTools.GetBlueprint<BlueprintArmorType>("cd4a47c5bacbff3498e960eec3a83485");
        public static BlueprintArmorType HideArmor = BlueprintTools.GetBlueprint<BlueprintArmorType>("7a01292cef39bf2408f7fae7a9f47594");
        public static BlueprintArmorType ScaleMail = BlueprintTools.GetBlueprint<BlueprintArmorType>("f95c21c70a5677346b75e447c7225ba6");
        public static BlueprintArmorType ChainShirt = BlueprintTools.GetBlueprint<BlueprintArmorType>("7467b0ab8641d8f43af7fc46f2108a1a");
        public static BlueprintArmorType StudLeather = BlueprintTools.GetBlueprint<BlueprintArmorType>("aae2cb63162d6334b9a9150398124d46");
        public static BlueprintArmorType Leather = BlueprintTools.GetBlueprint<BlueprintArmorType>("c850ba40ed3a61b489b438a5ffa71de9");
        public static BlueprintShieldType BucklerShield = BlueprintTools.GetBlueprint<BlueprintShieldType>("26fcc43f7d20374498d2e1643381d345");
        public static BlueprintShieldType HeavyShield = BlueprintTools.GetBlueprint<BlueprintShieldType>("d1b05b901bab9524388ebfa0435902a6");
        public static BlueprintShieldType LightShield = BlueprintTools.GetBlueprint<BlueprintShieldType>("d38e8ea23ce653c4582eb3e002555483");
        public static BlueprintShieldType TowerShield = BlueprintTools.GetBlueprint<BlueprintShieldType>("5f0f4b6e480e7054b8592b5a8b55854a");



        public static BlueprintWeaponType CompositeLongbow = BlueprintTools.GetBlueprint<BlueprintWeaponType>("1ac79088a7e5dde46966636a3ac71c35");
        public static BlueprintWeaponType CompositeShortbow = BlueprintTools.GetBlueprint<BlueprintWeaponType>("011f6f86a0b16df4bbf7f40878c3e80b");
        public static BlueprintWeaponType Longbow = BlueprintTools.GetBlueprint<BlueprintWeaponType>("7a1211c05ec2c46428f41e3c0db9423f");
        public static BlueprintWeaponType Shortbow = BlueprintTools.GetBlueprint<BlueprintWeaponType>("99ce02fb54639b5439d07c99c55b8542");
        public static BlueprintWeaponType LightCrossbow = BlueprintTools.GetBlueprint<BlueprintWeaponType>("d525e7a6d8d5aa648a976ac41194b8d0");
        public static BlueprintWeaponType HeavyCrossbow = BlueprintTools.GetBlueprint<BlueprintWeaponType>("36d0551b8a28587438a47fcbbf53c083");
        public static BlueprintWeaponType Longsword = BlueprintTools.GetBlueprint<BlueprintWeaponType>("d56c44bc9eb10204c8b386a02c7eed21");


        public static BlueprintItemWeapon ColdIronGreatSword = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("d48ee6124ad593f429e2e618726f2ef7");
        public static BlueprintItemWeapon DevaGreatSword = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("de889bf84998b8e46a4ba9b6b84cf1d0");

        public static BlueprintWeaponEnchantment Enhancement1 = BlueprintTools.GetBlueprint<BlueprintWeaponEnchantment>("d42fc23b92c640846ac137dc26e000d4");
        public static BlueprintWeaponEnchantment Enhancement2 = BlueprintTools.GetBlueprint<BlueprintWeaponEnchantment>("eb2faccc4c9487d43b3575d7e77ff3f5");
        public static BlueprintWeaponEnchantment Enhancement3 = BlueprintTools.GetBlueprint<BlueprintWeaponEnchantment>("80bb8a737579e35498177e1e3c75899b");
        public static BlueprintWeaponEnchantment Enhancement4 = BlueprintTools.GetBlueprint<BlueprintWeaponEnchantment>("783d7d496da6ac44f9511011fc5f1979");
        public static BlueprintWeaponEnchantment Enhancement5 = BlueprintTools.GetBlueprint<BlueprintWeaponEnchantment>("bdba267e951851449af552aa9f9e3992");
        public static BlueprintWeaponEnchantment Enhancement6 = BlueprintTools.GetBlueprint<BlueprintWeaponEnchantment>("0326d02d2e24d254a9ef626cc7a3850f");

        public static BlueprintWeaponEnchantment HolyEnch = BlueprintTools.GetBlueprint<BlueprintWeaponEnchantment>("28a9964d81fedae44bae3ca45710c140");
        public static BlueprintWeaponEnchantment BaneOutsiderEvil = BlueprintTools.GetBlueprint<BlueprintWeaponEnchantment>("20ba9055c6ae1e44ca270c03feacc53b");

        public static BlueprintItemWeapon Deterrence = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("0c56fef95e47d684b87dc774e818a38a"); // tästä +3 holy versio c3
        public static BlueprintItemWeapon RudeStopper = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("69e9559be15752d4093aa84e77f57e55"); // täst long bowi kopio, storytellerille, 
        public static BlueprintItemWeapon Overthrow = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("03731ae7545b93245b16ddf18b2ce3ba"); // tästä 1h flail versio
        public static BlueprintItemWeapon BladeOfOrderItem = BlueprintTools.GetBlueprint<BlueprintItemWeapon>("4aafece401c2b0b4ea251c20c8341921"); // 


        public static BlueprintEquipmentEnchantment Resistance3 = BlueprintTools.GetBlueprint<BlueprintEquipmentEnchantment>("9d6f77c05099caf4eab25228632fdf64"); // tästä +3 holy versio c3














    }
}
