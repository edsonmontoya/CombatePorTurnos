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
public enum TipoHabilidadCombate
{
    ENTERO,
    HABILIDAD,
    CURATIVO,
    VERDADERO,
    ENTEROENEMIGO,
    HABILIDADENEMIGO,
    CURATIVOENEMIGO,
    VERDADEROENEMIGO
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
    public TipoHabilidadCombate tipoHabilidadCombate;
    


    
    public void SiEquipoHab(Characters c)
    {

        
    
       
    }
    //Si elobjeto no esta siendo equipado llamas la funcion de quitar los modificadores
    public void NoEquipoHab(Characters c)
    {
        
    }
}
