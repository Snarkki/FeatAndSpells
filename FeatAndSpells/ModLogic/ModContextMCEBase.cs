using FeatAndSpells.Config;
using TabletopTweaks.Core.ModLogic;
using static UnityModManagerNet.UnityModManager;

namespace FeatAndSpells.ModLogic {
    internal class ModContextMCEBase : ModContextBase {
        public AddedContent AddedContent;
        public Fixes Fixes;

        public ModContextMCEBase(ModEntry ModEntry) : base(ModEntry) {
            LoadAllSettings();
#if DEBUG
            Debug = true;
#endif
        }
        public override void LoadAllSettings() {
            LoadSettings("AddedContent.json", "FeatAndSpells.Config", ref AddedContent);
            LoadSettings("Fixes.json", "FeatAndSpells.Config", ref Fixes);
            LoadBlueprints("FeatAndSpells.Config", Main.FASContext);
            LoadLocalization("FeatAndSpells.Localization");
        }

        public override void AfterBlueprintCachePatches() {
            base.AfterBlueprintCachePatches();
        }

        public override void SaveAllSettings() {
            base.SaveAllSettings();
            SaveSettings("AddedContent.json", AddedContent);
            SaveSettings("Fixes.json", Fixes);
        }
    }
}
