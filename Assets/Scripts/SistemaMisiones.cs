using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] 
    private EventManager eventManager;

    [SerializeField]
    private ToggleMision[] togglesMision;

    private void OnEnable()
    {
        eventManager.OnNuevaMision += EncenderToggleMision;
        eventManager.OnActualizarMision += ActualizarToggleMision;
        eventManager.OnTerminarMision += TerminarToggleMision;
    }

    private void EncenderToggleMision(MisionSO mision)
    {
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;
        if(mision.tieneRepeticion)
        {
            togglesMision[mision.indiceMision].TextoMision.text += "(" + mision.repeticionActual + "/" + mision.totalRepeticiones + ")";
        }
        togglesMision[mision.indiceMision].gameObject.SetActive(true);
    }
    private void ActualizarToggleMision(MisionSO mision)
    {
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;
        togglesMision[mision.indiceMision].TextoMision.text += "(" + mision.repeticionActual + "/" + mision.totalRepeticiones + ")";
    }
    private void TerminarToggleMision(MisionSO mision)
    {
        togglesMision[mision.indiceMision].ToggleVisual.isOn = true;
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenFinal;
    }

   
}
