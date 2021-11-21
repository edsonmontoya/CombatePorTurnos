using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecompensaCombate : MonoBehaviour
{
    public PlayerEnemigo enemigoRecompensa;
    public GestionPaneles paneles;
    public Text ExperienciaDada;
    public Text MonedasOro;
    public Text MonedasPlata;
    public Text MonedasCobre;
    public GestionCamaras gestionCamaras;



    public void AlQuererContinuarMundo()
    {
        paneles.barraOpcionesEncendido = true;
        paneles.victoriaEncendido = false;
        gestionCamaras.CamaraEnMundo();

    }
    public void GenerandoRecompensas()
    {
        ExperienciaDada.text = enemigoRecompensa.stats.ExperienciaDa.ToString();
        MonedasOro.text = enemigoRecompensa.stats.MonedasOro.ToString();
        MonedasPlata.text = enemigoRecompensa.stats.MonedasPlata.ToString();
        MonedasCobre.text = enemigoRecompensa.stats.MonedasCobre.ToString();
    }
}
