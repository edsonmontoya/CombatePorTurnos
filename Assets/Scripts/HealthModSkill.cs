using UnityEngine;
public enum HealthModType
{

    STAT_BASED, FIXED, PERCENTAGE
}
public class HealthModSkill : Skill
{
    [Header("Health Mod")]
    public float amount;
    public HealthModType modType;
    protected override void OnRun()
    {
        float amount = this.GetModification();
        this.receiver.ModifyHealth(amount);
    }
    public float GetModification()
    {
        switch (this.modType)
        {
            case HealthModType.STAT_BASED:
                Stats emitterStats = this.emitter.GetCurrentStats();
                Stats receiverStats = this.receiver.GetCurrentStats();

                float rawDamage = ((2 * emitterStats.Lvl / 5) + 2) * this.amount * (emitterStats.Ataque / receiverStats.Defensa);
                return (rawDamage / 50) + 2;
            case HealthModType.FIXED:
                return this.amount;
            case HealthModType.PERCENTAGE:
                Stats rStats = this.receiver.GetCurrentStats();
                return rStats.Salud * this.amount;
        }
        throw new System.InvalidCastException("HealthModSkill::GetDamage. Unreachable!");
    }
}