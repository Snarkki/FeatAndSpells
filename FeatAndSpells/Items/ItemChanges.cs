using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;
using Kingmaker.Blueprints.Classes;
using static FeatAndSpells.Main;
using static FeatAndSpells.Blueprints.Items;
using Kingmaker.Blueprints;

namespace FeatAndSpells.Items {
    public class ItemChanges {

        public static void Itemhandler() {
            ChangeArmors();
        }

        private static void ChangeArmors() {
            //heavies

            BandedArmor.m_ArmorBonus = 9;
            FullPlate.m_ArmorBonus = 10;
            HalfPlate.m_ArmorBonus = 9;

            BandedArmor.m_MaxDexterityBonus = 3;
            FullPlate.m_MaxDexterityBonus = 1;
            HalfPlate.m_MaxDexterityBonus = 3;

            // mediums
            BreastPlate.m_ArmorBonus = 8;
            ChainMail.m_ArmorBonus = 8;
            HideArmor.m_ArmorBonus = 8;
            ScaleMail.m_ArmorBonus = 8;

            ChainMail.m_MaxDexterityBonus = 5;
            HideArmor.m_MaxDexterityBonus = 5;
            ScaleMail.m_MaxDexterityBonus = 5;
            // lights
            ChainShirt.m_ArmorBonus = 6;
            ChainShirt.m_MaxDexterityBonus = 7;

            StudLeather.m_ArmorBonus = 5;
            StudLeather.m_MaxDexterityBonus = 8;

            Leather.m_ArmorBonus = 4;
            Leather.m_MaxDexterityBonus = 9;
            // shieldit
            BucklerShield.m_ArmorBonus = 2;
            HeavyShield.m_ArmorBonus = 4;
            LightShield.m_ArmorBonus = 3;
            TowerShield.m_ArmorBonus = 6;

            FASContext.Logger.LogHeader("Changed Mutation warrior");
        }
    }
}
