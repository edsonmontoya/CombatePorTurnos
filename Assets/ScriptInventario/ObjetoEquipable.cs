using UnityEngine;


public enum TipoEquipamiento 
{
    Casco,
    Armadura,
    Botas,
    Arma,
    SegundaMano,
    Habilidades
}
[CreateAssetMenu]
public class ObjetoEquipable : Objeto
{
    public int SaludBonus;
    public int AtaqueBonus;
    public int DefensaBonus;
    public int VelocidadBonus;
    public int HabilidadBonus;
    public int CuracionBonus;
    public string DescripcionObjeto;
    [Space]
    public float porcentajeSaludBonus;
    public float porcentajeAtaqueBonus;
    public float porcentajeDefensaBonus;
    public float porcentajeVelocidadBonus;
    public float porcentajeHabilidadBonus;
    public float porcentajeCuracionBonus;
    [Space]
    public TipoEquipamiento TipoEquipamiento;

    public void SiEquipo(Characters c)
    {

        //VALORES ENTEROS
        if(AtaqueBonus != 0)
        {
            c.Ataque.AgregarModificador(new ModificadorEstadisticas(AtaqueBonus, TipoModoEstadistica.Entero, this));
        }
        if (SaludBonus != 0)
        {
            c.Salud.AgregarModificador(new ModificadorEstadisticas(SaludBonus, TipoModoEstadistica.Entero, this));
        }
        if (DefensaBonus != 0)
        {
            c.Defensa.AgregarModificador(new ModificadorEstadisticas(DefensaBonus, TipoModoEstadistica.Entero, this));
        }
        if (VelocidadBonus != 0)
        {
            c.Velocidad.AgregarModificador(new ModificadorEstadisticas(VelocidadBonus, TipoModoEstadistica.Entero, this));
        }
        if (HabilidadBonus != 0)
        {
            c.Habilidad.AgregarModificador(new ModificadorEstadisticas(HabilidadBonus, TipoModoEstadistica.Entero, this));
        }
        if (CuracionBonus != 0)
        {
            c.Curacion.AgregarModificador(new ModificadorEstadisticas(CuracionBonus, TipoModoEstadistica.Entero, this));
        }




        //PORCENTAJES


        if (AtaqueBonus != 0)
        {
            c.Ataque.AgregarModificador(new ModificadorEstadisticas(porcentajeAtaqueBonus, TipoModoEstadistica.PorcentajeMultiple, this));
        }
        if (SaludBonus != 0)
        {
            c.Salud.AgregarModificador(new ModificadorEstadisticas(porcentajeSaludBonus, TipoModoEstadistica.PorcentajeMultiple, this));
        }
        if (DefensaBonus != 0)
        {
            c.Defensa.AgregarModificador(new ModificadorEstadisticas(porcentajeDefensaBonus, TipoModoEstadistica.PorcentajeMultiple, this));
        }
        if (VelocidadBonus != 0)
        {
            c.Velocidad.AgregarModificador(new ModificadorEstadisticas(porcentajeVelocidadBonus, TipoModoEstadistica.PorcentajeMultiple, this));
        }
        if (HabilidadBonus != 0)
        {
            c.Habilidad.AgregarModificador(new ModificadorEstadisticas(porcentajeHabilidadBonus, TipoModoEstadistica.PorcentajeMultiple, this));
        }
        if (CuracionBonus != 0)
        {
            c.Curacion.AgregarModificador(new ModificadorEstadisticas(porcentajeCuracionBonus, TipoModoEstadistica.PorcentajeMultiple, this));
        }
    }
    public void NoEquipo(Characters c)
    {
        c.Ataque.QuitandoTodosLosModificadores(this);
        c.Defensa.QuitandoTodosLosModificadores(this);
        c.Salud.QuitandoTodosLosModificadores(this);
        c.Velocidad.QuitandoTodosLosModificadores(this);
        c.Habilidad.QuitandoTodosLosModificadores(this);
        c.Curacion.QuitandoTodosLosModificadores(this);
    }
}
