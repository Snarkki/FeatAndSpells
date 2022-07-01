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
using static FeatAndSpells.Blueprints.Buffs;
using static FeatAndSpells.Blueprints.Abilities;
using TabletopTweaks.Core.Utilities;
using Kingmaker.Blueprints.Classes;
using static FeatAndSpells.Main;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities;

namespace FeatAndSpells.Spells {
    public class SpellChanges {

        public static void SpellChangeHandler() {
            AddFrighteningChange();
            AddSpells();
            ChangeDRSpells();
            ChangeDmgSpells();
            //ChangeSizeSpells();
        }

        private static void AddFrighteningChange() {

            //FrightenedSystemBuff

            FrightenedBuff.SetDescription(FASContext, "A frightened creature takes a –2" +
                " {g|Encyclopedia:Penalty}penalty{/g} on all {g|Encyclopedia:Attack}attack rolls{/g}, " +
                "{g|Encyclopedia:Saving_Throw}saving throws{/g}, {g|Encyclopedia:Skills}skill checks{/g}," +
                " and {g|Encyclopedia:Ability_Scores}ability checks{/g}. " +
                "A frightened creature may start to flee from its enemies, but is unable to move.");

            BlueprintComponent wSlowed = Helpers.Create<AddCondition>(c => {
                c.Condition = UnitCondition.CantMove;
            });
            FrightenedBuff.AddComponent(wSlowed);

            FASContext.Logger.LogHeader("Changed Spells: Frightened");
        }

        public static void AddSpells() {
            
            HurricaneBow.Range = AbilityRange.Close;
            MagicFangGreater.AddToSpellList(SpellTools.SpellList.ClericSpellList, 5);
            MagicFangGreater.AddToSpellList(SpellTools.SpellList.WitchSpellList, 5);
            MagicFangGreater.AddToSpellList(SpellTools.SpellList.ShamanSpelllist, 5);
            MageArmor.AddToSpellList(SpellTools.SpellList.MagusSpellList, 1);
            MageArmor.AddToSpellList(SpellTools.SpellList.AlchemistSpellList, 1);
            Echolocation.AddToSpellList(SpellTools.SpellList.RangerSpellList, 4);
            Eaglesoul.AddToSpellList(SpellTools.SpellList.RangerSpellList, 4);
            HealMass.AddToSpellList(SpellTools.SpellList.WitchSpellList, 9);
            InstantEnemy.AddToSpellList(SpellTools.SpellList.InquisitorSpellList, 3);
            FASContext.Logger.LogHeader("Changed Spells: spellbookadditions");
        }
        public static void ChangeDRSpells() {

            var ProtFromArrowConfig = ProtFromArrow.GetComponent<ContextRankConfig>();
            ProtFromArrowConfig.m_StepLevel = 100;
            ProtFromArrowConfig.m_Max = 1500;
            var ProtFromArrowDmgRes = ProtFromArrow.GetComponent<AddDamageResistancePhysical>();
            ProtFromArrowDmgRes.BypassedByMagic = false;        
            var StoneSkinConfig = StoneSkin.GetComponent<ContextRankConfig>();
            StoneSkinConfig.m_StepLevel = 100;
            StoneSkinConfig.m_Max = 1000;
            var ComStoneSkinConfig = StoneSkinCom.GetComponent<ContextRankConfig>();
            ComStoneSkinConfig.m_StepLevel = 100;
            ComStoneSkinConfig.m_Max = 1000;
            FASContext.Logger.LogHeader("Patched DR spell changes");
        }

