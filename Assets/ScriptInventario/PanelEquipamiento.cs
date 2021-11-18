using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PanelEquipamiento : MonoBehaviour
{
    [SerializeField] Transform slotsEquipamientoHijos;
    [SerializeField] SlotsEquipamiento[] slotsEquipamientos;
    public event Action<SlotObjetos> OnPointerEnterEvent;
    public event Action<SlotObjetos> OnPointerExitEvent;
    public event Action<SlotObjetos> OnRightClickEvent;
    public event Action<SlotObjetos> OnBeginDragEvent;
    public event Action<SlotObjetos> OnEndDragEvent;
    public event Action<SlotObjetos> OnDragEvent;
    public event Action<SlotObjetos> OnDropEvent;

    private void Awake()
    {
        for (int i = 0; i < slotsEquipamientos.Length; i++)
        {
            slotsEquipamientos[i].OnPointerEnterEvent += OnPointerEnterEvent;
            slotsEquipamientos[i].OnPointerExitEvent += OnPointerExitEvent;
            slotsEquipamientos[i].OnRightClickEvent += OnRightClickEvent;
            slotsEquipamientos[i].OnBeginDragEvent += OnBeginDragEvent;
            slotsEquipamientos[i].OnEndDragEvent += OnEndDragEvent;
            slotsEquipamientos[i].OnDragEvent += OnDragEvent;
            slotsEquipamientos[i].OnDropEvent += OnDropEvent;
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
