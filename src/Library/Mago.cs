namespace Library;

public class Mago
{
    public string Nombre { get; set; }
    public int Vida { get; private set; }

    public List<Hechizo> Hechizos { get; set; }

    public List<Item> Inventario;
    // --- ESTE ES EL CONSTRUCTOR ---
    public Mago(string nombre)
    {
        this.Nombre = nombre;
        this.Vida = 100; // Le damos una vida inicial de 100
        this.Hechizos = new List<Hechizo>(); // Creamos la lista vacía para que no dé error
    }

    public int ObtenerAtaqueTotal()
    {
        int ataqueTotal = 0;
        foreach (Item item in this.Inventario)
        {
            ataqueTotal = ataqueTotal + item.Ataque;
        }
        return ataqueTotal;
    }
    public int ObtenerDefensaTotal()
    {
        int defensaTotal = 0;
        foreach (Item item in this.Inventario)
        {
            defensaTotal = defensaTotal + item.Defensa;
        }
        return defensaTotal;
    }
    public void RecibirDaño(int daño)
    {
        this.Vida = this.Vida - daño;
    }
    public void Atacar(Mago enemigo) // Solo ataca a Magos
    {
        int ataque = this.ObtenerAtaqueTotal();
        enemigo.RecibirDaño(ataque);
    }
    public void Curar()
    {
        this.Vida = 100;
    }
}
public class Hechizo
{
    public string Nombre { get; set; }
    public int Ataque { get; set; }
}
