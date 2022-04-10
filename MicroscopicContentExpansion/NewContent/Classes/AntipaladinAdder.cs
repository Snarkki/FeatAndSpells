﻿using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Blueprints.Root;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;
using TabletopTweaks.Core.Utilities;
using static MicroscopicContentExpansion.Base.Main;
using MicroscopicContentExpansion.Base.NewContent.AntipaladinFeatures;

namespace MicroscopicContentExpansion.Base.NewContent.Antipaladin {
    class AntipaladinAdder {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch {
            static bool Initialized;

            static void Postfix() {
                if (Initialized) return;
                Initialized = true;
                MCEContext.Logger.LogHeader("Adding Antipaladin");

                //since class features use class level, first create semi-empty class
                CreateAntipaladin();

                SmiteGood.AddSmiteGood();
                UnholyResilience.AddUnholyResilience();
                TouchofCorruption.AddTouchofCorruption();                
                PlagueBringer.AddPlagueBringer();
                Cruelties.AddCruelties();
                AuraofCowardice.AddAuraOfCowardiceFeature();
                ChannelNegativeEnergy.AddChannelNegativeEnergy();
                AuraofDespair.AddAuraOfDespairFeature();

                UpdateAntipaladinProgression();
            }

            static void UpdateAntipaladinProgression() {

                var AntipaladinProgression = BlueprintTools.GetModBlueprint<BlueprintProgression>(MCEContext, "AntipaladinProgression");

                var SmiteGoodFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(MCEContext, "AntipaladinSmiteGoodFeature");
                var SmiteGoodAdditionalUse = BlueprintTools.GetModBlueprint<BlueprintFeature>(MCEContext, "AntipaladinSmiteGoodAdditionalUse");                
                var AntipaladinProficiencies = BlueprintTools.GetModBlueprint<BlueprintFeature>(MCEContext, "AntipaladinProficiencies");
                var UnholyResilience = BlueprintTools.GetModBlueprint<BlueprintFeature>(MCEContext, "AntipaladinUnholyResilience");

                var TouchOfCorruptionFeature = BlueprintTools.GetModBlueprint<BlueprintFeature>(MCEContext, "AntipaladinTouchOfCorruptionFeature");

                var AuraOfCowardice = BlueprintTools.GetModBlueprint<BlueprintFeature>(MCEContext, "AntipaladinAuraOfCowardiceFeature");
                                
                var PlagueBringer = BlueprintTools.GetModBlueprint<BlueprintFeature>(MCEContext, "AntipaladinPlagueBringer");
                var CrueltySelection = BlueprintTools.GetModBlueprint<BlueprintFeature>(MCEContext, "AntipaladinCrueltySelection");
                
                var ChannelNegativeEnergy = BlueprintTools.GetModBlueprint<BlueprintFeature>(MCEContext, "AntipaladinChannelNegativeEnergyFeature");

                var AuraOfDespair = BlueprintTools.GetModBlueprint<BlueprintFeature>(MCEContext, "AntipaladinAuraOfDespairFeature");



                AntipaladinProgression.LevelEntries = new LevelEntry[] {
                        Helpers.CreateLevelEntry(1, AntipaladinProficiencies, SmiteGoodFeature),
                        Helpers.CreateLevelEntry(2, UnholyResilience, TouchOfCorruptionFeature),
                        Helpers.CreateLevelEntry(3, AuraOfCowardice, PlagueBringer, CrueltySelection),
                        Helpers.CreateLevelEntry(4,  SmiteGoodAdditionalUse, ChannelNegativeEnergy),
                        Helpers.CreateLevelEntry(6,  CrueltySelection),
                        Helpers.CreateLevelEntry(7,  SmiteGoodAdditionalUse),
                        Helpers.CreateLevelEntry(8,  AuraOfDespair),
                        Helpers.CreateLevelEntry(9,  CrueltySelection),
                        Helpers.CreateLevelEntry(10,  SmiteGoodAdditionalUse),
                        Helpers.CreateLevelEntry(12,  CrueltySelection),
                        Helpers.CreateLevelEntry(13,  SmiteGoodAdditionalUse),
                        Helpers.CreateLevelEntry(15,  CrueltySelection),
                        Helpers.CreateLevelEntry(16,  SmiteGoodAdditionalUse),
                        Helpers.CreateLevelEntry(18,  CrueltySelection),
                        Helpers.CreateLevelEntry(19,  SmiteGoodAdditionalUse)
                };

                AntipaladinProgression.UIGroups = new UIGroup[] {
                        Helpers.CreateUIGroup(SmiteGoodFeature, SmiteGoodAdditionalUse),
                        Helpers.CreateUIGroup(CrueltySelection)
                };

                var AntipaladinClass = BlueprintTools.GetModBlueprint<BlueprintCharacterClass>(MCEContext, "AntipaladinClass");
                AntipaladinClass.m_SignatureAbilities = new BlueprintFeatureReference[1]
                {
                    SmiteGoodFeature.ToReference<BlueprintFeatureReference>()
                };
            }

