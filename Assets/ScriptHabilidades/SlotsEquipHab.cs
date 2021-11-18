using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsEquipHab : SlotHabilidades
{

    public TipoHabilidad TipoHabilidad;

    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = TipoHabilidad.ToString() + "SlotHabilidad";
    }
    public override bool PuedeRecibirHabilidad(Habilidad habilidad)
    {
        if (habilidad == null)
        {
            return true;
        }
        HabilidadEquipable habilidadEquipable = habilidad as HabilidadEquipable;
        return habilidadEquipable != null && habilidadEquipable.TipoHabilidad == TipoHabilidad;
    }
}
