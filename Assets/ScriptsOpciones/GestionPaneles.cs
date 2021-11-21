using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionPaneles : MonoBehaviour
{
    public bool inventarioEncendido;
    public bool caracteristicasEncendido;
    public bool habilidadesEncendido;
    public GameObject Habilidades;
    public GameObject Caracteristicas;
    public GameObject Inventario;
    public GameObject victoriaPanel;
    public GestionInventario inventory;
    public GestionCaracteristicas caracteristicas;
    public GameObject GestionSlots;
    public Items Objeto;
    public GameObject Combate;
    public GameObject barraOpciones;
    public bool combateEncendido;
    public bool barraOpcionesEncendido;
    public bool victoriaEncendido;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && combateEncendido == false)
        {
            habilidadesEncendido = false;
            caracteristicasEncendido = !caracteristicasEncendido;
        }
        if (caracteristicasEncendido == true)
        {
            Caracteristicas.SetActive(true);
            Habilidades.SetActive(false);
        }
        if (caracteristicasEncendido == false)
        {
            Habilidades.SetActive(false);
            Caracteristicas.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.I) && combateEncendido == false)
        {
            habilidadesEncendido = false;
            inventarioEncendido = !inventarioEncendido;
        }
        if (inventarioEncendido == true)
        {
            Habilidades.SetActive(false);
            Inventario.SetActive(true);
        }
        if (inventarioEncendido == false)
        {
            Inventario.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.H) && combateEncendido == false)
        {
            inventarioEncendido = false;
            caracteristicasEncendido = false;
            habilidadesEncendido = !habilidadesEncendido;
        }
        if (habilidadesEncendido == true)
        {
            inventarioEncendido = false;
            caracteristicasEncendido = false;
    Habilidades.SetActive(true);
        }
        if (habilidadesEncendido == false)
        {
            Habilidades.SetActive(false);
        }
        if(combateEncendido == true)
        {
            inventarioEncendido = false;
            caracteristicasEncendido = false;
            habilidadesEncendido = false;
            barraOpcionesEncendido = false;
        }
        if(barraOpcionesEncendido == true)
        {
            barraOpciones.SetActive(true);
            combateEncendido = false;
            Combate.SetActive(false);
        }
        if(victoriaEncendido == true)
        {
            victoriaPanel.SetActive(true);
        }
        if(victoriaEncendido == false)
        {
            victoriaPanel.SetActive(false);
        }
    }
    public void cuandoHagoClickCaracteristicas()
    {
        habilidadesEncendido = false;
        caracteristicasEncendido = !caracteristicasEncendido;
    }
    public void cuandoHagoClickInventario()
    {
        habilidadesEncendido = false;
        inventarioEncendido = !inventarioEncendido;
    }
    public void cuandoQuieroCerrarCaracteristicas()
    {
        caracteristicasEncendido = false;
    }
    public void cuandoQuieroCerrarInventario()
    {
        inventarioEncendido = false;
    }
    public void cuandoHagoClickHabilidades()
    {
        Inventario.SetActive(false);
        Caracteristicas.SetActive(false);
        habilidadesEncendido = !habilidadesEncendido;
    }
    public void cuandoQuieroCerrarHabilidades()
    {
        habilidadesEncendido = false;
    }
}
