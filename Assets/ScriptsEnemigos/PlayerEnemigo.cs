using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemigo : Enemigos
{
    public EnemigosStats enemigosStats;
    public Animator anmtr;
    public PlayerSkillPanel skillPanel;
    public Guerrero guerrero;
    public Enemigos enemigos;
    
     
    public override void IniciarTurnoEnemigo()
    {
        StartCoroutine(this.IA());
    }

    IEnumerator IA()
    {
      
        yield return new WaitForSeconds(1f);
       
        SkillEnemy skillEnemy = this.skillEnemy[Random.Range(0, 1)];
        skillEnemy.healthModSkillEnemy.SetEmitterAndReceiverEnemy(this, combateManager.GetOpposingEnemy());

        combateManager.OnFighterSkillEnemy(skillEnemy);
       




    }

}
