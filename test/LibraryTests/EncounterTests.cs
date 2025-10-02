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

    [Test]
    public void EnemigosFuertesVencenAUnHeroeDebil()
    {
    
        Heroe heroe = new Elfos("Héroe Débil"); // Sin items
        Enemigo enemigo1 = new Enemigo("Orco Fuerte", 1);
        enemigo1.EquiparItem(new Item { Ataque = 60 });
        Enemigo enemigo2 = new Enemigo("Trasgo Líder", 1);
        enemigo2.EquiparItem(new Item { Ataque = 60 });

        List<Heroe> heroes = new List<Heroe> { heroe };
        List<Enemigo> enemigos = new List<Enemigo> { enemigo1, enemigo2 };
        Encounter encuentro = new Encounter(heroes, enemigos);
        
     
        encuentro.DoEncounter();

    
        Assert.AreEqual(0, heroe.Vida);
        Assert.IsTrue(enemigo1.Vida > 0);
        Assert.IsTrue(enemigo2.Vida > 0);
    }

    [Test]
    public void HeroeSeCuraAlLlegarA5VP()
    {
 
    
        Heroe heroe = new Enano("Gimli");
        heroe.EquiparItem(new Item { Ataque = 100 }); 
        
  
        heroe.RecibirDaño(30); 
        
        Enemigo enemigoCon5VP = new Enemigo("Uruk-hai", 5);

        List<Heroe> heroes = new List<Heroe> { heroe };
        List<Enemigo> enemigos = new List<Enemigo> { enemigoCon5VP };
        Encounter encuentro = new Encounter(heroes, enemigos);
        
   
        encuentro.DoEncounter();
        

        Assert.AreEqual(5, heroe.PuntosDeVictoria);
        Assert.AreEqual(100, heroe.Vida); 
        Assert.IsTrue(heroe.YaRecibioCuraPorVP); 
    }

    [Test]
    public void AtaqueEnemigoEsCiclico()
    {

        Heroe heroe1 = new Mago("Gandalf");
        Heroe heroe2 = new Elfos("Legolas");
        
        Enemigo enemigo1 = new Enemigo("Enemigo 1", 1);
        enemigo1.EquiparItem(new Item { Ataque = 10 });
        Enemigo enemigo2 = new Enemigo("Enemigo 2", 1);
        enemigo2.EquiparItem(new Item { Ataque = 10 });
        Enemigo enemigo3 = new Enemigo("Enemigo 3", 1);
        enemigo3.EquiparItem(new Item { Ataque = 10 });

        heroe1.EquiparItem(new Item { Ataque = 100, Defensa = 100 });
        heroe2.EquiparItem(new Item { Ataque = 100, Defensa = 100 });

        List<Heroe> heroes = new List<Heroe> { heroe1, heroe2 };
        List<Enemigo> enemigos = new List<Enemigo> { enemigo1, enemigo2, enemigo3 };
        Encounter encuentro = new Encounter(heroes, enemigos);


        encuentro.DoEncounter();

        Assert.AreEqual(100, heroe1.Vida);
        

        Assert.AreEqual(100, heroe2.Vida);
    }
}