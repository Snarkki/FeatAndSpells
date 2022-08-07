
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;

namespace FeatAndSpells.Blueprints {
    public class Buffs {
        public static BlueprintBuff DebilitatingInjuryDisorientedEffectBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("1f1e42f8c06d7dc4bb70cc12c73dfb38");
        public static BlueprintBuff DebilitatingInjuryBewilderedEffectBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("22b1d98502050cb4cbdb3679ac53115e");
        public static BlueprintBuff DebilitatingInjuryHamperedEffectBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("5bfefc22a68e736488b0c309d9c1c1d4");
        public static BlueprintBuff PowerfulChangeBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("be5d23755e7e501448193bbbd71c5256");
        public static BlueprintBuff PowerfulChangeBuffGreater = BlueprintTools.GetBlueprint<BlueprintBuff>("d6ccf420a9b196e4cae334e0d3ea9e8b");
        public static BlueprintBuff ShareTransmutationBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("2231eb5d1a5a48d499a20fa5bde7a4e2");
        public static BlueprintBuff ShareTransmutationBuffGreater = BlueprintTools.GetBlueprint<BlueprintBuff>("e0d4e42a41a0a24459a1bfc4f0a3ae4c");
        public static BlueprintBuff FrightenedSystemBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("c4648cecc52c32945a5748098a2b9b32");
        public static BlueprintBuff FrightenedBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("f08a7239aa961f34c8301518e71d4cdf");
        
        public static BlueprintBuff ProtFromArrow = BlueprintTools.GetBlueprint<BlueprintBuff>("10014a817b0780c49a2d2d954f62fa55");
        public static BlueprintBuff StoneSkin = BlueprintTools.GetBlueprint<BlueprintBuff>("7aeaf147211349b40bb55c57fec8e28d");
        public static BlueprintBuff StoneSkinCom = BlueprintTools.GetBlueprint<BlueprintBuff>("714244637d461354b85b1808e7c6c814");

        public static BlueprintBuff EnlargePersonBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("4f139d125bb602f48bfaec3d3e1937cb");
        public static BlueprintBuff ReducePersonBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("b0793973c61a19744a8630468e8f4174");
        public static BlueprintBuff AnimalGrowthBuff = BlueprintTools.GetBlueprint<BlueprintBuff>("3fca5d38053677044a7ffd9a872d3a0a");

    }
}
