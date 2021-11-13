using UnityEngine;

public class Characters : MonoBehaviour
{
    public CaracteristicasStats Nivel;
    public CaracteristicasStats Salud;
    public CaracteristicasStats Ataque;
    public CaracteristicasStats Defensa;
    public CaracteristicasStats Velocidad;
    public CaracteristicasStats Habilidad;
    public CaracteristicasStats Curacion;

    [SerializeField] Inventario inventario;
    [SerializeField] PanelEquipamiento panelEquipamiento;
    [SerializeField] PanelEstadistica panelEstadistica;
    private void Awake()
    {
        panelEstadistica.EstableciendoEstadisticas(Nivel, Salud, Ataque, Defensa, Velocidad, Habilidad, Curacion);
        panelEstadistica.ActualizandoValores();
        inventario.OnItemRightClickedEvent += EquipadoDesdeInventario;
        panelEquipamiento.OnItemRightClickedEvent += UnequipadoDesdeEquiparPanel;
    }
    private void EquipadoDesdeInventario(Objeto objeto)
    {
        if(objeto is ObjetoEquipable)
        {
            Equipo((ObjetoEquipable)objeto);
            panelEstadistica.ActualizandoValores();
        }
    }
    private void UnequipadoDesdeEquiparPanel(Objeto objeto)
    {
        if(objeto is ObjetoEquipable)
        {
            SinEquipar((ObjetoEquipable)objeto);
            panelEstadistica.ActualizandoValores();
        }
    }

    public void Equipo(ObjetoEquipable objeto)
    {
        if(inventario.QuitarObjetos(objeto))
        {
            ObjetoEquipable objetoAnterior;
            if(panelEquipamiento.AgregarObjeto(objeto, out objetoAnterior))
            {
                if(objetoAnterior != null)
                {
                    inventario.AgregarItem(objetoAnterior);
                    objetoAnterior.NoEquipo(this);
                    panelEstadistica.ActualizandoValores();
                }
                
                objeto.SiEquipo(this);
                panelEstadistica.ActualizandoValores();
            }
            else
            {
                inventario.AgregarItem(objeto);
            }
        }
      
    }
    public void SinEquipar(ObjetoEquipable objeto)
    {
        if(!inventario.estaLleno() && panelEquipamiento.QuitarObjeto(objeto))
        {
            objeto.NoEquipo(this);
            panelEstadistica.ActualizandoValores();
            inventario.AgregarItem(objeto);
        }
    }
   
}
