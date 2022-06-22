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
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.AI.Blueprints;

namespace FeatAndSpells.Classes {
    public class Inquisitor
    {

        public static BlueprintAiAttack AttackAiAction = BlueprintTools.GetBlueprint<BlueprintAiAttack>("866ffa6c34000cd4a86fb1671f86c7d8");
        public static BlueprintAiAttack MirrorImageAiAction = BlueprintTools.GetBlueprint<BlueprintAiAttack>("fd46f0f75324dcb418c2758cf3c582a9");

        public static void ChangeHandler() {
            //AddGrandInquisitor();
            ChangeMonsterTactitician();
            ChangeClass();
        }

        public static void ChangeClass() {
            SacredHuntsmanArchetype.RemoveFeatures = new LevelEntry[] { };
        }

        public static void ChangeMonsterTactitician() {


            var WayOfTheOwl = Helpers.CreateBlueprint<BlueprintFeature>(FASContext, "WayOfTheOwl", bp => {
                bp.SetName(FASContext, "Way of the Owl");
                bp.SetDescription(FASContext, "Instead of using dexterity for your AC, you use your wisdom score.");
                bp.AddComponent(Helpers.Create<ReplaceStatBaseAttribute>(c => {
                    c.TargetStat = Kingmaker.EntitySystem.Stats.StatType.AC;
                    c.BaseAttributeReplacement = Kingmaker.EntitySystem.Stats.StatType.Wisdom;
                }));
                bp.AddComponent(Helpers.Create<ReplaceCMDDexterityStat>(c => {
                    c.NewStat = Kingmaker.EntitySystem.Stats.StatType.Wisdom;
                }));
            });


            //var InquisitorSpellBook = Helpers.CreateBlueprint<BlueprintSpellbook>(FASContext, "GrandInquisitorSpellBook", bp => {
            //    bp.Name = Helpers.CreateString(FASContext, "GrandInquisitorSpellBook.Name", "GrandInquisitor");
            //    bp.CastingAttribute = Kingmaker.EntitySystem.Stats.StatType.Wisdom;
            //    bp.IsMythic = false;
            //    bp.m_SpellsPerDay = SpellBooks.SorcererSpellPerDay.ToReference<BlueprintSpellsTableReference>();
            //    bp.m_SpellsKnown = SpellBooks.SorcererSpellKnown.ToReference<BlueprintSpellsTableReference>();
            //    bp.m_SpellList = SpellBooks.ClericSpellList.ToReference<BlueprintSpellListReference>();
            //    bp.m_CharacterClass = InquisitorClass.ToReference<BlueprintCharacterClassReference>();
            //    bp.Spontaneous = true;
            //    bp.AllSpellsKnown = false;
            //    bp.CantripsType = CantripsType.Orisions;
            //    bp.CasterLevelModifier = 0;
            //    bp.CanCopyScrolls = false;
            //    bp.IsArcane = false;
            //    bp.IsArcanist = false;
            //    bp.HasSpecialSpellList = false;
            //});

            //MonsterTactician.m_ReplaceSpellbook = InquisitorSpellBook.ToReference<BlueprintSpellbookReference>();
            var NewSimpleAi = Helpers.CreateBlueprint<BlueprintBrain>(FASContext, "NewSimpleAi", bp => {
                bp.m_Actions = new BlueprintAiActionReference[]
               {
                    AttackAiAction.ToReference<BlueprintAiActionReference>(),
                    MirrorImageAiAction.ToReference<BlueprintAiActionReference>(),
               };
            });

            var AzataBralani = Blueprints.Units.AzataBralani_Summoned;
            AzataBralani.Strength = 22;
            AzataBralani.Dexterity = 22;
            AzataBralani.m_Brain = NewSimpleAi.ToReference<BlueprintBrainReference>();
            AzataBralani.Body.m_PrimaryHand = Blueprints.Items.BladeOfOrderItem.ToReference<BlueprintItemEquipmentHandReference>();
            AzataBralani.m_AddFacts = AzataBralani.m_AddFacts.AppendToArray(
                Features.BabauSneakAttackFeature.ToReference<BlueprintUnitFactReference>()
                );


            BullycompanionArcheType.RemoveFeatures = new LevelEntry[] { };

            BullycompanionArcheType.AddFeatures = BullycompanionArcheType.AddFeatures.AppendToArray(
                    Helpers.CreateLevelEntry(1, LightBardingFeature),
                    Helpers.CreateLevelEntry(3, FurysFallFeature),
                    Helpers.CreateLevelEntry(10, BulwarkSturdyFeature)
                );


            MonsterTactician.RemoveFeatures = new LevelEntry[] { 
            };

            MonsterTactician.AddFeatures = MonsterTactician.AddFeatures.AppendToArray(
                    Helpers.CreateLevelEntry(1, FighterProfiencies, WayOfTheOwl ),
                    Helpers.CreateLevelEntry(2, SlayerFeatSelection2),
                    //Helpers.CreateLevelEntry(3, SneakAttackFeature),
                    Helpers.CreateLevelEntry(4, SlayerFeatSelection2),
                    //Helpers.CreateLevelEntry(5, ),
                    Helpers.CreateLevelEntry(6, SlayerFeatSelection6), //SneakAttackFeature, 
                    Helpers.CreateLevelEntry(8, SlayerFeatSelection6),
                    //Helpers.CreateLevelEntry(9, SneakAttackFeature),
                    Helpers.CreateLevelEntry(10, SlayerFeatSelection10),
                    //Helpers.CreateLevelEntry(11, ),
                    Helpers.CreateLevelEntry(12, SlayerFeatSelection10), //SneakAttackFeature
                    Helpers.CreateLevelEntry(14, SlayerFeatSelection10),
                    //Helpers.CreateLevelEntry(15, ), //SneakAttackFeature
                    Helpers.CreateLevelEntry(16, SlayerFeatSelection10)
                    //Helpers.CreateLevelEntry(18, SneakAttackFeature),
                    //Helpers.CreateLevelEntry(20, )
                );

            InquisitorClass.Progression.UIGroups = InquisitorClass.Progression.UIGroups.AppendToArray(
                   //Helpers.CreateUIGroup(SneakAttackFeature),
                   Helpers.CreateUIGroup(SlayerFeatSelection2, SlayerFeatSelection6, SlayerFeatSelection10),
                   Helpers.CreateUIGroup(WayOfTheOwl)
                );
            FASContext.Logger.LogHeader("Patch Monster Tactician");
        }

