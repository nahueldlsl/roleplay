namespace Library;
using System.Collections.Generic;

public class Personaje : IPersonaje
{
    // --- PROPIEDADES ---
    public string Nombre { get; set; }
    public int Vida { get; private set; }
    public List<Item> Inventario { get; set; }

    // --- CONSTRUCTOR ---
    public Personaje(string nombre)
    {
        this.Nombre = nombre;
        this.Vida = 100;
        this.Inventario = new List<Item>();
    }

    // --- MÉTODOS DEL CONTRATO IPersonaje ---
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

    public void Atacar(IPersonaje enemigo)
    {
        int dañoTotal = this.ObtenerAtaqueTotal();
        enemigo.RecibirDaño(dañoTotal);
    }

    public void Curar()
    {
        this.Vida = 100;
    }
    
    // Dentro de la clase Personaje
    public void EquiparItem(Item item)
    {
        // PRIMERA PREGUNTA: ¿El item es mágico?
        if (item is IMagico)
        {
            // Si es mágico, SEGUNDA PREGUNTA: ¿Este personaje es un Mago?
            if (this is Mago)
            {
                // Es mágico y soy un Mago, entonces SÍ puedo equiparlo.
                this.Inventario.Add(item);
                Console.WriteLine($"{this.Nombre} (Mago) ha equipado el item mágico {item.Nombre}.");
            }
            else
            {
                // Es mágico pero NO soy un Mago, entonces NO puedo equiparlo.
                Console.WriteLine($"{this.Nombre} no es un ser mágico. No puede equipar {item.Nombre}.");
            }
        }
        else
        {
            // Si el item NO es mágico, cualquiera puede equiparlo sin problemas.
            this.Inventario.Add(item);
            Console.WriteLine($"{this.Nombre} ha equipado {item.Nombre}.");
        }
    }
}