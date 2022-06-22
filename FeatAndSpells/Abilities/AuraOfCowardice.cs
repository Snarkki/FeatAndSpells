using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Core.Utilities;
using Kingmaker.Blueprints.Classes;
using static FeatAndSpells.Main;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using Kingmaker.Utility;
using Kingmaker.UnitLogic.Mechanics.Conditions;

namespace FeatAndSpells.Abilities {
    internal class AuraOfCowardice {

        public static void AddAuraOfCowardiceFeature() {
            var AOCIcon = AssetLoader.LoadInternal(FASContext, "Abilities", "Icon_AOC.png");
            var AuraOfCowardiceEffectBuff = Helpers.CreateBlueprint<BlueprintBuff>(FASContext, "AuraOfCowardiceEffectBuff", bp => {

                bp.SetName(FASContext, "Aura of Cowardice");
                bp.SetDescription(FASContext, "At 3rd level, a Dread Knight radiates a palpably daunting aura that causes all enemies within 10 " +
                    "feet to take a –4 penalty on saving throws against fear effects. Creatures that are normally immune to fear lose that " +
                    "immunity while within 10 feet of a Dread Knight with this ability. This ability functions only while the Dread Knight remains " +
                    "conscious, not if he is unconscious or dead.");

                bp.IsClassFeature = true;
                bp.m_Icon = AOCIcon;
                bp.AddComponent<SavingThrowBonusAgainstDescriptor>(c => {
                    c.SpellDescriptor = SpellDescriptor.Fear;
                    c.Value = -4;
                });
                bp.AddComponent<AbilityAreaEffectRunAction>(c => {
                    c.Round = Helpers.CreateActionList(
                        new ContextActionRemoveBuffsByDescriptor() {
                            SpellDescriptor = SpellDescriptor.FearImmunity
                        });

                });
            });


            var AuraOfCowardiceArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>(FASContext, "AuraOfCowardiceArea", bp => {

                bp.AggroEnemies = true;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet() { m_Value = 13 };
                bp.AddComponent<AbilityAreaEffectBuff>(c => {
                    c.m_Buff = AuraOfCowardiceEffectBuff.ToReference<BlueprintBuffReference>();
                    c.Condition = new ConditionsChecker() {

                        Conditions = new Condition[] {
                            new ContextConditionIsEnemy()
                        }

                    };

                });
            });

            var AuraOfCowardiceBuff = Helpers.CreateBlueprint<BlueprintBuff>(FASContext, "AuraOfCowardiceBuff", bp => {
                bp.SetName(FASContext, "Aura of Cowardice");
                bp.SetDescription(FASContext, "At 3rd level, a Dread Knight radiates a palpably daunting aura that causes all enemies within 10 " +
                    "feet to take a –4 penalty on saving throws against fear effects. Creatures that are normally immune to fear lose that " +
                    "immunity while within 10 feet of a Dread Knight with this ability. This ability functions only while the Dread Knight remains " +
                    "conscious, not if he is unconscious or dead.");
                bp.m_Icon = AOCIcon;

                bp.IsClassFeature = true;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = AuraOfCowardiceArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
            });

            var AuraOfCowardiceFeature = Helpers.CreateBlueprint<BlueprintFeature>(FASContext, "AuraOfCowardiceFeature", bp => {

                bp.SetName(FASContext, "Aura of Cowardice");
                bp.SetDescription(FASContext, "At 3rd level, a Dread Knight radiates a palpably daunting aura that causes all enemies within 10 " +
                    "feet to take a –4 penalty on saving throws against fear effects. Creatures that are normally immune to fear lose that " +
                    "immunity while within 10 feet of a Dread Knight with this ability. This ability functions only while the Dread Knight remains " +
                    "conscious, not if he is unconscious or dead.");
                bp.m_Icon = AOCIcon;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AuraFeatureComponent>(c => {
                    c.m_Buff = AuraOfCowardiceBuff.ToReference<BlueprintBuffReference>();
                });

            });
        }
    }
}