using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Guerrero : MonoBehaviour
{
    public string idName;
    public StatusPanel statusPanel;
    public CombateManager combateManager;
    public Characters characters;
    protected Stats stats;
    protected Skill[] skills;
    public Characters statsPersonaje;
    public PlayerEnemigo playerEnemigo;
    public float amount;



    public bool isAlive
    {
        get => this.characters.vidaActual._Valor > 0;
    }
    //Nuevo
    protected virtual void Start()
    {
        this.statusPanel.SetCaracteristicas(this.idName, this.characters);
        this.skills = this.GetComponentsInChildren<Skill>();
    }
    //NUEVO
    public void ModificandoSaludCombate(float amount)
    {
        this.characters.vidaActual._Valor = Mathf.Clamp(this.characters.vidaActual._Valor + amount, 0f, this.characters.Salud._Valor);
        this.characters.vidaActual._Valor = Mathf.Round(this.characters.vidaActual._Valor);
        this.statusPanel.SetSalud(this.characters.Salud._Valor, this.characters.vidaActual._Valor);


    }

    public Characters GetCurrentStats()
    {
        return this.characters;
    }
    public abstract void IniciarTurno();
    /*public void ModifyHealth(float amount)
    {
        this.stats.Curacion = Mathf.Clamp(this.stats.Curacion + amount, 0f, this.stats.Salud);
        this.stats.Curacion = Mathf.Round(this.stats.Curacion);
        this.statusPanel.SetHealth(this.stats.Salud, this.stats.Curacion);

    }
    public Stats GetCurrentStats()
    {
        return this.stats;
    }
    public abstract void InitTurn();*/
}