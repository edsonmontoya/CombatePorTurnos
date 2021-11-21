using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillPanel : MonoBehaviour
{
    public GameObject[] skillButtons;
    public Text[] skillButtonLabels;

    private void Update()
    {
    }
    private void Awake()
    {
        this.Hide();
        foreach (var btn in this.skillButtons)
        {
            btn.SetActive(true);
        }
    }

    public void ConfigureButtons(int index, string nombreHabilidad)
    {
        this.skillButtons[index].SetActive(true);
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