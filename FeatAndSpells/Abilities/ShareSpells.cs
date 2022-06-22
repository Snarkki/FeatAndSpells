using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeatAndSpells.Blueprints;
using static FeatAndSpells.Blueprints.Archetypes;
using static FeatAndSpells.Blueprints.Features;
using static FeatAndSpells.Blueprints.FeatureSelections;
using static FeatAndSpells.Blueprints.SpellBooks;
using static FeatAndSpells.Blueprints.CharacterClasses;
using TabletopTweaks.Core.Utilities;
using Kingmaker.Blueprints.Classes;
using static FeatAndSpells.Main;
using Kingmaker.Blueprints;
using HarmonyLib;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Utility;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic;
using Kingmaker.EntitySystem.Entities;

namespace FeatAndSpells.Abilities {
    public class ShareSpells {
        [HarmonyPatch(typeof(AbilityData), nameof(AbilityData.TargetAnchor), MethodType.Getter)]
        [HarmonyPatch(new Type[] { typeof(AbilityData) })]
        static class ShareSpell_patch {
            static void Postfix(ref AbilityTargetAnchor __result, AbilityData __instance) // AbilityData __this, 
            {
                if (__instance.Blueprint.Range == AbilityRange.Personal && __instance.Blueprint.School == SpellSchool.Transmutation) //
                {
                    __result = SharedSpells.canShareSpell(__instance) ? AbilityTargetAnchor.Unit : AbilityTargetAnchor.Owner;
                    //__result = AbilityTargetAnchor.Unit;
                }
            }
        }

        [HarmonyPatch(typeof(AbilityData), nameof(AbilityData.CanTarget))]
        class AbilityData__CanTarget__Patch {
            static bool Prefix(AbilityData __instance, TargetWrapper target, ref bool __result) {
                {
                    if (__instance.Blueprint.Range == AbilityRange.Personal && __instance.Blueprint.School == SpellSchool.Transmutation && SharedSpells.canShareSpell(__instance)) {
                        if (target.Unit == __instance.Caster.Unit) {
                            __result = true;
                            return true;
                        }
                        if (target.Unit.IsPet && target.Unit.Master == __instance.Caster.Unit) {
                            __result = true;
                            return false;
                            ////__result = SharedSpells.isValidShareSpellTarget(target.Unit, __instance.Caster);
                        }
                        __result = false;
                        return false;
                    }
                    __result = false;
                    return true;
                }
            }
        }

        public class SharedSpells {

            public static BlueprintFeatureSelection[] ac_selections;
            public static BlueprintFeature ac_share_spell;

            internal static void load() {
                ac_selections = new BlueprintFeatureSelection[]{
                                                            BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("48525e5da45c9c243a343fc6545dbdb9"), //domain
                                                            BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("90406c575576aee40a34917a1b429254"), //base
                                                            BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("3830f3630a33eba49b60f511b4c8f2a8"), //druid
                                                            BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("d91228368cb523a43ad17104adf26ba5"), //maddog
                                                            BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("b705c5184a96a84428eeb35ae2517a14"), //ranger
                                                            BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("2995b36659b9ad3408fd26f137ee2c67"), //sacred huntsmaster
                                                            BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("a540d7dfe1e2a174a94198aba037274c"), //sylvan sorcerer
                                                            };
                createClassSharedSpell();

            }

            private static void createClassSharedSpell() {

                BlueprintAbility magic_fang = BlueprintTools.GetBlueprint<BlueprintAbility>("403cf599412299a4f9d5d925c7b9fb33");
                //ac_share_spell = Helpers.CreateFeature("ShareSpellAnimalCompanion",
                //                             "Share Spells (Companion)",
                //                             "You may cast a spell with a range of Personal on your companion (as a touch range spell) instead of on yourself. This ability does not allow the companion to share abilities that are not spells, even if they function like spells.",
                //                             "",
                //                             magic_fang.Icon,
                //                             FeatureGroup.None);
                ac_share_spell = Helpers.CreateBlueprint<BlueprintFeature>(FASContext, "ShareSpellAnimalCompanion", bp => {
                    bp.SetName(FASContext, "Share Spells (Companion)");
                    bp.SetDescription(FASContext, "You may cast a spell with a range of Personal on your companion (as a touch range spell) instead of on yourself. This ability does not allow the companion to share abilities that are not spells, even if they function like spells.");
                    bp.m_Icon = magic_fang.Icon;
                });

                foreach (var selection in ac_selections) {
                    selection.AddComponent<AddFacts>(c => {
                        c.m_Facts = new BlueprintUnitFactReference[] { ac_share_spell.ToReference<BlueprintUnitFactReference>() };
                    });
                }
            }

            public static bool canShareSpell(AbilityData ability_data) {
                if (ability_data.Blueprint.Type != AbilityType.Spell) {
                    return false;
                }
                return (ability_data.Caster.HasFact(ac_share_spell) && ability_data.Spellbook != null);
            }

            public static bool isValidShareSpellTarget(UnitEntityData target, UnitDescriptor caster) {

                return (target.IsPet && caster.Unit == target && caster.HasFact(ac_share_spell) && target.Master == caster);
            }


        }
    }
}