using UnityEngine;
using UnityEngine.UI;

public class PanelEstadistica : MonoBehaviour
{
    [SerializeField] EstadisticaDisplay[] EstadisticasDisplays;
    [SerializeField] string[] nombresEstadisticas;
    public Text Experiencia;

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
