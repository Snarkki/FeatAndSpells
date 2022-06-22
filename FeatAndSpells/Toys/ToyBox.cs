using HarmonyLib;
using Kingmaker.UnitLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static FeatAndSpells.Main;

namespace FeatAndSpells.Toys {
    internal class ToyBox {
        [HarmonyPatch(typeof(EncumbranceHelper), "GetHeavy")]
        private static class EncumbranceHelper_GetHeavy_Patch {


            private static void Postfix(ref int __result) {
                if (FASContext.AddedContent.Toys.IsDisabled("WeightLimit")) { return; }

                __result = Mathf.RoundToInt(__result * 999);
            }
                
        }
    }
}
