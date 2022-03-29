using HyperGnosys.Effects;

namespace HyperGnosys.CombatModule
{

    /// <summary>
    /// Parent class requires Toucher and subscribes the ToucherObserverMethod
    /// to it on Start.
    /// </summary>
    public class AmountSubstractionEffectsProcessor : EffectsProcessor
    {
        ///Se busca la resistencia de cada damage en la lista y se resta la 
        ///resistencia al damage. Si no hay una resistencia entonces el damage
        ///se agrega completo al total damage.
        ///SI HAY DOS DAMAGES DEL MISMO TIPO EN LA LISTA, SE RESTARA LA RESISTENCIA
        ///A CADA UNO. El ataque debe sumar los damages del mismo tipo para que esto no pase
        public override void ReceiveEffects(EffectList effects)
        {
            EffectList reducedEffects = new EffectList();

            foreach (EffectProperty effect in effects.Effects)
            {
                bool resistanceFound = false;
                foreach (ResistanceReference resistance in Resistances)
                {
                    if (resistance.ResistanceType.Equals(effect.Value.EffectType))
                    {
                        float amountResisted = resistance.Value;
                        if (LimitDamageReduction && amountResisted > MaxReduction)
                        {
                            amountResisted = MaxReduction;
                        }
                        float reducedEffect = effect.Value.EffectMagnitude - resistance.Value;
                        if (!CanHaveNegativeDamage && reducedEffect < 0)
                        {
                            reducedEffect = 0;
                        }
                        reducedEffects.Effects.Add(new EffectProperty(reducedEffect, effect.Value.EffectType));
                        resistanceFound = true;
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