using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SkillEnemy : MonoBehaviour
{
    public Text nombreHabilidadEnemiga;
    public float duracionAnimacion;
    public HabilidadEquipable habilidadEquipable;
    public HealthModSkillEnemy healthModSkillEnemy;
    public HealthModType healthModType;


    public Guerrero emitter;
    public Guerrero receiver;
    public Enemigos emitterEnemy;
    public Enemigos receiverEnemy;


  
    private void AnimateEnemy()
   {
       var go = Instantiate(this.habilidadEquipable.prefabHabilidad, this.receiver.transform.position, Quaternion.identity);
       Destroy(go, this.duracionAnimacion);
   }
    private void AnimateEnemyOn()
    {
        var go = Instantiate(this.habilidadEquipable.prefabHabilidad, this.emitterEnemy.transform.position, Quaternion.identity);
        Destroy(go, this.duracionAnimacion);
    }
    public void RunEnemy()
    {
        if (habilidadEquipable.AsiMismo == true)
        {
            AnimateEnemyOn();
            float amount = healthModSkillEnemy.GetModificationEnemy();
            this.emitterEnemy.ModificandoSaludCombateEnemigo(amount);
        }
        else
        {
            this.AnimateEnemy();
            OnRunEnemy();
        }
        

    }
    public void SetEmitterAndReceiver(Guerrero _emitter, Guerrero _receiver)
    {
        this.emitter = _emitter;
        this.receiver = _receiver;
    }
    public void SetEmitterAndReceiverEnemy(Enemigos _emitter, Enemigos _receiver)
    {
        this.emitterEnemy = _emitter;
        this.receiverEnemy = _receiver;
    }
 
    protected abstract void OnRunEnemy();
}
