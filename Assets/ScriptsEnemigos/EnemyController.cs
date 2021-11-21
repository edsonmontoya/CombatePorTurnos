using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject prefab;
    public PlayerEnemigo playerEnemigo;
    public EnemigosStats enemigosStats;
    public CombateManager combateManager;
    public StatusPanel statusPanel;
    public GestionPaneles gestionPaneles;
    public ControlJugador controlJugador;


   
   
    
    

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            this.prefab.transform.position = new Vector3(-45.5f, 100.35f, 0);
            playerEnemigo.prefab = this.prefab;
            playerEnemigo.IDEnemy = enemigosStats.namaEnemigo;
            playerEnemigo.stats = this.enemigosStats;
            playerEnemigo.enemigosStats = this.enemigosStats;
            playerEnemigo.stats.ManaActualEnemigo = playerEnemigo.stats.ManaEnemigo;
            playerEnemigo.stats.vidaActualEnemigo = playerEnemigo.stats.SaludEnemigo;
            combateManager.InicializandoCombate();
            statusPanel.ActualizandoValoresCombate();
            statusPanel.barraVidaEnemigo.value = playerEnemigo.stats.vidaActualEnemigo / playerEnemigo.stats.SaludEnemigo;
            statusPanel.barraMana.value = playerEnemigo.stats.ManaActualEnemigo / playerEnemigo.stats.ManaEnemigo;
            statusPanel.healthSliderBarEnemy.color = new Color(0.128649f, 0.5566f, 0.1878753f, 1);

        }
        
    }
}


