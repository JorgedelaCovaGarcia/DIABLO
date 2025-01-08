using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Transform ruta;

    private NavMeshAgent agent;

    private List<Vector3> listadoPuntos = new List<Vector3>();

    private int indiceDestinoActual = 0;

    private Vector3 destinoActual;
    void Start()
    {
        StartCoroutine(PatrullarYEsperar());
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        {
            foreach (Transform t in ruta)
            {
                listadoPuntos.Add(t.position);
            }
        }
    }
    private IEnumerator PatrullarYEsperar()
    {
        while(true)
        {
            CalcularDestino();
            agent.SetDestination(destinoActual);
            yield return new WaitUntil( () => agent.remainingDistance <= 0);

            yield return new WaitForSeconds(UnityEngine.Random.Range(0.25f, 3f));
        }
    }
    
    private void CalcularDestino()
    {
        indiceDestinoActual++;
        if(indiceDestinoActual > listadoPuntos.Count)
        {
            indiceDestinoActual = 0;
        }

        destinoActual = listadoPuntos[indiceDestinoActual];
    }
}
