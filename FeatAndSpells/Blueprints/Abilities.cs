
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;

namespace FeatAndSpells.Blueprints {
    public class Abilities {

        public static BlueprintAbilityResource ArcanistArcaneReservoirResource = BlueprintTools.GetBlueprint<BlueprintAbilityResource>("cac948cbbe79b55459459dd6a8fe44ce");
        public static BlueprintAbility WitchDoctorChannel = BlueprintTools.GetBlueprint<BlueprintAbility>("d470eb6b3b31fde4bb44ec753de0b862");

        public static BlueprintAbility HurricaneBow = BlueprintTools.GetBlueprint<BlueprintAbility>("3e9d1119d43d07c4c8ba9ebfd1671952");
        public static BlueprintAbility GreatFang = BlueprintTools.GetBlueprint<BlueprintAbility>("f1100650705a69c4384d3edd88ba0f52");
        public static BlueprintAbility ExpRetreat = BlueprintTools.GetBlueprint<BlueprintAbility>("4f8181e7a7f1d904fbaea64220e83379");
        public static BlueprintAbility MageArmour = BlueprintTools.GetBlueprint<BlueprintAbility>("9e1ad5d6f87d19e4d8883d63a6e35568");
        public static BlueprintAbility Echolocation = BlueprintTools.GetBlueprint<BlueprintAbility>("20b548bf09bb3ea4bafea78dcb4f3db6");
        public static BlueprintAbility Eaglesoul = BlueprintTools.GetBlueprint<BlueprintAbility>("332ad68273db9704ab0e92518f2efd1c");
        public static BlueprintAbility Scare = BlueprintTools.GetBlueprint<BlueprintAbility>("08cb5f4c3b2695e44971bf5c45205df0");


        public static BlueprintAbility Fireball = BlueprintTools.GetBlueprint<BlueprintAbility>("2d81362af43aeac4387a3d4fced489c3");
        public static BlueprintAbility ControlledFireball = BlueprintTools.GetBlueprint<BlueprintAbility>("f72f8f03bf0136c4180cd1d70eb773a5");
        public static BlueprintAbility Snowball = BlueprintTools.GetBlueprint<BlueprintAbility>("9f10909f0be1f5141bf1c102041f93d9");
        public static BlueprintAbility MagicMissile = BlueprintTools.GetBlueprint<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");

        public static BlueprintAbility FireSnake = BlueprintTools.GetBlueprint<BlueprintAbility>("ebade19998e1f8542a1b55bd4da766b3");
        public static BlueprintAbility ConeOfCold = BlueprintTools.GetBlueprint<BlueprintAbility>("e7c530f8137630f4d9d7ee1aa7b1edc0");
        public static BlueprintAbility AcidicSpray = BlueprintTools.GetBlueprint<BlueprintAbility>("c543eef6d725b184ea8669dd09b3894c");

        public static BlueprintAbility ArrowOfLaw = BlueprintTools.GetBlueprint<BlueprintAbility>("dd2a5a6e76611c04e9eac6254fcf8c6b");
        public static BlueprintAbility OrdersWrath = BlueprintTools.GetBlueprint<BlueprintAbility>("1ec8f035d8329134d96cdc7b90fdc2e1");
        public static BlueprintAbility HolySmite = BlueprintTools.GetBlueprint<BlueprintAbility>("ad5ed5ea4ec52334a94e975a64dad336");
        public static BlueprintAbility BurningArc = BlueprintTools.GetBlueprint<BlueprintAbility>("eaac3d36e0336cb479209a6f65e25e7c");
        public static BlueprintAbility ScorchingRay = BlueprintTools.GetBlueprint<BlueprintAbility>("cdb106d53c65bbc4086183d54c3b97c7");

        public static BlueprintAbility DeathWard = BlueprintTools.GetBlueprint<BlueprintAbility>("0413915f355a38146bc6ad40cdf27b3f");
        public static BlueprintAbility HealMass = BlueprintTools.GetBlueprint<BlueprintAbility>("867524328b54f25488d371214eea0d90");

        public static BlueprintAbility InstantEnemy = BlueprintTools.GetBlueprint<BlueprintAbility>("42c78009dd5cb8e429b27c13d92152b7");
        public static BlueprintAbility FreebooterBaneAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("76f8f23f6502def4dbefedffdc4d4c43");

        //public static BlueprintAbility InstantEnemy = BlueprintTools.GetBlueprint<BlueprintAbility>("42c78009dd5cb8e429b27c13d92152b7");
        //public static BlueprintAbility InstantEnemy = BlueprintTools.GetBlueprint<BlueprintAbility>("42c78009dd5cb8e429b27c13d92152b7");

        public static BlueprintAbility MonsterTacticianSummonVId3 = BlueprintTools.GetBlueprint<BlueprintAbility>("4b448928d02cdaa4c83a0254b149c7cd");

        public static BlueprintAbility Vanish = BlueprintTools.GetBlueprint<BlueprintAbility>("f001c73999fb5a543a199f890108d936");
        public static BlueprintAbility MirrorImage = BlueprintTools.GetBlueprint<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
        public static BlueprintAbility Displacement = BlueprintTools.GetBlueprint<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
        public static BlueprintAbility ShadowConjuration = BlueprintTools.GetBlueprint<BlueprintAbility>("caac251ca7601324bbe000372a0a1005");
        public static BlueprintAbility ShadowEvocation = BlueprintTools.GetBlueprint<BlueprintAbility>("237427308e48c3341b3d532b9d3a001f");
        public static BlueprintAbility PhantasmalPutrefication = BlueprintTools.GetBlueprint<BlueprintAbility>("1f2e6019ece86d64baa5effa15e81ecc");
        public static BlueprintAbility ShadowConjurationGreater = BlueprintTools.GetBlueprint<BlueprintAbility>("08255ea4cdd812341af93f9cd113acb9");
        public static BlueprintAbility ShadowEvocationGreater = BlueprintTools.GetBlueprint<BlueprintAbility>("3c4a2d4181482e84d9cd752ef8edc3b6");
        public static BlueprintAbility Weird = BlueprintTools.GetBlueprint<BlueprintAbility>("870af83be6572594d84d276d7fc583e0");
    }
}
