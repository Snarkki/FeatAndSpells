using System.Collections.Generic;
using FeatAndSpells.Blueprints;
//using static FeatAndSpells.Blueprints.Archetypes;
//using static FeatAndSpells.Blueprints.Features;
//using static FeatAndSpells.Blueprints.FeatureSelections;
//using static FeatAndSpells.Blueprints.SpellBooks;
//using static FeatAndSpells.Blueprints.CharacterClasses;
//using TabletopTweaks.Core.Utilities;
//using Kingmaker.Blueprints.Classes;
//using static FeatAndSpells.Main;
//using Kingmaker.Blueprints;
//using Kingmaker.EntitySystem.Stats;
//using Kingmaker.UnitLogic.FactLogic;
//using Kingmaker.UnitLogic.Mechanics.Components;
//using Kingmaker.Blueprints.Classes.Spells;

//namespace FeatAndSpells.Classes {
//    internal class Bloodrager {
//        public static void ChangeHandler() {
//            ChangePrimalist();
//        }


//        public static void ChangePrimalist() {

//            var PrimalistSpellbook = Helpers.CreateBlueprint<BlueprintSpellbook>(FASContext, "PrimalistSpellbook", bp => {
//                bp.Name = Helpers.CreateString(FASContext, "PrimalistSpellbook.Name", "Primalist Spellbook");
//                bp.CastingAttribute = Kingmaker.EntitySystem.Stats.StatType.Charisma;
//                bp.IsMythic = false;
//                bp.m_SpellsPerDay = SpellBooks.SorcererSpellPerDay.ToReference<BlueprintSpellsTableReference>();
//                bp.m_SpellsKnown = SpellBooks.SorcererSpellKnown.ToReference<BlueprintSpellsTableReference>();
//                bp.m_SpellList = SpellBooks.ClericSpellList.ToReference<BlueprintSpellListReference>();
//                bp.m_CharacterClass = Blueprints.CharacterClasses.BloodragerClass.ToReference<BlueprintCharacterClassReference>();
//                bp.Spontaneous = true;
//                bp.AllSpellsKnown = false;
//                bp.CantripsType = CantripsType.Orisions;
//                bp.CasterLevelModifier = 0;
//                bp.CanCopyScrolls = false;
//                bp.IsArcane = false;
//                bp.IsArcanist = false;
//                bp.HasSpecialSpellList = false;
//            });

//            MonsterTactician.m_ReplaceSpellbook = InquisitorSpellBook.ToReference<BlueprintSpellbookReference>();


//        }
//    }
//}