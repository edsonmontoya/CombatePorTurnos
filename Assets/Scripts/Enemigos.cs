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
    public SkillEnemy[] skillEnemy;
    public GameObject prefab;
    public Characters characters;
    public StatusPanel statusPanel;
    public PlayerEnemigo playerEnemigo;

  

    public void Update()
    {
       
    }


    public bool isAlive
    {
        get => this.stats.vidaActualEnemigo > 0;
    }
    //Nuevo
    protected virtual void Start()
    {
        this.statusPanelEnemigo.SetCaracteristicasEnemigo(this.playerEnemigo, this.stats);
        this.skillEnemy = this.GetComponentsInChildren<SkillEnemy>();
      
    }
    //NUEVO
    public void ModificandoSaludCombate(float amount)
    {

        characters.vidaActual._Valor = Mathf.Clamp(characters.vidaActual._Valor + amount, 0f, characters.Salud._Valor);
        characters.vidaActual._Valor = Mathf.Round(characters.vidaActual._Valor);
        statusPanel.SetSalud(characters.vidaActual._Valor, characters.Salud._Valor);


    }
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
    public abstract void IniciarTurnoEnemigo();
}



