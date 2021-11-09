using UnityEngine;
using UnityEngine.UI;

public class StatusPanel : MonoBehaviour
{
    public Text nameLabel;
    public Text levelLabel;
    public Slider barraVida;
    public Image healthSliderBar;
    public Text healthLabel;


    public void SetStats(string name, Stats stats)
    {
        this.nameLabel.text = name;
        this.levelLabel.text = $"N. {stats.Lvl}";
        this.SetHealth(stats.Curacion, stats.Salud);
    }
    public void SetHealth(float curacion, float salud)
    {
        this.healthLabel.text = $"{Mathf.RoundToInt(salud)}/{Mathf.RoundToInt(curacion)}";
        float percentage = salud / curacion;
        this.barraVida.value = percentage;
        if (percentage < 0.45f)
        {
            this.healthSliderBar.color = Color.red;
        }
        else
        {
            this.healthSliderBar.color = Color.green;
        }
    }
}