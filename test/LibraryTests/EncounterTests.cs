using NUnit.Framework;
using Library;
using System.Collections.Generic;

public class EncounterTests
{
    [Test]
    public void UnHeroeFuerteVenceAUnEnemigoDebil()
    {

        Heroe heroe = new Mago("Gandalf");
        heroe.EquiparItem(new Item { Nombre = "Bastón de Poder", Ataque = 100, Defensa = 100 });


        Enemigo enemigo = new Enemigo("Orco", 3);

        List<Heroe> heroes = new List<Heroe> { heroe };
        List<Enemigo> enemigos = new List<Enemigo> { enemigo };

        Encounter encuentro = new Encounter(heroes, enemigos);

        encuentro.DoEncounter();
        
        Assert.AreEqual(0, enemigo.Vida);

        Assert.IsTrue(heroe.Vida > 0);

        Assert.AreEqual(3, heroe.PuntosDeVictoria);
    }
}