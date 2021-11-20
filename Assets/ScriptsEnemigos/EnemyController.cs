using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject prefab;
    public PlayerEnemigo playerEnemigo;
    public EnemigosStats enemigosStats;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(prefab, new Vector3(-45.5f, 100.35f, 0), Quaternion.identity);
            playerEnemigo.IDEnemy = enemigosStats.namaEnemigo;
            playerEnemigo.stats = this.enemigosStats;
            playerEnemigo.enemigosStats = this.enemigosStats;
        }
    }
}
