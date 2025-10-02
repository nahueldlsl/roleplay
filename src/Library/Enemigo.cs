namespace Library;

public class Enemigo : Personaje
{
    public int ValorDePuntosDeVictoria { get; }

    public Enemigo(String nombre, int valorVP) : base(nombre)
    {
        this.ValorDePuntosDeVictoria = valorVP;
    }
}