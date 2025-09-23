namespace Library;

public class Enanos
{
    public string Nombre { get; set; }
    public int Vida { get; private set; }
    public List<Item> Inventario;

    public Enanos(string nombre)
    {
        this.Nombre = nombre;
        this.Vida = 100;
        this.Inventario = new List<Item>
        {
            new Item("Espada", 100, 0),
            new Item("Escudo", 0, 50)
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

        this.Vida -= dañoReal;
        if (this.Vida < 0)
        {
            this.Vida = 0;
        }
    }

    // Atacar a otro Enano (o cualquier personaje que tenga RecibirDaño)
    public void Atacar(Enanos enemigo) // Solo ataca enanos (?)
    {
        int ataque = this.ObtenerAtaqueTotal();
        enemigo.RecibirDaño(ataque);
    }
    public void Atacar(Elfos enemigo) // Solo ataca enanos (?)
    {
        int ataque = this.ObtenerAtaqueTotal();
        enemigo.RecibirDaño(ataque);
    }
    public void Atacar(Mago enemigo) // Solo ataca enanos (?)
    {
        int ataque = this.ObtenerAtaqueTotal();
        enemigo.RecibirDaño(ataque);
    }

    // Mostrar estado
    public void MostrarEstado()
    {
        Console.WriteLine($"{Nombre} tiene {Vida} de vida.");
    }
}