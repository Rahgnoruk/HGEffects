using HyperGnosys.Core;
using UnityEngine;

namespace HyperGnosys.Effects
{
    public abstract class ABaseEffectApplier : MonoBehaviour, IEffectApplier
    {
        [SerializeField] private bool debugging = true;
        [SerializeField] private ExternalizableLabeledProperty<float> targetProperty;
        public abstract void ApplyEffects(EffectList effectList);
        public bool Debugging { get => debugging; set => debugging = value; }
        protected ExternalizableLabeledProperty<float> TargetProperty { get => targetProperty; set => targetProperty = value; }
    }
}