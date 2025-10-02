// Archivo: Encounter.cs
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
        Console.WriteLine("¡COMIENZA EL ENCUENTRO!");

        while (HayHeroesVivos() && HayEnemigosVivos())
        {
            // --- FASE 1: TURNO DE LOS ENEMIGOS ---
            Console.WriteLine("\n--- Turno de los Enemigos ---");
            List<Heroe> heroesVivos = ObtenerHeroesVivos();
            List<Enemigo> enemigosVivos = ObtenerEnemigosVivos();

            if (heroesVivos.Count > 0)
            {
                for (int i = 0; i < enemigosVivos.Count; i++)
                {
                    int indiceHeroeAtacado = i % heroesVivos.Count;
                    Enemigo atacante = enemigosVivos[i];
                    Heroe defensor = heroesVivos[indiceHeroeAtacado];

                    Console.WriteLine($"{atacante.Nombre} ataca a {defensor.Nombre}.");
                    atacante.Atacar(defensor);
                }
            }
            
            // --- FASE 2: TURNO DE LOS HÉROES ---
            Console.WriteLine("\n--- Turno de los Héroes ---");
            // Volvemos a obtener las listas por si algún héroe murió en la fase anterior
            heroesVivos = ObtenerHeroesVivos(); 
            enemigosVivos = ObtenerEnemigosVivos();

            // Bucle externo: recorre a los héroes que atacan
            foreach (Heroe heroe in heroesVivos)
            {
                // Bucle interno: recorre a los enemigos que son atacados
                foreach (Enemigo enemigo in enemigosVivos)
                {
                    // Un enemigo ya derrotado no puede ser atacado de nuevo en este turno
                    if (enemigo.Vida > 0)
                    {
                        Console.WriteLine($"{heroe.Nombre} ataca a {enemigo.Nombre}.");
                        int vidaEnemigoAntes = enemigo.Vida;
                        heroe.Atacar(enemigo);

                        // Comprobar si el enemigo murió con este ataque
                        if (enemigo.Vida <= 0 && vidaEnemigoAntes > 0)
                        {
                            Console.WriteLine($"{enemigo.Nombre} ha sido derrotado!");
                            heroe.AcumularPuntos(enemigo.ValorDePuntosDeVictoria);

                            // Comprobar si el héroe debe curarse
                            if (heroe.PuntosDeVictoria >= 5 && !heroe.YaRecibioCuraPorVP)
                            {
                                heroe.Curar();
                                heroe.YaRecibioCuraPorVP = true; // Marcamos que ya se curó
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine("\n¡EL ENCUENTRO HA TERMINADO!");
        
        // --- LÓGICA DEL GANADOR ---
        if (HayHeroesVivos())
        {
            Console.WriteLine("¡Los Héroes han ganado!");
        }
        else
        {
            Console.WriteLine("¡Los Enemigos han ganado!");
        }
    }

    // --- MÉTODOS PRIVADOS DE AYUDA (Refactorizados para reutilizarlos) ---

    private List<Heroe> ObtenerHeroesVivos()
    {
        List<Heroe> heroesVivos = new List<Heroe>();
        foreach (Heroe heroe in this.heroes)
        {
            if (heroe.Vida > 0)
            {
                heroesVivos.Add(heroe);
            }
        }
        return heroesVivos;
    }
    
    private bool HayHeroesVivos()
    {
        return ObtenerHeroesVivos().Count > 0;
    }

    private List<Enemigo> ObtenerEnemigosVivos()
    {
        List<Enemigo> enemigosVivos = new List<Enemigo>();
        foreach (Enemigo enemigo in this.enemigos)
        {
            if (enemigo.Vida > 0)
            {
                enemigosVivos.Add(enemigo);
            }
        }
        return enemigosVivos;
    }

    private bool HayEnemigosVivos()
    {
        return ObtenerEnemigosVivos().Count > 0;
    }
}