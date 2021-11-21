using UnityEngine;
using UnityEngine.UI;

public class PanelEstadistica : MonoBehaviour
{
    public StatusPanel statusPanels;
    [SerializeField] EstadisticaDisplay[] EstadisticasDisplays;
    [SerializeField] string[] nombresEstadisticas;
    public Characters characters;
    public Text Experiencia;
    public PlayerEnemigo playerEnemigo;

    public CaracteristicasStats[] Estadisticas;
    
    private void OnValidate()
    {
        EstadisticasDisplays = GetComponentsInChildren<EstadisticaDisplay>();
        ActualizandoNombreEstadistica();
    }

    //Aqui establecemos los parametros de las estadisticas del script CaracteristicasStats
    public void EstableciendoEstadisticas(params CaracteristicasStats[] charStats)
    {
        Estadisticas = charStats;
        if(Estadisticas.Length> EstadisticasDisplays.Length)
        {
            return;
        }
        for(int i = 0; i < Estadisticas.Length; i++)
        {
            EstadisticasDisplays[i].gameObject.SetActive(i < EstadisticasDisplays.Length);
        }
    }
    //Siempre que ocurra una modificacion se usa esta funcion para que las estadisticas del panel sean igual al valor de las estadisticas
    public void ActualizandoValores()
    {
        for (int i = 0; i < Estadisticas.Length; i++)
        {
            EstadisticasDisplays[i].valorText.text = Estadisticas[i].Valor.ToString();
        }
        //CodigoMomentaneo mientras agrego pociones de mana y salud
       
        statusPanels.healthLabel.text = $"{Mathf.RoundToInt(characters.vidaActual._Valor)}/{Mathf.RoundToInt(characters.Salud._Valor)}";
        statusPanels.manaLabel.text = $"{Mathf.RoundToInt(characters.ManaActual._Valor)}/{Mathf.RoundToInt(characters.Mana._Valor)}";
        statusPanels.levelLabel.text = "Nvl. " + characters.Nivel._Valor.ToString();

        
    }
    //Normalmente es para alguna modificacion de Nombres en el panel
    public void ActualizandoNombreEstadistica()
    {
        for (int i = 0; i < nombresEstadisticas.Length; i++)
        {
            EstadisticasDisplays[i].nametext.text = nombresEstadisticas[i];
        }
    }
}
