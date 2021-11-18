using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventario : MonoBehaviour
{
    [SerializeField] List<Objeto> listaObjetos;
    public Transform objetosHijos;
    [SerializeField] SlotObjetos[] slotsObjetos;
    public event Action<SlotObjetos> OnPointerEnterEvent;
    public event Action<SlotObjetos> OnPointerExitEvent;
    public event Action<SlotObjetos> OnRightClickEvent;
    public event Action<SlotObjetos> OnBeginDragEvent;
    public event Action<SlotObjetos> OnEndDragEvent;
    public event Action<SlotObjetos> OnDragEvent;
    public event Action<SlotObjetos> OnDropEvent;

    private void Awake()
    {
        for (int i = 0; i < slotsObjetos.Length; i++)
        {
            slotsObjetos[i].OnPointerEnterEvent += OnPointerEnterEvent;
            slotsObjetos[i].OnPointerExitEvent += OnPointerExitEvent;
            slotsObjetos[i].OnRightClickEvent += OnRightClickEvent;
            slotsObjetos[i].OnBeginDragEvent += OnBeginDragEvent;
            slotsObjetos[i].OnEndDragEvent += OnEndDragEvent;
            slotsObjetos[i].OnDragEvent += OnDragEvent;
            slotsObjetos[i].OnDropEvent += OnDropEvent;
        }
        ActualizandoUI();
    }
    private void OnValidate()
    {
        if (objetosHijos != null)
        {
            slotsObjetos = objetosHijos.GetComponentsInChildren<SlotObjetos>();
        }
        ActualizandoUI();
    }
    //Establecemos la lista y la cantidad de slots asi como tambien la actualizacion de la lista
    private void ActualizandoUI()
    {
        int i = 0;
        for (; i < listaObjetos.Count && i < slotsObjetos.Length; i++)
        {
           slotsObjetos[i].Objeto = listaObjetos[i];
        }
        for (; i < slotsObjetos.Length; i++)
        {
            slotsObjetos[i].Objeto = null;
        }
    }
    //Agregamos los objetos, si esta lleno retorna falso
    public bool AgregarItem(Objeto Objeto)
    {
        for (int i = 0; i < slotsObjetos.Length; i++)
        {
            if(slotsObjetos[i].Objeto == null)
            {
                slotsObjetos[i].Objeto = Objeto;
                return true;
            }
        }
        return false;
    }
    //Quitamos los objetos y actualizamos la lista
    public bool QuitarObjetos(Objeto Objeto)
    {
        for (int i = 0; i < slotsObjetos.Length; i++)
        {
            if (slotsObjetos[i].Objeto == Objeto)
            {
                slotsObjetos[i].Objeto = null;
                return true;
            }
        }
        return false;
    }
    public bool estaLleno()
    {
        for (int i = 0; i < slotsObjetos.Length; i++)
        {
            if (slotsObjetos[i].Objeto == null)
            {
                
                return false;
            }
        }
        return true;
    }
}
