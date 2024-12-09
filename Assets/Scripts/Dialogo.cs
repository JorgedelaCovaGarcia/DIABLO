using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogo")]
public class Dialogo : ScriptableObject
{
    [TextArea]
    public string[] frases;
    public float tiempoEntreLetras;
    
}
