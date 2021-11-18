using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class InformacionHabilidad : MonoBehaviour
{

    
    [SerializeField] Text NombreHabilidad;
    [SerializeField] Text TipoDamageInfo;
    [SerializeField] Text DamageInfo;
    [SerializeField] Text DamageHabilidadInfo;
    [SerializeField] Text costeManaInfo;
    [SerializeField] Text velocidadHabilidadInfo;
    [SerializeField] Text DescripcionHabilidadInfo;
    [SerializeField] Image iconoHabilidad;
    public void MostrandoInformacionHabilidad(HabilidadEquipable habilidad)
    {
        
        NombreHabilidad.text = habilidad.nombreHabilidad;
        TipoDamageInfo.text = habilidad.TipoDamage;
        DamageInfo.text = habilidad.DamageFisico.ToString();
        DamageHabilidadInfo.text = habilidad.DamageHabilidad.ToString();
        costeManaInfo.text = habilidad.costeMana.ToString();
        velocidadHabilidadInfo.text = habilidad.VelocidadDelaHabilidad.ToString();
        iconoHabilidad.sprite = habilidad.imagenHabilidad;

        DescripcionHabilidadInfo.text = habilidad.DescripcionObjeto;
     
        gameObject.SetActive(true);

    }
    public void OcultandoInformacionHabilidad()
    {
        gameObject.SetActive(false);
    }

    
}
