using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGuerrero : Guerrero
{
    public Characters personajeStats;
    public CaracteristicasStats caracteristicasActuales;
    public Animator anmtr;
    [Header("UI")]
    public PlayerSkillPanel skillPanel;
    private void Awake()
    {
        this.stats = new Stats(10, 10, 10, 10, 10, 10);
    
    }
    public override void InitTurn()
    {
        this.skillPanel.Show();
        for (int i = 0; i < this.skills.Length; i++)
        {
            this.skillPanel.ConfigureButtons(i, this.skills[i].nombreHabilidad);
        }
    }
    void Atacando()
    {
        anmtr.SetBool("isAtacando", true);
        StartCoroutine("Esperar");
    }
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.8f);
        anmtr.SetBool("isAtacando", false);
    }

    public  void ExecuteSkill(int index)
    {
        this.skillPanel.Hide();
        Skill skill = this.skills[index];
        Atacando();
        skill.SetEmitterAndReceiver(this, this.combateManager.GetOpposingGuerrero());
        this.combateManager.OnFighterSkill(skill);


        Debug.Log($"Lanzando {skill.nombreHabilidad} al enemigo");
    }
}