using UnityEngine;

public class HealthModSkill : Skill
{
    [Header("Health Mod")]
    public float amount;
    public Characters personaje;
    public EnemigosStats enemigosStats;
    public PlayerEnemigo playerEnemigo;
    
   

    protected override void OnRun()
    {
        
        float amount = this.GetModification();
        this.emitter.ModificandoSaludCombateEnemigo(amount);
    }
   
    public void Update()
    {
        this.nombreHabilidad.text = habilidadEquipable.nombreHabilidad;
        this.imagenHabilidadCombate.sprite = habilidadEquipable.imagenHabilidad;
        this.DamageCombate.text = habilidadEquipable.DamageFisico.ToString();
        this.HabilidadCombate.text = habilidadEquipable.DamageHabilidad.ToString();
        this.CuracionCombate.text = habilidadEquipable.AutoCuracion.ToString();
    }
   
    public float GetModification()
    {
        switch (habilidadEquipable.healthModType)
        {     
            case HealthModType.ENTERO:
                float RFisico = Random.value * -5;
                float rawDamage =  - personaje.Ataque._Valor - habilidadEquipable.DamageFisico + playerEnemigo.enemigosStats.DefensaEnemigo +RFisico;
                float noDamage = 0;
                if(rawDamage > 0)
                {
                    rawDamage = noDamage;
                }
                return rawDamage;
            case HealthModType.CURATIVO:
                float CFisico = Random.value * 5;
                return personaje.Curacion._Valor + habilidadEquipable.AutoCuracion+ CFisico;
            case HealthModType.HABILIDAD:
                float HFisico = Random.value * -5;
                float NoDamageHabilidad = 0;
                float habDamage =   - habilidadEquipable.DamageHabilidad - personaje.Habilidad._Valor + playerEnemigo.enemigosStats.DefensaEnemigo+ HFisico;
                if(habDamage > 0)
                {
                    habDamage = NoDamageHabilidad;
                }
                return habDamage;
            case HealthModType.VERDADERO:
                float VFisico = Random.value * -5;
                float NoVerdadero = 0;
                float VerDamage = -personaje.Ataque._Valor + playerEnemigo.enemigosStats.DefensaEnemigo + VFisico;
                if(VerDamage == 0)
                {
                    VerDamage = NoVerdadero;
                }
                return VerDamage;
                
        }
        throw new System.InvalidCastException("HealthModSkill::GetDamage. Unreachable!");
    }
}