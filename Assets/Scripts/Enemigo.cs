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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
