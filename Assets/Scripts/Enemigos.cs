using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemigos : MonoBehaviour
{
    public string IDEnemy;
    public StatusPanel statusPanelEnemigo;
    public CombateManager combateManager;
    public  EnemigosStats stats;
    protected Skill[] skills;
    public float amount;
    public PlayerEnemigo playerEnemigo;



    public bool isAlive
    {
        get => this.stats.vidaActualEnemigo > 0;
    }
    //Nuevo
    protected virtual void Start()
    {
        
        this.statusPanelEnemigo.SetCaracteristicasEnemigo(this.playerEnemigo, this.stats);
        this.skills = this.GetComponentsInChildren<Skill>();
    }
    //NUEVO
    public void ModificandoSaludCombateEnemigo(float amount)
    {
        //this.playerEnemigo.enemigosStats.vidaActualEnemigo = Mathf.Clamp(this.playerEnemigo.enemigosStats.vidaActualEnemigo + amount, 0f, this.playerEnemigo.enemigosStats.SaludEnemigo);
        //this.playerEnemigo.enemigosStats.vidaActualEnemigo = Mathf.Round(this.playerEnemigo.enemigosStats.vidaActualEnemigo);
        //this.statusPanel.SetSalud(this.playerEnemigo.enemigosStats.SaludEnemigo, this.playerEnemigo.enemigosStats.vidaActualEnemigo);


    }

    public EnemigosStats GetCurrentStats()
    {
        return this.stats;
    }
    public abstract void IniciarTurno();
}



