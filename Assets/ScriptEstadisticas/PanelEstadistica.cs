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
        characters.ManaActual._Valor = characters.Mana._Valor;
        characters.vidaActual._Valor = characters.Salud._Valor;
        statusPanels.healthLabel.text = $"{Mathf.RoundToInt(characters.vidaActual._Valor)}/{Mathf.RoundToInt(characters.Salud._Valor)}";
        statusPanels.manaLabel.text = $"{Mathf.RoundToInt(characters.ManaActual._Valor)}/{Mathf.RoundToInt(characters.Mana._Valor)}";
        statusPanels.levelLabel.text = "Nvl. " + characters.Nivel._Valor.ToString();

        
    }
    public void ActualizandoValoresCombate()
    {
        statusPanels.stats = playerEnemigo.stats;
        playerEnemigo.stats.ManaActualEnemigo = playerEnemigo.enemigosStats.ManaEnemigo;
        playerEnemigo.stats.vidaActualEnemigo = playerEnemigo.enemigosStats.SaludEnemigo;
        statusPanels.healthLabelEnemigo.text = $"{Mathf.RoundToInt(playerEnemigo.enemigosStats.vidaActualEnemigo)}/{Mathf.RoundToInt(playerEnemigo.enemigosStats.SaludEnemigo)}";
        statusPanels.manaLabelEnemigo.text = $"{Mathf.RoundToInt(playerEnemigo.enemigosStats.ManaActualEnemigo)}/{Mathf.RoundToInt(playerEnemigo.enemigosStats.ManaEnemigo)}";
        statusPanels.levelLabelEnemigo.text = "Nvl. " + playerEnemigo.stats.NivelEnemigo;
        statusPanels.nameLabelEnemigo.text = playerEnemigo.IDEnemy;
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
