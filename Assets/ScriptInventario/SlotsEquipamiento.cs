using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsEquipamiento : SlotObjetos
{

    public TipoEquipamiento TipoEquipamiento;

    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = TipoEquipamiento.ToString() + "Slot";
    }
    public override bool PuedeRecibirObjeto(Objeto objeto)
    {
        if(objeto == null)
        {
            return true;
        }
        ObjetoEquipable objetoEquipable = objeto as ObjetoEquipable;
        return objetoEquipable != null && objetoEquipable.TipoEquipamiento == TipoEquipamiento;
    }

}

