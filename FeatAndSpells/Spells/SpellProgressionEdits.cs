using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;
using static FeatAndSpells.Blueprints.SpellBooks;
using static FeatAndSpells.Main;

namespace FeatAndSpells.Spells {
        public static class SpellProgressionEdits {
            public static void SpellProgressionProcessing() {



            //var MergedSpellsKnown = SorcererSpellsKnownTable.CreateCopy(FASContext, "MergedSpellsKnown", bp => {
            //});
            //MergedPatchSpontanousCasterSpellProgression(MergedSpellsKnown);

                bool flag = SorcererSpellsKnownTable != null;
                if (flag) { PatchSpontanousCasterSpellProgression(SorcererSpellsKnownTable); }

                bool flag2 = CrossbloodedSpellsKnownTable != null;
                if (flag2) { PatchSpontanousCasterSpellProgression(CrossbloodedSpellsKnownTable); }

                bool flag9 = SorcererSpellsDailyTable != null;
                if (flag9) { BaseWorldcrawlSpontaneousSpellKnown(SorcererSpellsDailyTable); }

                bool flag3 = BardSpellsKnownTable != null;
                if (flag3) { MythicSpellsKnown(BardSpellsKnownTable); }
                bool flag21 = BardSpellSlotsTable != null;
                if (flag21) { MergedPatchSpontanousCasterSpellProgression(BardSpellSlotsTable); }

                bool flag4 = InquisitorSpellsKnownTable != null;
                if (flag4) { HybridSpellsKnown(InquisitorSpellsKnownTable); }
                bool flag22 = InquisitorSpellSlotsTable != null;
                if (flag22) { BaseWorldcrawlHybridSpellProgression(InquisitorSpellSlotsTable); }


                bool flag5 = SkaldSpellsKnownTable != null;
                if (flag5) { HybridSpellsKnown(SkaldSpellsKnownTable); }

                bool flag6 = BloodragerSpellKnownTable != null;
                if (flag6) { HalfSpellKnown(BloodragerSpellKnownTable); }

                bool flag7 = WizardSpellLevels != null;
                if (flag7) { BaseWorldcrawlPreparedSpellProgression(WizardSpellLevels); }

                bool flag8 = WitchSpellLevels != null;
                if (flag8) { BaseWorldcrawlPreparedSpellProgression(WitchSpellLevels); }

                bool flag10 = ShamanSpellLevels != null;
                if (flag10) { BaseWorldcrawlPreparedSpellProgression(ShamanSpellLevels); }


                bool flag12 = EldritchFontSpellSlots != null;
                if (flag12) { BaseWorldcrawlPreparedSpellProgression(EldritchFontSpellSlots); }

                bool flag13 = DruidSpellLevels != null;
                if (flag13) { BaseWorldcrawlPreparedSpellProgression(DruidSpellLevels); }

                bool flag14 = ClericSpellLevels != null;
                if (flag14) { BaseWorldcrawlPreparedSpellProgression(ClericSpellLevels); }

                bool flag16 = ArcanistSpellSlots != null;
                if (flag16) { BaseWorldcrawlPreparedSpellProgression(ArcanistSpellSlots); }

                bool flag17 = ArcanistSpellsPerDayTable != null;
                if (flag17) { BaseWorldcrawlSpontaneousSpellKnown(ArcanistSpellsPerDayTable); }

                bool flag18 = AngelfireApostleSpellLevels != null;
                if (flag18) { BaseWorldcrawlPreparedSpellProgression(AngelfireApostleSpellLevels); }

                bool flag19 = CrusaderSpellLevels != null;
                if (flag19) { BaseWorldcrawlPreparedSpellProgression(CrusaderSpellLevels); }

                bool flag20 = AlchemistSpellLevels != null;
                if (flag20) { BaseWorldcrawlHybridSpellProgression(AlchemistSpellLevels); }





                bool flag23 = MagusSpellLevels != null;
                if (flag23) { BaseWorldcrawlHybridSpellProgression(MagusSpellLevels); }

                bool flag24 = SwordSaintSpellLevels != null;
                if (flag24) { BaseWorldcrawlHybridSpellProgression(SwordSaintSpellLevels); }

                bool flag25 = WarpriestSpellSlotsTable != null;
                if (flag25) { BaseWorldcrawlHybridSpellProgression(WarpriestSpellSlotsTable); }

                bool flag26 = SkaldSpellSlotsTable != null;
                if (flag26) { BaseWorldcrawlHybridSpellProgression(SkaldSpellSlotsTable); }

                bool flag27 = BloodragerSpellPerDayTable != null;
                if (flag27) { HalfSpellsPerKnown(BloodragerSpellPerDayTable); } // HalfSpellsPerKnown
                if (flag27) { HalfSpellsKnown(BloodragerSpellKnownTable); } // HalfSpellsKnown

                bool flag28 = PaladinSpellLevels != null;
                if (flag28) { BaseWorldcrawlHybridSpellProgression(PaladinSpellLevels); }

                bool flag29 = RangerSpellLevels != null;
                if (flag29) { BaseWorldcrawlHybridSpellProgression(RangerSpellLevels); }




                FASContext.Logger.LogHeader("Spell level and spells known progressions updated.");
            }



