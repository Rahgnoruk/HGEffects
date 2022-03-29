using HyperGnosys.Core;
using HyperGnosys.Effects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HyperGnosys.CombatModule
{
    public class FilteredEffectApplier : MonoBehaviour, IEffectApplier
    {
        [SerializeField] private bool debugging = true;
        [SerializeField] private ABaseEffectApplier effectApplier;
        [SerializeField] private List<EffectType> filteredEffectTypes;
        public bool Debugging { get => debugging; set => debugging = value; }
        public ABaseEffectApplier EffectApplier { get => effectApplier; set => effectApplier = value; }
        public List<EffectType> FilteredEffectTypes { get => filteredEffectTypes; set => filteredEffectTypes = value; }

        public void ApplyEffects(EffectList effectList)
        {
            HGDebug.Log("FilteredEffectApplier in " + transform.name + " activated", debugging);
            List<EffectProperty> filteredEffects
                = effectList.Effects.Where(effect => !filteredEffectTypes.Contains(effect.Value.EffectType)).ToList();
            effectApplier.ApplyEffects(effectList);
        }
    }
}