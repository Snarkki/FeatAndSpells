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
using HarmonyLib;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Utility;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using static Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Facts;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.EntitySystem.Stats;
using FeatAndSpells.Components;

namespace FeatAndSpells.Abilities {
    public class MythicAbilities {

        public static void MythicHandler() {
            //CreateLimitlessWitchHexes();
            //CreateLimitlessSmite();
            //PatchWanderingHex();
            //PatchUnstoppable();
            //PatchJudgementAura();
            //PatchLimitlessDemonRage();
            //PatchBoundlessHealing();
            //CreateSwiftHex();
            //CreateSwiftHuntersBond();
        }
        public static BlueprintFeatureSelection mythictalents = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("ba0e5a900b775be4a99702f1ed08914d");
        public static BlueprintFeatureSelection mythicextratalents = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("8a6a511c55e67d04db328cc49aaad2b8");


        public static void CreateLimitlessWitchHexes() {
            var LimitlessWitchHexes = Helpers.CreateBlueprint<BlueprintFeature>(FASContext, "LimitlessWitchHexes", bp => {
                bp.SetName(FASContext, "Limitless Witch Hexes");
                bp.SetDescription(FASContext, "Your curse knows no bounds.\nBenefit: You can use your hexes with no time restriction.");
                bp.Groups = new FeatureGroup[] { FeatureGroup.MythicAbility };
            });
            // cooldown based
            foreach (var ability in Blueprints.Hexes.HexList) {

                var check = ability.GetComponent<AbilityTargetHasFact>();
                if (check == null)
                    continue;

                var checknew = new AbilityTargetHasFactExcept();
                checknew.m_CheckedFacts = check.m_CheckedFacts;
                checknew.Inverted = check.Inverted;
                checknew.PassIfFact = LimitlessWitchHexes.ToReference<BlueprintUnitFactReference>();

                ability.RemoveComponent(check);
                ability.AddComponent(checknew);
            }
            // resource based
            var WitchHexAuraOfPurityActivatableAbility = BlueprintTools.GetBlueprint<BlueprintActivatableAbility>("298edc3bc21e61044bba25f4e767cb8b");
            var WitchHexLifeGiverAbility = BlueprintTools.GetBlueprint<BlueprintAbility>("cedc4959ab311d548881844eecddf57a");
            WitchHexAuraOfPurityActivatableAbility.GetComponent<ActivatableAbilityResourceLogic>().m_FreeBlueprint = LimitlessWitchHexes.ToReference<BlueprintUnitFactReference>(); // WitchHexAuraOfPurityActivatableAbility
            WitchHexLifeGiverAbility.GetComponent<AbilityResourceLogic>().ResourceCostDecreasingFacts.Add(LimitlessWitchHexes.ToReference<BlueprintUnitFactReference>());

            mythictalents.m_AllFeatures = mythictalents.m_AllFeatures.AppendToArray(LimitlessWitchHexes.ToReference<BlueprintFeatureReference>());
            mythicextratalents.m_AllFeatures = mythictalents.m_AllFeatures.AppendToArray(LimitlessWitchHexes.ToReference<BlueprintFeatureReference>());
        }