            private static void PatchSpontanousCasterSpellProgression(BlueprintSpellsTable fullCasterSlots) {
                List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>();
                var additionalSlotTables = new List<int[]>
                    {
                    new[] {0, 3},
                    new[] {0, 4},
                    new[] {0, 5},
                    new[] {0, 5, 3},
                    new[] {0, 5, 4},
                    new[] {0, 5, 5, 3},
                    new[] {0, 6, 5, 3},
                    new[] {0, 6, 5, 5, 2},
                    new[] {0, 6, 5, 5, 3},
                    new[] {0, 6, 6, 5, 4, 2},
                    new[] {0, 6, 6, 5, 5, 3},
                    new[] {0, 6, 6, 6, 5, 4, 2},
                    new[] {0, 6, 6, 6, 5, 5, 3},
                    new[] {0, 6, 6, 6, 5, 5, 4, 2},
                    new[] {0, 6, 6, 6, 5, 5, 5, 3},
                    new[] {0, 6, 6, 6, 5, 5, 5, 4, 2},
                    new[] {0, 6, 6, 6, 5, 5, 5, 5, 3},
                    new[] {0, 6, 6, 6, 5, 5, 5, 5, 4, 2},
                    new[] {0, 6, 6, 6, 5, 5, 5, 5, 5, 3},
                    new[] {0, 6, 6, 6, 5, 5, 5, 5, 5, 4},
                };
                SpellsLevelEntry[] cantrips = new SpellsLevelEntry[]
                {
                new SpellsLevelEntry(),
                };
                levels.AddRange(cantrips);
                levels.AddRange(additionalSlotTables.Select(slots => new SpellsLevelEntry { Count = slots }));
                fullCasterSlots.Levels = levels.ToArray();
            }
            private static void HybridSpellsKnown(BlueprintSpellsTable CasterSlots) {
                List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>();
                var additionalSlotTables = new List<int[]>
                    {
                    new[] {0, 2},
                    new[] {0, 3},
                    new[] {0, 4},
                    new[] {0, 5, 2},
                    new[] {0, 6, 2},
                    new[] {0, 6, 3},
                    new[] {0, 6, 4, 2},
                    new[] {0, 6, 5, 3},
                    new[] {0, 6, 6, 4},
                    new[] {0, 6, 6, 4, 2},
                    new[] {0, 6, 6, 6, 3},
                    new[] {0, 6, 6, 6, 4},
                    new[] {0, 6, 6, 6, 4, 2},
                    new[] {0, 6, 6, 6, 5, 3},
                    new[] {0, 6, 6, 6, 5, 4},
                    new[] {0, 6, 6, 6, 6, 4, 2},
                    new[] {0, 6, 6, 6, 6, 5, 3},
                    new[] {0, 6, 6, 6, 6, 6, 4},
                    new[] {0, 7, 7, 7, 6, 6, 4},
                    new[] {0, 7, 7, 7, 6, 6, 5},
                };
                SpellsLevelEntry[] cantrips = new SpellsLevelEntry[]
    {
                new SpellsLevelEntry(),
    };
                levels.AddRange(cantrips);
                levels.AddRange(additionalSlotTables.Select(slots => new SpellsLevelEntry { Count = slots }));
                CasterSlots.Levels = levels.ToArray();
            }
            private static void HalfSpellKnown(BlueprintSpellsTable CasterSlots) {
                List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>();
                var additionalSlotTables = new List<int[]>
                    {
                    new[] {0},
                    new[] {0},
                    new[] {0},
                    new[] {0, 2},
                    new[] {0, 3},
                    new[] {0, 4},
                    new[] {0, 5, 2},
                    new[] {0, 6, 3},
                    new[] {0, 6, 4},
                    new[] {0, 6, 5, 2},
                    new[] {0, 6, 6, 3},
                    new[] {0, 6, 6, 4},
                    new[] {0, 6, 6, 5, 2},
                    new[] {0, 6, 6, 6, 3},
                    new[] {0, 6, 6, 6, 4},
                    new[] {0, 6, 6, 6, 5},
                    new[] {0, 6, 6, 6, 6},
                    new[] {0, 7, 7, 6, 6},
                    new[] {0, 7, 7, 7, 7},
                    new[] {0, 8, 8, 8, 8},
                };
                SpellsLevelEntry[] cantrips = new SpellsLevelEntry[]
    {
                new SpellsLevelEntry(),
    };
                levels.AddRange(cantrips);
                levels.AddRange(additionalSlotTables.Select(slots => new SpellsLevelEntry { Count = slots }));
                CasterSlots.Levels = levels.ToArray();
            }

