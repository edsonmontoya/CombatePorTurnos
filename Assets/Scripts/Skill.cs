using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    [Header("Habilidades")]
    public Text nombreHabilidad;
    public float duracionAnimacion;
    public bool selfInflicted;
    public Image imagenHabilidadCombate;
    public Text DamageCombate;
    public Text HabilidadCombate;
    public Text CuracionCombate;
    public HealthModSkill healthModSkill;

    public HabilidadEquipable habilidadEquipable;

    protected Guerrero emitter;
    protected Guerrero receiver;
    protected Enemigos emitterEnemy;
    protected Enemigos receiverEnemy;

    
   /* private void Animate()
    {
        var go = Instantiate(this.habilidadEquipable.prefabHabilidad, this.emitter.transform.position, Quaternion.identity);
        Destroy(go, this.duracionAnimacion);
    }
    private void AnimateEnemy()
    {
        var go = Instantiate(this.habilidadEquipable.prefabHabilidad, this.emitter.transform.position, Quaternion.identity);
        Destroy(go, this.duracionAnimacion);
    }*/
    public void Run()
    {
        if (this.selfInflicted == true)
        {
            float amount = healthModSkill.GetModification();
            this.emitter.ModificandoSaludCombate(amount);
        }
        else
        {
            this.OnRun();
        }
        //this.Animate();
        
    }
    public void RunEnemy()
    {
        if (this.selfInflicted == true)
        {
            float amount = healthModSkill.GetModification();
            this.emitter.ModificandoSaludCombateEnemigo(amount);
        }
        else
        {
            this.OnRunEnemy();
        }
        //this.AnimateEnemy();
       
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
    protected abstract void OnRun();
    protected abstract void OnRunEnemy();
}