using UnityEngine;

namespace HyperGnosys.Effects
{
    [System.Serializable]
    public class Effect
    {
        [SerializeField] private float effectMagnitude;
        [SerializeField] private EffectType effectType;

        public float EffectMagnitude { get => effectMagnitude; set => effectMagnitude = value; }
        public EffectType EffectType { get => effectType; set => effectType = value; }
    }
}