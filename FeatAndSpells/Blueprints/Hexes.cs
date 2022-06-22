
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

    // used by mythic abilities
    public class Hexes {




        /// <summary>
        ///  HEX LIST
        /// </summary>
        public static BlueprintAbility ShamanHexAirBarrierAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("3e14f46a35228b946af0c1fe79870e54");
        public static BlueprintAbility ShamanHexAmelioratingBaseAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("2b35e887d852cb949a1d8e308efe8065");
        public static BlueprintAbility ShamanHexAmelioratingDazzleAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ff1cf8952b8551f4c9fbe32966f9a945");
        public static BlueprintAbility ShamanHexAmelioratingFatuguedAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("8bc94d17348204041ab8863d4f841a99");
        public static BlueprintAbility ShamanHexAmelioratingShakenAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5e02868509087b248a2c6daad16e9aef");
        public static BlueprintAbility ShamanHexAmelioratingSickenedAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("137c8f8182413dc4e80abe2a9d0313b5");
        public static BlueprintAbility ShamanHexBattleWardAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("29b3a96956eaf8d4cb42205ee233a158");
        public static BlueprintAbility ShamanHexBeckoningChillAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5617c38bde7d56f4094b2fc714399566");
        public static BlueprintAbility ShamanHexBoneLockAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("98293e0bfb86f4f418dcfbe7bf7f8fc2");
        public static BlueprintAbility ShamanHexBoneWardAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1d33fcbc7f5175446bb9577e0f7811b3");
        public static BlueprintAbility ShamanHexChantAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("6cd07c80aabf2b248a11921090de9c17");
        public static BlueprintAbility ShamanHexDraconicResilienceAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("9802c5950219c6c41a9293076e221d12");
        public static BlueprintAbility ShamanHexEntanglingCurseAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("dcabd85e723bac941bc5807a6a953e89");
        public static BlueprintAbility ShamanHexEvilEyeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("66a62322b44f25c418472df9a77f5b3a");
        public static BlueprintAbility ShamanHexEvilEyeACAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e66d3b4d6669f9f4ea79056d4a525098");
        public static BlueprintAbility ShamanHexEvilEyeAttackAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("3e427e1fb78631c4b9f17e39bc19c96f");
        public static BlueprintAbility ShamanHexEvilEyeSavesAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c2fa8c5d307efbb41a15d55373f414e2");
        public static BlueprintAbility ShamanHexFearfulGazeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a824b1806059bd54db0b5b0093472f21");
        public static BlueprintAbility ShamanHexFireNimbusAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("487981678b77e0b4aa5ff0328f50ecb2");
        public static BlueprintAbility ShamanHexFlameCurseAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ba28f4a77f3741c4187b283d42e22554");
        public static BlueprintAbility ShamanHexFortuneAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c91f9e996c0af364dae41569cb9586e7");
        public static BlueprintAbility ShamanHexFuryAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("313c37a6410ac514b835490cf768794f");
        public static BlueprintAbility ShamanHexHamperingHexAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("8e7f48a657b6380429dc1fc685096288");
        public static BlueprintAbility ShamanHexHealingAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("3d4c6361e60fa664db01d5709baaa812");
        public static BlueprintAbility ShamanHexHypothermiaAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4de66387a2c36624385930b0f5e596af");
        public static BlueprintAbility ShamanHexMetalCurseAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ff2f3177d34778b41b5bfe0b140cba42");
        public static BlueprintAbility ShamanHexMisfortuneAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("8b9ffc4cd53b82f44ab7c0ddca85877d");
        public static BlueprintAbility ShamanHexProtectiveLuckAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e3eddc31b2430b7408c62f313efea4bc");
        public static BlueprintAbility ShamanHexSlumberAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d7767bd68ca218c4cb99e35b1cc50d8c");
        public static BlueprintAbility ShamanHexWardAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("07e1c038726e0824eabaa39e6038a854");
        public static BlueprintAbility ShamanHexWardOfFlamesAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e80c565458d9c0c4ea1323dc8cf122d9");
        public static BlueprintAbility ShamanHexWindWardAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1b1e0ae5916e6564ba3f0e2ab4fc403a");
        public static BlueprintAbility ShamanWanderingHexAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e7be24dd1cf591d4baecd9578705513d");
        public static BlueprintAbility ShamanWanderingHexAbility2 = BlueprintTools.GetBlueprint<BlueprintAbility>("1c06611ab264115479d16c0ff3ab0446");
        public static BlueprintAbility WitchHexAgonyAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("0d38e470e350ce34f869c20002d45763");
        public static BlueprintAbility WitchHexAmelioratingBaseAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("48f55c7834a2fe845928337f091a0932");
        public static BlueprintAbility WitchHexAmelioratingDazzleAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("c9097a1d0685f2f468ab63c1138815ad");
        public static BlueprintAbility WitchHexAmelioratingFatuguedAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("b1505c6512a0f2c4581dfa6af14e9d5c");
        public static BlueprintAbility WitchHexAmelioratingShakenAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("43738e1ea3c328549bcdd81883841e05");
        public static BlueprintAbility WitchHexAmelioratingSickenedAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e98cf086294d6134bb76d35e090cb059");
        public static BlueprintAbility WitchHexAnimalServantAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4a511e1dfeec46c4b867bf61b15eae2b");
        public static BlueprintAbility WitchHexAnimalSkinAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("3cae80cecdc2fb84b86587032132d48f");
        public static BlueprintAbility WitchHexBeastsGiftAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("b5816eb8a1c295b42b1edb0b9f48dfd8");
        public static BlueprintAbility WitchHexBeastsGiftBiteAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("fcaaf1f25440a8f40ae424c7708e9a0f");
        public static BlueprintAbility WitchHexBeastsGiftClawAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("3108e18055b46b84f8a57898ad5ad075");
        public static BlueprintAbility WitchHexCackleAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("4bd01292a9bc4304f861a6a07f03b855");
        public static BlueprintAbility WitchHexDeathCurseAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d560ab2a1b0613649833a0d92d6cfc6b");
        public static BlueprintAbility WitchHexDeliciousFrightAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e7489733ac7ccca40917d9364b406adb");
        public static BlueprintAbility WitchHexEvilEyeAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("d25c72a92dd8d38449a6a371ef36413e");
        public static BlueprintAbility WitchHexEvilEyeACAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("899b08dfc31868e4cb2c6287df9d355c");
        public static BlueprintAbility WitchHexEvilEyeAttackAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("954650e8a7542e642819716bb78bee86");
        public static BlueprintAbility WitchHexEvilEyeSavesAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ba52aed3017521a4abafcbae4ee06d10");
        public static BlueprintAbility WitchHexFortuneAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("eaf7077a8ff35644883df6d4f7b2084c");
        public static BlueprintAbility WitchHexHealingAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("ed4fbfcdb0f5dcb41b76d27ed00701af");
        public static BlueprintAbility WitchHexHoarfrostAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("7244a24f0c186ce4b8a89fd26feded50");
        public static BlueprintAbility WitchHexLayToRestAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1bb5466b9bfcb5e47b9f667dad5784f9");
        public static BlueprintAbility WitchHexLifeGiverAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("cedc4959ab311d548881844eecddf57a");
        public static BlueprintAbility WitchHexMajorAmelioratingBaseAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5fa471f18a914f743b1200b7520c215d");
        public static BlueprintAbility WitchHexMajorAmelioratingBlindedAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e946e3fdc42ea65408daee0f029b4100");
        public static BlueprintAbility WitchHexMajorAmelioratingCurseAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("0e8f3d24a2cea644e91273f6c551152d");
        public static BlueprintAbility WitchHexMajorAmelioratingDiseaseAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("05bba992bea833349a246fd47042748c");
        public static BlueprintAbility WitchHexMajorAmelioratingPoisonAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("1411baa7c0e58f547b76b6b13e5443f3");
        public static BlueprintAbility WitchHexMajorHealingAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("3408c351753aa9049af25af31ebef624");
        public static BlueprintAbility WitchHexMisfortuneAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("46cf5c995494e784c8d9a1696f9c61a7");
        public static BlueprintAbility WitchHexProtectiveLuckAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("e7ecd11651b4df34897f33271a8d1cfc");
        public static BlueprintAbility WitchHexRegenerativeSinewAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("40d201c6fbbb46e46a63dec8508de65a");
        public static BlueprintAbility WitchHexRegenerativeSinewFastHealingAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("b5c4c51cc9993b14b9dc0f0c54199d09");
        public static BlueprintAbility WitchHexRegenerativeSinewRestorationAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("0a6effb356101cc46aa0bed8c3ab6fd4");
        public static BlueprintAbility WitchHexRestlessSlumberAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("a69fb167bb41c6f45a19c81ed4e3c0d9");
        public static BlueprintAbility WitchHexSlumberAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("630ea63a63457ff4f9de059c578c930a");
        public static BlueprintAbility WitchHexVulnerabilityCurseAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("8f0eb58c2d6aeab4e8523ec85b4b2bc7");
        public static BlueprintAbility WitchHexWardAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("5adb5a0650f5b2049bab1afe822bd3bd");
        public static BlueprintAbility WitchWanderingHexAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("b209beab784d93546b40a2fa2a09ffa8");

        public static List<BlueprintAbility> EvilEyeList = new List<BlueprintAbility>() {
                    ShamanHexEvilEyeAbility,
                ShamanHexEvilEyeACAbility,
                ShamanHexEvilEyeAttackAbility,
                ShamanHexEvilEyeSavesAbility,
                WitchHexEvilEyeAbility,
                WitchHexEvilEyeACAbility,
                WitchHexEvilEyeAttackAbility,
                WitchHexEvilEyeSavesAbility,
        };




        public static List<BlueprintAbility> HexList = new List<BlueprintAbility>() {
                ShamanHexAirBarrierAbility,
                ShamanHexAmelioratingBaseAbility,
                ShamanHexAmelioratingDazzleAbility,
                ShamanHexAmelioratingFatuguedAbility,
                ShamanHexAmelioratingShakenAbility,
                ShamanHexAmelioratingSickenedAbility,
                ShamanHexBattleWardAbility,
                ShamanHexBeckoningChillAbility,
                ShamanHexBoneLockAbility,
                ShamanHexBoneWardAbility,
                ShamanHexChantAbility,
                ShamanHexDraconicResilienceAbility,
                ShamanHexEntanglingCurseAbility,
                ShamanHexEvilEyeAbility,
                ShamanHexEvilEyeACAbility,
                ShamanHexEvilEyeAttackAbility,
                ShamanHexEvilEyeSavesAbility,
                ShamanHexFearfulGazeAbility,
                ShamanHexFireNimbusAbility,
                ShamanHexFlameCurseAbility,
                ShamanHexFortuneAbility,
                ShamanHexFuryAbility,
                ShamanHexHamperingHexAbility,
                ShamanHexHealingAbility,
                ShamanHexHypothermiaAbility,
                ShamanHexMetalCurseAbility,
                ShamanHexMisfortuneAbility,
                ShamanHexProtectiveLuckAbility,
                ShamanHexSlumberAbility,
                ShamanHexWardAbility,
                ShamanHexWardOfFlamesAbility,
                ShamanHexWindWardAbility,
                ShamanWanderingHexAbility,
                ShamanWanderingHexAbility2,
                WitchHexAgonyAbility,
                WitchHexAmelioratingBaseAbility,
                WitchHexAmelioratingDazzleAbility,
                WitchHexAmelioratingFatuguedAbility,
                WitchHexAmelioratingShakenAbility,
                WitchHexAmelioratingSickenedAbility,
                WitchHexAnimalServantAbility,
                WitchHexAnimalSkinAbility,
                WitchHexBeastsGiftAbility,
                WitchHexBeastsGiftBiteAbility,
                WitchHexBeastsGiftClawAbility,
                WitchHexCackleAbility,
                WitchHexDeathCurseAbility,
                WitchHexDeliciousFrightAbility,
                WitchHexEvilEyeAbility,
                WitchHexEvilEyeACAbility,
                WitchHexEvilEyeAttackAbility,
                WitchHexEvilEyeSavesAbility,
                WitchHexFortuneAbility,
                WitchHexHealingAbility,
                WitchHexHoarfrostAbility,
                WitchHexLayToRestAbility,
                WitchHexLifeGiverAbility,
                WitchHexMajorAmelioratingBaseAbility,
                WitchHexMajorAmelioratingBlindedAbility,
                WitchHexMajorAmelioratingCurseAbility,
                WitchHexMajorAmelioratingDiseaseAbility,
                WitchHexMajorAmelioratingPoisonAbility,
                WitchHexMajorHealingAbility,
                WitchHexMisfortuneAbility,
                WitchHexProtectiveLuckAbility,
                WitchHexRegenerativeSinewAbility,
                WitchHexRegenerativeSinewFastHealingAbility,
                WitchHexRegenerativeSinewRestorationAbility,
                WitchHexRestlessSlumberAbility,
                WitchHexSlumberAbility,
                WitchHexVulnerabilityCurseAbility,
                WitchHexWardAbility,
                WitchWanderingHexAbility,

        };


    }
}
