
using UnityEngine;

public class HealthModSkillEnemy : SkillEnemy
{
    public float amount;
    public Characters personaje;
    public EnemigosStats enemigosStats;
    public PlayerEnemigo playerEnemigo;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.enemigosStats = playerEnemigo.stats;
       
    }
    protected override void OnRunEnemy()
    {
        float amount = this.GetModificationEnemy();
        this.emitterEnemy.ModificandoSaludCombate(amount);
    }

    public float GetModificationEnemy()
    {
        switch (habilidadEquipable.healthModType)
        {
            
            case HealthModType.ENTEROENEMIGO:
                float TFisico = Random.value * -5;
                float rawDamage = -playerEnemigo.enemigosStats.AtaqueEnemigo - habilidadEquipable.DamageFisico + personaje.Defensa._Valor + TFisico;
                float noDamage = 0;
                if (rawDamage > 0)
                {
                    rawDamage = noDamage;
                }
                return rawDamage;
            case HealthModType.CURATIVOENEMIGO:
                float CFisico = Random.value * 5;
                return playerEnemigo.enemigosStats.CuracionEnemigo +CFisico;
            case HealthModType.HABILIDADENEMIGO:
                float HFisico = Random.value * -5;
                float NoDamageHabilidad = 0;
                float habDamage = -playerEnemigo.enemigosStats.HabilidadEnemigo - habilidadEquipable.DamageHabilidad + personaje.Defensa._Valor + HFisico;
                if (habDamage > 0)
                {
                    habDamage = NoDamageHabilidad;
                }
                return habDamage;
            

        }
        throw new System.InvalidCastException("HealthModSkill::GetDamage. Unreachable!");
    }
}
