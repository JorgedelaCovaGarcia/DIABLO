using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Misión")]
public class MisionSO : ScriptableObject
{
    public string ordenInicial;
    public string ordenFinal;
    public bool tieneRepeticion;
    public int totalRepeticiones;
    public int indiceMision; //indice unico que representa a cada mision

    [SerializeField]
    public int repeticionActual;


    
}
