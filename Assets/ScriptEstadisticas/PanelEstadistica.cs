using UnityEngine;

public class PanelEstadistica : MonoBehaviour
{
    [SerializeField] EstadisticaDisplay[] EstadisticasDisplays;
    [SerializeField] string[] nombresEstadisticas;
    private CaracteristicasStats[] Estadisticas;

    private void OnValidate()
    {
        EstadisticasDisplays = GetComponentsInChildren<EstadisticaDisplay>();
        ActualizandoNombreEstadistica();
    }
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
    public void ActualizandoValores()
    {
        for (int i = 0; i < Estadisticas.Length; i++)
        {
            EstadisticasDisplays[i].valorText.text = Estadisticas[i].Valor.ToString();
        }
    }
    public void ActualizandoNombreEstadistica()
    {
        for (int i = 0; i < nombresEstadisticas.Length; i++)
        {
            EstadisticasDisplays[i].nametext.text = nombresEstadisticas[i];
        }
    }
}
