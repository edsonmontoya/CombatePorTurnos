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
    public float amount;
    public PlayerEnemigo playerEnemigo;




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
        this.statusPanel.SetSalud( this.characters.vidaActual._Valor, this.characters.Salud._Valor);


    }
    public void ModificandoSaludCombateEnemigo(float amount)
    {
        playerEnemigo.stats.vidaActualEnemigo = (int)Mathf.Clamp(playerEnemigo.stats.vidaActualEnemigo + amount, 0f, playerEnemigo.stats.SaludEnemigo);
        playerEnemigo.stats.vidaActualEnemigo = (int)Mathf.Round(playerEnemigo.stats.vidaActualEnemigo);
        playerEnemigo.statusPanelEnemigo.SetSaludEnemigo(playerEnemigo.stats.vidaActualEnemigo, playerEnemigo.stats.SaludEnemigo);


    }
    public PlayerEnemigo GetCurrentStatsEnemy()
    {
        return this.playerEnemigo;
    }
    public Characters GetCurrentStats()
    {
        return this.characters;
    }
    public abstract void IniciarTurno();
    
}