using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class SlotHabilidades : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler,IDropHandler
{
    public event Action<SlotHabilidades> OnPointerEnterEvent;
    public event Action<SlotHabilidades> OnPointerExitEvent;
    public event Action<SlotHabilidades> OnRightClickEvent;
    public event Action<SlotHabilidades> OnBeginDragEvent;
    public event Action<SlotHabilidades> OnEndDragEvent;
    public event Action<SlotHabilidades> OnDragEvent;
    public event Action<SlotHabilidades> OnDropEvent;
    public Image imagenHabilidad;
    public Text textoBotonHabilidad;
    public Habilidad _habilidad;
    [SerializeField] InformacionHabilidad infoHabilidad;
    private Color normalColor = Color.white;
    private Color invisibleColor = new Color(1, 1, 1, 0);
    public Habilidad habilidad
    {
        get { return _habilidad; }
        set
        {
            _habilidad = value;
            if (_habilidad == null)
            {
                textoBotonHabilidad.enabled = false;
                imagenHabilidad.color = invisibleColor;
            }
            else
            {
                imagenHabilidad.sprite = _habilidad.imagenHabilidad;
                imagenHabilidad.color = normalColor;
                textoBotonHabilidad.text = _habilidad.nombreHabilidad;
                textoBotonHabilidad.enabled = true;
            }
        }
    }
    protected virtual void OnValidate()
    {
        if (imagenHabilidad == null)
        {
            imagenHabilidad = GetComponent<Image>();
        }
        if (infoHabilidad == null)
        {
            infoHabilidad = FindObjectOfType<InformacionHabilidad>();
        }
        if (textoBotonHabilidad == null)
        {
            textoBotonHabilidad = GetComponent<Text>();
        }
        if (textoBotonHabilidad == null)
        {
            infoHabilidad = FindObjectOfType<InformacionHabilidad>();
        }
    }
    public virtual bool PuedeRecibirHabilidad(Habilidad habilidad)
    {
        return true;
    }
    //Funcion para cuando realizas el click derecho
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (habilidad != null && OnRightClickEvent != null)
                OnRightClickEvent(this);
        }
    }
    //Funcion para cuando mantienes el mouse 
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (OnPointerEnterEvent != null)
        {
            OnPointerEnterEvent(this);
        }
           

    }
    //Funcion para cuando dejas de mantener el mouse
    public void OnPointerExit(PointerEventData eventData)
    {
        if (OnPointerExitEvent != null)
            OnPointerExitEvent(this);
    }
    
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
