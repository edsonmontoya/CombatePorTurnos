using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Guerrero : MonoBehaviour
{
    public string idName;
    public StatusPanel statusPanel;
    public CombateManager combateManager;
    protected Stats stats;
    protected Skill[] skills;
    public CaracteristicasStats valores;



    public bool isAlive
    {
        get => this.stats.Curacion > 0;
    }
    protected virtual void Start()
    {
        this.statusPanel.SetStats(this.idName, this.stats);
        this.skills = this.GetComponentsInChildren<Skill>();
    }
    public void ModifyHealth(float amount)
    {
        this.stats.Curacion = Mathf.Clamp(this.stats.Curacion + amount, 0f, this.stats.Salud);
        this.stats.Curacion = Mathf.Round(this.stats.Curacion);
        this.statusPanel.SetHealth(this.stats.Salud, this.stats.Curacion);

    }
    public Stats GetCurrentStats()
    {
        return this.stats;
    }
    public abstract void InitTurn();
}