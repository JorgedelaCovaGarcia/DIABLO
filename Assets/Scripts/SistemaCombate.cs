using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float velocidadCombate;
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private float danhoAtaque;
    [SerializeField] private Animator anim;

    private void Awake()
    {
        main.Combate = this;
    }

    private void OnEnable() //El combate ha sido activado
    {
        agent.speed = velocidadCombate;
        agent.stoppingDistance = distanciaAtaque;
    }
    private void Update()
    {
        //Solo si existe un objetivo y es alcanzable...
        if(main.Target != null && agent.CalculatePath(main.Target.position, new NavMeshPath()))
        {
            EnfocarObjetivo();

            //Perseguimos al objetivo
            agent.SetDestination(main.Target.position);

            //Cuando tenga al objetivo a distancia de ataque...
            if(!agent.pathPending && agent.remainingDistance <= distanciaAtaque)
            {
                //atacar --> Ejecutar animacion
                anim.SetBool("atacarEnemigo", true);
            }

        }
        else
        {
            //Deshabilitamos script de combate
            main.ActivarPatrulla();
        }
        
    }

    private void EnfocarObjetivo()
    {
        Vector3 direccionATarget = (main.Target.transform.position - transform.position).normalized;
        direccionATarget.y = 0;
        Quaternion rotacionATarget = Quaternion.LookRotation(direccionATarget); 
        transform.rotation = rotacionATarget;

    }

    #region Ejecutados por evento de animación
    private void Atacar()
    {
        //Hacer daño al target.
        main.Target.GetComponent<Player>().HacerDanho(danhoAtaque);

    }
    private void FinAnimacionAtaque()
    {
        anim.SetBool("atacarEnemigo", false);
    }
    #endregion
}
