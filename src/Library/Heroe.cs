
namespace Library;

public class Heroe : Personaje
{
 
    public int PuntosDeVictoria { get; private set; }


    public Heroe(string nombre) : base(nombre)
    {
        this.PuntosDeVictoria = 0; 
    }


    public void AcumularPuntos(int puntos)
    {
        this.PuntosDeVictoria += puntos;
        Console.WriteLine($"{this.Nombre} ha ganado {puntos} VP! Total: {this.PuntosDeVictoria} VP.");
    }
}