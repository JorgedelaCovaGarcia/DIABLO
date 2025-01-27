using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventManager")]
public class EventManager : MonoBehaviour
{
    //creo un evento.
    public event Action<MisionSO> OnNuevaMision;
    public void NuevaMision(MisionSO mision)
    {
        //Lanzar/disparar el evento/notificacion.
        OnNuevaMision.Invoke(mision);
    }
}
