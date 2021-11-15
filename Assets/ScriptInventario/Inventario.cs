using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventario : MonoBehaviour
{
    [SerializeField] List<Objeto> listaObjetos;
    public Transform objetosHijos;
    [SerializeField] SlotObjetos[] slotsObjetos;
    public event Action<Objeto> OnItemRightClickedEvent;

    private void Awake()
    {
        for (int i = 0; i < slotsObjetos.Length; i++)
        {
            slotsObjetos[i].OnRightClickEvent += OnItemRightClickedEvent;
        }
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
        if(estaLleno())
        {
            return false;
        }
        listaObjetos.Add(Objeto);
        ActualizandoUI();
        return true;
    }
    //Quitamos los objetos y actualizamos la lista
    public bool QuitarObjetos(Objeto Objeto)
    {
        if (listaObjetos.Remove(Objeto))
        {
            ActualizandoUI();
            return true;
        }
        return false;
    }
    public bool estaLleno()
    {
        return listaObjetos.Count >= slotsObjetos.Length;
    }
}
