using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Misi�n")]
public class MisionSO : ScriptableObject
{
    public string ordenInicial;
    public string ordenFinal;
    public bool tieneRepeticion;
    public int totalRepeticiones;
    public int indiceMision; //indice unico que representa a cada mision

    [NonSerialized]
    public int repeticionActual;


    
}
