using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public int ID;
    public string Tipo;
    public string Descripcion;
    public Sprite Icono;

    
    [HideInInspector]
    public bool itemCogido;

    [HideInInspector]
    public bool equipado;

    private void Update()
    {
      
    }
    public void ItemUsando()
    {
      
    }
}
