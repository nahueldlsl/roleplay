using System;
using System.Collections.Generic;
using Library;

public class Program
{
    public static void Main(string[] args)
    {
        IPersonaje aragorn = new Enano("Aragorn");
        IPersonaje gandalf = new Mago("Gandalf");

        Item espada = new Item { Nombre = "Espada Común", Ataque = 15, Defensa = 5 };
        Item bastonMagico = new BastonMagico { Nombre = "Bastón de Poder", Ataque = 10, Defensa = 20 };

        Console.WriteLine("--- INTENTANDO EQUIPAR ITEMS ---");
            
        aragorn.EquiparItem(espada);
        aragorn.EquiparItem(bastonMagico); // Debería fallar

        Console.WriteLine("--------------------------------");

        gandalf.EquiparItem(espada);
        gandalf.EquiparItem(bastonMagico); // Debería funcionar

        Console.WriteLine("\n--- COMBATE DE PRUEBA ---");
        Console.WriteLine($"Vida inicial de Aragorn: {aragorn.Vida}");
        gandalf.Atacar(aragorn);
        Console.WriteLine($"Vida final de Aragorn: {aragorn.Vida}");
    }
}