        public static void CreateLimitlessSmite() {
            var smite_evil = BlueprintTools.GetBlueprint<BlueprintAbility>("7bb9eb2042e67bf489ccd1374423cdec");
            var smite_chaos = BlueprintTools.GetBlueprint<BlueprintAbility>("a4df3ed7ef5aa9148a69e8364ad359c5");
            var mark_of_justice = BlueprintTools.GetBlueprint<BlueprintAbility>("7a4f0c48829952e47bb1fd1e4e9da83a");
            var abundant_smite = BlueprintTools.GetBlueprint<BlueprintFeature>("7e5b63faeca24474db0bfd019167dda4");
            var abundant_smitechaos = BlueprintTools.GetBlueprint<BlueprintFeature>("4cdc155e26204491ba4d193646cb4443");

            var LimitlessSmite = Helpers.CreateBlueprint<BlueprintFeature>(FASContext, "LimitlessSmite", bp => {
                bp.SetName(FASContext, "Limitless Smite");
                bp.SetDescription(FASContext, "Benefit: You no longer have a limited amount of Smite per day.");
                bp.m_Icon = smite_evil.Icon;
                bp.Groups = new FeatureGroup[] { FeatureGroup.MythicAbility };
                bp.AddPrerequisiteFeature(abundant_smite, GroupType.Any);
                bp.AddPrerequisiteFeature(abundant_smitechaos, GroupType.Any);
            });

            smite_evil.GetComponent<AbilityResourceLogic>().ResourceCostDecreasingFacts.Add(LimitlessSmite.ToReference<BlueprintUnitFactReference>());
            smite_chaos.GetComponent<AbilityResourceLogic>().ResourceCostDecreasingFacts.Add(LimitlessSmite.ToReference<BlueprintUnitFactReference>());
            mark_of_justice.GetComponent<AbilityResourceLogic>().ResourceCostDecreasingFacts.Add(LimitlessSmite.ToReference<BlueprintUnitFactReference>());

            mythictalents.m_AllFeatures = mythictalents.m_AllFeatures.AppendToArray(LimitlessSmite.ToReference<BlueprintFeatureReference>());
            mythicextratalents.m_AllFeatures = mythictalents.m_AllFeatures.AppendToArray(LimitlessSmite.ToReference<BlueprintFeatureReference>());
        }

        public static void CreateSwiftHuntersBond() {
            var hunterfeat = BlueprintTools.GetBlueprint<BlueprintFeature>("6dddf5ba2291f41498df2df7f8fa2b35"); //HuntersBondFeature
            var huntersab = BlueprintTools.GetBlueprint<BlueprintAbility>("cd80ea8a7a07a9d4cb1a54e67a9390a5"); //HuntersBondAbility

            //huntersab.Get().AvailableMetamagic |= Metamagic.Quicken;
            var SwiftHuntersBond = Helpers.CreateBlueprint<BlueprintFeature>(FASContext, "SwiftHuntersBond", bp => {
                bp.SetName(FASContext, "Swift Hunters Bond");
                bp.SetDescription(FASContext, "Benefit: You can use Hunter's Bond as a swift action.");
                bp.m_Icon = hunterfeat.Icon;
                bp.Groups = new FeatureGroup[] { FeatureGroup.MythicAbility };
                bp.AddPrerequisiteFeature(hunterfeat, GroupType.Any);
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.Any;
                    c.Metamagic = Metamagic.Quicken;
                    c.Abilities = new List<BlueprintAbilityReference>() { huntersab.ToReference<BlueprintAbilityReference>() };
                });
                bp.AddPrerequisiteFeature(hunterfeat, GroupType.Any);
            });

