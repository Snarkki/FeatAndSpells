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
using Kingmaker.UnitLogic.FactLogic;

namespace FeatAndSpells.Classes {
    public class Witch {

        public static void ChangeHandler() {;
            BuffLeyLine();
        }

        private static void BuffLeyLine() {
            LeyLineGuardian.RemoveFeatures = new LevelEntry[] { };

            LeyLineGuardian.AddFeatures = LeyLineGuardian.AddFeatures.AppendToArray(
                Helpers.CreateLevelEntry(1, SpellPenetration, RangedLegerdemainFeature, PointBlankShot),
                Helpers.CreateLevelEntry(3, GreaterSpellPenetration)
            );

            var comp = Progressions.WitchShadowPatronProgression.GetComponents<AddSpellsToDescription>().First();
            comp.m_Spells = new BlueprintAbilityReference[] {
                Blueprints.Abilities.Vanish.ToReference<BlueprintAbilityReference>(),
                Blueprints.Abilities.MirrorImage.ToReference<BlueprintAbilityReference>(),
                Blueprints.Abilities.Displacement.ToReference<BlueprintAbilityReference>(),
                Blueprints.Abilities.ShadowConjuration.ToReference<BlueprintAbilityReference>(),
                Blueprints.Abilities.ShadowEvocation.ToReference<BlueprintAbilityReference>(),
                Blueprints.Abilities.PhantasmalPutrefaction.ToReference<BlueprintAbilityReference>(),
                Blueprints.Abilities.ShadowConjurationGreater.ToReference<BlueprintAbilityReference>(),
                Blueprints.Abilities.ShadowEvocationGreater.ToReference<BlueprintAbilityReference>(),
                Blueprints.Abilities.Weird.ToReference<BlueprintAbilityReference>(),
            };

            var knownSpell = WitchPatronSpellLevel2.GetComponents<AddKnownSpell>().First();
            knownSpell.m_Spell = Blueprints.Abilities.MirrorImage.ToReference<BlueprintAbilityReference>();

            var knownSpell1 = WitchPatronSpellLevel9.GetComponents<AddKnownSpell>().First();
            knownSpell1.m_Spell = Blueprints.Abilities.Weird.ToReference<BlueprintAbilityReference>();
        }

    }
}
