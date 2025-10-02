using System;
using System.Collections.Generic;
using Library;

public class Program
{
    public static void Main(string[] args)
    {
        IPersonaje aragorn = new Enano("Aragorn");
        IPersonaje gandalf = new Mago("Gandalf");
        IPersonaje legolas = new Elfos("Legolas");

        Item espada = new Item { Nombre = "Espada Común", Ataque = 15, Defensa = 5 };
        Item bastonMagico = new BastonMagico { Nombre = "Bastón de Poder", Ataque = 10, Defensa = 20 };
        Item arco = new Item { Nombre = "Arco", Ataque = 60, Defensa = 0 };

        Console.WriteLine("--- INTENTANDO EQUIPAR ITEMS ---");
            
        aragorn.EquiparItem(espada);
        aragorn.EquiparItem(bastonMagico); // Debería fallar

        Console.WriteLine("--------------------------------");

        gandalf.EquiparItem(espada);
        gandalf.EquiparItem(bastonMagico); // Debería funcionar
        
        Console.WriteLine("--------------------------------");
        
        legolas.EquiparItem(arco);

        Console.WriteLine("\n--- COMBATE DE PRUEBA ---");
        Console.WriteLine($"Vida inicial de Aragorn: {aragorn.Vida}");
        gandalf.Atacar(aragorn);
        Console.WriteLine($"Vida final de Aragorn: {aragorn.Vida}");
        Console.WriteLine("\n--- COMBATE PARTE 2 ---");
        Console.WriteLine($"Vida inicial de Gandalf: {gandalf.Vida}");
        legolas.Atacar(gandalf);
        Console.WriteLine($"Vida final de Gandalf: {gandalf.Vida}");
    }
}
