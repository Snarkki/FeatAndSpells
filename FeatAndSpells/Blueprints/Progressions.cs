
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;

namespace FeatAndSpells.Blueprints {
    public class Progressions {


        public static BlueprintProgression OrderOfNailProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("e506d5dee7944b50824054c6526c6532");

        public static BlueprintProgression SpecialisationSchoolTransmutationProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("b6a604dab356ac34788abf4ad79449ec");
        public static BlueprintProgression BasicFeatProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("5b72dd2ca2cb73b49903806ee8986325");

        public static BlueprintProgression MythicCompanionProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("21e74c19da02acb478e32da25abd9d28");
        public static BlueprintProgression MythicStartingProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("af4ee0acb9114e544bf02f39027966b0");
        public static BlueprintProgression AeonProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("34b9484b0d5ce9340ae51d2bf9518bbe");
        public static BlueprintProgression AngelProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("2f6fe889e91b6a645b055696c01e2f74");
        public static BlueprintProgression AzataProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("9db53de4bf21b564ca1a90ff5bd16586");
        public static BlueprintProgression DemonProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("285fe49f7df8587468f676aa49362213");
        public static BlueprintProgression DevilProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("87bc9abf00b240a44bb344fea50ec9bc");
        public static BlueprintProgression GoldenDragonProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("a6fbca43902c6194c947546e89af64bd");
        public static BlueprintProgression LegendProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("905383229aaf79e4b8d7e2d316b68715");
        public static BlueprintProgression LichProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("ccec4e01b85bf5d46a3c3717471ba639");
        public static BlueprintProgression SwarmThatWalksProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("bf5f103ccdf69254abbad84fd371d5c9");
        public static BlueprintProgression TricksterProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("cc64789b0cc5df14b90da1ffee7bbeea");

        public static BlueprintProgression InquisitorProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("4e945c2fe5e252f4ea61eee7fb560017");
        public static BlueprintProgression OracleProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("5dd9b4982c9ed0b4090d5a35c459b729");
        public static BlueprintProgression BardProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("8127f5ff40f5b484b8be98609358b9d2");
        public static BlueprintProgression SkaldProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("26418fed2bc153245972a5b54204ed75");
        
        public static BlueprintProgression clericClassProgress = BlueprintTools.GetBlueprint<BlueprintProgression>("b2cd67193d1199f41bc6ecec3a2f2c87");
        public static BlueprintProgression WitchProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("c5e9e2b086a9814409fb6a29a5acdd0f");
        public static BlueprintProgression WizardProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("02f3049806dbf62459259ea8cae8f715");
        public static BlueprintProgression ShamanProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("d04a543c82b45694c805301bce9dac24");
        public static BlueprintProgression DruidProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("01006f2ac8866764fb7af135e73be81c");
        public static BlueprintProgression WarpriestProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("062b215705430ad47b7174c1e75d285e");
        public static BlueprintProgression BloodragerProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("69dec3bda9a94914bb159cba128300b9");
        public static BlueprintProgression PaladinProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("fd325cbba872e5f40b618970678db002");
        public static BlueprintProgression ClericProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("b2cd67193d1199f41bc6ecec3a2f2c87");
        public static BlueprintProgression ArcanistProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("974911193b8a8b947a8275f96bb265d6");
        public static BlueprintProgression AlchemistProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("efd55ff9be2fda34981f5b9c83afe4f1");
        public static BlueprintProgression MagusProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("1b912721a7e075d4f9cfe8dafa39414c");
        public static BlueprintProgression RangerProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("97261d609529d834eba4fd4da1bc44dc");
        public static BlueprintProgression HunterProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("f4943530be50c3c4da841a7b96cfae98");

        public static BlueprintProgression WitchShadowPatronProgression = BlueprintTools.GetBlueprint<BlueprintProgression>("f48bfffe3618c274dbd42dfff8d0df56");

        public static List<BlueprintProgression> PreparedCasterList = new List<BlueprintProgression>() {
            clericClassProgress,
            WitchProgression,
            WizardProgression,
            ShamanProgression,
            DruidProgression,
            WarpriestProgression,
            BloodragerProgression,
            PaladinProgression,
            clericClassProgress,
            ArcanistProgression,
            AlchemistProgression,
            MagusProgression,
            RangerProgression,
            HunterProgression
        };
    }
}



