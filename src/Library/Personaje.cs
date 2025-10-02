// Archivo: Personaje.cs
namespace Library;
using System;
using System.Collections.Generic;

public class Personaje : IPersonaje
{
    // --- PROPIEDADES COMUNES ---
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

    // --- MÉTODOS COMUNES ---
    public void EquiparItem(Item item)
    {
        if (item is IMagico)
        {
            if (this is Mago) 
            {
                this.Inventario.Add(item);
                Console.WriteLine($"{this.Nombre} (Mago) ha equipado el item mágico {item.Nombre}.");
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
        int defensa = ObtenerDefensaTotal();
        int dañoReal = daño - defensa;

        if (dañoReal > 0)
        {
            this.Vida -= dañoReal;
        }

        if (this.Vida < 0)
        {
            this.Vida = 0;
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
        Console.WriteLine($"¡{this.Nombre} se ha curado por completo!");
    }
}