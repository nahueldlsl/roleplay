using System;
using System.Collections.Generic;

namespace Library;

public class Encounter
{
    private List<Heroe> heroes;
    private List<Enemigo> enemigos;

    public Encounter(List<Heroe> heroes, List<Enemigo> enemigos)
    {
        this.heroes = heroes;
        this.enemigos = enemigos;
    }

    public void DoEncounter()
    {
        Console.WriteLine("¡Comienza el encuentro!");

        // Usamos nuestros nuevos métodos para la condición del bucle.
        while (HayHeroesVivos() && HayEnemigosVivos())
        {
            // Fase 1: Turno de ataque de los Enemigos.

            // Fase 2: Turno de ataque de los Héroes.
        }

        Console.WriteLine("¡El encuentro ha terminado!");
    }

    // --- MÉTODOS PRIVADOS DE AYUDA ---

    private bool HayHeroesVivos()
    {
        foreach (Heroe heroe in this.heroes)
        {
            if (heroe.Vida > 0)
            {
                return true;
            }
        }
        return false;
    }

    private bool HayEnemigosVivos()
    {
        foreach (Enemigo enemigo in this.enemigos)
        {
            if (enemigo.Vida > 0)
            {
                return true;
            }
        }
        return false;
    }
}