namespace Library;

public class Item :IAtacante, IDefensor
{
    public string Nombre { get; set; }
    public int Ataque { get; set; }
    public int Defensa { get; set; }
}