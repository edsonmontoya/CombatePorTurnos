using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : Guerrero
{
    private void Awake()
    {
        this.stats = new Stats(60, 5, 10, 20, 10);
    }
    public override void InitTurn()
    {
        StartCoroutine(this.IA());
    }
    IEnumerator IA()
    {
        yield return new WaitForSeconds(1f);
        Skill skill = this.skills[Random.Range(0, this.skills.Length)];
        skill.SetEmitterAndReceiver(this, this.combateManager.GetOpposingGuerrero());
        this.combateManager.OnFighterSkill(skill);
    }
}