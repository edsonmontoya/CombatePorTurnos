using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionCaracteristicas : MonoBehaviour
{
    public bool caracteristicasEncendido;
    public GameObject Caracteristicas;
    public GestionInventario inventory;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            inventory.inventarioEncendido = false;
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
    }
    public void cuandoHagoClick()
    {
        caracteristicasEncendido = true;
        inventory.inventarioEncendido = false;
    }
    public void cuandoQuieroCerrar()
    {
        caracteristicasEncendido = false;
    }

}
