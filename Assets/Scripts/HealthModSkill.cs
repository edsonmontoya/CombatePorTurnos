using UnityEngine;
public enum HealthModType
{

    ENTERO,
    HABILIDAD,
    CURATIVO,
    VERDADERO,
    ENTEROENEMIGO,
    HABILIDADENEMIGO,
    CURATIVOENEMIGO,
    VERDADEROENEMIGO
        
}
public class HealthModSkill : Skill
{
    [Header("Health Mod")]
    public float amount;
    public HealthModType modType;
    public Characters personaje;
    public EnemigosStats enemigosStats;
    public PlayerEnemigo playerEnemigo;
    protected override void OnRun()
    {
        
        float amount = this.GetModification();
        this.emitter.ModificandoSaludCombateEnemigo(amount);
    }
    protected override void OnRunEnemy()
    {
        float amount = this.GetModification();
        this.emitter.ModificandoSaludCombate(amount);
    }
    public void Update()
    {
        this.enemigosStats = playerEnemigo.stats;
        this.nombreHabilidad.text = habilidadEquipable.nombreHabilidad;
        this.imagenHabilidadCombate.sprite = habilidadEquipable.imagenHabilidad;
        this.DamageCombate.text = habilidadEquipable.DamageFisico.ToString();
        this.HabilidadCombate.text = habilidadEquipable.DamageHabilidad.ToString();
        this.CuracionCombate.text = habilidadEquipable.AutoCuracion.ToString();
    }
    public float GetModification()
    {
        switch (this.modType)
        {
            case HealthModType.ENTERO:
                float rawDamage =  - personaje.Ataque._Valor - habilidadEquipable.DamageFisico + playerEnemigo.enemigosStats.DefensaEnemigo;
                return rawDamage;
            case HealthModType.CURATIVO:
                return personaje.Curacion._Valor + habilidadEquipable.AutoCuracion;
            case HealthModType.HABILIDAD:
                float habDamage =   - habilidadEquipable.DamageHabilidad - personaje.Habilidad._Valor + playerEnemigo.enemigosStats.DefensaEnemigo;
                return habDamage;
            case HealthModType.VERDADERO:
                return this.amount;
                
        }
        throw new System.InvalidCastException("HealthModSkill::GetDamage. Unreachable!");
    }
    public float GetModificationEnemy()
    {
        switch (this.modType)
        {
            case HealthModType.ENTEROENEMIGO:
                float rawDamage = -playerEnemigo.enemigosStats.AtaqueEnemigo ;
                return rawDamage;
            case HealthModType.CURATIVOENEMIGO:
                return playerEnemigo.enemigosStats.CuracionEnemigo;
            case HealthModType.HABILIDADENEMIGO:
                float habDamage = -playerEnemigo.enemigosStats.HabilidadEnemigo;
                return habDamage;
            case HealthModType.VERDADEROENEMIGO:
                return this.amount;

        }
        throw new System.InvalidCastException("HealthModSkill::GetDamage. Unreachable!");
    }
}