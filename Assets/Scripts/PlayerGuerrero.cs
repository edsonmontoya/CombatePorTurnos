using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGuerrero : Guerrero
{
    [Header("UI")]
    public PlayerSkillPanel skillPanel;
    private void Awake()
    {
        this.stats = new Stats(60, 10, 20, 45, 20);
    }
    public override void InitTurn()
    {
        this.skillPanel.Show();
        for (int i = 0; i < this.skills.Length; i++)
        {
            this.skillPanel.ConfigureButtons(i, this.skills[i].nombreHabilidad);
        }

    }

    public void ExecuteSkill(int index)
    {
        this.skillPanel.Hide();
        Skill skill = this.skills[index];
        skill.SetEmitterAndReceiver(this, this.combateManager.GetOpposingGuerrero());
        this.combateManager.OnFighterSkill(skill);

        Debug.Log($"Lanzando {skill.nombreHabilidad} al enemigo");
    }
}