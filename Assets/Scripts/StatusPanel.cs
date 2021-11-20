using UnityEngine;
using UnityEngine.UI;

public class StatusPanel : MonoBehaviour
{
    public Text nameLabel;
    public Text levelLabel;
    public Slider barraVida;
    public Image healthSliderBar;
    public Slider barraMana;
    public Text manaLabel;
    public Text healthLabel;
    public Characters Characters;
    public Image ManaSliderBar;
    public EnemigosStats stats;
    public PlayerEnemigo playerEnemigo;
    public StatusPanel statusPanel;
    public StatusPanel statusPanel1;

    public Text nameLabelEnemigo;
    public Text levelLabelEnemigo;
    public Slider barraVidaEnemigo;
    public Slider barraManaEnemigo;
    public Text healthLabelEnemigo;
    public Text manaLabelEnemigo;
    


    public void Update()
    {
        ActualizandoValoresCombate();
    }
    //NUEVO
    public void SetCaracteristicas(string name, Characters characters)
    {
        this.nameLabel.text = name;
        this.levelLabel.text = "Nvl. " + characters.Nivel._Valor.ToString();
        this.SetSalud(Characters.vidaActual._Valor, Characters.Salud._Valor);
        this.SetMana(Characters.ManaActual._Valor, Characters.Mana._Valor);
    }
    //NUEVO
    public void SetSalud(float vidaActual, float Salud)
    {
        this.healthLabel.text = $"{Mathf.RoundToInt(vidaActual)}/{Mathf.RoundToInt(Salud)}";
        float porcentaje = vidaActual / Salud;
        this.barraVida.value = porcentaje;
        if(porcentaje < 0.5f)
        {
            this.healthSliderBar.color = Color.red;
        }
        
    }
    //NUEVO
    public void SetMana(float manaActual, float Mana)
    {
       this.manaLabel.text = $"{Mathf.RoundToInt(manaActual)}/{Mathf.RoundToInt(Mana)}";
        this.barraMana.value = manaActual / Mana;
    }
    //NUEVO
    public void SetCaracteristicasEnemigo(PlayerEnemigo playerEnemigo, EnemigosStats enemigosStats)
    {
        this.statusPanel.stats = playerEnemigo.stats;
        this.statusPanel.stats = playerEnemigo.enemigosStats;
        this.nameLabelEnemigo.text = enemigosStats.namaEnemigo;
        this.levelLabelEnemigo.text = "Nvl. " + playerEnemigo.enemigosStats.NivelEnemigo;
        this.SetSaludEnemigo(playerEnemigo.enemigosStats.vidaActualEnemigo, playerEnemigo.enemigosStats.SaludEnemigo);
        this.SetManaEnemigo(playerEnemigo.enemigosStats.ManaActualEnemigo, playerEnemigo.enemigosStats.ManaEnemigo);
    }
    public void SetSaludEnemigo(float vidaActual, float Salud)
    {
        this.healthLabelEnemigo.text = $"{Mathf.RoundToInt(vidaActual)}/{Mathf.RoundToInt(Salud)}";
        float porcentaje = vidaActual / Salud;
        this.barraVidaEnemigo.value = porcentaje;
        if (porcentaje < 0.5f)
        {
            this.healthSliderBar.color = Color.red;
        }

    }
    public void SetManaEnemigo(float manaActual, float Mana)
    {
        this.manaLabelEnemigo.text = $"{Mathf.RoundToInt(manaActual)}/{Mathf.RoundToInt(Mana)}";
        this.barraManaEnemigo.value = manaActual / Mana;
    }
    public void ActualizandoValoresCombate()
    {
        statusPanel1.stats = playerEnemigo.stats;
        playerEnemigo.stats.ManaActualEnemigo = playerEnemigo.enemigosStats.ManaEnemigo;
        playerEnemigo.stats.vidaActualEnemigo = playerEnemigo.enemigosStats.SaludEnemigo;
        statusPanel1.healthLabelEnemigo.text = $"{Mathf.RoundToInt(playerEnemigo.enemigosStats.vidaActualEnemigo)}/{Mathf.RoundToInt(playerEnemigo.enemigosStats.SaludEnemigo)}";
        statusPanel1.manaLabelEnemigo.text = $"{Mathf.RoundToInt(playerEnemigo.enemigosStats.ManaActualEnemigo)}/{Mathf.RoundToInt(playerEnemigo.enemigosStats.ManaEnemigo)}";
        statusPanel1.levelLabelEnemigo.text = "Nvl. " + playerEnemigo.stats.NivelEnemigo;
        statusPanel1.nameLabelEnemigo.text = playerEnemigo.IDEnemy;
    }


    /*public void SetStats(string name, Stats stats)
    {
        this.nameLabel.text = name;
        this.levelLabel.text = $"N. {stats.Lvl}";
        this.SetHealth(stats.Curacion, stats.Salud);
    }
    public void SetHealth(float salud, float saludMaxima)
    {
        this.healthLabel.text = $"{Mathf.RoundToInt(salud)}/{Mathf.RoundToInt(saludMaxima)}";
        float percentage = salud / saludMaxima;
        this.barraVida.value = percentage;
        if (percentage < 0.45f)
        {
            this.healthSliderBar.color = Color.red;
        }
        else
        {
            this.healthSliderBar.color = Color.green;
        }
    }*/
}