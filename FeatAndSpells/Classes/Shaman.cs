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
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace FeatAndSpells.Classes {
    public class Shaman
    {
        public static void ChangeHandler() {
            ModdedWitchDoctor();
            //AddShadowFang();
        }

        public static void ModdedWitchDoctor() {

            var WitchDoctorSpellBook = Helpers.CreateBlueprint<BlueprintSpellbook>(FASContext, "WitchDoctorSpellBook", bp => {
                bp.Name = Helpers.CreateString(FASContext, "WitchDoctorSpellBook.Name", "WitchDoctorSpellBook");
                bp.CastingAttribute = Kingmaker.EntitySystem.Stats.StatType.Wisdom;
                bp.IsMythic = false;
                bp.m_SpellsPerDay = SorcererSpellPerDay.ToReference<BlueprintSpellsTableReference>();
                bp.m_SpellsKnown = SorcererSpellKnown.ToReference<BlueprintSpellsTableReference>();
                bp.m_SpellList = ShamanSpellList.ToReference<BlueprintSpellListReference>();
                bp.m_CharacterClass = ShamanClass.ToReference<BlueprintCharacterClassReference>();
                bp.Spontaneous = true;
                bp.AllSpellsKnown = false;
                bp.CantripsType = CantripsType.Orisions;
                bp.CasterLevelModifier = 0;
                bp.CanCopyScrolls = false;
                bp.IsArcane = false;
                bp.IsArcanist = false;
                bp.HasSpecialSpellList = false;
            });

            var BetterChannel = Blueprints.Abilities.WitchDoctorChannel.GetComponent<ContextRankConfig>();
            BetterChannel.m_StepLevel = 0;

            WitchDoctorArchetype.m_ReplaceSpellbook = WitchDoctorSpellBook.ToReference<BlueprintSpellbookReference>();

            //WitchDoctorArchetype.RecommendedAttributes = new Kingmaker.EntitySystem.Stats.StatType[] { Kingmaker.EntitySystem.Stats.StatType.Charisma };

            WitchDoctorArchetype.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, ShamanHexSelection),
                    Helpers.CreateLevelEntry(3, BasicFeatSelection),
                    Helpers.CreateLevelEntry(4, WitchDoctorHeal),
                    Helpers.CreateLevelEntry(5, ShamanHexSelection),
                    Helpers.CreateLevelEntry(7, ShamanHexSelection),
                    Helpers.CreateLevelEntry(9, BasicFeatSelection),
                    Helpers.CreateLevelEntry(8, WitchDoctorCOunterCurse),
                    Helpers.CreateLevelEntry(11, ShamanHexSelection),
                    Helpers.CreateLevelEntry(13, BasicFeatSelection),
                    Helpers.CreateLevelEntry(14, ShamanHexSelection),
                    Helpers.CreateLevelEntry(18, BasicFeatSelection),
                };
            FASContext.Logger.LogHeader("Changed witchdoctor");

        }



       public static void AddShadowFang()
        {

            var ShadowFangArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(FASContext, "ShadowFangArchetype", bp => {
                bp.SetName(FASContext, "Shadow Fang");
                bp.SetDescription(FASContext, "Shadow fangs are shamans who have specialized in striking their enemies where they are weakest.");

                bp.ReplaceClassSkills = true;
                bp.ClassSkills = new Kingmaker.EntitySystem.Stats.StatType[] {
                    Kingmaker.EntitySystem.Stats.StatType.SkillMobility,
                    Kingmaker.EntitySystem.Stats.StatType.SkillThievery,
                    Kingmaker.EntitySystem.Stats.StatType.SkillLoreNature,
                    Kingmaker.EntitySystem.Stats.StatType.SkillStealth,
                    Kingmaker.EntitySystem.Stats.StatType.SkillPerception,
                    Kingmaker.EntitySystem.Stats.StatType.SkillLoreReligion,
                };

                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(4, ShamanWanderingSpiritFeature),
                    Helpers.CreateLevelEntry(6, ShamanWanderingHexFeature),
                    Helpers.CreateLevelEntry(14, ShamanWanderingHexFeature2),
                };

                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, SneakAttack, PaladinProficiencies, WeaponFinesse),
                    Helpers.CreateLevelEntry(3, SneakAttack, FinesseTraining),
                    Helpers.CreateLevelEntry(4, DebilitatingInjury),
                    Helpers.CreateLevelEntry(5, SneakAttack),
                    Helpers.CreateLevelEntry(7, SneakAttack),
                    Helpers.CreateLevelEntry(9, SneakAttack),
                    Helpers.CreateLevelEntry(11, SneakAttack),
                    Helpers.CreateLevelEntry(13, SneakAttack),
                    Helpers.CreateLevelEntry(15, SneakAttack),
                    Helpers.CreateLevelEntry(17, SneakAttack),
                    Helpers.CreateLevelEntry(19, SneakAttack),          
                };
            });


            var DisorientedConfig = Blueprints.Buffs.DebilitatingInjuryDisorientedEffectBuff.GetComponent<ContextRankConfig>();
            DisorientedConfig.m_Class = DisorientedConfig.m_Class.AppendToArray(ShamanClass.ToReference<BlueprintCharacterClassReference>());
            DisorientedConfig.m_AdditionalArchetypes = DisorientedConfig.m_AdditionalArchetypes.AppendToArray(ShadowFangArchetype.ToReference<BlueprintArchetypeReference>());

            var BewilderedConfig = Buffs.DebilitatingInjuryBewilderedEffectBuff.GetComponent<ContextRankConfig>();
            BewilderedConfig.m_Class = BewilderedConfig.m_Class.AppendToArray(ShamanClass.ToReference<BlueprintCharacterClassReference>());
            BewilderedConfig.m_AdditionalArchetypes = BewilderedConfig.m_AdditionalArchetypes.AppendToArray(ShadowFangArchetype.ToReference<BlueprintArchetypeReference>());

            //var HamperedConfig = DebilitatingInjuryHamperedEffectBuff.GetComponent<ContextRankConfig>();
            //HamperedConfig.m_Class = HamperedConfig.m_Class.AppendToArray(ShamanClass.ToReference<BlueprintCharacterClassReference>());
            //HamperedConfig.m_AdditionalArchetypes = HamperedConfig.m_AdditionalArchetypes.AppendToArray(ShadowFangArchetype.ToReference<BlueprintArchetypeReference>());



            ShamanClass.m_Archetypes = ShamanClass.m_Archetypes.AppendToArray(ShadowFangArchetype.ToReference<BlueprintArchetypeReference>());

            ShamanClass.Progression.UIGroups = ShamanClass.Progression.UIGroups.AppendToArray(
                Helpers.CreateUIGroup(
                    SneakAttack
                ),
                Helpers.CreateUIGroup(
                    PaladinProficiencies,
                    DebilitatingInjury
                )
                    );
            FASContext.Logger.LogHeader("Changed ShadowFang");

        }
    }
}
