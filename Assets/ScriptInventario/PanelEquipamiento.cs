using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PanelEquipamiento : MonoBehaviour
{
    [SerializeField] Transform slotsEquipamientoHijos;
    [SerializeField] SlotsEquipamiento[] slotsEquipamientos;
    public event Action<Objeto> OnItemRightClickedEvent;

    private void Awake()
    {
        for (int i = 0; i < slotsEquipamientos.Length; i++)
        {
            slotsEquipamientos[i].OnRightClickEvent += OnItemRightClickedEvent;
        }
    }
    private void OnValidate()
    {
        slotsEquipamientos = slotsEquipamientoHijos.GetComponentsInChildren<SlotsEquipamiento>();
    }
    public bool AgregarObjeto(ObjetoEquipable objeto, out ObjetoEquipable objetoAnterior)
    {
        for (int i = 0; i< slotsEquipamientos.Length; i++)
        {
            if(slotsEquipamientos[i].TipoEquipamiento == objeto.TipoEquipamiento)
            {
                objetoAnterior = (ObjetoEquipable)slotsEquipamientos[i].Objeto;
                slotsEquipamientos[i].Objeto = objeto;
                return true;
            }
        }
        objetoAnterior = null;
        return false;
    }
    public bool QuitarObjeto(ObjetoEquipable objeto)
    {
        for (int i = 0; i < slotsEquipamientos.Length; i++)
        {
            if (slotsEquipamientos[i].Objeto == objeto)
            {
                slotsEquipamientos[i].Objeto = null;
                return true;
            }
        }
        return false;
    }

}
