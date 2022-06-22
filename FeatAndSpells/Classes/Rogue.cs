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
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.FactLogic;

namespace FeatAndSpells.Classes {
    public class Rogue
    {


        public static void ChangeHandler() {
            ChangeKnifeMaster();
            CreateEldritchTricksters();
        }

        public static void CreateEldritchTricksters() {

            var EldrichTricksterArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(FASContext, "EldrichTricksterArchetype", bp => {
                bp.SetName(FASContext, "Eldrich Trickster");
                bp.SetDescription(FASContext, "Eldrich Trickster are spontanous casters.");

                bp.m_ReplaceSpellbook = SageSpellbook.ToReference<BlueprintSpellbookReference>();

                bp.RemoveFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(2, RogueTalentSelection),
                    Helpers.CreateLevelEntry(3, FinesseTraining),
                    Helpers.CreateLevelEntry(6, RogueTalentSelection),
                    Helpers.CreateLevelEntry(11, FinesseTraining),
                    Helpers.CreateLevelEntry(12, RogueTalentSelection),
                    Helpers.CreateLevelEntry(14, RogueTalentSelection),
                    Helpers.CreateLevelEntry(18, RogueTalentSelection),
                    Helpers.CreateLevelEntry(19, FinesseTraining),
                };

                bp.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, RangedLegerdemainFeature, FullCasterFeature),
                    Helpers.CreateLevelEntry(2, BasicFeatSelection),
                    Helpers.CreateLevelEntry(6, BasicFeatSelection),
                    Helpers.CreateLevelEntry(12, BasicFeatSelection),
                    Helpers.CreateLevelEntry(14, BasicFeatSelection),
                    Helpers.CreateLevelEntry(15, Features.SurpriseSpells),
                    Helpers.CreateLevelEntry(18, BasicFeatSelection)
                };
            });

            RogueClass.m_Archetypes = RogueClass.m_Archetypes.AppendToArray(EldrichTricksterArchetype.ToReference<BlueprintArchetypeReference>());

            RogueClass.Progression.UIGroups = RogueClass.Progression.UIGroups.AppendToArray(
                 Helpers.CreateUIGroup(
                    RangedLegerdemainFeature, Features.SurpriseSpells
                ),
                Helpers.CreateUIGroup(
                    BasicFeatSelection
                )
            );



            FASContext.Logger.LogHeader("Created Eldrich Trickster");
        }

        public static void ChangeKnifeMaster()
        {
            KMBladeSense.RemoveComponents<ACBonusAgainstWeaponGroup>();
            KMBladeSense.AddComponent<AddStatBonus>(c => {
                c.Descriptor = Kingmaker.Enums.ModifierDescriptor.Dodge;
                c.Stat = Kingmaker.EntitySystem.Stats.StatType.AC;
                c.Value = 1;
                c.ScaleByBasicAttackBonus = false;
            });
            KMBladeSense.SetDescription(FASContext, "Your ability to fight in close combats have trained your ability to dodge enemy attacks. You gain +1 dodge AC for every levelup of this skill");

            KnifeMaster.AddFeatures = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, RangerProfiencys),
                    Helpers.CreateLevelEntry(3, KMBladeSense),
                    Helpers.CreateLevelEntry(6, KMBladeSense),
                    Helpers.CreateLevelEntry(9, KMBladeSense),
                    Helpers.CreateLevelEntry(12, KMBladeSense),
                    Helpers.CreateLevelEntry(15, KMBladeSense),
                    Helpers.CreateLevelEntry(18, KMBladeSense),
                };
            RogueClass.Progression.UIGroups = RogueClass.Progression.UIGroups.AppendToArray(
                   Helpers.CreateUIGroup(KMBladeSense),
                   Helpers.CreateUIGroup(RangerProfiencys)
                );
            FASContext.Logger.LogHeader("Changed KnifeMaster");
        }

    }
}