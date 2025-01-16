using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public SistemaPatrulla patrulla;
    private SistemaCombate combate;

    private Transform target;

    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public SistemaCombate Combate { get => combate; set => combate = value; }
    public Transform Target { get => target; set => target = value; }
    
    public void ActivarCombate(Transform target)
    {
        patrulla.enabled = false;
        Combate.enabled = true;
        this.target = target;
    }

    public void ActivarPatrulla()
    {
        combate.enabled = false;
        patrulla.enabled = true;
    }

    void Start()
    {
        //Empieza el juego y se activa la patrulla
        patrulla.enabled = true ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
