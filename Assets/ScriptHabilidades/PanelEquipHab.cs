using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PanelEquipHab : MonoBehaviour
{
    [SerializeField] Transform slotsEquipHabHijos;
    [SerializeField] SlotsEquipHab[] slotsEquipHab;
    public event Action<SlotHabilidades> OnPointerEnterEvent;
    public event Action<SlotHabilidades> OnPointerExitEvent;
    public event Action<SlotHabilidades> OnRightClickEvent;
    public event Action<SlotHabilidades> OnBeginDragEvent;
    public event Action<SlotHabilidades> OnEndDragEvent;
    public event Action<SlotHabilidades> OnDragEvent;
    public event Action<SlotHabilidades> OnDropEvent;

    private void Awake()
    {
        for (int i = 0; i < slotsEquipHab.Length; i++)
        {
            slotsEquipHab[i].OnPointerEnterEvent += OnPointerEnterEvent;
            slotsEquipHab[i].OnPointerExitEvent += OnPointerExitEvent;
            slotsEquipHab[i].OnRightClickEvent += OnRightClickEvent;
            slotsEquipHab[i].OnBeginDragEvent += OnBeginDragEvent;
            slotsEquipHab[i].OnEndDragEvent += OnEndDragEvent;
            slotsEquipHab[i].OnDragEvent += OnDragEvent;
            slotsEquipHab[i].OnDropEvent += OnDropEvent;
        }
        
    }
    private void OnValidate()
    {
        slotsEquipHab = slotsEquipHabHijos.GetComponentsInChildren<SlotsEquipHab>();
    }
    public bool AgregarHabilidad(HabilidadEquipable habilidad, out HabilidadEquipable habilidadAnterior)
    {
        for (int i = 0; i < slotsEquipHab.Length; i++)
        {
            if (slotsEquipHab[i].TipoHabilidad == habilidad.TipoHabilidad)
            {
                habilidadAnterior = (HabilidadEquipable)slotsEquipHab[i].habilidad;
                slotsEquipHab[i].habilidad = habilidad;
                return true;
            }
        }
        habilidadAnterior = null;
        return false;
    }
    public bool QuitarHabilidad(HabilidadEquipable habilidad)
    {
        for (int i = 0; i < slotsEquipHab.Length; i++)
        {
            if (slotsEquipHab[i].habilidad == habilidad)
            {
                slotsEquipHab[i].habilidad = null;
                return true;
            }
        }
        return false;
    }

}
