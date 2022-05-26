using UnityEngine;
using UnityEngine.UI;

public class Characters : MonoBehaviour
{
    public float cobreDefinitivo;
    public float plataDefinitiva;
    public float experiencidaDefinitiva;
    public string IdName;
    public CaracteristicasStats Nivel;
    public CaracteristicasStats Salud;
    public CaracteristicasStats vidaActual;
    public CaracteristicasStats Mana;
    public CaracteristicasStats ManaActual;
    public CaracteristicasStats Ataque;
    public CaracteristicasStats Defensa;
    public CaracteristicasStats Velocidad;
    public CaracteristicasStats Habilidad;
    public CaracteristicasStats Curacion;
    public CaracteristicasStats Experiencia;
    public CaracteristicasStats ExperienciaMaxima;
    public CaracteristicasStats Puntos;
    public CaracteristicasStats MonedasOro;
    public CaracteristicasStats MonedasPlata;
    public CaracteristicasStats MonedasCobre;
    public Slider barraExperiencia;
    public Inventario inventario;
    public PanelEquipamiento panelEquipamiento;
    [SerializeField] PanelEstadistica panelEstadistica;
    [SerializeField] PanelEquipHab panelEquipamientoHabilidades;
    [SerializeField] Habilidades habilidades;
    [SerializeField] InformacionHabilidad informacionHabilidad;
    [SerializeField] InformacionObjeto informacionObjeto;
    [SerializeField] Image objetoArrastable;
    private SlotHabilidades habilidadArrastable;
    private SlotObjetos itemArrastable;
    public Enemigos enemigos;
    public RecompensaCombate recompensaCombate;

