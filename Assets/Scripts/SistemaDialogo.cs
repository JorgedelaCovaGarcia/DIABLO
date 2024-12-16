using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    //PATRÓN SINGL-TON
    //1. Sólo existe una única instancia de SistemaDialogo.
    //2. Es accesible DESDE CUALQUIER PUNTO del programa.

    [SerializeField] private GameObject marcoDialogo;
    [SerializeField] private TMP_Text textoDialogo;
    [SerializeField] private Transform npcCamera;


    private bool escribiendo;
    private int indiceFraseActual = 0;

    private Dialogo dialogoActual;

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

    public void IniciarDialogo(Dialogo dialogo, Transform cameraPoint)
    {
        Time.timeScale = 0;

        dialogoActual = dialogo;
        marcoDialogo.SetActive(true);
        npcCamera.SetPositionAndRotation(cameraPoint.position, cameraPoint.rotation);
        StartCoroutine(EscribirFrase());
    }

    private IEnumerator EscribirFrase()
    {
        escribiendo = true;
        textoDialogo.text = string.Empty;
        char[] fraseEnLetras = dialogoActual.frases[indiceFraseActual].ToCharArray();

        foreach (char letra in fraseEnLetras)
        {
            textoDialogo.text += letra;
            yield return new WaitForSecondsRealtime(dialogoActual.tiempoEntreLetras);
        }
        escribiendo = false;
    }

    private void CompletarFrase()
    {
        textoDialogo.text = dialogoActual.frases[indiceFraseActual];
        StopAllCoroutines();
        escribiendo = false;
    }
    public void SiguienteFrase()
    {
        if(!escribiendo)
        {
            indiceFraseActual++;
            if (indiceFraseActual < dialogoActual.frases.Length)
            {
                StartCoroutine(EscribirFrase());
            }
            else
            {
                FinalizarDialogo();
            }
        }
        else
        {
            CompletarFrase();
        }
    }
    private void FinalizarDialogo()
    {
        Time.timeScale = 1.0f;

        marcoDialogo.SetActive(false);
        indiceFraseActual = 0;
        escribiendo = false ;
        dialogoActual = null;

    }
   
}
