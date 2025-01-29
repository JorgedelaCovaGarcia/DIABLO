using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class NPC : MonoBehaviour , IInteractuable
{
    [SerializeField] private EventManager eventManager;
    [SerializeField] private MisionSO miMision;
    [SerializeField] private Dialogo dialogoActual;
    [SerializeField] private Dialogo dialogo1;
    [SerializeField] private Dialogo dialogo2;
    [SerializeField] private Dialogo miDialogo;
    [SerializeField] private float duracionRotacion;
    [SerializeField] private Transform cameraPoint;


    private void Awake()
    {
        dialogoActual = dialogo1;
    }

    private void OnEnable()
    {
        eventManager.OnTerminarMision += CambiarDialogo;
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
        if(miMision == misionTerminada)
        {
            dialogoActual = dialogo2;
        }
    }
    public void Interactuar()
    {
        throw new NotImplementedException();
    }

    internal void Interactuar(Transform interactuador)
    {
        //Poco a poco voy rotando haia el interactuador y cuando termine de rotarme... se inicia la interaccion
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y).OnComplete(IniciarInteraccion);
    }

    private void IniciarInteraccion()
    {
        SistemaDialogo.sistema.IniciarDialogo(dialogoActual, cameraPoint);

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
