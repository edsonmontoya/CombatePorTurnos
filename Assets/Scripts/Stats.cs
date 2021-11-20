public class Stats : Characters
{
    public CaracteristicasStats NivelCombate;
    public CaracteristicasStats SaludCombate;
    public CaracteristicasStats vidaActualCombate;
    public CaracteristicasStats ManaCombate;
    public CaracteristicasStats ManaActualCombate;
    public CaracteristicasStats AtaqueCombate;
    public CaracteristicasStats DefensaCombate;
    public CaracteristicasStats VelocidadCombate;
    public CaracteristicasStats HabilidadCombate;
    public CaracteristicasStats CuracionCombate;
    public CaracteristicasStats ExperienciaCombate;
    
    

    public Stats(int NivelCombate, int SaludCombate, int vidaActualCombate, int ManaActualCombate,int ManaCombate, int AtaqueCombate, int DefensaCombate, int VelocidadCombate, int HabilidadCombate,int CuracionCombate, int ExperienciaCombate)
    {
        this.NivelCombate = Nivel;
        this.SaludCombate = Salud;
        this.vidaActualCombate = vidaActual;
        this.ManaActualCombate = ManaActual;
        this.ManaCombate = Mana;
        this.AtaqueCombate = Ataque;
        this.DefensaCombate = Defensa;
        this.VelocidadCombate = Velocidad;
        this.HabilidadCombate = Habilidad;
        this.CuracionCombate = Curacion;
        this.ExperienciaCombate = Experiencia;

    }
    /*public Stats Clone()
    {
       // return new Stats(this.NivelCombate, this.Salud, this.vidaActual, this.ManaActual, this.Mana, this.Ataque, this.Defensa, this.Velocidad, this.Habilidad, this.Curacion, this.Experiencia);
    }*/
}
