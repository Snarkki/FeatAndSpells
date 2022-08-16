using System;
using System.Collections.Generic;
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
using Kingmaker.UnitLogic.Mechanics.Components;

namespace FeatAndSpells.Classes {
    internal class Arcanist {

        public static void ChangeHandler() {
            ChangeBrownFur();
        }


        public static void ChangeBrownFur() {


            BrownFurArchetype.RemoveFeatures = new LevelEntry[] { };


        }
    }
}