            private static void BaseWorldcrawlPreparedSpellProgression(BlueprintSpellsTable CasterSlots) {
                List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>();
                var additionalSlotTables = new List<int[]>
                    {
                    new[] {0, 3},
                    new[] {0, 4},
                    new[] {0, 5, 3},
                    new[] {0, 5, 4},
                    new[] {0, 6, 4, 2},
                    new[] {0, 6, 5, 3},
                    new[] {0, 6, 5, 3, 2},
                    new[] {0, 6, 6, 4, 3},
                    new[] {0, 6, 6, 4, 3, 2},
                    new[] {0, 6, 6, 5, 4, 3},
                    new[] {0, 6, 6, 5, 4, 3, 2},
                    new[] {0, 6, 6, 6, 5, 4, 3},
                    new[] {0, 6, 6, 6, 5, 4, 3, 2},
                    new[] {0, 6, 6, 6, 6, 5, 4, 3},
                    new[] {0, 6, 6, 6, 6, 5, 4, 3, 2},
                    new[] {0, 6, 6, 6, 6, 6, 5, 4, 3},
                    new[] {0, 6, 6, 6, 6, 6, 5, 4, 3, 2},
                    new[] {0, 6, 6, 6, 6, 6, 6, 5, 4, 3},
                    new[] {0, 6, 6, 6, 6, 6, 6, 5, 4, 3},
                    new[] {0, 6, 6, 6, 6, 6, 6, 6, 5, 4},
                    new[] {0, 6, 6, 6, 6, 6, 6, 6, 5, 4},
                    new[] {0, 6, 6, 6, 6, 6, 6, 6, 6, 5},
                    new[] {0, 6, 6, 6, 6, 6, 7, 6, 6, 5},
                    new[] {0, 6, 6, 6, 6, 6, 7, 6, 6, 6},
                    new[] {0, 6, 6, 6, 6, 6, 7, 7, 6, 6},
                    new[] {0, 6, 6, 6, 6, 6, 7, 7, 7, 6},
                    new[] {0, 6, 6, 6, 6, 6, 7, 7, 7, 7},
                };
                SpellsLevelEntry[] cantrips = new SpellsLevelEntry[]
    {
                new SpellsLevelEntry(),
    };
                levels.AddRange(cantrips);
                levels.AddRange(additionalSlotTables.Select(slots => new SpellsLevelEntry { Count = slots }));
                CasterSlots.Levels = levels.ToArray();
            }
            private static void BaseWorldcrawlSpontaneousSpellKnown(BlueprintSpellsTable CasterSlots) {
                List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>();
                var additionalSlotTables = new List<int[]>
                    {
                    new[] {0, 6},
                    new[] {0, 7},
                    new[] {0, 8},
                    new[] {0, 8, 5},
                    new[] {0, 8, 7},
                    new[] {0, 8, 8, 5},
                    new[] {0, 8, 8, 6},
                    new[] {0, 8, 8, 7, 5},
                    new[] {0, 8, 8, 8, 6},
                    new[] {0, 8, 8, 8, 7, 4},
                    new[] {0, 8, 8, 8, 7, 5},
                    new[] {0, 8, 8, 8, 8, 5, 4},
                    new[] {0, 8, 8, 8, 8, 6, 5},
                    new[] {0, 8, 8, 8, 8, 6, 6, 4},
                    new[] {0, 8, 8, 8, 8, 7, 6, 5},
                    new[] {0, 8, 8, 8, 8, 7, 7, 5, 4},
                    new[] {0, 8, 8, 8, 8, 8, 7, 6, 5},
                    new[] {0, 8, 8, 8, 8, 8, 8, 6, 5, 3},
                    new[] {0, 8, 8, 8, 8, 8, 8, 7, 6, 4},
                    new[] {0, 8, 8, 8, 8, 8, 8, 7, 7, 5},
                };

            //new[] { 0, 6 },
            //        new[] { 0, 8 },
            //        new[] { 0, 10 },
            //        new[] { 0, 10, 5 },
            //        new[] { 0, 10, 7 },
            //        new[] { 0, 10, 8, 5 },
            //        new[] { 0, 10, 9, 6 },
            //        new[] { 0, 10, 10, 7, 5 },
            //        new[] { 0, 10, 10, 8, 6 },
            //        new[] { 0, 10, 10, 8, 7, 4 },
            //        new[] { 0, 10, 10, 9, 7, 5 },
            //        new[] { 0, 10, 10, 9, 8, 5, 4 },
            //        new[] { 0, 10, 10, 10, 8, 6, 5 },
            //        new[] { 0, 10, 10, 10, 8, 6, 6, 4 },
            //        new[] { 0, 10, 10, 10, 9, 7, 6, 5 },
            //        new[] { 0, 10, 10, 10, 9, 7, 7, 5, 4 },
            //        new[] { 0, 10, 10, 10, 9, 8, 7, 6, 5 },
            //        new[] { 0, 10, 10, 10, 10, 8, 8, 6, 5, 3 },
            //        new[] { 0, 10, 10, 10, 10, 9, 8, 7, 6, 4 },
            //        new[] { 0, 10, 10, 10, 10, 9, 9, 7, 7, 5 },

                SpellsLevelEntry[] cantrips = new SpellsLevelEntry[]
    {
                new SpellsLevelEntry(),
    };
                levels.AddRange(cantrips);
                levels.AddRange(additionalSlotTables.Select(slots => new SpellsLevelEntry { Count = slots }));
                CasterSlots.Levels = levels.ToArray();
            }
            private static void BaseWorldcrawlHybridSpellProgression(BlueprintSpellsTable CasterSlots) {
                List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>();
                var additionalSlotTables = new List<int[]>
                    {
                    new[] {0, 4},
                    new[] {0, 5},
                    new[] {0, 6},
                    new[] {0, 6, 4},
                    new[] {0, 7, 5},
                    new[] {0, 7, 6},
                    new[] {0, 8, 7, 4},
                    new[] {0, 8, 7, 5},
                    new[] {0, 8, 8, 6},
                    new[] {0, 8, 8, 7, 4},
                    new[] {0, 8, 8, 7, 5},
                    new[] {0, 8, 8, 8, 6},
                    new[] {0, 8, 8, 8, 7, 4},
                    new[] {0, 8, 8, 8, 7, 5},
                    new[] {0, 8, 8, 8, 8, 6},
                    new[] {0, 8, 8, 8, 8, 7, 4},
                    new[] {0, 8, 8, 8, 8, 7, 5},
                    new[] {0, 8, 8, 8, 8, 8, 6},
                    new[] {0, 8, 8, 8, 8, 8, 7},
                    new[] {0, 8, 8, 8, 8, 8, 7},

                };
                SpellsLevelEntry[] cantrips = new SpellsLevelEntry[]
    {
                new SpellsLevelEntry(),
    };
                levels.AddRange(cantrips);
                levels.AddRange(additionalSlotTables.Select(slots => new SpellsLevelEntry { Count = slots }));
                CasterSlots.Levels = levels.ToArray();
            }
            private static void HalfSpellsKnown(BlueprintSpellsTable CasterSlots) {
                List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>();
                var additionalSlotTables = new List<int[]>
                    {
                    new[] {0},
                    new[] {0},
                    new[] {0},
                    new[] {0, 2},
                    new[] {0, 3},
                    new[] {0, 4},
                    new[] {0, 5, 2},
                    new[] {0, 6, 3},
                    new[] {0, 6, 4},
                    new[] {0, 6, 6, 2},
                    new[] {0, 6, 6, 3},
                    new[] {0, 6, 6, 4},
                    new[] {0, 6, 6, 5, 2},
                    new[] {0, 6, 6, 6, 3},
                    new[] {0, 6, 6, 6, 4},
                    new[] {0, 6, 6, 6, 5},
                    new[] {0, 6, 6, 6, 6},
                };
                SpellsLevelEntry[] cantrips = new SpellsLevelEntry[]
    {
                new SpellsLevelEntry(),
    };
                levels.AddRange(cantrips);
                levels.AddRange(additionalSlotTables.Select(slots => new SpellsLevelEntry { Count = slots }));
                CasterSlots.Levels = levels.ToArray();
            }

