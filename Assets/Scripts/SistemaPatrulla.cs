using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Transform ruta;

    private List<Transform> listadoPuntos = new List<Transform>();

    private Transform[] array = new Transform[50];
    void Start()
    {
        foreach(Transform punto in ruta)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
