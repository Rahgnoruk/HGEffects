using HyperGnosys.Core;
using HyperGnosys.Effects;

public class EffectPropertyListGameEvent : AEventComponent<EffectList>
{
    public override void Raise(EffectList effects)
    {
        base.Raise(effects);
        HGDebug.Log($"GameObject Game Event in { transform.name } raising List of EffectReferences", GameEvent.Debugging);
    }
}