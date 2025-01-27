using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMision : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoMision;

    private Toggle toggleVisual;

    public TMP_Text TextoMision { get => textoMision; set => textoMision = value; }

    private void Awake()
    {
        toggleVisual = GetComponent<Toggle>();
    }
}
