using HyperGnosys.Core;

namespace HyperGnosys.Effects
{
    [System.Serializable]
    public class EffectProperty : ObservableProperty<Effect>
    {
        public EffectProperty(float localValue, EffectType localEffectType)
        {
            Value = new Effect();
            Value.EffectMagnitude = localValue;
            Value.EffectType = localEffectType;
        }

        public EffectProperty(EffectProperty other)
        {
            Value = new Effect();
            Value.EffectMagnitude = other.Value.EffectMagnitude;
            Value.EffectType = other.Value.EffectType;
        }
    }
}