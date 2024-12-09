using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    //PATRÓN SINGL-TON
    //1. Sólo existe una única instancia de SistemaDialogo.
    //2. Es accesible DESDE CUALQUIER PUNTO del programa.


    public static SistemaDialogo sistema;

    // Awake se ejecuta ANTES del Start() independientemente de que el game object este activo o no
    void Awake()
    {
        //Si el troo esta libre...
        if (sistema == null)
        {
            // Me hao con el trono, y entonces SistemaDialogo SOY YO (this).
            sistema = this;
        }
        else
        {
            //Me han quitado el trono, por lo tanto, me mato(soy un falso rey).
            Destroy(this.gameObject);
        }
    }

    public void IniciarDialogo(Dialogo dialogo)
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
