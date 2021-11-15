using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class SlotObjetos : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public event Action<Objeto> OnRightClickEvent;
    public Image imagenObjeto;
    public Objeto _objeto;
    [SerializeField] InformacionObjeto infoObjeto;

   
    public Objeto Objeto
    {
        get { return _objeto; }
        set
        {
            _objeto = value;
            if (_objeto == null)
            {
                imagenObjeto.enabled = false;
            }
            else
            {
                imagenObjeto.sprite = _objeto.imagenObjeto;
                imagenObjeto.enabled = true;
            }
        }
    }
    protected virtual void OnValidate()
    {
        if (imagenObjeto == null)
        {
            imagenObjeto = GetComponent<Image>();
        }
        if(infoObjeto == null)
        
            infoObjeto = FindObjectOfType<InformacionObjeto>();
        
    }
    //Funcion para cuando realizas el click derecho
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (Objeto != null && OnRightClickEvent != null)
                OnRightClickEvent(Objeto);
        }
    }
    //Funcion para cuando mantienes el mouse 
    public void OnPointerEnter(PointerEventData eventData)
    {
        if( Objeto is ObjetoEquipable)
        {
            infoObjeto.MostrandoInformacion((ObjetoEquipable)Objeto);
        }
        
    }
    //Funcion para cuando dejas de mantener el mouse
    public void OnPointerExit(PointerEventData eventData)
    {
        infoObjeto.OcultandoInformacion((ObjetoEquipable)Objeto);
    }
}
