using UnityEngine;

namespace HyperGnosys.Effects
{
    [System.Serializable]
    public class ResistanceReference
    {
        [SerializeField] private bool debugging = true;
        [SerializeField] private bool useScriptableValue = true;
        [Tooltip("Solo necesitas asignar los valores locales si no usas el ScriptableValue")]
        [SerializeField] private float localValue;
        [SerializeField] private EffectType localResistanceType;
        [SerializeField] private ScriptableResistance scriptableResistance;

        public ResistanceReference(float localValue, EffectType localResistanceType)
        {
            UseScriptableValue = false;
            this.localValue = localValue;
            this.localResistanceType = localResistanceType;
            scriptableResistance = null;
        }

        public ResistanceReference(ResistanceReference other)
        {
            UseScriptableValue = false;
            localValue = other.Value;
            localResistanceType = other.ResistanceType;
            scriptableResistance = null;
        }

        public float Value
        {
            get
            {
                return UseScriptableValue ? scriptableResistance.ResistanceAmount : localValue;
            }
            set
            {
                if (UseScriptableValue)
                {
                    scriptableResistance.ResistanceAmount = value;
                }
                else
                {
                    localValue = value;
                }
            }
        }
        public EffectType ResistanceType
        {
            get
            {
                return UseScriptableValue ? scriptableResistance.ResistanceType : localResistanceType;
            }
        }
        public bool UseScriptableValue { get => useScriptableValue; set => useScriptableValue = value; }
    }
}