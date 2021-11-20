using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCamaras : MonoBehaviour
{
    public Camera camaraMundo;
    public Camera camaraCombateZona1;
    public AudioSource SonidoMundo;
    public AudioSource SonidoZona1Combate;

    public void CamaraEnMundo()
    {
        SonidoMundo.Play();
        camaraMundo.enabled = true;
        camaraCombateZona1.enabled = false;
        SonidoMundo.mute = false;
        SonidoZona1Combate.mute = true;
        SonidoMundo.playOnAwake = true;
    }
    public void CamaraEnCombateZona1()
    {
        SonidoZona1Combate.Play();
        SonidoMundo.mute = true;
        SonidoZona1Combate.mute = false;
        camaraMundo.enabled = false;
        camaraCombateZona1.enabled = true;
    }
}
