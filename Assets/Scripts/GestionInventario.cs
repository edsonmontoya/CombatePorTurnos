using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionInventario : MonoBehaviour
{
    public bool inventarioEncendido;
    public GameObject Inventario;
    private int todosSlots;
    private int encenderSlots;
    private GameObject[] slot;
    public GameObject GestionSlots;
    public Items Objeto;
    public GestionCaracteristicas caracteristicas;
    void Start()
    {
        todosSlots = GestionSlots.transform.childCount;
        slot = new GameObject[todosSlots];
        for (int i = 0; i < todosSlots; i++)
        {
            slot[i] = GestionSlots.transform.GetChild(i).gameObject;
            if (slot[i].GetComponent<Slot>().Objeto == null)
            {
                slot[i].GetComponent<Slot>().slotVacio = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            caracteristicas.caracteristicasEncendido = false;
            inventarioEncendido = !inventarioEncendido;
        }
        if (inventarioEncendido == true)
        {
            Inventario.SetActive(true);
        }
        if (inventarioEncendido == false)
        {
            Inventario.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Objetos")
        {
            GameObject itemCogido = other.gameObject;
            Items Objeto = itemCogido.GetComponent<Items>();
            AgregarItem(itemCogido,Objeto.ID,Objeto.Tipo,Objeto.Descripcion,Objeto.Icono);
        }
    }
    public void AgregarItem(GameObject itemObject,int itemID, string tipoObjeto, string itemDescripcion, Sprite itemIcono)
    {
        for (int i = 0; i < todosSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().slotVacio)
            {
                itemObject.GetComponent<Items>().itemCogido = true;
                slot[i].GetComponent<Slot>().Objeto = itemObject;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().Tipo = tipoObjeto;
                slot[i].GetComponent<Slot>().Descripcion = itemDescripcion;
                slot[i].GetComponent<Slot>().Icono = itemIcono;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().ActualizandoSlot();

                slot[i].GetComponent<Slot>().slotVacio = false;
                return;
            }
            
        }
    }
    public void cuandoHagoClick()
    {
        caracteristicas.caracteristicasEncendido = false;
        inventarioEncendido = true;
    }
    public void cuandoQuieroCerrar()
    {
        inventarioEncendido = false;
    }
    /*public static GestionInventario instance;
    public static GestionInventario Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GestionInventario>();
            }
            return instance;
        }
    
    
    
    }*/
   


}
