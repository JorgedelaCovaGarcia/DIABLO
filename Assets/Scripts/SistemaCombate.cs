using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float velocidadCombate;

    private void Awake()
    {
        main.Combate = this;
    }

    private void OnEnable()
    {
        agent.speed = velocidadCombate;
    }
    private void Update()
    {
        agent.speed = velocidadCombate; 
        agent.SetDestination(main.Target.position);
    }
}
