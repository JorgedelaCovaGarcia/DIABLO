using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaDeMuerte : MonoBehaviour, IInteractuable
{
    private Outline outline;
    [SerializeField] private MisionSO mision;
    [SerializeField] private EventManager eventManager;
  
    public void Interactuar(Transform interactor)
    {
        mision.repeticionActual++;//aumentamos en 1 la repeticion de la mision

        //todavía quedan setas por recoger.
        if(mision.repeticionActual < mision.totalRepeticiones)
        {
            eventManager.ActualizarMision(mision);
        }
        else
        {
            eventManager.TerminarMision(mision);
        }
        
        Destroy(gameObject);
    }
    private void Awake()
    {
        outline = GetComponent<Outline>();

    }
    private void OnMouseEnter()
    {
        outline.enabled = true;

    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
