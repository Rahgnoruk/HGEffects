using HyperGnosys.Effects;
using System.Collections.Generic;
using UnityEngine;

public class ResistanceList : MonoBehaviour
{
    [SerializeField] private List<ResistanceReference> resistances = new List<ResistanceReference>();
    public List<ResistanceReference> Resistances { get => resistances; set => resistances = value; }
}