    private void OnValidate()
    {
        if (informacionObjeto == null)
        {
            informacionObjeto = FindObjectOfType<InformacionObjeto>();
        }
        if (informacionHabilidad == null)
        {
            informacionHabilidad = FindObjectOfType<InformacionHabilidad>();
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        panelEstadistica.EstableciendoEstadisticas(Experiencia,ExperienciaMaxima, Nivel, Salud,Mana, Ataque, Defensa, Velocidad, Habilidad, Curacion, Puntos); 
        panelEstadistica.ActualizandoValores();

        inventario.OnRightClickEvent += ObjetoEquipada;
        panelEquipamiento.OnRightClickEvent += ObjetoDesequipada;

        inventario.OnPointerEnterEvent += MostrarInfoObj;
        panelEquipamiento.OnPointerEnterEvent += MostrarInfoObj;

        inventario.OnPointerExitEvent += NoMostrarInfoObj;
        panelEquipamiento.OnPointerExitEvent += NoMostrarInfoObj;

        inventario.OnBeginDragEvent += BeginDragObj;
        panelEquipamiento.OnBeginDragEvent += BeginDragObj;

        inventario.OnEndDragEvent += EndDragObj;
        panelEquipamiento.OnEndDragEvent += EndDragObj;

        inventario.OnDragEvent += DragObj;
        panelEquipamiento.OnDragEvent += DragObj;

        inventario.OnDropEvent += DropObj;
        panelEquipamiento.OnDropEvent += DropObj;

        //------------------------------------------------------------------------


        habilidades.OnRightClickEvent += HabilidadEquipada;
        panelEquipamientoHabilidades.OnRightClickEvent += HabilidadDesequipada;

        habilidades.OnPointerEnterEvent += MostrarInfoHab;
        panelEquipamientoHabilidades.OnPointerEnterEvent += MostrarInfoHab;

        habilidades.OnPointerExitEvent += NoMostrarInfoHab;
        panelEquipamientoHabilidades.OnPointerExitEvent += NoMostrarInfoHab;

        habilidades.OnBeginDragEvent += BeginDrag;
        panelEquipamientoHabilidades.OnBeginDragEvent += BeginDrag;

        habilidades.OnEndDragEvent += EndDrag;
        panelEquipamientoHabilidades.OnEndDragEvent += EndDrag;

        habilidades.OnDragEvent += Drag;
        panelEquipamientoHabilidades.OnDragEvent += Drag;

        habilidades.OnDropEvent += Drop;
        panelEquipamientoHabilidades.OnDropEvent += Drop;
        
    }
    public void Start()
    {
        
    }
    public void Update()
    {
        EstableciendoBarraExperiencia();
        
    }

    public void ObjetoEquipada(SlotObjetos slotObjetos)
    {
        ObjetoEquipable objetoEquipable = slotObjetos.Objeto as ObjetoEquipable;
        if (objetoEquipable != null)
        {
            Equipo(objetoEquipable);
        }
    }
    public void ObjetoDesequipada(SlotObjetos slotObjetos)
    {
        ObjetoEquipable objetoEquipable = slotObjetos.Objeto as ObjetoEquipable;
        if (objetoEquipable != null)
        {
            SinEquipar(objetoEquipable);
        }
    }
    public void MostrarInfoObj(SlotObjetos slotObjetos)
    {
        ObjetoEquipable objetoEquipable = slotObjetos.Objeto as ObjetoEquipable;
        if (objetoEquipable != null)
        {
            informacionObjeto.MostrandoInformacion(objetoEquipable);
        }
    }
    private void NoMostrarInfoObj(SlotObjetos slotObjetos)
    {
        informacionObjeto.OcultandoInformacion();
    }

    private void BeginDragObj(SlotObjetos slotObjetos)
    {
        if (slotObjetos.Objeto != null)
        {
            itemArrastable = slotObjetos;
            objetoArrastable.sprite = slotObjetos.Objeto.imagenObjeto;
            objetoArrastable.transform.position = Input.mousePosition;
            objetoArrastable.enabled = true;
        }
    }
    private void EndDragObj(SlotObjetos slotObjetos)
    {
        itemArrastable = null;
        objetoArrastable.enabled = false;
    }
    private void DragObj(SlotObjetos slotObjetos)
    {
        if (objetoArrastable.enabled)
        {
            objetoArrastable.transform.position = Input.mousePosition;
        }
    }
    private void DropObj(SlotObjetos dropslotObjetos)
    {
       if(dropslotObjetos.PuedeRecibirObjeto(itemArrastable.Objeto)&& itemArrastable.PuedeRecibirObjeto(dropslotObjetos.Objeto))
        {
            ObjetoEquipable tomarObjeto = itemArrastable.Objeto as ObjetoEquipable;
            ObjetoEquipable soltarObjeto = dropslotObjetos.Objeto as ObjetoEquipable;
            if(itemArrastable is SlotsEquipamiento)
            {
                if(tomarObjeto != null)
                {
                    tomarObjeto.NoEquipo(this);
                }
                if (soltarObjeto != null)
                {
                    soltarObjeto.SiEquipo(this);
                }
            }
            if (dropslotObjetos is SlotsEquipamiento)
            {
                if (tomarObjeto != null)
                {
                    tomarObjeto.SiEquipo(this);
                }
                if (soltarObjeto != null)
                {
                    soltarObjeto.NoEquipo(this);
                }
            }
            panelEstadistica.ActualizandoValores();
            Objeto objetoArrastable = itemArrastable.Objeto;
            itemArrastable.Objeto = dropslotObjetos.Objeto;
            dropslotObjetos.Objeto = objetoArrastable;
        }
          
        
    }
    public void HabilidadEquipada(SlotHabilidades slotHabilidades)
    {
        HabilidadEquipable habilidadEquipable = slotHabilidades.habilidad as HabilidadEquipable;
        if (habilidadEquipable != null)
        {
            EquipoHabilidad(habilidadEquipable);
        }
    }
    
    public void HabilidadDesequipada(SlotHabilidades slotHabilidades)
    {
        HabilidadEquipable habilidadEquipable = slotHabilidades.habilidad as HabilidadEquipable;
        if (habilidadEquipable != null)
        {
            SinEquiparHabilidad(habilidadEquipable);
        }
    }
    public void MostrarInfoHab(SlotHabilidades slotHabilidades)
    {
        HabilidadEquipable habilidadEquipable = slotHabilidades.habilidad as HabilidadEquipable;
        if (habilidadEquipable != null)
        {
            informacionHabilidad.MostrandoInformacionHabilidad(habilidadEquipable);
        }
    }
    private void NoMostrarInfoHab(SlotHabilidades slotHabilidades)
    {
        informacionHabilidad.OcultandoInformacionHabilidad();
    }

    private void BeginDrag(SlotHabilidades slotHabilidades)
    {
        if(slotHabilidades.habilidad != null)
        {
            habilidadArrastable = slotHabilidades;
            objetoArrastable.sprite = slotHabilidades.habilidad.imagenHabilidad;
            objetoArrastable.transform.position = Input.mousePosition;
            objetoArrastable.enabled = true;
        }
    }
    private void EndDrag(SlotHabilidades slotHabilidades)
    {
        habilidadArrastable = null;
        objetoArrastable.enabled = false;
    }
    private void Drag(SlotHabilidades slotHabilidades)
    {
        if (objetoArrastable.enabled)
        {
            objetoArrastable.transform.position = Input.mousePosition;
        }
    }
    private void Drop(SlotHabilidades dropslotHabilidades)
    {
        
        if(dropslotHabilidades.PuedeRecibirHabilidad(habilidadArrastable.habilidad) && habilidadArrastable.PuedeRecibirHabilidad(dropslotHabilidades.habilidad))
        {
            HabilidadEquipable TomarItem = habilidadArrastable.habilidad as HabilidadEquipable;
            HabilidadEquipable SoltarItem = dropslotHabilidades.habilidad as HabilidadEquipable;

            if(habilidadArrastable is SlotsEquipHab)
            {
                if (TomarItem != null)
                {
                    TomarItem.NoEquipoHab(this);
                }
                if (SoltarItem != null)
                {
                    SoltarItem.SiEquipoHab(this);
                }
            }
            if (dropslotHabilidades is SlotsEquipHab)
            {
                if (TomarItem != null)
                {
                    TomarItem.SiEquipoHab(this);
                }
                if (SoltarItem != null)
                {
                    SoltarItem.NoEquipoHab(this);
                }

            }
            Habilidad objetoArrastable = habilidadArrastable.habilidad;
            habilidadArrastable.habilidad = dropslotHabilidades.habilidad;
            dropslotHabilidades.habilidad = objetoArrastable;
        }
    }
    //Aqui indicamos que si llamamos a la funcion y el objeto se encuentra en el inventario, mandarlo al panel de equipamiento
 /*
    public void EquipadoDesdeHabilidades(Habilidad habilidad)
    {
        if (habilidad is HabilidadEquipable)
        {
            EquipoHabilidad((HabilidadEquipable)habilidad);
        }
    }
    //Aqui indicamos que si llamamos a la funcion y el objeto se encuentra en el panel de equipamiento, mandarlo al inventario

    public void UnequipadoDesdeHabilidadPanel(Habilidad habilidad)
    {
        if (habilidad is HabilidadEquipable)
        {
            SinEquiparHabilidad((HabilidadEquipable)habilidad);
        }
    }*/
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
    public void EquipoHabilidad(HabilidadEquipable habilidad)
    {
        if (habilidades.QuitarHabilidades(habilidad))
        {
            
            HabilidadEquipable habilidadAnterior;
            if (panelEquipamientoHabilidades.AgregarHabilidad(habilidad, out habilidadAnterior))
            {
                if (habilidadAnterior != null)
                {
                    habilidades.AgregarHabilidades(habilidadAnterior);
                }
            }
            else
            {
                habilidades.AgregarHabilidades(habilidad);
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
    public void SinEquiparHabilidad(HabilidadEquipable habilidad)
    {
        if (!habilidades.estaLleno() && panelEquipamientoHabilidades.QuitarHabilidad(habilidad))
        {
            //habilidad.NoEquipo(this);
            habilidades.AgregarHabilidades(habilidad);

            //habilidades.ActualizandoUIHabilidades();
        }
    }
    //Esta funcion es momentanea
    public void SubiendoExperiencia()
    {
         float RandomExperiencia = Random.value * 5;
         experiencidaDefinitiva = (int)Mathf.Round(enemigos.stats.ExperienciaDa + RandomExperiencia);
        Experiencia._Valor = Mathf.Round(experiencidaDefinitiva + Experiencia._Valor);
           Experiencia.ValorBase = Experiencia._Valor;
            panelEstadistica.ActualizandoValores();
        
        if(Experiencia._Valor >= ExperienciaMaxima.ValorBase)
        {
            Experiencia.ValorBase = 0;
            Nivel.ValorBase = Nivel.ValorBase + 1;
            ExperienciaMaxima.ValorBase = Mathf.RoundToInt(ExperienciaMaxima.ValorBase * 1.2f);
            
            Puntos.ValorBase = Puntos.Valor + 5;
        }
    }
    public void SubiendoMonedas()
    {
        float RandomCobre = Random.value * 10;
        float RandomPlata = Random.value * 2;
         plataDefinitiva = (int)Mathf.Round(enemigos.stats.MonedasPlata + RandomPlata);
         cobreDefinitivo = (int)Mathf.Round(enemigos.stats.MonedasCobre + RandomCobre);

        MonedasCobre._Valor = Mathf.Round(cobreDefinitivo + MonedasCobre._Valor);
        MonedasCobre.ValorBase = MonedasCobre._Valor;

        MonedasPlata._Valor = Mathf.Round(plataDefinitiva + MonedasPlata._Valor);
        MonedasPlata.ValorBase = MonedasPlata._Valor;


        MonedasOro._Valor = MonedasOro._Valor + enemigos.stats.MonedasOro;
        MonedasOro.ValorBase = MonedasOro._Valor;
        

        if (MonedasCobre._Valor >= 100)
        {
            MonedasCobre._Valor = 0;
            MonedasPlata._Valor = MonedasPlata._Valor + 1;
        }
        if(MonedasPlata._Valor >= 100)
        {
            MonedasPlata._Valor = 0;
            MonedasOro._Valor = MonedasOro._Valor + 1;
        }
        panelEstadistica.ActualizandoValores();
    }

    //Apartir de aqui las funciones son para subir caracteristicas (hay maneras mejores de optimizar el codigo) posible cambio
    public void SubiendoCaracteristicaSalud()
    {
        if(Puntos.ValorBase > 0)
        {
            Salud.ValorBase = Salud.ValorBase + 5;
            Puntos.ValorBase = Puntos.ValorBase - 1;
            vidaActual._Valor = Salud._Valor;
            panelEstadistica.ActualizandoValores();
        }
    }
    public void SubiendoCaracteristicaMana()
    {
        if (Puntos.ValorBase > 0)
        {
            Mana.ValorBase = Mana.ValorBase + 5;
            Puntos.ValorBase = Puntos.ValorBase - 1;
            ManaActual._Valor = Mana._Valor;
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
            barraExperiencia.value = Experiencia._Valor / ExperienciaMaxima.ValorBase;
            panelEstadistica.ActualizandoValores();
    }
    //Aqui termina la locura de estas funciones
}
