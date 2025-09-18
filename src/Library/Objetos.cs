namespace Library;

public class Item
{
    public string Nombre { get; set; }
    public int Ataque { get; private set; }
    public int Defensa { get; private set; }
    public List<Item> Inventario { get; set; }

    public Item(string nombre, int ataque, int defensa)
    {
        this.Nombre = nombre;
        this.Ataque = ataque;
        this.Defensa = defensa;
        this.Inventario = new List<Item>();
    }
}