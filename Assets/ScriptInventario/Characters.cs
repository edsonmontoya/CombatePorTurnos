using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Characters : MonoBehaviour
{
 
    public CaracteristicasStats Nivel;
    public CaracteristicasStats Salud;
    public CaracteristicasStats Mana;
    public CaracteristicasStats Ataque;
    public CaracteristicasStats Defensa;
    public CaracteristicasStats Velocidad;
    public CaracteristicasStats Habilidad;
    public CaracteristicasStats Curacion;
    public CaracteristicasStats Experiencia;
    public CaracteristicasStats ExperienciaMaxima;
    public CaracteristicasStats Puntos;
    public Slider barraExperiencia;
    [SerializeField] Inventario inventario;
    [SerializeField] PanelEquipamiento panelEquipamiento;
    [SerializeField] PanelEstadistica panelEstadistica;
    private void Awake()
    {
        panelEstadistica.EstableciendoEstadisticas(Experiencia,ExperienciaMaxima, Nivel, Salud,Mana, Ataque, Defensa, Velocidad, Habilidad, Curacion, Puntos); 
        panelEstadistica.ActualizandoValores();
        inventario.OnItemRightClickedEvent += EquipadoDesdeInventario;
        panelEquipamiento.OnItemRightClickedEvent += UnequipadoDesdeEquiparPanel;
        
    }
    public void Start()
    {
        
    }
    public void Update()
    {
        EstableciendoBarraExperiencia();
        SubiendoExperiencia();
        
    }
    //Aqui indicamos que si llamamos a la funcion y el objeto se encuentra en el inventario, mandarlo al panel de equipamiento
    private void EquipadoDesdeInventario(Objeto objeto)
    {
        if(objeto is ObjetoEquipable)
        {
            Equipo((ObjetoEquipable)objeto);
            panelEstadistica.ActualizandoValores();
        }
    }
    //Aqui indicamos que si llamamos a la funcion y el objeto se encuentra en el panel de equipamiento, mandarlo al inventario
    private void UnequipadoDesdeEquiparPanel(Objeto objeto)
    {
        if(objeto is ObjetoEquipable)
        {
            SinEquipar((ObjetoEquipable)objeto);
            panelEstadistica.ActualizandoValores();
        }
    }
    //Aqui se hace el switch del item equipado al item por equipar
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
    //Aqui indicamos que si el inventario no esta lleno y quitamos el objeto lo agregue al inventario
    public void SinEquipar(ObjetoEquipable objeto)
    {
        if(!inventario.estaLleno() && panelEquipamiento.QuitarObjeto(objeto))
        {
            objeto.NoEquipo(this);
            panelEstadistica.ActualizandoValores();
            inventario.AgregarItem(objeto);
        }
    }
    //Esta funcion es momentanea
    public void SubiendoExperiencia()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Experiencia.ValorBase = Experiencia.ValorBase+10;
            panelEstadistica.ActualizandoValores();
        }
        if(Experiencia.ValorBase >= ExperienciaMaxima.ValorBase)
        {
            Experiencia.ValorBase = 0;
            Nivel.ValorBase = Nivel.ValorBase + 1;
            ExperienciaMaxima.ValorBase = Mathf.RoundToInt(ExperienciaMaxima.ValorBase * 1.2f);
            
            Puntos.ValorBase = Puntos.Valor + 5;
        }
    }
    //Apartir de aqui las funciones son para subir caracteristicas (hay maneras mejores de optimizar el codigo) posible cambio
    public void SubiendoCaracteristicaSalud()
    {
        if(Puntos.ValorBase > 0)
        {
            Salud.ValorBase = Salud.ValorBase + 1;
            Puntos.ValorBase = Puntos.ValorBase - 1;
            panelEstadistica.ActualizandoValores();
        }
    }
    public void SubiendoCaracteristicaMana()
    {
        if (Puntos.ValorBase > 0)
        {
            Mana.ValorBase = Mana.ValorBase + 1;
            Puntos.ValorBase = Puntos.ValorBase - 1;
            panelEstadistica.ActualizandoValores();
        }
    }
    public void SubiendoCaracteristicaAtaque()
    {
        if (Puntos.ValorBase > 0)
        {
            Ataque.ValorBase = Ataque.ValorBase + 1;
            Puntos.ValorBase = Puntos.ValorBase - 1;
            panelEstadistica.ActualizandoValores();
        }
    }
    public void SubiendoCaracteristicaDefensa()
    {
        if (Puntos.ValorBase > 0)
        {
            Defensa.ValorBase = Defensa.ValorBase + 1;
            Puntos.ValorBase = Puntos.ValorBase - 1;
            panelEstadistica.ActualizandoValores();
        }
    }
    public void SubiendoCaracteristicaVelocidad()
    {
        if (Puntos.ValorBase > 0)
        {
            Velocidad.ValorBase = Velocidad.ValorBase + 1;
            Puntos.ValorBase = Puntos.ValorBase - 1;
            panelEstadistica.ActualizandoValores();
        }
    }
    public void SubiendoCaracteristicaHabilidad()
    {
        if (Puntos.ValorBase > 0)
        {
            Habilidad.ValorBase = Habilidad.ValorBase + 1;
            Puntos.ValorBase = Puntos.ValorBase - 1;
            panelEstadistica.ActualizandoValores();
        }
    }
    public void SubiendoCaracteristicaCuracion()
    {
        if (Puntos.ValorBase > 0)
        {
            Curacion.ValorBase = Curacion.ValorBase + 1;
            Puntos.ValorBase = Puntos.ValorBase - 1;
            panelEstadistica.ActualizandoValores();
        }
    }
    public void EstableciendoBarraExperiencia()
    {
            barraExperiencia.value = Experiencia.ValorBase / ExperienciaMaxima.ValorBase;
            panelEstadistica.ActualizandoValores();
    }
    //Aqui termina la locura de estas funciones
}
