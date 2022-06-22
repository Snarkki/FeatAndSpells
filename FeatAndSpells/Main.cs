using HarmonyLib;
using FeatAndSpells.ModLogic;
using TabletopTweaks.Core.Utilities;
using UnityModManagerNet;

namespace FeatAndSpells {
    static class Main {
        public static bool Enabled;
        public static ModContextMCEBase FASContext;
        static bool Load(UnityModManager.ModEntry modEntry) {
            var harmony = new Harmony(modEntry.Info.Id);
            FASContext = new ModContextMCEBase(modEntry);
            FASContext.LoadAllSettings();
            FASContext.ModEntry.OnSaveGUI = OnSaveGUI;
            FASContext.ModEntry.OnGUI = UMMSettingsUI.OnGUI;
            harmony.PatchAll();
            PostPatchInitializer.Initialize(FASContext);
            return true;
        }

        static void OnSaveGUI(UnityModManager.ModEntry modEntry) {
            FASContext.SaveAllSettings();
        }
    }
}
