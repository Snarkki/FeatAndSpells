using TabletopTweaks.Core.Config;

namespace FeatAndSpells.Config {
    public class AddedContent : IUpdatableSettings {
        public bool NewSettingsOffByDefault = true;
        public SettingGroup Toys = new SettingGroup();

        public void Init() {
        }

        public void OverrideSettings(IUpdatableSettings userSettings) {
            var loadedSettings = userSettings as AddedContent;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            Toys.LoadSettingGroup(loadedSettings.Toys, NewSettingsOffByDefault);
        }
    }
}
