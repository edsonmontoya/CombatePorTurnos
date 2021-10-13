public class Stats
{
    public float Curacion;
    public float Salud;
    public int Lvl;
    public float Defensa;
    public float Ataque;
    public float Habilidad;

    public Stats(float Salud, int Lvl, float Defensa, float Ataque, float Habilidad)
    {
        this.Curacion = Salud;
        this.Salud = Salud;
        this.Lvl = Lvl;
        this.Defensa = Defensa;
        this.Ataque = Ataque;
        this.Habilidad = Habilidad;

    }
    public Stats Clone()
    {
        return new Stats(this.Salud, this.Lvl, this.Habilidad, this.Defensa, this.Ataque);
    }
}