        //public static void AddGrandInquisitor()
        //{



        //    var GrandInquisitorArchetype = Helpers.CreateBlueprint<BlueprintArchetype>(FASContext, "GrandInquisitorArchetype", bp => {
        //        bp.SetName(FASContext, "Grand Inquisitor");
        //        bp.SetDescription(FASContext, "A Grand Inquisitor loses out on the team potential of an regular inquisitor for more focus on the divine spellcasting of a cleric.");
        //        bp
        //    });

        //    InquisitorClass.m_Archetypes = InquisitorClass.m_Archetypes.AppendToArray(GrandInquisitorArchetype.ToReference<BlueprintArchetypeReference>());

            
        //    GrandInquisitorArchetype.RemoveFeatures = new LevelEntry[] {
        //            //Helpers.CreateLevelEntry(1, JudgementFeature),
        //            Helpers.CreateLevelEntry(3, TeamWorkSelection),
        //            //Helpers.CreateLevelEntry(4, JudgementAdditionalFeature),
        //            Helpers.CreateLevelEntry(6, TeamWorkSelection),
        //            //Helpers.CreateLevelEntry(7, JudgementAdditionalFeature),
        //            //Helpers.CreateLevelEntry(8, SecondJudgementFeature),
        //            Helpers.CreateLevelEntry(9, TeamWorkSelection),
        //            //Helpers.CreateLevelEntry(10, JudgementAdditionalFeature),
        //            Helpers.CreateLevelEntry(12, TeamWorkSelection),
        //            //Helpers.CreateLevelEntry(13, JudgementAdditionalFeature),
        //            Helpers.CreateLevelEntry(15, TeamWorkSelection),
        //            //Helpers.CreateLevelEntry(16, JudgementAdditionalFeature, ThirdJudgementFeature),
        //            Helpers.CreateLevelEntry(18, TeamWorkSelection),
        //            //Helpers.CreateLevelEntry(19, JudgementAdditionalFeature),
        //           // Helpers.CreateLevelEntry(20, TrueJudgementFeature),
        //        };
            
        //    GrandInquisitorArchetype.AddFeatures = new LevelEntry[] {
        //            Helpers.CreateLevelEntry(1, FighterProfiencies, WayOfTheOwl),
        //            Helpers.CreateLevelEntry(2, SlayerFeatSelection2),
        //            //Helpers.CreateLevelEntry(3, SneakAttackFeature),
        //            Helpers.CreateLevelEntry(4, SlayerFeatSelection2),
        //            //Helpers.CreateLevelEntry(5, ),
        //            Helpers.CreateLevelEntry(6, SlayerFeatSelection6), //SneakAttackFeature, 
        //            Helpers.CreateLevelEntry(8, SlayerFeatSelection6),
        //            //Helpers.CreateLevelEntry(9, SneakAttackFeature),
        //            Helpers.CreateLevelEntry(10, SlayerFeatSelection10),
        //           // Helpers.CreateLevelEntry(11, ),
        //            Helpers.CreateLevelEntry(12, SlayerFeatSelection10), //SneakAttackFeature
        //            Helpers.CreateLevelEntry(14, SlayerFeatSelection10),
        //            //Helpers.CreateLevelEntry(15, ), //SneakAttackFeature
        //            Helpers.CreateLevelEntry(16, SlayerFeatSelection10),
        //            //Helpers.CreateLevelEntry(18, SneakAttackFeature),
        //           // Helpers.CreateLevelEntry(20, )
        //        };


        //    InquisitorClass.Progression.UIGroups = InquisitorClass.Progression.UIGroups.AppendToArray(
        //           //Helpers.CreateUIGroup(SneakAttackFeature),
        //           Helpers.CreateUIGroup(SlayerFeatSelection2, SlayerFeatSelection6, SlayerFeatSelection10),
        //           Helpers.CreateUIGroup(WayOfTheOwl)
        //        );

        //    FASContext.Logger.LogHeader("Patch Grand Inquisitor");
        //}
    }
}
