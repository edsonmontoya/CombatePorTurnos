using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : Guerrero
{
    void Update()
    {
        
    }
    public Animator anmtr;
    private void Awake()
    {
        
        this.stats = new Stats(60, 10, 10, 45, 10);
    }
    public override void InitTurn()
    {
        StartCoroutine(this.IA());
    }
    IEnumerator IA()
    {
        yield return new WaitForSeconds(1f);
        Skill skill = this.skills[Random.Range(0, this.skills.Length)];
        anmtr.SetBool("isAtacando", true);
        skill.SetEmitterAndReceiver(this, this.combateManager.GetOpposingGuerrero());
        this.combateManager.OnFighterSkill(skill);
        yield return new WaitForSeconds(0.8f);
        anmtr.SetBool("isAtacando", false);
    }
}