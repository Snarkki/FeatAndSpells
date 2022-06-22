
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;

namespace FeatAndSpells.Blueprints {
    public class SpellBooks {

        public static SpellsLevelEntry[] BaseWorldcrawlPreparedSpellProgression;
        public static SpellsLevelEntry[] BaseWorldcrawlPreparedMin1SpellProgression;
        public static SpellsLevelEntry[] BaseWorldcrawlSpontaneousSpellProgression;
        public static SpellsLevelEntry[] BaseWorldcrawlHybridSpellProgression;
        public static SpellsLevelEntry[] BaseWorldcrawlHybridHalfSpellProgression;
        public static SpellsLevelEntry[] BaseWorldcrawlPreparedSpellKnownProgression;
        public static SpellsLevelEntry[] BaseWorldcrawlSpontaneousSpellKnownProgression;
        public static SpellsLevelEntry[] CrossbloodedWorldcrawlSpontaneousSpellKnownProgression;
        public static SpellsLevelEntry[] BaseWorldcrawlHybridSpellKnownProgression;
        public static SpellsLevelEntry[] BaseWorldcrawlHybridHalfSpellKnownProgression;

        public static BlueprintSpellbook PaladinSpellbook = BlueprintTools.GetBlueprint<BlueprintSpellbook>("bce4989b070ce924b986bf346f59e885");
        public static BlueprintSpellbook ClericSpellbook = BlueprintTools.GetBlueprint<BlueprintSpellbook>("4673d19a0cf2fab4f885cc4d1353da33");
        public static BlueprintSpellbook BardSpellBook = BlueprintTools.GetBlueprint<BlueprintSpellbook>("bc04fc157a8801d41b877ad0d9af03dd");
        public static BlueprintSpellsTable SorcererSpellPerDay = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("dbff16956df2eda48a1da5c9617cc836");
        public static BlueprintSpellsTable SorcererSpellKnown = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("d232bc78d967a964bac4d4d38e7ca5f4");
        public static BlueprintSpellList ClericSpellList = BlueprintTools.GetBlueprint<BlueprintSpellList>("8443ce803d2d31347897a3d85cc32f53");
        public static BlueprintSpellList WizardSpellList = BlueprintTools.GetBlueprint<BlueprintSpellList>("ba0401fdeb4062f40a7aa95b6f07fe89");
        public static BlueprintSpellList ShamanSpellList = BlueprintTools.GetBlueprint<BlueprintSpellList>("c0c40e42f07ff104fa85492da464ac69");
        public static BlueprintSpellbook EldritchScionSpellbook = BlueprintTools.GetBlueprint<BlueprintSpellbook>("e2763fbfdb91920458c4686c3e7ed085");
        public static BlueprintSpellbook SageSpellbook = BlueprintTools.GetBlueprint<BlueprintSpellbook>("cc2052732997b654e93eac268a39a0a9");
        public static BlueprintSpellbook ExploiterWizardSpellbook = BlueprintTools.GetBlueprint<BlueprintSpellbook>("d09794fb6f93e4a40929a965b434070d");
        public static BlueprintSpellbook WizardSpellbook = BlueprintTools.GetBlueprint<BlueprintSpellbook>("5a38c9ac8607890409fcb8f6342da6f4");
        public static BlueprintSpellbook AccursedSpellBook = BlueprintTools.GetBlueprint<BlueprintSpellbook>("b897fe0947e4b804082b1a687c21e6e2");
        public static BlueprintSpellbook BloodragerSpellBook = BlueprintTools.GetBlueprint<BlueprintSpellbook>("e19484252c2f80e4a9439b3681b20f00");

        public static BlueprintSpellList PaladinSpellList = BlueprintTools.GetBlueprint<BlueprintSpellList>("9f5be2f7ea64fe04eb40878347b147bc");

