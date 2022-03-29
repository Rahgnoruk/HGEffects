using HyperGnosys.Core;
using HyperGnosys.Effects;
using UnityEngine;

namespace HyperGnosys.CombatModule
{
    public class PercentageSubstractionEffectsProcessor : EffectsProcessor
    {
        public override void ReceiveEffects(EffectList effects)
        { 
            HGDebug.Log($"Percentage Substraction Effect Receiver in {transform.name} is reducing effects", Debugging);
            EffectList reducedEffects = new EffectList();
            ///Se busca la resistencia de cada damage en la lista y se reduce en el  
            ///porcentaje de resistencia que haya en la lista. 
            ///Si no hay una resistencia entonces el damage se agrega completo al total damage.
            ///Por características matematicas, en este caso no importa si hay dos damages del mismo tipo, 
            ///ya que no hay problema con que cada uno se reduzca en el mismo porcentaje y luego se sume.
            ///ax + bx = x(a+b)
            foreach (EffectProperty effect in effects.Effects)
            {
                bool resistanceFound = false;
                foreach (ResistanceReference resistance in Resistances)
                {
                    if (resistance.ResistanceType.Equals(effect.Value.EffectType))
                    {
                        resistanceFound = true;
                        float resistancePercentage = resistance.Value;
                        if (LimitDamageReduction && resistance.Value > MaxReduction)
                        {
                            resistancePercentage = MaxReduction;
                        }
                        ///Estas dos lineas son lo que cambia los dos modos de reduccion de daño
                        float percentageReduced = effect.Value.EffectMagnitude * resistancePercentage;
                        float reducedEffect = effect.Value.EffectMagnitude - percentageReduced;
                        if (!CanHaveNegativeDamage && reducedEffect < 0)
                        {
                            reducedEffect = 0;
                        }
                        reducedEffects.Effects.Add(new EffectProperty(reducedEffect, effect.Value.EffectType));
                        break;
                    }
                }
                if (!resistanceFound)
                {
                    reducedEffects.Effects.Add(new EffectProperty(effect));
                }
            }
            this.OnReceivedEffects.Invoke(reducedEffects);
        }
    }
}