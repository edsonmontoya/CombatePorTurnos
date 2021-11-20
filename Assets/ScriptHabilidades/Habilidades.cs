using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Habilidades : MonoBehaviour
{
    [SerializeField] List<Habilidad> listaHabilidades;
    public Transform habilidadesHijos;
    [SerializeField] SlotHabilidades[] slotshabilidades;
    public event Action<SlotHabilidades> OnPointerEnterEvent;
    public event Action<SlotHabilidades> OnPointerExitEvent;
    public event Action<SlotHabilidades> OnRightClickEvent;
    public event Action<SlotHabilidades> OnBeginDragEvent;
    public event Action<SlotHabilidades> OnEndDragEvent;
    public event Action<SlotHabilidades> OnDragEvent;
    public event Action<SlotHabilidades> OnDropEvent;
    // Start is called before the first frame update


    private void Awake()
    {
        for (int i = 0; i < slotshabilidades.Length; i++)
        {
            slotshabilidades[i].OnPointerEnterEvent += OnPointerEnterEvent;
            slotshabilidades[i].OnPointerExitEvent += OnPointerExitEvent;
            slotshabilidades[i].OnRightClickEvent += OnRightClickEvent;
            slotshabilidades[i].OnBeginDragEvent += OnBeginDragEvent;
            slotshabilidades[i].OnEndDragEvent += OnEndDragEvent;
            slotshabilidades[i].OnDragEvent += OnDragEvent;
            slotshabilidades[i].OnDropEvent += OnDropEvent;
        }
        ActualizandoUIHabilidades();
    }


    private void OnValidate()
    {
        if (habilidadesHijos != null)
        {
            slotshabilidades = habilidadesHijos.GetComponentsInChildren<SlotHabilidades>();
        }
        ActualizandoUIHabilidades();
        //habilidadesHijos = habilidadesHijos.GetComponentInChildren<SlotHabilidades>(1);
    }
    //Establecemos la lista y la cantidad de slots asi como tambien la actualizacion de la lista
    public void ActualizandoUIHabilidades()
    {
        int i = 0;
        for (; i < listaHabilidades.Count && i < slotshabilidades.Length; i++)
        {
            slotshabilidades[i].habilidad = listaHabilidades[i];
        }
        for (; i < slotshabilidades.Length; i++)
        {
            slotshabilidades[i].habilidad = null;
        }
    }
    //Agregamos los objetos, si esta lleno retorna falso
    public bool AgregarHabilidades(Habilidad habilidad)
    {
        for (int i = 0; i < slotshabilidades.Length; i++)
        {
            if(slotshabilidades[i].habilidad == null)
            {
                slotshabilidades[i].habilidad = habilidad;
                return true;
            }
        }
        return false;
    }
    //Quitamos los objetos y actualizamos la lista
    public bool QuitarHabilidades(Habilidad habilidad)
    {
        for (int i = 0; i < slotshabilidades.Length; i++)
        {
            if (slotshabilidades[i].habilidad == habilidad)
            {
                slotshabilidades[i].habilidad = null;
                return true;
            }
        }
        return false;
    }
    public bool estaLleno()
    {
        for (int i = 0; i < slotshabilidades.Length; i++)
        {
            if (slotshabilidades[i].habilidad == null)
            {
                return false;
            }
        }
        return true;
    }
}
