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
using Kingmaker.Blueprints.Classes.Spells;

namespace FeatAndSpells.Classes {
    public class Sorcerer
    {

        public static void ChangeHandler() {
            ChangeSageBloodLine();
        }

        public static void ChangeSageBloodLine() {

            //var MergedSpellsKnown = BlueprintTools.GetModBlueprint<BlueprintSpellsTable>(FASContext, "MergedSpellsKnown");

            //SageSpellbook.m_SpellsKnown = MergedSpellsKnown.ToReference<BlueprintSpellsTableReference>();

            SageSorcererArcheType.AddSkillPoints = 2;

            SageSorcererArcheType.AddFeatures = SageSorcererArcheType.AddFeatures.AppendToArray(
                    Helpers.CreateLevelEntry(1, SpellPenetration, RangedLegerdemainFeature, PointBlankShot),
                    Helpers.CreateLevelEntry(2, SneakAttack, PreciseShot),
                    Helpers.CreateLevelEntry(3, GreaterSpellPenetration, RangedLegerdemainFeature),
                    Helpers.CreateLevelEntry(4, SneakAttack),
                    Helpers.CreateLevelEntry(5, ToughnessFeature),
                    Helpers.CreateLevelEntry(7, SneakAttack),
                    Helpers.CreateLevelEntry(10, SneakAttack),
                    Helpers.CreateLevelEntry(13, SneakAttack),
                    Helpers.CreateLevelEntry(15, SurpriseSpells),
                    Helpers.CreateLevelEntry(16, SneakAttack),
                    Helpers.CreateLevelEntry(19, SneakAttack)
                );
            

        }

      



    }
}