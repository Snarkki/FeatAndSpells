
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
    public class Features {



        public static BlueprintFeature BackgroundAcolyte = BlueprintTools.GetBlueprint<BlueprintFeature>("7cc9014488caa5445a0c8b5e17b95466");
        public static BlueprintFeature BackgroundFarmhand = BlueprintTools.GetBlueprint<BlueprintFeature>("25b35e09665310d4faac3020f8198cfb");
        public static BlueprintFeature FauchardProfiency = BlueprintTools.GetBlueprint<BlueprintFeature>("b3f41cd91571ba54e8c3b0c5da4a7071");
        public static BlueprintFeature GlaiveProfiency = BlueprintTools.GetBlueprint<BlueprintFeature>("38d4d143e7f293249b72694ddb1e0a32");
        public static BlueprintFeature EstocProfiency = BlueprintTools.GetBlueprint<BlueprintFeature>("9dc64f0b9161a354c9471a631318e16c");
        public static BlueprintFeature BackgroundMartialDisciple = BlueprintTools.GetBlueprint<BlueprintFeature>("46d69a77c26701a459607c3f42e3664a");

        public static BlueprintFeature ArmorTraining = BlueprintTools.GetBlueprint<BlueprintFeature>("3c380607706f209499d951b29d3c44f3");
        public static BlueprintFeature ArmorMastery = BlueprintTools.GetBlueprint<BlueprintFeature>("ae177f17cfb45264291d4d7c2cb64671");
        public static BlueprintFeature TwoHandedFighterOverhandChop = BlueprintTools.GetBlueprint<BlueprintFeature>("ad4d4db6bb9c75a4a9bc59174b948769");
        public static BlueprintFeature TwoHandedFighterBackswing = BlueprintTools.GetBlueprint<BlueprintFeature>("1bbda0dab2f8dc540a647bdc5f0e59ce");
        public static BlueprintFeature TwoHandedFighterPiledriverFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("4723b31d7defd3d4e85395e2a3353b01");
        public static BlueprintFeature TwoHandedFighterGreaterPowerAttack = BlueprintTools.GetBlueprint<BlueprintFeature>("1b058a5ce1de415449a0f105c55b5f8b");
        public static BlueprintFeature TwoHandedFighterDevastatingBlowFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("687aa977ef0d3f849af8bee2f40930df");
        public static BlueprintFeature MutagenAbility = BlueprintTools.GetBlueprint<BlueprintFeature>("20b8ea6975554b347b43c6c5f5e65ca8");
        public static BlueprintFeature StudiousSquire = BlueprintTools.GetBlueprint<BlueprintFeature>("0c5065ffc67c4494cba9a14226714ae6");
        public static BlueprintFeature DivineGrace = BlueprintTools.GetBlueprint<BlueprintFeature>("8a5b5e272e5c34e41aa8b4facbb746d3");
        public static BlueprintFeature ArmigerArdentFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("fcffd9b743a98784fb9e293c22ee6aff");
        public static BlueprintFeature ThugFrighteningFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("5476fa6ac147a584aa886f1c232b8a87");
        public static BlueprintFeature AuraOfCourage = BlueprintTools.GetBlueprint<BlueprintFeature>("e45ab30f49215054e83b4ea12165409f");
        public static BlueprintFeature DivineHealth = BlueprintTools.GetBlueprint<BlueprintFeature>("41d1d0de15e672349bf4262a5acf06ce");
        public static BlueprintFeature AuraOfResolve = BlueprintTools.GetBlueprint<BlueprintFeature>("a28693b24cc412c478b8b85877f2dad2");
        public static BlueprintFeature AuraOfFaith = BlueprintTools.GetBlueprint<BlueprintFeature>("0437f4af5ad49b544bccf48aa7a51319");
        public static BlueprintFeature AuraOfRightouness = BlueprintTools.GetBlueprint<BlueprintFeature>("6bd4a71232014254e80726f3a3756962");
        public static BlueprintFeature FighterProfiencies = BlueprintTools.GetBlueprint<BlueprintFeature>("a23591cc77086494ba20880f87e73970");
        public static BlueprintFeature JudgementFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("981def910b98200499c0c8f85a78bde8");
        public static BlueprintFeature JudgementAdditionalFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("ee50875819478774b8968701893b52f5");
        public static BlueprintFeature SecondJudgementFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("33bf0404b70d65f42acac989ec5295b2");
        public static BlueprintFeature ThirdJudgementFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("490c7e92b22cc8a4bb4885a027b355db");
        public static BlueprintFeature TrueJudgementFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("f069b6557a2013544ac3636219186632");
        public static BlueprintFeature SneakAttackFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");
        public static BlueprintFeature ScaledFistAcBonus = BlueprintTools.GetBlueprint<BlueprintFeature>("3929bfd1beeeed243970c9fc0cf333f8");
        public static BlueprintFeature CannyDefense = BlueprintTools.GetBlueprint<BlueprintFeature>("f58e19256746efa419e640175d4e21ad");
        public static BlueprintFeature NatureWhisperAc = BlueprintTools.GetBlueprint<BlueprintFeature>("3d2cd23869f0d98458169b88738f3c32");
        public static BlueprintFeature DragonDiscipleConstitution = BlueprintTools.GetBlueprint<BlueprintFeature>("95de611796547be489e527fae84abbd6");
        public static BlueprintFeature DragonDiscipleStrength = BlueprintTools.GetBlueprint<BlueprintFeature>("270259f59c6ae6040babd5797feef2e2");
        public static BlueprintFeature DragonDiscipleNaturalArmor = BlueprintTools.GetBlueprint<BlueprintFeature>("aa4f9fd22a07ddb49982500deaed88f9");
        public static BlueprintFeature AdvancedArmorTraining1 = BlueprintTools.GetBlueprint<BlueprintFeature>("c1e7a208-b5a5-44f5-8071-af88a61ab842");
        public static BlueprintFeature AdvancedArmorTraining2 = BlueprintTools.GetBlueprint<BlueprintFeature>("7743a11f-8414-49b4-9352-24ac1de82edd");
        public static BlueprintFeature AdvancedArmorTraining3 = BlueprintTools.GetBlueprint<BlueprintFeature>("59cb9654-de71-4739-9b4d-6a384d32dd3a");
        public static BlueprintFeature AdvancedArmorTraining4 = BlueprintTools.GetBlueprint<BlueprintFeature>("67eb66ec-9875-4e22-8a6b-4633a10327fa");
        public static BlueprintFeature AdvancedArmorTraining5 = BlueprintTools.GetBlueprint<BlueprintFeature>("bae7b370-c4e8-427c-939a-30e7133501c7");
        public static BlueprintFeature AdvancedArmorTraining6 = BlueprintTools.GetBlueprint<BlueprintFeature>("80246fa3-dfe1-4dea-94ec-6e6640900083");
        public static BlueprintFeature AdvancedArmorTrainingSelection = BlueprintTools.GetBlueprint<BlueprintFeature>("5bf17c2a-e9ee-4615-b27c-993629ed9bc3");
        public static BlueprintFeature FighterWeaponTraining = BlueprintTools.GetBlueprint<BlueprintFeature>("b8cecf4e5e464ad41b79d5b42b76b399");
        public static BlueprintFeature FighterWeaponTrainingRankUp = BlueprintTools.GetBlueprint<BlueprintFeature>("5f3cc7b9a46b880448275763fe70c0b0");
        public static BlueprintFeature FighterArmorTraining = BlueprintTools.GetBlueprint<BlueprintFeature>("3c380607706f209499d951b29d3c44f3");
        public static BlueprintFeature SelectionMercy = BlueprintTools.GetBlueprint<BlueprintFeature>("02b187038a8dce545bb34bbfb346428d");
        public static BlueprintFeature ChannelEnergy = BlueprintTools.GetBlueprint<BlueprintFeature>("cb6d55dda5ab906459d18a435994a760");
        public static BlueprintFeature MarkOfJustice = BlueprintTools.GetBlueprint<BlueprintFeature>("9f13fdd044ccb8a439f27417481cb00e");
        public static BlueprintFeature ZenArcheryFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("379c0da9f384e7547a70c259445377f5");
        public static BlueprintFeature ZenArchery = BlueprintTools.GetBlueprint<BlueprintFeature>("379c0da9f384e7547a70c259445377f5");
        public static BlueprintFeature KiArrows = BlueprintTools.GetBlueprint<BlueprintFeature>("604a24b659bb69a4796ddb9fbf957504");
        public static BlueprintFeature KiArrowsFeatureLvl5 = BlueprintTools.GetBlueprint<BlueprintFeature>("2f15be4c783431347bd57847a05135f5");
        public static BlueprintFeature KiArrowsFeatureLvl8 = BlueprintTools.GetBlueprint<BlueprintFeature>("fe8f6067014cc7c4db0606c348aed049");
        public static BlueprintFeature KiArrowsFeatureLvl12 = BlueprintTools.GetBlueprint<BlueprintFeature>("fc3a51a9bfb99974d8731fffeaef65d1");
        public static BlueprintFeature KiArrowsFeatureLvl16 = BlueprintTools.GetBlueprint<BlueprintFeature>("1d1ea286cc98dd34a9266adfa9dd5ae1");
        public static BlueprintFeature KiArrowsFeatureLvl20 = BlueprintTools.GetBlueprint<BlueprintFeature>("d8a8d5cf1f915384f9d669c34252fd5c");
        public static BlueprintFeature HuntersBond = BlueprintTools.GetBlueprint<BlueprintFeature>("b705c5184a96a84428eeb35ae2517a14");
        public static BlueprintFeature FreeBootersBane = BlueprintTools.GetBlueprint<BlueprintFeature>("485fa71b077a0304f86915a7718678ad");
        public static BlueprintFeature KMBladeSense = BlueprintTools.GetBlueprint<BlueprintFeature>("112bf4c6943097942b24eadfa750215f");
        public static BlueprintFeature RangerProfiencys = BlueprintTools.GetBlueprint<BlueprintFeature>("c5e479367d07d62428f2fe92f39c0341");
        public static BlueprintFeature SneakAttack = BlueprintTools.GetBlueprint<BlueprintFeature>("9b9eac6709e1c084cb18c3a366e0ec87");
        public static BlueprintFeature ShamanWanderingSpiritFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("70e6075a72633ba49804ccb6203fb18c");
        public static BlueprintFeature ShamanWanderingHexFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("2674f98616188814fbba9f8fccf43564");
        public static BlueprintFeature ShamanWanderingHexFeature2 = BlueprintTools.GetBlueprint<BlueprintFeature>("f15d95a394e950a42b1d6afbb9f781d9");
        public static BlueprintFeature DebilitatingInjury = BlueprintTools.GetBlueprint<BlueprintFeature>("def114eb566dfca448e998969bf51586");
        public static BlueprintFeature PaladinProficiencies = BlueprintTools.GetBlueprint<BlueprintFeature>("b10ff88c03308b649b50c31611c2fefb");
        public static BlueprintFeature WeaponFinesse = BlueprintTools.GetBlueprint<BlueprintFeature>("90e54424d682d104ab36436bd527af09");
        public static BlueprintFeature WitchDoctorHeal = BlueprintTools.GetBlueprint<BlueprintFeature>("eb388d17f07e0b44d9f83ada0148cc69");
        public static BlueprintFeature WitchDoctorCOunterCurse = BlueprintTools.GetBlueprint<BlueprintFeature>("74ce117848b4ea641acf266d84ee1602");
        public static BlueprintFeature SlayerAdvance = BlueprintTools.GetBlueprint<BlueprintFeature>("758e04f4568ec3f4c8d1fd83aed06fb9");
        public static BlueprintFeature Quarry = BlueprintTools.GetBlueprint<BlueprintFeature>("385260ca07d5f1b4e907ba22a02944fc");
        public static BlueprintFeature SlayerAdvanceUpgrade = BlueprintTools.GetBlueprint<BlueprintFeature>("f4df3231977753d4ebd2ceb2ef5901ed");
        public static BlueprintFeature QuarryUpgrade = BlueprintTools.GetBlueprint<BlueprintFeature>("25e009b7e53f86141adee3a1213af5af");
        public static BlueprintFeature VitalStrikeFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("14a1fc1356df9f146900e1e42142fc9d");
        public static BlueprintFeature RowdyVitalDamage = BlueprintTools.GetBlueprint<BlueprintFeature>("6ce0dd0cd1ef43eda9e62cdf483e05c3");
        public static BlueprintFeature VitalStrikeFeatureImproved = BlueprintTools.GetBlueprint<BlueprintFeature>("52913092cd018da47845f36e6fbe240f");
        public static BlueprintFeature VitalStrikeFeatureGreater = BlueprintTools.GetBlueprint<BlueprintFeature>("e2d1fa11f6b095e4fb2fd1dcf5e36eb3");
        public static BlueprintFeature SurpriseSpells = BlueprintTools.GetBlueprint<BlueprintFeature>("de5cb97a702699841abd3fc66c69fbcf");
        public static BlueprintFeature PowerFulChange = BlueprintTools.GetBlueprint<BlueprintFeature>("5e01e267021bffe4e99ebee3fdc872d1");
        public static BlueprintFeature ShareTransmutation = BlueprintTools.GetBlueprint<BlueprintFeature>("c4ed8d1a90c93754eacea361653a7d56");
        public static BlueprintFeature TransmutationSupremacy = BlueprintTools.GetBlueprint<BlueprintFeature>("c94d764d2ce3cd14f892f7c00d9f3a70");
        public static BlueprintFeature ArcanistArcaneReservoir = BlueprintTools.GetBlueprint<BlueprintFeature>("55db1859bd72fd04f9bd3fe1f10e4cbb");
        public static BlueprintFeature ExploiterExploitSelection = BlueprintTools.GetBlueprint<BlueprintFeature>("2ba8a0040e0149e9ae9bfcb01a8ff01d");
        public static BlueprintFeature ArcaneBondSelection = BlueprintTools.GetBlueprint<BlueprintFeature>("03a1781486ba98043afddaabf6b7d8ff");
        public static BlueprintFeature SpecialistSchoolSelection = BlueprintTools.GetBlueprint<BlueprintFeature>("5f838049069f1ac4d804ce0862ab5110");
        public static BlueprintFeature WitchCantrips = BlueprintTools.GetBlueprint<BlueprintFeature>("c213af60aba83ed4993948dce6b947b8");
        public static BlueprintFeature StigmaWitchCantrips = BlueprintTools.GetBlueprint<BlueprintFeature>("d83becdd1ab644b995ae4aa96a493351");
        public static BlueprintFeature HexChannelFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("b40316f05d4772e4894688e6743602bd");
        public static BlueprintFeature HealingDomainGreaterFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("b9ea4eb16ded8b146868540e711f81c8");
        public static BlueprintFeature FurysFallFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("0fc1ed8532168f74a9441bd17ad59e66");
        public static BlueprintFeature BulwarkSturdyFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("e0c54f5ab4f9494e8fa1440dda771b5a");
        public static BlueprintFeature LightBardingFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("c62ba548b1a34b94b9802925b35737c2");

        public static BlueprintFeature PreciseShot = BlueprintTools.GetBlueprint<BlueprintFeature>("8f3d1e6b4be006f4d896081f2f889665");
        public static BlueprintFeature RapidShotFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("9c928dc570bb9e54a9649b3ebfe47a41");
        public static BlueprintFeature PointBlankShot = BlueprintTools.GetBlueprint<BlueprintFeature>("0da0c194d6e1d43419eb8d990b28e0ab");

        public static BlueprintFeature SlayerStudyTarget = BlueprintTools.GetBlueprint<BlueprintFeature>("09bdd9445ac38044389476689ae8d5a1");
        public static BlueprintFeature SlayerStudyTargetSwift = BlueprintTools.GetBlueprint<BlueprintFeature>("40d4f55a5ac0e4f469d67d36c0dfc40b");

        public static BlueprintFeature WeaponTrainingBows = BlueprintTools.GetBlueprint<BlueprintFeature>("e0401ecade57d4144978dbd714c4069f");
        public static BlueprintFeature WeaponTrainingThrown = BlueprintTools.GetBlueprint<BlueprintFeature>("0bbf10151dd1d8d4c8653d245e425453");

        public static BlueprintFeature ToughnessFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
        public static BlueprintFeature PointBlankFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("0da0c194d6e1d43419eb8d990b28e0ab");
        public static BlueprintFeature PointBlankMythicFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("b651baa5f6faba646b7e3082929dfaf5");
        public static BlueprintFeature PointBlankMasterLongbow = BlueprintTools.GetBlueprint<BlueprintFeature>("22baf0213c7382f4cbe5641d03a8e476");
        public static BlueprintFeature AbundantCasting = BlueprintTools.GetBlueprint<BlueprintFeature>("cf594fa8871332a4ba861c6002480ec2");
        public static BlueprintFeature CraneStyle = BlueprintTools.GetBlueprint<BlueprintFeature>("0c17102f650d9044290922b0fad9132f");
        public static BlueprintFeature DodgeFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");
        public static BlueprintFeature ImprovedPreciseShot = BlueprintTools.GetBlueprint<BlueprintFeature>("46f970a6b9b5d2346b10892673fe6e74");
        public static BlueprintFeature Manyshot = BlueprintTools.GetBlueprint<BlueprintFeature>("adf54af2a681792489826f7fd1b62889");
        public static BlueprintFeature ClusteredShots = BlueprintTools.GetBlueprint<BlueprintFeature>("f7de245bb20f12f47864c7cb8b1d1abb");
        public static BlueprintFeature ExtraChannelOracle = BlueprintTools.GetBlueprint<BlueprintFeature>("53da6bf487997e947960bd6c02be9adf");
        public static BlueprintFeature SpellPenetration = BlueprintTools.GetBlueprint<BlueprintFeature>("ee7dc126939e4d9438357fbd5980d459");
        public static BlueprintFeature GreaterSpellPenetration = BlueprintTools.GetBlueprint<BlueprintFeature>("1978c3f91cfbbc24b9c9b0d017f4beec");


        public static BlueprintFeature ScrollFocus = BlueprintTools.GetBlueprint<BlueprintFeature>("51245c2b92a5b4247acf754156798fea");
        public static BlueprintFeature ScrollSpecialization = BlueprintTools.GetBlueprint<BlueprintFeature>("3964f0389e60da944aaa2ffd227ae531");
        public static BlueprintFeature ScrollMasterry = BlueprintTools.GetBlueprint<BlueprintFeature>("f42f41dd022e73d4a95019bc03230014");


        public static BlueprintFeature BabauSneakAttackFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("e1cd1d7a6e6716245889ba222a2a831a");
        public static BlueprintFeature OracleChannelRevelation = BlueprintTools.GetBlueprint<BlueprintFeature>("ade57ae9bbe55c142a012c2453b3088c");
        public static BlueprintFeature OracleLifeMysteryFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("a5458a1c316d1f24e8d9770f4fc179fa");

        public static BlueprintFeature WitchPatronSpellLevel2 = BlueprintTools.GetBlueprint<BlueprintFeature>("6414624190cc33f4facc0db67374514b");
        public static BlueprintFeature WitchPatronSpellLevel9 = BlueprintTools.GetBlueprint<BlueprintFeature>("160d0bf31f229c8488f3a889d3f45b9a");
        public static BlueprintFeature RangedLegerdemainFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("d99bab42783d29f48870274fb1e85bc4");
        public static BlueprintFeature FullCasterFeature = BlueprintTools.GetBlueprint<BlueprintFeature>("9fc9813f569e2e5448ddc435abf774b3");

        public static BlueprintFeature TricksterAthleticsTier1Feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("b7de8e5e4d67faf4791866966afc0a43");
        public static BlueprintFeature TricksterAthleticsTier2Feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("198b6abf58a36404f8189787a082fa02");
        public static BlueprintFeature TricksterAthleticsTier3Feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("e45bf795c4f84c3b8a83c011f8580491");

        public static BlueprintFeature TricksterKnowledgeArcanaTier1Feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("c7bb946de7454df4380c489a8350ba38");
        public static BlueprintFeature TricksterKnowledgeArcanaTier2Feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("7bbd9f681440a294382b527a554e419d");
        public static BlueprintFeature TricksterKnowledgeArcanaTier3Feature = ResourcesLibrary.TryGetBlueprint<BlueprintFeature>("5e26c673173e423881e318d2f0ae84f0");
    }
}