        private static void HalfSpellsPerKnown(BlueprintSpellsTable CasterSlots) {
            List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>();
            var additionalSlotTables = new List<int[]>
                {
                    new[] {0},
                    new[] {0},
                    new[] {0},
                    new[] {0, 3},
                    new[] {0, 4},
                    new[] {0, 5},
                    new[] {0, 6, 3},
                    new[] {0, 7, 4},
                    new[] {0, 7, 5},
                    new[] {0, 7, 7, 3},
                    new[] {0, 7, 7, 4},
                    new[] {0, 7, 7, 5},
                    new[] {0, 7, 7, 6, 3},
                    new[] {0, 7, 7, 7, 4},
                    new[] {0, 7, 7, 7, 5},
                    new[] {0, 7, 7, 7, 6},
                    new[] {0, 7, 7, 7, 7},
                };
            SpellsLevelEntry[] cantrips = new SpellsLevelEntry[]
{
                new SpellsLevelEntry(),
};
            levels.AddRange(cantrips);
            levels.AddRange(additionalSlotTables.Select(slots => new SpellsLevelEntry { Count = slots }));
            CasterSlots.Levels = levels.ToArray();
        }

        private static void MergedPatchSpontanousCasterSpellProgression(BlueprintSpellsTable fullCasterSlots) {
            List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>();
            var additionalSlotTables = new List<int[]>
                {
                    new[] {0, 3 },
                    new[] {0, 3 },
                    new[] {0, 4 },
                    new[] {0, 5, 3 },
                    new[] {0, 6, 3 },
                    new[] {0, 6, 5 },
                    new[] {0, 6, 6, 3 },
                    new[] {0, 6, 6, 4 },
                    new[] {0, 6, 6, 5 },
                    new[] {0, 6, 6, 6, 3 },
                    new[] {0, 6, 6, 6, 4 },
                    new[] {0, 6, 6, 6, 5 },
                    new[] {0, 6, 6, 6, 6, 3 },
                    new[] {0, 6, 6, 6, 6, 4 },
                    new[] {0, 6, 6, 6, 6, 5 },
                    new[] {0, 6, 6, 6, 6, 6, 3 },
                    new[] {0, 6, 6, 6, 6, 6, 4 },
                    new[] {0, 6, 6, 6, 6, 6, 5 },
                    new[] {0, 6, 6, 6, 6, 6, 6, 3 },
                    new[] {0, 6, 6, 6, 6, 6, 6, 4 },
                    new[] {0, 6, 6, 6, 6, 6, 6, 5 },
                    new[] {0, 6, 6, 6, 6, 6, 6, 6, 3 },
                    new[] {0, 6, 6, 6, 6, 6, 6, 6, 4 },
                    new[] {0, 6, 6, 6, 6, 6, 6, 6, 5 },
                    new[] {0, 6, 6, 6, 6, 6, 6, 6, 6, 3 },
                    new[] {0, 6, 6, 6, 6, 6, 6, 6, 6, 4 },
                    new[] {0, 6, 6, 6, 6, 6, 6, 6, 6, 5 },
                    new[] {0, 6, 6, 6, 6, 6, 6, 6, 6, 6 },
                };
            SpellsLevelEntry[] cantrips = new SpellsLevelEntry[]
            {
                new SpellsLevelEntry(),
            };
            levels.AddRange(cantrips);
            levels.AddRange(additionalSlotTables.Select(slots => new SpellsLevelEntry { Count = slots }));
            fullCasterSlots.Levels = levels.ToArray();
        }

