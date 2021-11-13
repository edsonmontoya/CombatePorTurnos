using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class SlotObjetos : MonoBehaviour, IPointerClickHandler
{
    public event Action<Objeto> OnRightClickEvent;
    public Image imagenObjeto;
    public Objeto _objeto;

   
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
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (Objeto != null && OnRightClickEvent != null)
                OnRightClickEvent(Objeto);
        }
    }
}
