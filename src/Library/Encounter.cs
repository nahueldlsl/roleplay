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

        while (HayHeroesVivos() && HayEnemigosVivos())
        {
            Console.WriteLine("\n--- Turno de los Enemigos ---");
            List<Heroe> heroesVivos = new List<Heroe>();
            foreach (Heroe heroe in this.heroes)
            {
                if (heroe.Vida > 0)
                {
                    heroesVivos.Add(heroe);
                }
            }

            List<Enemigo> enemigosVivos = new List<Enemigo>();
            foreach (Enemigo enemigo in this.enemigos)
            {
                if (enemigo.Vida > 0)
                {
                    enemigosVivos.Add(enemigo);
                }
            }
            
            for (int i = 0; i < enemigosVivos.Count; i++)
            {
                int indiceHeroeAtacado = i % heroesVivos.Count;
            
                Enemigo atacante = enemigosVivos[i];
                Heroe defensor = heroesVivos[indiceHeroeAtacado];

                Console.WriteLine($"{atacante.Nombre} ataca a {defensor.Nombre}.");
                atacante.Atacar(defensor);
            }
        }

        Console.WriteLine("¡El encuentro ha terminado!");
    }
    

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