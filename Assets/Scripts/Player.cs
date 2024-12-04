using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Creo un rayo desde la camara a la posicion del raton
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            //Y si ese rayo impacta en algo...
            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                //Le decimos al agente(nosotros) que tiene como destino el punto de impacto.
                agent.SetDestination(hitInfo.point);
            }
        }
        
       
    }

}