            mythictalents.m_AllFeatures = mythictalents.m_AllFeatures.AppendToArray(SwiftHuntersBond.ToReference<BlueprintFeatureReference>());
            mythicextratalents.m_AllFeatures = mythictalents.m_AllFeatures.AppendToArray(SwiftHuntersBond.ToReference<BlueprintFeatureReference>());

        }

        public static void CreateSwiftHex() {
            var witch_selection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("9846043cf51251a4897728ed6e24e76f"); //WitchHexSelection
            var shaman_selection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("4223fe18c75d4d14787af196a04e14e7"); //ShamanHexSelection
            var trickster_selection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("290bbcc3c3bb92144b853fd8fb8ff452"); //SylvanTricksterTalentSelection
            var grant_hex = BlueprintTools.GetBlueprint<BlueprintFeature>("d24c2467804ce0e4497d9978bafec1f9"); //WitchGrandHex

            var abilities = new List<BlueprintAbilityReference>();

            foreach (var ability in Blueprints.Hexes.EvilEyeList) {
                abilities.Add(ability.ToReference<BlueprintAbilityReference>());
            }


            var MythicSwiftHex = Helpers.CreateBlueprint<BlueprintFeature>(FASContext, "MythicSwiftHex", bp => {
                bp.SetName(FASContext, "Cursing Gaze");
                bp.SetDescription(FASContext, "A mere glimpse is enough to curse your enemies. You may use evil eye, as a swift action.");
                bp.m_Icon = grant_hex.Icon;
                bp.Groups = new FeatureGroup[] { FeatureGroup.MythicAbility };
                bp.AddPrerequisiteFeature(witch_selection, GroupType.Any);
                bp.AddPrerequisiteFeature(shaman_selection, GroupType.Any);
                bp.AddPrerequisiteFeature(trickster_selection, GroupType.Any);
                bp.AddComponent<AutoMetamagic>(c => {
                    c.m_AllowedAbilities = AutoMetamagic.AllowedType.Any;
                    c.Metamagic = Metamagic.Quicken;
                    c.Abilities = abilities;
                });
            });

            mythictalents.m_AllFeatures = mythictalents.m_AllFeatures.AppendToArray(MythicSwiftHex.ToReference<BlueprintFeatureReference>());
            mythicextratalents.m_AllFeatures = mythictalents.m_AllFeatures.AppendToArray(MythicSwiftHex.ToReference<BlueprintFeatureReference>());
        }


        public static void PatchLimitlessDemonRage() {
            var rage = BlueprintTools.GetBlueprint<BlueprintActivatableAbility>("0999f99d6157e5c4888f4cfe2d1ce9d6"); //DemonRageAbility
            var rage2 = BlueprintTools.GetBlueprint<BlueprintAbility>("260daa5144194a8ab5117ff568b680f5"); //DemonRageActivateAbility
            var limitless = BlueprintTools.GetBlueprint<BlueprintUnitFact>("5cb58e6e406525342842a073fb70d068"); //LimitlessRage

            rage.GetComponent<ActivatableAbilityResourceLogic>().m_FreeBlueprint = limitless.ToReference<BlueprintUnitFactReference>();
            rage2.GetComponent<AbilityResourceLogic>().ResourceCostDecreasingFacts.Add(limitless.ToReference<BlueprintUnitFactReference>());
        }

        public static void PatchUnstoppable() {
            var unstoppable = BlueprintTools.GetBlueprint<BlueprintFeature>("74afc3465db56924c9618a42d84efab8"); //Unstoppable
            var dominate = BlueprintTools.GetBlueprint<BlueprintBuff>("c0f4e1c24c9cd334ca988ed1bd9d201f"); //DominatePersonBuff
            var entangle = BlueprintTools.GetBlueprint<BlueprintBuff>("f7f6330726121cf4b90a6086b05d2e38"); //EntangleBuff

            unstoppable.GetComponents<BuffSubstitutionOnApply>().FirstOrDefault(f => f.SpellDescriptor.HasAnyFlag(SpellDescriptor.Paralysis))
                .SpellDescriptor |= SpellDescriptor.Stun | SpellDescriptor.Daze | SpellDescriptor.Confusion | SpellDescriptor.Petrified;

            //MindAffecting or Compulsion or DominatePersonBuff
            unstoppable.AddComponents(new BuffSubstitutionOnApply() { m_GainedFact = dominate.ToReference<BlueprintBuffReference>(),
                                                                      m_SubstituteBuff = entangle.ToReference<BlueprintBuffReference>()
            });
        }

        public static void PatchBoundlessHealing() {
            var feat = BlueprintTools.GetBlueprint<BlueprintFeature>("c8bbb330aaecaf54dbc7570200653f8c"); //BoundlessHealing


            feat.AddComponents(new AddKnownSpellsAnyClass() {
                Spells = new BlueprintAbilityReference[] {
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("5590652e1c2225c4ca30c4a699ab3649"), //1: CureLightWoundsCast
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("6b90c773a6543dc49b2505858ce33db5"), //2: CureModerateWoundsCast
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("3361c5df793b4c8448756146a88026ad"), //3: CureSeriousWoundsCast
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("41c9016596fe1de4faf67425ed691203"), //4: CureCriticalWoundsCast
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("5d3d689392e4ff740a761ef346815074"), //5: CureLightWoundsMass
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("571221cc141bc21449ae96b3944652aa"), //6: CureModerateWoundsMass
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("0cea35de4d553cc439ae80b3a8724397"), //7: CureSeriousWoundsMass
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("1f173a16120359e41a20fc75bb53d449"), //8: CureCriticalWoundsMass
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("5da172c4c89f9eb4cbb614f3a67357d3"), //6: HealCast
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("867524328b54f25488d371214eea0d90"), //9: HealMass
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("d5847cad0b0e54c4d82d6c59a3cda6b0"), //5: BreathOfLifeCast
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("e84fc922ccf952943b5240293669b171"), //2: RestorationLesser
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("f2115ac1148256b4ba20788f7e966830"), //4: Restoration
                    BlueprintTools.GetBlueprintReference<BlueprintAbilityReference>("fafd77c6bfa85c04ba31fdc1c962c914"), //7: RestorationGreater
                },
                Levels = new int[] {
                    1, //1: CureLightWoundsCast
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    6, //6: HealCast
                    9, //9: HealMass
                    5, //5: BreathOfLifeCast
                    2, //2: RestorationLesser
                    4,
                    7,
                }
            });
        }

        public static void PatchWanderingHex() {
            var feat = BlueprintTools.GetBlueprint<BlueprintAbility>("b209beab784d93546b40a2fa2a09ffa8"); //WitchWanderingHexAbility
            feat.RemoveComponents<AbilityResourceLogic>();
        }

        public static void PatchJudgementAura() {
            var ability = BlueprintTools.GetBlueprint<BlueprintAbility>("faa50b5d67eb4745b7b1157629d5c304"); //JudgementAuraAbility
            var fact = BlueprintTools.GetBlueprintReference<BlueprintUnitFactReference>("4a6dc772c9a7fe742a65820007107f03"); //EverlastingJudgement

            ability.GetComponent<AbilityResourceLogic>().ResourceCostDecreasingFacts.Add(fact);
        }





    }
}

