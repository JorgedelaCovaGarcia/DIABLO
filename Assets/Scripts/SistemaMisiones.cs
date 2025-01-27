using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] 
    private EventManager eventManager;

    [SerializeField]
    private GameObject[] toggleMision;//coleccion toggles

    [SerializeField]
    private ToggleMision[] togglesMision;

    private void OnEnable()
    {
        eventManager.OnNuevaMision += EncenderToggleMision;
    }

    private void EncenderToggleMision(MisionSO mision)
    {

    }
    private void EncenderToggleMision()
    {
        
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
