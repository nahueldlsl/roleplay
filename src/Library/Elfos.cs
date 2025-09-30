namespace Library;

public class Elfos : IPersonaje
{
    // --- COPIA 1 DE LAS PROPIEDADES ---
    public string Nombre { get; set; }
    public int Vida { get; private set; }
    public List<Item> Inventario { get; set; }

    // --- COPIA 1 DEL CONSTRUCTOR ---
    public Elfos(string nombre)
    {
        this.Nombre = nombre;
        this.Vida = 100;
        this.Inventario = new List<Item>();
    }

    // --- COPIA 1 DE LOS MÉTODOS ---
    public void EquiparItem(Item item)
    {
        if (item is IMagico)
        {
            // 'this is Mago' será falso para un Elfo, así que la lógica funciona.
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
        if (ObtenerDefensaTotal() > 0)
        {
            int defensa = ObtenerDefensaTotal();
            daño = daño - defensa;
            if (daño > 0 && daño <= 100)
            {
                this.Vida -= daño;
            }
            else if (daño > 100)
            {
                this.Vida = 0;
            }
        }
        else
        {
            if (daño > 100)
            {
                this.Vida = 0;
            }
            else
            {
                this.Vida -= daño;
            }
        }
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