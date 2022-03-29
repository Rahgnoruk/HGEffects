using System.Collections.Generic;
using UnityEngine;

namespace HyperGnosys.Effects
{
    [System.Serializable]
    public class EffectList
    {
        /// <summary>
        /// Tiene que ser Tooltip porque poner Help evita que se serialice la lista
        /// </summary>
        [Tooltip("Si la defensa es AmountSubstraction, evita agregar dos Damages del mismo tipo ya que " +
            "la resistencia se restara dos veces, uno a cada Damage. A menos, claro, que esa sea tu intencion")]
        [SerializeField] private List<EffectProperty> effects = new List<EffectProperty>();
        public List<EffectProperty> Effects { get => effects; set => effects = value; }
    }
}