        public static BlueprintSpellsTable WizardSpellLevels = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("78bb94ed2e75122428232950bb09e97b");
        public static BlueprintSpellsTable WitchSpellLevels = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("ecc94555638dcb942a51a1c0ffb60341");
        public static BlueprintSpellsTable SorcererSpellsDailyTable = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("dbff16956df2eda48a1da5c9617cc836");
        public static BlueprintSpellsTable ShamanSpellLevels = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("ce51ca64670b6a147a4bd4960a91a490");
        public static BlueprintSpellsTable LichSpellsPerDay = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("4924b73038564c543a371b4c4d1def45");
        public static BlueprintSpellsTable EldritchFontSpellSlots = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("67682cefce9401e469bee46dac597051");
        public static BlueprintSpellsTable DruidSpellLevels = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("6a45ad1fb1b9f7240aea942b7c22111d");
        public static BlueprintSpellsTable CrossbloodedSpellsKnownTable = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("aa44e19184bdb7f4fb17d4aeeecb79b9");
        public static BlueprintSpellsTable AngeSpellsPerDay = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("94e3ed4d8e5c4674a8131a3c71e290e0");
        public static BlueprintSpellsTable ArcanistSpellsPerDayTable = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("d1d296ca4bf8449409fc330a54ad58e1");
        public static BlueprintSpellsTable ArcanistSpellSlots = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("44be796c5d37bb244aae59d0a005530f");
        public static BlueprintSpellsTable ClericSpellLevels = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("fb5ef8ddad475284c82257b79bf1749e");
        public static BlueprintSpellsTable AngelfireApostleSpellLevels = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("46348fc0157a20a429657aee4df2791d");
        public static BlueprintSpellsTable CrusaderSpellLevels = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("799265ebe0ed27641b6d415251943d03");
        public static BlueprintSpellsTable AlchemistSpellLevels = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("bf4a0a03a45275d438b8c59cd5388259");
        public static BlueprintSpellsTable BardSpellSlotsTable = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("0a8eec9ca5c0dc64795243ab3c55d924");
        public static BlueprintSpellsTable InquisitorSpellSlotsTable = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("83d3e15962e5d6949b90b5c226a2b487");
        public static BlueprintSpellsTable MagusSpellLevels = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("6326b540f7c6a604f9d6f82cc0e2293c");
        public static BlueprintSpellsTable SwordSaintSpellLevels = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("b9fdc0b2d37eb9e4298f9163edf5ca82");
        public static BlueprintSpellsTable WarpriestSpellSlotsTable = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("c73a394ec54adc243aef8ac967e39324");
        public static BlueprintSpellsTable SkaldSpellSlotsTable = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("39aeb5d8dafde5a40ba2032dec65db70");
        public static BlueprintSpellsTable SorcererSpellsKnownTable = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("d232bc78d967a964bac4d4d38e7ca5f4"); 
        public static BlueprintSpellsTable BardSpellsKnownTable = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("90de6b4f591d1184497fbfbae6e16547");
        public static BlueprintSpellsTable InquisitorSpellsKnownTable = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("c133d22305bab964c88a767cc69b1f9b");
        public static BlueprintSpellsTable SkaldSpellsKnownTable = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("84eee37ad49807f41836729761955da3");
        public static BlueprintSpellsTable BloodragerSpellKnownTable = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("d9e9437865e83344b864ef49ffa53013");
        public static BlueprintSpellsTable BloodragerSpellPerDayTable = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("caf7018942861664ebe87687893ad05d");
        public static BlueprintSpellsTable PaladinSpellLevels = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("9aed4803e424ae8429c392d8fbfb88ff");
        public static BlueprintSpellsTable RangerSpellLevels = BlueprintTools.GetBlueprint<BlueprintSpellsTable>("d2b0abf29cfaf8842b75c2efc7f40157");


        public static BlueprintFeatureSelectMythicSpellbook LichIncorporareSpellBookFeature = BlueprintTools.GetBlueprint<BlueprintFeatureSelectMythicSpellbook>("3f16e9caf7c683c40884c7c455ed26af");

    }
}




