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
using Kingmaker.EntitySystem.Stats;

namespace FeatAndSpells.Classes {

    public class Magus {

        public static void ChangeHandler() {
            ChangeSkills();
            ChangeSwordSaint();
        }

        private static void ChangeSkills() {
            MagusClass.SkillPoints = 5;
            MagusClass.ClassSkills = new StatType[] {
                StatType.SkillKnowledgeArcana,
                StatType.SkillKnowledgeWorld,
                StatType.SkillUseMagicDevice,
                StatType.SkillAthletics,
                StatType.SkillMobility,
                StatType.SkillPersuasion,
                StatType.SkillThievery,
                StatType.SkillStealth,
                StatType.SkillPerception };
        }

        public static void ChangeSwordSaint() {

            Blueprints.Abilities.SenseVitals.AddToSpellList(SpellTools.SpellList.MagusSpellList, 2);

            Blueprints.Abilities.LegendaryProportions.AddToSpellList(SpellTools.SpellList.MagusSpellList, 7);
            Blueprints.Abilities.KiShout.AddToSpellList(SpellTools.SpellList.MagusSpellList, 7);
            Blueprints.Abilities.PrismaticSpray.AddToSpellList(SpellTools.SpellList.MagusSpellList, 7);
            Blueprints.Abilities.WavesOfExhaustion.AddToSpellList(SpellTools.SpellList.MagusSpellList, 7);
            Blueprints.Abilities.WavesOfEctasy.AddToSpellList(SpellTools.SpellList.MagusSpellList, 7);
            Blueprints.Abilities.UmbralStrike.AddToSpellList(SpellTools.SpellList.MagusSpellList, 7);
            Blueprints.Abilities.FingerOfDeath.AddToSpellList(SpellTools.SpellList.MagusSpellList, 7);

            Blueprints.Abilities.FrightfulAspect.AddToSpellList(SpellTools.SpellList.MagusSpellList, 8);
            Blueprints.Abilities.Stormbolts.AddToSpellList(SpellTools.SpellList.MagusSpellList, 8);
            Blueprints.Abilities.RiftOfRuin.AddToSpellList(SpellTools.SpellList.MagusSpellList, 8);
            Blueprints.Abilities.ShoutGreater.AddToSpellList(SpellTools.SpellList.MagusSpellList, 8);
            Blueprints.Abilities.PolarRay.AddToSpellList(SpellTools.SpellList.MagusSpellList, 8);

            Blueprints.Abilities.HeroicInvocation.AddToSpellList(SpellTools.SpellList.MagusSpellList, 9);
            Blueprints.Abilities.OverwhelmingPresence.AddToSpellList(SpellTools.SpellList.MagusSpellList, 9);
            Blueprints.Abilities.Foresight.AddToSpellList(SpellTools.SpellList.MagusSpellList, 9);

            SpellBooks.EldritchScionSpellbook.CastingAttribute = StatType.Intelligence;

            SwordSaintArcheType.m_ReplaceSpellbook = SpellBooks.EldritchScionSpellbook.ToReference<BlueprintSpellbookReference>();


            FASContext.Logger.LogHeader("Changed SwordSaint");
        }
    }
}