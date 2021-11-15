using UnityEngine;
public enum HealthModType
{

    ENTERO_,
    POCERNTAJE,
    VERDADERO,
        
}
public class HealthModSkill : Skill
{
    [Header("Health Mod")]
    public float amount;
    public HealthModType modType;
    public Characters personaje;
    protected override void OnRun()
    {
        float amount = this.GetModification();
        this.receiver.ModifyHealth(amount);
    }
    public float GetModification()
    {
        switch (this.modType)
        {
            case HealthModType.ENTERO_:
                //CaracteristicasStats caracteristicas = this.emitter.
                Stats emitterStats = this.emitter.GetCurrentStats();
                Stats receiverStats = this.receiver.GetCurrentStats();

                float rawDamage = ((2 * emitterStats.Lvl / 5) + 2) * this.amount * (emitterStats.Ataque / receiverStats.Defensa);
                return (rawDamage / 50) + 2;
            case HealthModType.VERDADERO:
                return this.amount;
            case HealthModType.POCERNTAJE:
                Stats rStats = this.receiver.GetCurrentStats();
                return rStats.Salud * this.amount;
        }
        throw new System.InvalidCastException("HealthModSkill::GetDamage. Unreachable!");
    }
}