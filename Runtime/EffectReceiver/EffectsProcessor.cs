using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HyperGnosys.Effects
{
    /// <summary>
    /// El componente esta hecho para que a partir de un UnityEvent<GameObject> 
    /// se mande a llamar ReceiveCollision.
    /// </summary>
    public abstract class EffectsProcessor : MonoBehaviour
    {
        [SerializeField] private bool debugging = true;
        /// <summary>
        /// Tiene que ser Tooltip porque poner Help evita que se serialice la lista
        /// </summary>
        [Tooltip("Si colocas resistencias a mano no las hagas constantes. " +
            "\nSi este componente es donde se van a sumar las resistencias recibidas por el personaje " +
            "(de objetos, hechizos, donde sea) deja la lista de resistencias vacia o ponle resistencias editables," +
            "ya que al recibir nuevas resistencias le sumara el valor de las nuevas a las viejas." +
            "Si se agrega una resistencia cuyo ResistanceType aun no está en la lista, se crea una nueva instancia " +
            "de ResistanceReference y la agrega a la lista. Estas nuevas Resistance References son No Constantes y " +
            "no usan ScriptableValue")]
        [SerializeField] private List<ResistanceReference> resistances = new List<ResistanceReference>();
        [Space]
        [Tooltip("Si en el juego la reducción de efectos puede hacer que llegues a números negativos," +
            "pon esta opción en verdadero. Esto se puede usar si quieres que el daño pueda curar" +
            "el excedente de resistencia o las curaciones hagan daño reflejar el daño.")]
        [SerializeField] private bool canHaveNegativeEffectMagnitudes = true;
        [Space]
        [Tooltip("Si en el juego tu resistencia puede bajar de 0 pon esta opción verdadera." +
            "Por ejemplo para si las criaturas pueden ser vulnerables a ciertos DamageTypes.")]
        [SerializeField] private bool canHaveNegativeResistance = true;
        [Space]
        [Tooltip("Si seleccionas esta opción, al momento de recibir aumentos de resistencia, " +
            "se asegurara de que no pase del maxReduction. El valor por defecto esta " +
            "para el modo de reducción de daño por porcentaje. ")]
        [SerializeField] private bool limitEffectReduction = true;
        [SerializeField] private float maxReduction = 0.90f;
        [SerializeField] protected UnityEvent<EffectList> OnReceivedEffects = new UnityEvent<EffectList>();

        public abstract void ReceiveEffects(EffectList effects);
        public void AddResistances(List<ResistanceReference> newResistances)
        {
            foreach (ResistanceReference newResistance in newResistances)
            {
                bool matchfound = false;
                foreach (ResistanceReference resistance in Resistances)
                {
                    if (newResistance.ResistanceType.Equals(resistance.ResistanceType))
                    {
                        resistance.Value += newResistance.Value;
                        if (LimitDamageReduction && resistance.Value > MaxReduction)
                        {
                            resistance.Value = MaxReduction;
                        }
                        matchfound = true;
                    }
                }
                if (!matchfound)
                {
                    if (LimitDamageReduction && newResistance.Value > MaxReduction)
                    {
                        Resistances.Add(new ResistanceReference(MaxReduction, newResistance.ResistanceType));
                    }
                    else
                    {
                        Resistances.Add(new ResistanceReference(newResistance));
                    }
                }
            }
        }
        public void RemoveResistances(List<ResistanceReference> removedResistances)
        {
            foreach (ResistanceReference removedResistance in removedResistances)
            {
                bool matchfound = false;
                foreach (ResistanceReference resistance in Resistances)
                {
                    if (removedResistance.ResistanceType.Equals(resistance.ResistanceType))
                    {
                        resistance.Value -= removedResistance.Value;
                        if (!CanHaveNegativeResistance && resistance.Value < 0)
                        {
                            resistance.Value = 0;
                        }
                        matchfound = true;
                    }
                }
                if (!matchfound)
                {
                    if (!CanHaveNegativeResistance && removedResistance.Value < 0)
                    {
                        Resistances.Add(new ResistanceReference(0, removedResistance.ResistanceType));
                    }
                    else
                    {
                        Resistances.Add(new ResistanceReference(removedResistance));
                    }
                }
            }
        }
        protected List<ResistanceReference> Resistances { get => resistances; set => resistances = value; }
        protected bool CanHaveNegativeDamage { get => canHaveNegativeEffectMagnitudes; set => canHaveNegativeEffectMagnitudes = value; }
        protected bool CanHaveNegativeResistance { get => canHaveNegativeResistance; set => canHaveNegativeResistance = value; }
        protected float MaxReduction { get => maxReduction; set => maxReduction = value; }
        protected bool LimitDamageReduction { get => limitEffectReduction; set => limitEffectReduction = value; }
        public bool Debugging { get => debugging; set => debugging = value; }
    }
}