//public static void CreateLimitlessBombs() {
//    var bomb_resource = BlueprintGuid.Parse("1633025edc9d53f4691481b48248edd7");
//    var incense_resource = BlueprintGuid.Parse("d03d97aac38e798479b81dfa9eda55c6");
//    var bomb_prereq = Helper.ToRef<BlueprintFeatureReference>("54c57ce67fa1d9044b1b3edc459e05e2"); //AlchemistBombsFeature
//    var incense_prereq = Helper.ToRef<BlueprintFeatureReference>("7614401346b64a8409f7b8c367db488f"); //IncenseFogFeature

//    var limitless = Helper.CreateBlueprintFeature(
//        "LimitlessBombs",
//        "Limitless Alchemist's Creations",
//        "You learn how to create a philosopher’s stone that turns everything into chemicals.\nBenefit: You no longer have a limited amount of Bombs or Incenses per day.",
//        group: FeatureGroup.MythicAbility,
//        icon: Helper.StealIcon("5fa0111ac60ed194db82d3110a9d0352")
//        ).SetComponents(
//        Helper.CreatePrerequisiteFeature(bomb_prereq, true),
//        Helper.CreatePrerequisiteFeature(incense_prereq, true)
//        );

//    SetResourceDecreasing(bomb_resource, limitless.ToRef2());
//    SetResourceDecreasing(incense_resource, limitless.ToRef2());

//    Helper.AddMythicTalent(limitless);
//}
//public static void CreateLimitlessArcanePool() {
//    var arcane_resource = BlueprintGuid.Parse("effc3e386331f864e9e06d19dc218b37");
//    var arcane_resourceEldritch = BlueprintGuid.Parse("17b6158d363e4844fa073483eb2655f8");
//    var abundant_arcane = Helper.ToRef<BlueprintFeatureReference>("8acebba92ada26043873cae5b92cef7b"); //AbundantArcanePool

