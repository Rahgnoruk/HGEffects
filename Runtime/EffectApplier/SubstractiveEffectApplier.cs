using HyperGnosys.Core;

namespace HyperGnosys.Effects
{
    public class SubstractiveEffectApplier : ABaseEffectApplier
    {
        public override void ApplyEffects(EffectList effectList)
        {

            foreach (EffectProperty effect in effectList.Effects)
            {
                HGDebug.Log($"Applying effect {effect.Value.EffectType.name} with magnitude {effect.Value.EffectMagnitude}"
                    , Debugging);
                TargetProperty.Value -= effect.Value.EffectMagnitude;
            }
        }
    }
}