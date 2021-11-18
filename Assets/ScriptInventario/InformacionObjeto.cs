using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class InformacionObjeto : MonoBehaviour
{
    [SerializeField] Text NombreObjeto;
    [SerializeField] Text saludInfo;
    [SerializeField] Text manaInfo;
    [SerializeField] Text ataqueInfo;
    [SerializeField] Text defensaInfo;
    [SerializeField] Text velocidadInfo;
    [SerializeField] Text habilidadInfo;
    [SerializeField] Text curacionInfo;
    [SerializeField] Text descripcionInfo;
    [SerializeField] Text saludBonusInfo;
    [SerializeField] Text manaBonusInfo;
    [SerializeField] Text ataqueBonusInfo;
    [SerializeField] Text defensaBonusInfo;
    [SerializeField] Text velocidadBonusInfo;
    [SerializeField] Text habilidadBonusInfo;
    [SerializeField] Text curacionBonusInfo;
    [SerializeField] Image iconoObjeto;
   
    //Aqui mostramos los objetos en el panel chiquito de informacion
    public void MostrandoInformacion(ObjetoEquipable objeto)
    {
        NombreObjeto.text = objeto.nombreObjeto;
        saludInfo.text = objeto.SaludBonus.ToString();
        manaInfo.text = objeto.ManaBonus.ToString();
        ataqueInfo.text = objeto.AtaqueBonus.ToString();
        defensaInfo.text = objeto.DefensaBonus.ToString();
        velocidadInfo.text = objeto.VelocidadBonus.ToString();
        habilidadInfo.text = objeto.HabilidadBonus.ToString();
        curacionInfo.text = objeto.CuracionBonus.ToString();
        descripcionInfo.text = objeto.DescripcionObjeto;
        iconoObjeto.sprite = objeto.imagenObjeto;
      
        saludBonusInfo.text = ("X") + objeto.porcentajeSaludBonus.ToString();
        manaBonusInfo.text = ("X") + objeto.porcentajeManaBonus.ToString();
        ataqueBonusInfo.text = ("X") + objeto.porcentajeAtaqueBonus.ToString();
        defensaBonusInfo.text = ("X") + objeto.porcentajeDefensaBonus.ToString();
        velocidadBonusInfo.text = ("X") + objeto.porcentajeVelocidadBonus.ToString();
        habilidadBonusInfo.text = ("X") + objeto.porcentajeHabilidadBonus.ToString();
        curacionBonusInfo.text = ("X")+objeto.porcentajeCuracionBonus.ToString();
        gameObject.SetActive(true);

    }
    //Esta funcion sera para mostrar los bonus en objetos raros
    public void MonstrandoBonus(ObjetoEquipable objeto)
    {

    }
    //Cuando el mouse deje de apuntar se llama a esta funcion
    public void OcultandoInformacion()
    {
        gameObject.SetActive(false);
    }
 
}
