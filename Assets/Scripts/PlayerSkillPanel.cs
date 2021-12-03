using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillPanel : MonoBehaviour
{
    public HealthModSkill[] skillButtons;
    public Text[] skillButtonLabels;
    public SlotsEquipHab[] slotsEquipHabs;
    public HealthModType healthModType;

    private void Update()
    {
        ActualizandoUICombate();
    }
    private void Awake()
    {
       
        this.Hide();
        foreach (var btn in this.skillButtons)
        {
            //btn.SetActive(true);
        }
    }

    public void ActualizandoUICombate()
    {
        int i = 0;
        //por cada slot del equipamiento de habilidades
        for (; i < slotsEquipHabs.Length; i++)
        {
            //si el slot de equipamiento esta vacio...
            if(slotsEquipHabs[i].habilidad == null)
            {
                //los botones de combate pues estaran vacios
                skillButtons[i].habilidadEquipable = null;
            }
            //si no el boton tendra la habilidad del slot de equipamiento
            skillButtons[i].habilidadEquipable = (HabilidadEquipable)slotsEquipHabs[i].habilidad;
            //skillButtons[i].habilidadEquipable = slotsEquipHabs[i].habilidad;
        }
        
    }
   
    public void ConfigureButtons(int index, string nombreHabilidad)
    {
        //this.skillButtons[index].habilidadEquipable = 
        this.skillButtonLabels[index].text = nombreHabilidad;
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