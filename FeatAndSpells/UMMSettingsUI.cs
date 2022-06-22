﻿using TabletopTweaks.Core.UMMTools;
using UnityModManagerNet;

namespace FeatAndSpells {
    internal static class UMMSettingsUI {
        private static int selectedTab;
        public static void OnGUI(UnityModManager.ModEntry modEntry) {
            UI.AutoWidth();
            UI.TabBar(ref selectedTab,
                    () => UI.Label("SETTINGS WILL NOT BE UPDATED UNTIL YOU RESTART YOUR GAME.".yellow().bold()),
                    new NamedAction("Added Content", () => SettingsTabs.AddedContent()),
                    new NamedAction("Fixes", () => SettingsTabs.Fixes())
            );
        }
    }

    internal static class SettingsTabs {

        public static void AddedContent() {
            var TabLevel = SetttingUI.TabLevel.Zero;
            var AddedContent = Main.FASContext.AddedContent;
            UI.Div(0, 15);
            using (UI.VerticalScope()) {
                UI.Toggle("New Settings Off By Default".bold(), ref AddedContent.NewSettingsOffByDefault);
                UI.Space(25);
                SetttingUI.SettingGroup("Toys", TabLevel, AddedContent.Toys);
            }
        }

        public static void Fixes() {
            var TabLevel = SetttingUI.TabLevel.Zero;
            var Fixes = Main.FASContext.Fixes;
            UI.Div(0, 15);
            using (UI.VerticalScope()) {
                UI.Toggle("New Settings Off By Default".bold(), ref Fixes.NewSettingsOffByDefault);
                UI.Space(25);

                SetttingUI.SettingGroup("Miscellaneous", TabLevel, Fixes.Miscellaneous);
            }
        }



    }
}
