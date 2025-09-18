namespace Library;

public class Elfos
{
    public string Name { get; set; }
    public int HealthPoints { get; private set; }
    public List<Item> Inventario;
    public Elfos(string name)
    {
        this.Name = name;
        this.HealthPoints = 100;
        this.Inventario = new List<Item>
        {
            new Item("Arco", 70, 0),
            new Item("Armadura", 0, 65)
        };
    }
    // Calcular ataque total
    public int ObtenerAtaqueTotal()
    {
        int total = 0;
        foreach (var item in Inventario)
        {
            total += item.Ataque;
        }

        return total;
    }
    // Calcular defensa total
    public int ObtenerDefensaTotal()
    {
        int total = 0;
        foreach (var item in Inventario)
        {
            total += item.Defensa;
        }

        return total;
    }
    // Recibir daño
    public void RecibirDaño(int daño)
    {
        int defensa = ObtenerDefensaTotal();
        int dañoReal = daño - defensa;
        if (dañoReal < 0)
        {
            dañoReal = 0;
        }

        this.HealthPoints -= dañoReal;
        if (this.HealthPoints < 0)
        {
            this.HealthPoints = 0;
        }
    }
    /*public void Atacar()*/ //Queda pendiente 
}