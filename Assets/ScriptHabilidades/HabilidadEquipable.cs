using UnityEngine;

public enum TipoHabilidad
{
   Todas,
   Ninguna,
   otra,
   opcion1,
   opcion2,
   opcion3
}
[CreateAssetMenu]
public class HabilidadEquipable : Habilidad
{
    
    public int DamageFisico;
    public int DamageHabilidad;
    public int AutoCuracion;
    public string TipoDamage;
    [Space]
    public int BuffSalud;
    public int BuffMana;
    public int BuffAtaque;
    public int BuffDefensa;
    public int BuffVelocidad;
    public int BuffHabilidad;
    [Space]
    public int VelocidadDelaHabilidad;
    public int costeMana;
    public string DescripcionObjeto;
    [Space]
    public float porcentajeFisicoDamage;
    public float porcentajeHabilidadDamage;
    public float porcentajeCuracionDamage;
    [Space]
    public TipoHabilidad TipoHabilidad;

    public void SiEquipoHab(Characters c)
    {

        //VALORES ENTEROS
        if (DamageFisico != 0)
        {
            c.Ataque.AgregarModificador(new ModificadorEstadisticas(DamageFisico, TipoModoEstadistica.Entero, this));
        }
        if (DamageHabilidad != 0)
        {
            c.Mana.AgregarModificador(new ModificadorEstadisticas(DamageHabilidad, TipoModoEstadistica.Entero, this));
        }
        if (AutoCuracion != 0)
        {
            c.Salud.AgregarModificador(new ModificadorEstadisticas(AutoCuracion, TipoModoEstadistica.Entero, this));
        }
        if (BuffSalud != 0)
        {
            c.Defensa.AgregarModificador(new ModificadorEstadisticas(BuffSalud, TipoModoEstadistica.Entero, this));
        }
        if (BuffMana != 0)
        {
            c.Velocidad.AgregarModificador(new ModificadorEstadisticas(BuffMana, TipoModoEstadistica.Entero, this));
        }
        if (BuffAtaque != 0)
        {
            c.Habilidad.AgregarModificador(new ModificadorEstadisticas(BuffAtaque, TipoModoEstadistica.Entero, this));
        }
        if (BuffDefensa != 0)
        {
            c.Curacion.AgregarModificador(new ModificadorEstadisticas(BuffDefensa, TipoModoEstadistica.Entero, this));
        }
       
    }
    //Si elobjeto no esta siendo equipado llamas la funcion de quitar los modificadores
    public void NoEquipoHab(Characters c)
    {
        c.Mana.QuitandoTodosLosModificadores(this);
        c.Ataque.QuitandoTodosLosModificadores(this);
        c.Defensa.QuitandoTodosLosModificadores(this);
        c.Salud.QuitandoTodosLosModificadores(this);
        c.Velocidad.QuitandoTodosLosModificadores(this);
        c.Habilidad.QuitandoTodosLosModificadores(this);
        c.Curacion.QuitandoTodosLosModificadores(this);
    }
}
