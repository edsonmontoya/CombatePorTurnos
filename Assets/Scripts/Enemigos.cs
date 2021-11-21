using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemigos : MonoBehaviour
{
    public string IDEnemy;
    public StatusPanel statusPanelEnemigo;
    public CombateManager combateManager;
    public  EnemigosStats stats;
    public float amount;
    public PlayerEnemigo playerEnemigo;
    public Skill[] skills;


    

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
        playerEnemigo.stats.vidaActualEnemigo = (int)Mathf.Clamp(playerEnemigo.stats.vidaActualEnemigo + amount, 0f, playerEnemigo.stats.SaludEnemigo);
        playerEnemigo.stats.vidaActualEnemigo = (int)Mathf.Round(playerEnemigo.stats.vidaActualEnemigo);
        playerEnemigo.statusPanelEnemigo.SetSaludEnemigo(playerEnemigo.stats.vidaActualEnemigo, playerEnemigo.stats.SaludEnemigo);


    }

    public EnemigosStats GetCurrentStats()
    {
        return this.stats;
    }
    public abstract void IniciarTurno();
}



