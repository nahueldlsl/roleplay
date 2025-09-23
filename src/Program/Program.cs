using System;
using System.Collections.Generic;
using Library; 

namespace EncuentrosTierraMedia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Crear personajes
            Elfos legolas = new Elfos("Legolas");
            Mago gandalf = new Mago("Gandalf el Gris");
            Enanos gimli = new Enanos("Gimli");
            Mago saruman = new Mago("Saruman el Blanco");

            // Crear ítems
            Item arcoElfico = new Item("Arco de Lothlórien", 25, 0);
            Item armaduraElfica = new Item("Armadura Élfica", 0, 15);

            Item bastonGris = new Item("Bastón de Poder Gris", 15, 10);
            Item espadaGlamdring = new Item("Espada Glamdring", 20, 5);

            Item hachaGimli = new Item("Hacha de Guerra", 30, 0);
            Item armaduraEnana = new Item("Armadura Enana", 0, 20);

            Item bastonBlanco = new Item("Bastón de Saruman", 18, 12);
            Item armaduraIsengard = new Item("Armadura de Isengard", 0, 25);

            // Asignar inventarios
            legolas.Inventario.Add(arcoElfico);
            legolas.Inventario.Add(armaduraElfica);

            gandalf.Inventario.Add(bastonGris);
            gandalf.Inventario.Add(espadaGlamdring);

            gimli.Inventario.Add(hachaGimli);
            gimli.Inventario.Add(armaduraEnana);

            saruman.Inventario.Add(bastonBlanco);
            saruman.Inventario.Add(armaduraIsengard);

            // Mostrar estado inicial
            Console.WriteLine("--- ¡COMIENZA EL COMBATE EN LA TIERRA MEDIA! ---");
            MostrarEstado(legolas);
            MostrarEstado(gandalf);
            MostrarEstado(gimli);
            MostrarEstado(saruman);
            Console.WriteLine("----------------------------------\n");

            // Combate ejemplo
            Console.WriteLine($"{legolas.Name} ataca a {gimli.Nombre}!");
            legolas.Atacar(gimli);
            MostrarEstado(gimli);

            Console.WriteLine($"{gandalf.Nombre} ataca a {legolas.Name}!");
            gandalf.Atacar(legolas);
            MostrarEstado(legolas);

            Console.WriteLine($"{gimli.Nombre} contraataca a {legolas.Name}!");
            gimli.Atacar(legolas);
            MostrarEstado(legolas);

            Console.WriteLine($"{saruman.Nombre} ataca a {gandalf.Nombre}!");
            saruman.Atacar(gandalf);
            MostrarEstado(gandalf);

            Console.WriteLine("\n--- ESTADO FINAL DESPUÉS DEL COMBATE ---");
            MostrarEstado(legolas);
            MostrarEstado(gandalf);
            MostrarEstado(gimli);
            MostrarEstado(saruman);
        }

        private static void MostrarEstado(dynamic personaje)
        {
            Console.WriteLine($"{personaje.Name} - Vida: {personaje.HealthPoints}, Ataque: {personaje.ObtenerAtaqueTotal()}, Defensa: {personaje.ObtenerDefensaTotal()}");
        }
    }
}

