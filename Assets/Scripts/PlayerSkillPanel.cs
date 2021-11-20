using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillPanel : MonoBehaviour
{
    public GameObject[] skillButtons;
    public Text[] skillButtonLabels;
    public PanelEquipHab panelEquipHab;


    private void Awake()
    {
        this.Hide();
        foreach (var btn in this.skillButtons)
        {
            btn.SetActive(false);
        }
    }

    public void EquipandoHabilidadCombate(PanelEquipHab panelEquipHab)
    {
        //this.skillButtons[] = panelEquipHab.AgregarHabilidad;
    }
    public void ConfigureButtons(int index, string skillName)
    {
        this.skillButtons[index].SetActive(true);
        this.skillButtonLabels[index].text = skillName;
    }
    public void Show()
    {
        this.gameObject.SetActive(true);

    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}