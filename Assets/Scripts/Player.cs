using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    private Transform ultimoClick;
    
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        if (Time.timeScale == 1)
        {
            Movimiento();
        }
        
        ComprobarInteraccion();
    }

    private void Movimiento()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Creo un rayo desde la camara a la posicion del raton
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            //Y si ese rayo impacta en algo...
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                //Le decimos al agente(nosotros) que tiene como destino el punto de impacto.
                agent.SetDestination(hitInfo.point);

                ultimoClick = hitInfo.transform;
            }
        }
    }
    private void ComprobarInteraccion()
    {
        //Si existe un interactuable al cual clické y lleva consigo el script NPC...
        if(ultimoClick != null && ultimoClick.TryGetComponent(out NPC npc))
        {
            //Actualizo distancia de parada para no "comerme" al npc.
            agent.stoppingDistance = 2f;

            //Mira a ver si hemos llegado a dicho destino.
            if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                //Y por lo tanto, interactuo con el npc
                npc.Interactuar(this.transform);

                //Me olvido del ultimo click porque solo quiero interactuar una vez
                ultimoClick = null;
            }
        }
        //Si no es un npc, si no que es un click en el suelo...
        else if(ultimoClick)
        {
            //Reseteo el stoppingDistance original.
            agent.stoppingDistance = 0f;
        }
    }
}