//    var limitless = Helper.CreateBlueprintFeature(
//        "LimitlessArcanePool",
//        "Limitless Arcane Pool",
//        "Benefit: You can use your arcana without using your arcane pool. You still need to spend arcane points for spell recall.",
//        group: FeatureGroup.MythicAbility,
//        icon: abundant_arcane.Get().Icon
//        ).SetComponents(
//        Helper.CreatePrerequisiteFeature(abundant_arcane)
//        );

//    SetResourceDecreasing(arcane_resource, limitless.ToRef2(), true);
//    SetResourceDecreasing(arcane_resourceEldritch, limitless.ToRef2(), true);

//    Helper.AddMythicTalent(limitless);
//}

//public static void CreateLimitlessArcaneReservoir() {
//    var arcane_resource = BlueprintGuid.Parse("cac948cbbe79b55459459dd6a8fe44ce");
//    var arcane_prereq = Helper.ToRef<BlueprintFeatureReference>("55db1859bd72fd04f9bd3fe1f10e4cbb"); //ArcanistArcaneReservoirFeature
//    var enforcerer_prereq = Helper.ToRef<BlueprintFeatureReference>("9d1e2212594cf47438fff2fa3477b954"); //ArcaneEnforcerArcaneReservoirFeature

//    var limitless = Helper.CreateBlueprintFeature(
//        "LimitlessArcaneReservoir",
//        "Limitless Arcane Reservoir",
//        "Benefit: You can use your arcane exploits without using your arcane reservoir. This does not apply to Magical Supremacy.",
//        group: FeatureGroup.MythicAbility,
//        icon: Helper.StealIcon("42f96fc8d6c80784194262e51b0a1d25")
//        ).SetComponents(
//        Helper.CreatePrerequisiteFeature(arcane_prereq, true),
//        Helper.CreatePrerequisiteFeature(enforcerer_prereq, true)
//        );

//    SetResourceDecreasing(arcane_resource, limitless.ToRef2(), true);

//    Helper.AddMythicTalent(limitless);
//}

//public static void CreateLimitlessKi() {
//    var ki_resource = BlueprintGuid.Parse("9d9c90a9a1f52d04799294bf91c80a82");
//    var scaled_resource = BlueprintGuid.Parse("7d002c1025fbfe2458f1509bf7a89ce1");
//    var abundant_ki = Helper.ToRef<BlueprintFeatureReference>("e8752f9126d986748b10d0bdac693264"); //AbundantKiPool

//    var limitless = Helper.CreateBlueprintFeature(
//        "LimitlessKi",
//        "Limitless Ki",
//        "Your body and mind are in perfect equilibrium.\nBenefit: Your abilities cost one less ki.",
//        group: FeatureGroup.MythicAbility,
//        icon: abundant_ki.Get().Icon
//        ).SetComponents(
//        Helper.CreatePrerequisiteFeature(abundant_ki)
//        );

//    SetResourceDecreasing(ki_resource, limitless.ToRef2());
//    SetResourceDecreasing(scaled_resource, limitless.ToRef2());

//    Helper.AddMythicTalent(limitless);
//}

//public static void CreateLimitlessDomain() {
//    var limitless = Helper.CreateBlueprintFeature(
//        "LimitlessDomainPowers",
//        "Limitless Domain Powers",
//        "You are chosen by your deity.\nBenefit: You can use the abilities of your domains at will.",
//        group: FeatureGroup.MythicAbility
//        );

//    foreach (var ability in Resource.Cache.Ability) {
//        var logic = ability.GetComponent<AbilityResourceLogic>();
//        if (logic == null)
//            continue;
//        if (logic.CostIsCustom)
//            continue;
//        if (!ability.name.Contains("Domain"))
//            continue;

//        logic.ResourceCostDecreasingFacts.Add(limitless.ToRef2());
//    }

//    foreach (var ability in Resource.Cache.Activatable) {
//        var logic = ability.GetComponent<ActivatableAbilityResourceLogic>();
//        if (logic == null)
//            continue;
//        if (!ability.name.Contains("Domain"))
//            continue;

