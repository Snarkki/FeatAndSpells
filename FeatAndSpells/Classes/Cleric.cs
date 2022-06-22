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

namespace FeatAndSpells.Classes {
    internal class Cleric {
        public static void ChangeHandler() {
            ChangeCrusader();
        }


        public static void ChangeCrusader() {
            CrusaderArchetype.m_ReplaceSpellbook = SpellBooks.ClericSpellbook.ToReference<BlueprintSpellbookReference>();
            CrusaderArchetype.RemoveFeatures = new LevelEntry[] { };
        }
    }
}
