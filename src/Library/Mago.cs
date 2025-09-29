namespace Library;
public class Mago : IPersonaje
{
    // --- COPIA 2 DE LAS PROPIEDADES ---
    public string Nombre { get; set; }
    public int Vida { get; private set; }
    public List<Item> Inventario { get; set; }
    // Propiedad única del Mago
    public List<Hechizo> Hechizos { get; set; }

    // --- COPIA 2 DEL CONSTRUCTOR ---
    public Mago(string nombre)
    {
        this.Nombre = nombre;
        this.Vida = 100;
        this.Inventario = new List<Item>();
        this.Hechizos = new List<Hechizo>(); // Se inicializa la propiedad del Mago
    }

    // --- COPIA 2 DE LOS MÉTODOS ---
    public void EquiparItem(Item item)
    {
        if (item is IMagico)
        {
            // 'this is Mago' será verdadero para un Mago, así que la lógica funciona.
            if (this is Mago) 
            {
                this.Inventario.Add(item);
                Console.WriteLine($"{this.Nombre} ha equipado el item mágico {item.Nombre}.");
            }
            else
            {
                Console.WriteLine($"{this.Nombre} no es un ser mágico. No puede equipar {item.Nombre}.");
            }
        }
        else
        {
            this.Inventario.Add(item);
            Console.WriteLine($"{this.Nombre} ha equipado {item.Nombre}.");
        }
    }
    
    public int ObtenerAtaqueTotal()
    {
        int ataqueTotal = 0;
        foreach (Item item in this.Inventario) { ataqueTotal += item.Ataque; }
        return ataqueTotal;
    }

    public int ObtenerDefensaTotal()
    {
        int defensaTotal = 0;
        foreach (Item item in this.Inventario) { defensaTotal += item.Defensa; }
        return defensaTotal;
    }

    public void RecibirDaño(int daño)
    {
        this.Vida -= daño;
    }

    public void Atacar(IPersonaje enemigo)
    {
        int dañoTotal = this.ObtenerAtaqueTotal();
        enemigo.RecibirDaño(dañoTotal);
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

public class BastonMagico : Item, IMagico
{
    
}
