using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionPaneles : MonoBehaviour
{
    public bool inventarioEncendido;
    public bool caracteristicasEncendido;
    public GameObject Caracteristicas;
    public GameObject Inventario;
    public GestionInventario inventory;
    public GestionCaracteristicas caracteristicas;
    public GameObject GestionSlots;
    public Items Objeto;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            caracteristicasEncendido = !caracteristicasEncendido;
        }
        if (caracteristicasEncendido == true)
        {
            Caracteristicas.SetActive(true);
        }
        if (caracteristicasEncendido == false)
        {
            Caracteristicas.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
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
    public void cuandoHagoClickCaracteristicas()
    {
        caracteristicasEncendido = true;
    }
    public void cuandoHagoClickInventario()
    {
       
        inventarioEncendido = true;
    }
    public void cuandoQuieroCerrarCaracteristicas()
    {
        caracteristicasEncendido = false;
    }
    public void cuandoQuieroCerrarInventario()
    {
        inventarioEncendido = false;
    }

}
