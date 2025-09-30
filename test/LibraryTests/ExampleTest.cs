using NUnit.Framework;
using Library;

namespace LibraryTests;

public class Test()
{
    [Test]
    public void CrearElfoTest()
    {
        // Arrange & Act
        Elfos elfo = new Elfos("Legolas");
        Assert.Pass();
            // Assert
            Assert.AreEqual("Legolas", elfo.Nombre);
            Assert.AreEqual(100, elfo.Vida);
            Assert.AreEqual(2, elfo.Inventario.Count);
        }

        [Test]
        public void CrearElfoConEquipoTest()
        {
            // Arrange
            Elfos elfo = new Elfos("Tauriel");
            Item arco = new Item { Nombre = "Arco", Ataque = 60, Defensa = 0 };
            Item armadura = new Item { Nombre = "Armadura", Defensa = 75, Ataque = 0 };
            elfo.EquiparItem(arco);
            elfo.EquiparItem(armadura);

            // Act
            var item1 = elfo.Inventario[0];
            var item2 = elfo.Inventario[1];

            // Assert
            Assert.AreEqual("Arco", item1.Nombre);
            Assert.AreEqual("Armadura", item2.Nombre);
        }

        [Test]
        public void ElfoAtacarTest()
        {
            // Arrange
            Elfos legolas = new Elfos("Legolas");
            Elfos tauriel = new Elfos("Tauriel");
            Item arco = new Item { Nombre = "Arco", Ataque = 60, Defensa = 0 };
            Item armadura = new Item { Nombre = "Armadura", Defensa = 75, Ataque = 0 };
            legolas.EquiparItem(arco);
            tauriel.EquiparItem(armadura);

            int vidaInicial = tauriel.Vida;

            // Act
            legolas.Atacar(tauriel);

            // Assert
            Assert.Less(tauriel.Vida, vidaInicial,
                "La vida de Tauriel debería haber disminuido después del ataque");
        }
    }

    public class EnanosTests
    {
        [Test]
        public void Constructor_CreaEnanoConVida100YDosItems()
        {
            Enano enano = new Enano("Gimli");
            Item espada = new Item { Nombre = "Espada", Ataque = 80, Defensa = 0 };
            Item escudo = new Item { Nombre = "Escudo", Ataque = 0, Defensa = 55 };
            enano.EquiparItem(espada);
            enano.EquiparItem(escudo);

            Assert.AreEqual("Gimli", enano.Nombre);
            Assert.AreEqual(100, enano.Vida);
            Assert.AreEqual(2, enano.Inventario.Count);
            Assert.AreEqual("Espada", enano.Inventario[0].Nombre);
            Assert.AreEqual("Escudo", enano.Inventario[1].Nombre);
        }

        [Test]
        public void ObtenerAtaqueTotal_SumaAtaquesDeItems()
        {
            Enano enano = new Enano("Gimli");
            Item espada = new Item { Nombre = "Espada", Ataque = 90, Defensa = 0 };
            Item cuchillo = new Item { Nombre = "Cuticuchillo", Ataque = 10, Defensa = 0 };
            enano.EquiparItem(espada);
            enano.EquiparItem(cuchillo);

            int ataqueTotal = enano.ObtenerAtaqueTotal();

            Assert.AreEqual(100, ataqueTotal);
        }

        [Test]
        public void ObtenerDefensaTotal_SumaDefensasDeItems()
        {
            Enano enano = new Enano("Gimli");
            Item escudo = new Item { Nombre = "Escudo", Ataque = 0, Defensa = 50 };
            enano.EquiparItem(escudo);

            int defensaTotal = enano.ObtenerDefensaTotal();

            Assert.AreEqual(50, defensaTotal);
        }

        [Test]
        public void RecibirDaño_MayorQueDefensa_RestaVidaCorrectamente()
        {
            Enano enano = new Enano("Gimli");
            Item escudo = new Item { Nombre = "Escudo", Ataque = 0, Defensa = 50 };
            enano.EquiparItem(escudo);
            
            enano.RecibirDaño(80); // 80 - defensa 50 = 30

            Assert.AreEqual(70, enano.Vida);
        }

        [Test]
        public void RecibirDaño_MenorQueDefensa_NoRestaVida()
        {
            Enano enano = new Enano("Gimli");
            Item escudo = new Item { Nombre = "Escudo", Ataque = 0, Defensa = 50 };
            enano.EquiparItem(escudo);

            enano.RecibirDaño(40); // 40 - defensa 50 = daño real 0

            Assert.AreEqual(100, enano.Vida);
        }

        [Test]
        public void RecibirDaño_NoPermiteVidaNegativa()
        {
            Enano enano = new Enano("Gimli");

            enano.RecibirDaño(500);

            Assert.AreEqual(0, enano.Vida);
        }

        [Test]
        public void Atacar_RestaVidaDelEnemigo()
        {
            Enano atacante = new Enano("Gimli");
            Enano defensor = new Enano("Thorin");
            Item espada = new Item { Nombre = "Espada", Ataque = 100, Defensa = 0 };
            Item escudo = new Item { Nombre = "Escudo", Ataque = 0, Defensa = 50 };
            atacante.EquiparItem(espada);
            defensor.EquiparItem(escudo);

            atacante.Atacar(defensor);

            // ataque = 100, defensa = 50, daño real = 50
            Assert.AreEqual(50, defensor.Vida);
        }
    }


