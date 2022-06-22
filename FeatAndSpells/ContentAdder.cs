using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using static FeatAndSpells.Main;

namespace FeatAndSpells {
    class ContentAdder {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch {
            static bool Initialized;

            [HarmonyAfter(new string[] { "TabletopTweaks-Base" })]
            static void Postfix() {
                if (Initialized) return;
                Initialized = true;
                FASContext.Logger.LogHeader("Creating feat & spells");
                // EI TOIMI OIKEIN HAJOTTAA TB
                //Abilities.OathbreakersDirectionFeature.AddOathbreakersDirection();
                Abilities.OtherChanges.OtherChangesHandler();
                Abilities.AuraOfCowardice.AddAuraOfCowardiceFeature();
                Abilities.ShareSpells.SharedSpells.load();
                Spells.SpellChanges.SpellChangeHandler();
                Spells.NewSpells.HandleNewSpells();
                Spells.SpellProgressionEdits.SpellProgressionProcessing();


                Companions.CompanionChanges.CompanionHandler();
                //Items.ItemChanges.Itemhandler();
                Items.Weapons.Handler();
            //    // 
                FASContext.Logger.LogHeader("Class Changes");
                Classes.Alchemist.ChangeHandler();
                Classes.Fighter.ChangeHandler();
                Classes.Cleric.ChangeHandler();
                Classes.Arcanist.ChangeHandler();
                Classes.Oracle.ChangeHandler();
                Classes.Inquisitor.ChangeHandler();
                Classes.Magus.ChangeHandler();
                Classes.PaladinTemplar.ChangeHandler();
                Classes.Ranger.ChangeHandler();
                Classes.Rogue.ChangeHandler();
                Classes.Shaman.ChangeHandler();
                Classes.Slayer.ChangeHandler();
                Classes.Sorcerer.ChangeHandler();
                Classes.Witch.ChangeHandler();
                //
                //darkcodex stuff
                Abilities.MythicAbilities.MythicHandler();
                //Abilities.WitchAbilities.WitchHandler();
            }
        }
    }
}