//        if (logic.m_FreeBlueprint != null && !logic.m_FreeBlueprint.IsEmpty())
//            Main.Print($"ERROR: {ability.name} has already a FreeBlueprint");
//        logic.m_FreeBlueprint = limitless.ToRef2();
//    }

//    Helper.AddMythicTalent(limitless);
//}
//public static void CreateLimitlessShaman() {
//    var shaman_resource = BlueprintGuid.Parse("ecf700928d1e3a647a92c095f5de1999"); //ShamanWeaponPoolResourse
//    var shaman_prereq = Helper.ToRef<BlueprintFeatureReference>("ef7e19661304e124f95c49637f931429"); //ShamanWeaponPoolFeature

//    var limitless = Helper.CreateBlueprintFeature(
//        "LimitlessShamanWeapon",
//        "Limitless Spirit Weapon",
//        "Your soul fused with a spirit.\nBenefit: You no longer have a limited amount of Spirit Weapon uses per day.",
//        group: FeatureGroup.MythicAbility,
//        icon: Helper.StealIcon("0e5ec4d781678234f83118df41fd27c3")
//        ).SetComponents(
//        Helper.CreatePrerequisiteFeature(shaman_prereq, true)
//        );

//    SetResourceDecreasing(shaman_resource, limitless.ToRef2());

//    Helper.AddMythicTalent(limitless);

//    // TableTopTweaks
//    var ttt_feature = Helper.Get<BlueprintFeature>("22731cf358814278b18e6ab4e741e988"); //WarriorSpiritFeature
//    var ttt_ability = Helper.Get<BlueprintAbility>("55929e3504f84f5095dd60ad0fbb1c29"); //WarriorSpiritToggleAbility
//    if (ttt_feature != null && ttt_ability != null) {
//        limitless.AddComponents(Helper.CreatePrerequisiteFeature(ttt_feature.ToRef(), true));
//        ttt_ability.GetComponent<AbilityResourceLogic>()?.ResourceCostDecreasingFacts?.Add(limitless.ToRef2());
//    }
//}
//public static void CreateLimitlessWarpriest() {
//    var weapon_resource = BlueprintGuid.Parse("cc700ef06c6fec449ab085cbcd74709c"); //SacredWeaponEnchantResource
//    var armor_resource = BlueprintGuid.Parse("04af200173fafb94381b33e8fe3146e7"); //SacredArmorEnchantResource
//    var warpriest_prereq = Helper.ToRef<BlueprintCharacterClassReference>("30b5e47d47a0e37438cc5a80c96cfb99"); //WarpriestClass.

//    var limitless = Helper.CreateBlueprintFeature(
//        "LimitlessWarpriest",
//        "Limitless Sacred Warpriest",
//        "You are chosen by your deity.\nBenefit: You no longer have a limited amount of Sacred Weapon and Sacred Armor rounds per day.",
//        group: FeatureGroup.MythicAbility,
//        icon: Helper.StealIcon("0e5ec4d781678234f83118df41fd27c3")
//        ).SetComponents(
//        Helper.CreatePrerequisiteClassLevel(warpriest_prereq, 1)
//        );

//    SetResourceDecreasing(weapon_resource, limitless.ToRef2());
//    SetResourceDecreasing(armor_resource, limitless.ToRef2());

//    Helper.AddMythicTalent(limitless);
//}

//public static void CreateKineticMastery() {
//    var kineticist_class = Helper.ToRef<BlueprintCharacterClassReference>("42a455d9ec1ad924d889272429eb8391");

//    var kinetic_mastery = Helper.CreateBlueprintFeature(
//        "KineticMastery",
//        "Kinetic Mastery",
//        "You mastered the elements. Benefit: You add your mythic rank to attack rolls of physical kinetic blasts and half your mythic rank to attack rolls of energy kinetic blasts.",
//        group: FeatureGroup.MythicFeat
//        ).SetComponents(
//        Helper.CreatePrerequisiteClassLevel(kineticist_class, 1),
//        new KineticMastery()
//        );

//    Helper.AddMythicFeat(kinetic_mastery);
//}