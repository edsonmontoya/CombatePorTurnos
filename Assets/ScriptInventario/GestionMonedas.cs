using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionMonedas : MonoBehaviour
{
    public Text MonedasOro;
    public Text MonedasPlata;
    public Text MonedasCobre;
    public Characters characters;


    public void Update()
    {
        MonedasOro.text = characters.MonedasOro._Valor.ToString();
        MonedasPlata.text = characters.MonedasPlata._Valor.ToString();
        MonedasCobre.text = characters.MonedasCobre._Valor.ToString();
    }
}
