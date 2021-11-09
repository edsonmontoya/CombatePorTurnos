using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject Objeto;
    public string Tipo;
    public string Descripcion;
    public int ID;
    public bool slotVacio;
    public Sprite Icono;


    public Transform slotIconoGameObject;



    private void Start()
    {
        slotIconoGameObject = transform.GetChild(0);
    }

    public void ActualizandoSlot()
    {
        slotIconoGameObject.GetComponent<Image>().sprite = Icono;
    }

}
