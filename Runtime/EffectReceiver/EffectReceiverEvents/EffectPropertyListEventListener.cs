using HyperGnosys.Core;
using HyperGnosys.Effects;
using UnityEngine;
public class EffectPropertyListEventListener : AEventListenerComponent<EffectList>
{
    public override void OnEventRaised(EffectList effectList)
    {
        base.OnEventRaised(effectList);
        HGDebug.Log($"GameObject Event Listener in {transform.name} transmitting effect list", EventListener.Debugging);
    }
}