            static void CreateAntipaladin() {
                var PaladinClassProficiencies = BlueprintTools.GetBlueprint<BlueprintFeature>("b10ff88c03308b649b50c31611c2fefb");

                var AntipaladinProficiencies = Helpers.CreateBlueprint<BlueprintFeature>(MCEContext, "AntipaladinProficiencies", bp => {
                    bp.SetName(Helpers.CreateString(MCEContext, $"AntipaladinProficiences.Name", "Antipaladin Proficiences"));
                    bp.SetDescription(Helpers.CreateString(MCEContext, $"AntipaladinProficiences.Description", "Antipaladins are " +
                        "proficient with all simple and {g|Encyclopedia:Weapon_Proficiency}martial weapons{/g}, with all types of " +
                        "armor (heavy, medium, and light), and with shields (except tower shields)."));
                    bp.AddComponent<AddFacts>(c => {
                        c.m_Facts = new BlueprintUnitFactReference[] {
                            BlueprintTools.GetBlueprintReference<BlueprintUnitFactReference>("6d3728d4e9c9898458fe5e9532951132"),
                            BlueprintTools.GetBlueprintReference<BlueprintUnitFactReference>("46f4fb320f35704488ba3d513397789d"),
                            BlueprintTools.GetBlueprintReference<BlueprintUnitFactReference>("1b0f68188dcc435429fb87a022239681"),
                            BlueprintTools.GetBlueprintReference<BlueprintUnitFactReference>("e70ecf1ed95ca2f40b754f1adb22bbdd"),
                            BlueprintTools.GetBlueprintReference<BlueprintUnitFactReference>("203992ef5b35c864390b4e4a1e200629"),
                            BlueprintTools.GetBlueprintReference<BlueprintUnitFactReference>("cb8686e7357a68c42bdd9d4e65334633"),
                        };
                    });
                    bp.Ranks = 1;
                    bp.IsClassFeature = true;
                });

                var AntipaladinProgression = Helpers.CreateBlueprint<BlueprintProgression>(MCEContext, "AntipaladinProgression", bp => {
                    bp.LevelEntries = new LevelEntry[] {
                        Helpers.CreateLevelEntry(1, AntipaladinProficiencies),
                    };
                });

                var PaladinClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("bfa11238e7ae3544bbeb4d0b92e897ec");
                var AnimalClass = BlueprintTools.GetBlueprint<BlueprintCharacterClass>("4cd1757a0eea7694ba5c933729a53920");

                var AntipaladinClass = Helpers.CreateBlueprint<BlueprintCharacterClass>(MCEContext, "AntipaladinClass", bp => {
                    bp.LocalizedName = Helpers.CreateString(MCEContext, $"AntipaladinClass.Name", "Antipaladin");
                    bp.LocalizedDescription = Helpers.CreateString(MCEContext, $"AntipaladinClass.Description", "Although it is a rare" +
                        " occurrence, paladins do sometimes stray from the path of righteousness. Most of these wayward holy warriors seek" +
                        " out redemption and forgiveness for their misdeeds, regaining their powers through piety, charity, and powerful" +
                        " magic. Yet there are others, the dark and disturbed few, who turn actively to evil, courting the dark powers" +
                        " they once railed against in order to take vengeance on their former brothers. It’s said that those who climb" +
                        " the farthest have the farthest to fall, and antipaladins are living proof of this fact, their pride and hatred" +
                        " blinding them to the glory of their forsaken patrons." +
                        "\n\n" +
                        "Antipaladins become the antithesis of their former selves. They make pacts with fiends, take the lives of the" +
                        " innocent, and put nothing ahead of their personal power and wealth. Champions of evil, they often lead armies" +
                        " of evil creatures and work with other villains to bring ruin to the holy and tyranny to the weak. Not surprisingly" +
                        ", paladins stop at nothing to put an end to such nefarious antiheroes.");
                    bp.LocalizedDescriptionShort = bp.LocalizedDescription;

                    bp.HitDie = Kingmaker.RuleSystem.DiceType.D10;
                    bp.m_BaseAttackBonus = PaladinClass.m_BaseAttackBonus;
                    bp.m_FortitudeSave = PaladinClass.m_FortitudeSave;
                    bp.m_PrototypeId = PaladinClass.m_PrototypeId;
                    bp.m_ReflexSave = PaladinClass.m_ReflexSave;
                    bp.m_WillSave = PaladinClass.m_WillSave;
                    bp.m_Progression = AntipaladinProgression.ToReference<BlueprintProgressionReference>();
                    bp.RecommendedAttributes = PaladinClass.RecommendedAttributes;
                    bp.NotRecommendedAttributes = PaladinClass.NotRecommendedAttributes;
                    bp.m_EquipmentEntities = PaladinClass.m_EquipmentEntities;
                    bp.m_StartingItems = PaladinClass.StartingItems;
                    bp.m_SignatureAbilities = new BlueprintFeatureReference[0]
                    {

                    };
                    bp.m_Difficulty = 5;
                    bp.m_DefaultBuild = null;
                    bp.m_Archetypes = new BlueprintArchetypeReference[0] { };
                    bp.SkillPoints = 2;
                    bp.ClassSkills = new StatType[4] {
                        StatType.SkillStealth, StatType.SkillMobility, StatType.SkillAthletics, StatType.SkillLoreReligion
                    };
                    bp.IsDivineCaster = true;
                    bp.IsArcaneCaster = false;
                    bp.StartingGold = 411;
                    bp.PrimaryColor = 6;
                    bp.SecondaryColor = 11;
                    bp.MaleEquipmentEntities = PaladinClass.MaleEquipmentEntities;
                    bp.FemaleEquipmentEntities = PaladinClass.FemaleEquipmentEntities;
                    bp.RecommendedAttributes = PaladinClass.RecommendedAttributes;
                    bp.AddComponent<PrerequisiteNoClassLevel>(c => {
                        c.m_CharacterClass = PaladinClass.ToReference<BlueprintCharacterClassReference>();
                        c.m_CharacterClass = AnimalClass.ToReference<BlueprintCharacterClassReference>();
                    });
                    bp.AddComponent<PrerequisiteIsPet>(c => {
                        c.Not = true;
                        c.HideInUI = true;
                    });
                    bp.AddComponent<PrerequisiteAlignment>(c => { c.Alignment = Kingmaker.UnitLogic.Alignments.AlignmentMaskType.ChaoticEvil; });
                });


                BlueprintRoot.Instance.Progression.m_CharacterClasses = BlueprintRoot.Instance.Progression.m_CharacterClasses
                    .AddToArray(AntipaladinClass.ToReference<BlueprintCharacterClassReference>());

                AntipaladinProgression.AddClass(AntipaladinClass);
            }

        }
    }
}