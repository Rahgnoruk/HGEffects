using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Scriptable Resistance", menuName ="HyperGnosys/Combat(Effects)/Scriptable Resistance")]
public class ScriptableResistance : ScriptableObject
{
    [SerializeField]
    private EffectType resistanceType;
    [SerializeField]
    private float resistanceAmount = 20;

    public EffectType ResistanceType { get => resistanceType; set => resistanceType = value; }
    public float ResistanceAmount { get => resistanceAmount; set => resistanceAmount = value; }
}