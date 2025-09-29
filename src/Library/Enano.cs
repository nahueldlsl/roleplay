namespace Library;
public class Enano : IPersonaje
{
    // --- COPIA 1 DE LAS PROPIEDADES ---
    public string Nombre { get; set; }
    public int Vida { get; private set; }
    public List<Item> Inventario { get; set; }

    // --- COPIA 1 DEL CONSTRUCTOR ---
    public Enano(string nombre)
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
            // 'this is Mago' será falso para un Enano, así que la lógica funciona.
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

    public void Curar()
    {
        this.Vida = 100;
    }
}