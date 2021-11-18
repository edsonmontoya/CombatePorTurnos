using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class SlotObjetos : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{

    public Image imagenObjeto;
    public Objeto _objeto;
    [SerializeField] InformacionObjeto infoObjeto;
    public event Action<SlotObjetos> OnPointerEnterEvent;
    public event Action<SlotObjetos> OnPointerExitEvent;
    public event Action<SlotObjetos> OnRightClickEvent;
    public event Action<SlotObjetos> OnBeginDragEvent;
    public event Action<SlotObjetos> OnEndDragEvent;
    public event Action<SlotObjetos> OnDragEvent;
    public event Action<SlotObjetos> OnDropEvent;

    private Color colorNormal = Color.white;
    private Color disableColor = new Color(1, 1, 1, 0);
    public Objeto Objeto
    {
        get { return _objeto; }
        set
        {
            _objeto = value;
            if (_objeto == null)
            {
                imagenObjeto.color = disableColor;
            }
            else
            {
                imagenObjeto.sprite = _objeto.imagenObjeto;
                imagenObjeto.color = colorNormal;
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
    public virtual bool PuedeRecibirObjeto(Objeto objeto)
    {
        return true;
    }
    //Funcion para cuando realizas el click derecho
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (Objeto != null && OnRightClickEvent != null)
                OnRightClickEvent(this);
        }
    }
    //Funcion para cuando mantienes el mouse 
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (OnPointerEnterEvent != null)
            OnPointerEnterEvent(this);

    }
    //Funcion para cuando dejas de mantener el mouse
    public void OnPointerExit(PointerEventData eventData)
    {
        if (OnPointerExitEvent != null)
            OnPointerExitEvent(this);
    }
    Vector2 posicionOriginalObjetos;
    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragEvent != null)
            OnDragEvent(this);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnBeginDragEvent != null)
            OnBeginDragEvent(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (OnEndDragEvent != null)
            OnEndDragEvent(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (OnDropEvent != null)
            OnDropEvent(this);
    }

}
