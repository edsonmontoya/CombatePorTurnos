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

    public Image healthSliderBarEnemy;
    public Image ManaSliderBarEnemy;
    public Text nameLabelEnemigo;
    public Text levelLabelEnemigo;
    public Slider barraVidaEnemigo;
    public Slider barraManaEnemigo;
    public Text healthLabelEnemigo;
    public Text manaLabelEnemigo;
   
    


    public void Update()
    {
        
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
        else
        {
            this.healthSliderBar.color = new Color(0.128649f, 0.5566f, 0.1878753f, 1);
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
        this.statusPanel.stats = stats;
        this.statusPanel.stats = playerEnemigo.stats;
        this.statusPanel.stats = playerEnemigo.enemigosStats;
        this.nameLabelEnemigo.text = enemigosStats.namaEnemigo;
        this.levelLabelEnemigo.text = "Nvl. " + playerEnemigo.enemigosStats.NivelEnemigo;
        this.levelLabelEnemigo.text = "Nvl. " + enemigosStats.NivelEnemigo;
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
            this.healthSliderBarEnemy.color = Color.red;
        }
        else
        {
            this.healthSliderBarEnemy.color = new Color(0.128649f, 0.5566f, 0.1878753f, 1);
        }

    }
    public void SetManaEnemigo(float manaActual, float Mana)
    {
        this.manaLabelEnemigo.text = $"{Mathf.RoundToInt(manaActual)}/{Mathf.RoundToInt(Mana)}";
        this.barraManaEnemigo.value = manaActual / Mana;
    }
    public void ActualizandoValoresCombate()
    {
        //Este es el posible error

        statusPanel1.stats = playerEnemigo.stats;
        //playerEnemigo.stats.ManaActualEnemigo = playerEnemigo.enemigosStats.ManaEnemigo;
        //playerEnemigo.stats.vidaActualEnemigo = playerEnemigo.enemigosStats.SaludEnemigo;
        statusPanel1.healthLabelEnemigo.text = $"{Mathf.RoundToInt(playerEnemigo.enemigosStats.vidaActualEnemigo)}/{Mathf.RoundToInt(playerEnemigo.enemigosStats.SaludEnemigo)}";
        statusPanel1.manaLabelEnemigo.text = $"{Mathf.RoundToInt(playerEnemigo.enemigosStats.ManaActualEnemigo)}/{Mathf.RoundToInt(playerEnemigo.enemigosStats.ManaEnemigo)}";
        statusPanel1.levelLabelEnemigo.text = "Nvl. " + playerEnemigo.stats.NivelEnemigo;
        statusPanel1.nameLabelEnemigo.text = playerEnemigo.IDEnemy;
    }
}