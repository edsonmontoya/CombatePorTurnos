using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGuerrero : Guerrero
{
    public Characters personajeStats;
    public CaracteristicasStats caracteristicasActuales;
    public Animator anmtr;
    public PlayerSkillPanel skillPanel;
    public HealthModSkill healthModSkill1;
    public HealthModSkill healthModSkill2;
    public HealthModSkill healthModSkill3;
    public HealthModSkill healthModSkill4;
    public HealthModSkill healthModSkill5;
    public GameObject AtaqueBasico;

    public override void IniciarTurno()
    {
        
        this.skillPanel.Show();
        this.AtaqueBasico.SetActive(true);
        for (int i = 0; i < this.skills.Length; i++)
        {
            
            this.skillPanel.ConfigureButtons(i, this.skills[i].nombreHabilidad.text);
            
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
    
    public void ExecuteSkill1()
    {
        //this.skillPanel.Hide();
        //this.AtaqueBasico.SetActive(false);
        Atacando();
        healthModSkill1.SetEmitterAndReceiver(this, this.combateManager.GetOpposingGuerrero());
        this.combateManager.OnFighterSkill(healthModSkill1);

        Debug.Log($"Lanzando {healthModSkill1.nombreHabilidad.text} al enemigo");
    }
    public void ExecuteSkill2()
    {
        //this.skillPanel.Hide();
        //this.AtaqueBasico.SetActive(false);
        Atacando();
        healthModSkill2.SetEmitterAndReceiver(this, this.combateManager.GetOpposingGuerrero());
        this.combateManager.OnFighterSkill(healthModSkill2);

        Debug.Log($"Lanzando {healthModSkill2.nombreHabilidad.text} al enemigo");
    }
    public void ExecuteSkill3()
    {
        //this.skillPanel.Hide();
        //this.AtaqueBasico.SetActive(false);
        Atacando();
        healthModSkill3.SetEmitterAndReceiver(this, this.combateManager.GetOpposingGuerrero());
        this.combateManager.OnFighterSkill(healthModSkill3);

        Debug.Log($"Lanzando {healthModSkill3.nombreHabilidad.text} al enemigo");
    }
    public void ExecuteSkill4()
    {
        //this.skillPanel.Hide();
        //this.AtaqueBasico.SetActive(false);
        Atacando();
        healthModSkill4.SetEmitterAndReceiver(this, this.combateManager.GetOpposingGuerrero());
        this.combateManager.OnFighterSkill(healthModSkill4);

        Debug.Log($"Lanzando {healthModSkill4.nombreHabilidad.text} al enemigo");
    }
    public void ExecuteSkill5()
    {
        //this.skillPanel.Hide();
        //this.AtaqueBasico.SetActive(false);
        Atacando();
        healthModSkill5.SetEmitterAndReceiver(this, this.combateManager.GetOpposingGuerrero());
        this.combateManager.OnFighterSkill(healthModSkill5);

        Debug.Log($"Lanzando {healthModSkill5.nombreHabilidad.text} al enemigo");
    }

}




