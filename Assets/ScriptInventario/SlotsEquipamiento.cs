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


}