        public static void ChangeDmgSpells() {

            //var FireballConfig = Fireball.GetComponent<ContextRankConfig>();
            //FireballConfig.m_Max = 15;
            //var ControlledFireballConfig = ControlledFireball.GetComponent<ContextRankConfig>();
            //ControlledFireballConfig.m_Max = 15;
            //var SnowballConfig = Snowball.GetComponent<ContextRankConfig>();
            //SnowballConfig.m_Max = 10;
            //var MagicMissileConfig = MagicMissile.GetComponent<ContextRankConfig>();
            //MagicMissileConfig.m_Max = 10;

            //var FireSnakeC = FireSnake.GetComponent<ContextRankConfig>();
            //FireSnakeC.m_Max = 20;
            //var ConeOfColdC = ConeOfCold.GetComponent<ContextRankConfig>();
            //ConeOfColdC.m_Max = 20;
            //var AcidicSprayC = AcidicSpray.GetComponent<ContextRankConfig>();
            //AcidicSprayC.m_Max = 20;
            var ArrowOfLawC = ArrowOfLaw.GetComponent<ContextRankConfig>();
            ArrowOfLawC.m_Max = 20;
            var OrdersWrathC = OrdersWrath.GetComponent<ContextRankConfig>();
            OrdersWrathC.m_Max = 20;
            var HolySmiteC = HolySmite.GetComponent<ContextRankConfig>();
            HolySmiteC.m_Max = 20;

            var ScorchingRayConfig = ScorchingRay.GetComponent<ContextRankConfig>();
            ScorchingRayConfig.m_Max = 5;

            //BurningArc.AddToSpellList(SpellTools.SpellList.ShamanSpelllist, 2);
            //ScorchingRay.AddToSpellList(SpellTools.SpellList.ShamanSpelllist, 2);
            BurningArc.AddToSpellList(SpellTools.SpellList.WitchSpellList, 2);
            ScorchingRay.AddToSpellList(SpellTools.SpellList.WitchSpellList, 2);
            //Fireball.AddToSpellList(SpellTools.SpellList.ShamanSpelllist, 3);
            //ControlledFireball.AddToSpellList(SpellTools.SpellList.ShamanSpelllist, 4);
            // AbilityEffectRunAction  typeId: 66e032e5cf38801428940a1a0d14b946
            //ContextConditionHitDice  typeId: ffac81c4dcead2c4286c31f1b5227ba9
            //BlueprintAbility Scare = Resources.GetBlueprint<BlueprintAbility>("08cb5f4c3b2695e44971bf5c45205df0");
            //var maxHd = Scare.GetComponent<AbilityEffectRunAction>();
            //var tete = maxHd.Actions.GetActions

        }


        public static void ChangeSizeSpells() {

            EnlargePersonBuff.RemoveComponents<ChangeUnitSize>();
            ReducePersonBuff.RemoveComponents<ChangeUnitSize>();

            AnimalGrowthBuff.Components = new BlueprintComponent[] {
                Helpers.Create<AddContextStatBonus>( c => {
                    c.Stat = Kingmaker.EntitySystem.Stats.StatType.Strength;
                    c.Value = new ContextValue() {
                                    ValueType = ContextValueType.Simple,
                                    Value = 10,
                                    ValueRank = AbilityRankType.Default,
                                    ValueShared = AbilitySharedValue.Damage,
                                    Property = Kingmaker.UnitLogic.Mechanics.Properties.UnitProperty.None
                                };
                    c.Descriptor = Kingmaker.Enums.ModifierDescriptor.Size;
                }),
                Helpers.Create<AddContextStatBonus>( c => {
                    c.Stat = Kingmaker.EntitySystem.Stats.StatType.Constitution;
                                        c.Value = new ContextValue() {
                                    ValueType = ContextValueType.Simple,
                                    Value = 6,
                                    ValueRank = AbilityRankType.Default,
                                    ValueShared = AbilitySharedValue.Damage,
                                    Property = Kingmaker.UnitLogic.Mechanics.Properties.UnitProperty.None
                                };
                    c.Descriptor = Kingmaker.Enums.ModifierDescriptor.Size;
                }),
                Helpers.Create<AddContextStatBonus>( c => {
                    c.Stat = Kingmaker.EntitySystem.Stats.StatType.AC;
                                        c.Value = new ContextValue() {
                                    ValueType = ContextValueType.Simple,
                                    Value = 3,
                                    ValueRank = AbilityRankType.Default,
                                    ValueShared = AbilitySharedValue.Damage,
                                    Property = Kingmaker.UnitLogic.Mechanics.Properties.UnitProperty.None
                                };
                    c.Multiplier = 1;
                    c.Descriptor = Kingmaker.Enums.ModifierDescriptor.NaturalArmorEnhancement;
                }),
            };
            AnimalGrowthBuff.SetDescription(FASContext, "Animal Growth gives your animal companion +10 strength, +6 constitution and +3 natual armour enchantment. It does not actually change the size of the animal!");

            //ReducePersonBuff
        }
    }
}
