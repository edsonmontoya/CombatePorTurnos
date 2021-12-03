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
    public HealthModType healthModType;

    public HabilidadEquipable habilidadEquipable;

    protected Guerrero emitter;
    protected Guerrero receiver;
    public Enemigos emitterEnemy;
    public CamaraVibrando camaraVibra;

    
    private void Animate()
    {
        var go = Instantiate(this.habilidadEquipable.prefabHabilidad, emitterEnemy.transform.position, Quaternion.identity);
       
        Destroy(go, this.duracionAnimacion);
    }
    private void AnimateCura()
    {
        var go = Instantiate(this.habilidadEquipable.prefabHabilidad, emitter.transform.position, Quaternion.identity);

        Destroy(go, this.duracionAnimacion);
    }
    public void Run()
    {
        if (habilidadEquipable.AsiMismo == true)
        {
            float amount = healthModSkill.GetModification();
            this.emitter.ModificandoSaludCombate(amount);
            this.AnimateCura();
        }
        else
        {
            this.Animate();
            this.OnRun();
        }
        if (habilidadEquipable.Vibrando == true)
        {
            this.Animate();
            StartCoroutine(camaraVibra.Vibra());
            //this.OnRun();
        }

      
       
        
    }
    public void SetEmitterAndReceiver(Guerrero _emitter, Guerrero _receiver)
    {
        this.emitter = _emitter;
        this.receiver = _receiver;
    }
    protected abstract void OnRun();
}