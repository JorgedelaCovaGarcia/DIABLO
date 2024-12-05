using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class NPC : MonoBehaviour
{

    [SerializeField] private float duracionRotacion;
    internal void Interactuar(Transform interactuador)
    {
        Debug.Log("Hola !!");
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
