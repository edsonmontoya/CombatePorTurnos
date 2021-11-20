using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGuerrero : Guerrero
{
    public Characters personajeStats;
    public CaracteristicasStats caracteristicasActuales;
    public Animator anmtr;
    //public PlayerSkillPanel skillPanel;

    public override void IniciarTurno()
    {
        
    }

}

/*public override void InitTurn()
   {
       this.skillPanel.Show();
       for (int i = 0; i < this.skills.Length; i++)
       {
           this.skillPanel.ConfigureButtons(i, this.skills[i].nombreHabilidad);
       }
   }*/
/*void Atacando()
{
    anmtr.SetBool("isAtacando", true);
    StartCoroutine("Esperar");
}
IEnumerator Esperar()
{
    yield return new WaitForSeconds(0.8f);
    anmtr.SetBool("isAtacando", false);
}

/*public  void ExecuteSkill(int index)
{
    this.skillPanel.Hide();
    Skill skill = this.skills[index];
    Atacando();
    skill.SetEmitterAndReceiver(this, this.combateManager.GetOpposingGuerrero());
    this.combateManager.OnFighterSkill(skill);


    Debug.Log($"Lanzando {skill.nombreHabilidad} al enemigo");
}*/