        private static void MythicSpellsKnown(BlueprintSpellsTable fullCasterSlots) {
            List<SpellsLevelEntry> levels = new List<SpellsLevelEntry>();
            var additionalSlotTables = new List<int[]>
                {
                    new[] {0, 2 },
                    new[] {0, 3 },
                    new[] {0, 3 },
                    new[] {0, 4, 2 },
                    new[] {0, 4, 3 },
                    new[] {0, 4, 3 },
                    new[] {0, 4, 4, 2 },
                    new[] {0, 4, 4, 3 },
                    new[] {0, 4, 4, 3 },
                    new[] {0, 4, 4, 4, 2 },
                    new[] {0, 4, 4, 4, 3 },
                    new[] {0, 4, 4, 4, 3 },
                    new[] {0, 4, 4, 4, 4, 3 },
                    new[] {0, 4, 4, 4, 4, 3 },
                    new[] {0, 4, 4, 4, 4, 4 },
                    new[] {0, 4, 4, 4, 4, 4, 2 },
                    new[] {0, 4, 4, 4, 4, 4, 3 },
                    new[] {0, 4, 4, 4, 4, 4, 3 },
                    new[] {0, 4, 4, 4, 4, 4, 3, 2 },
                    new[] {0, 4, 4, 4, 4, 4, 3, 3 },
                    new[] {0, 4, 4, 4, 4, 4, 3, 3 },
                    new[] {0, 4, 4, 4, 4, 4, 3, 3, 2 },
                    new[] {0, 4, 4, 4, 4, 4, 3, 3, 3 },
                    new[] {0, 4, 4, 4, 4, 4, 3, 3, 3 },
                    new[] {0, 4, 4, 4, 4, 4, 3, 3, 3, 2 },
                    new[] {0, 4, 4, 4, 4, 4, 3, 3, 3, 3 },
                    new[] {0, 4, 4, 4, 4, 4, 3, 3, 3, 3 },
                    new[] {0, 4, 4, 4, 4, 4, 3, 3, 3, 3 },
                };
            SpellsLevelEntry[] cantrips = new SpellsLevelEntry[]
            {
                new SpellsLevelEntry(),
            };
            levels.AddRange(cantrips);
            levels.AddRange(additionalSlotTables.Select(slots => new SpellsLevelEntry { Count = slots }));
            fullCasterSlots.Levels = levels.ToArray();
        }

    }
    }






