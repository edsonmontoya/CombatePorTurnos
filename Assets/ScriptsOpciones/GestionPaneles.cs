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
    public GestionInventario inventory;
    public GestionCaracteristicas caracteristicas;
    public GameObject GestionSlots;
    public Items Objeto;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
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
        if (Input.GetKeyDown(KeyCode.I))
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
        if (Input.GetKeyDown(KeyCode.H))
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
