public class Stats
{
    public float Curacion;
    public float Salud;
    public int Lvl;
    public float Defensa;
    public float Ataque;
    public float Habilidad;
    public float velocidad;

    public Stats(float curacion, float Salud, float Ataque, float Defensa, float Habilidad, float velocidad)
    {
        this.Curacion = Salud;
        this.Salud = Salud;
        this.Defensa = Defensa;
        this.Ataque = Ataque;
        this.Habilidad = Habilidad;
        this.velocidad = velocidad;

    }
    public Stats Clone()
    {
        return new Stats(this.Curacion,this.Salud, this.Habilidad, this.Defensa, this.Ataque, this.velocidad);
    }
}
