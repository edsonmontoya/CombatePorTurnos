using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemigo : Enemigos
{
    public EnemigosStats enemigosStats;
    public Animator anmtr;
    public PlayerSkillPanel skillPanel;
    public Guerrero guerrero;
    
    public override void IniciarTurno()
    {
        StartCoroutine(this.IA());
    }

    IEnumerator IA()
    {
        yield return new WaitForSeconds(1f);
        Skill skill = this.skills[Random.Range(0,1)];
        skill.SetEmitterAndReceiver(guerrero , this.combateManager.GetOpposingGuerrero());

        this.combateManager.OnFighterSkill(skill);
        

    }

}
