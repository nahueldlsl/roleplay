using NUnit.Framework;
using Library;

namespace Library.Tests
{
    public class EnanosTests
    {
        [Test]
        public void Constructor_CreaEnanoConVida100YDosItems()
        {
            Enanos enano = new Enanos("Gimli");

            Assert.AreEqual("Gimli", enano.Nombre);
            Assert.AreEqual(100, enano.Vida);
            Assert.AreEqual(2, enano.Inventario.Count);
            Assert.AreEqual("Espada", enano.Inventario[0].Nombre);
            Assert.AreEqual("Escudo", enano.Inventario[1].Nombre);
        }

        [Test]
        public void ObtenerAtaqueTotal_SumaAtaquesDeItems()
        {
            Enanos enano = new Enanos("Gimli");

            int ataqueTotal = enano.ObtenerAtaqueTotal();

            Assert.AreEqual(100, ataqueTotal);
        }

        [Test]
        public void ObtenerDefensaTotal_SumaDefensasDeItems()
        {
            Enanos enano = new Enanos("Gimli");

            int defensaTotal = enano.ObtenerDefensaTotal();

            Assert.AreEqual(50, defensaTotal);
        }

        [Test]
        public void RecibirDaño_MayorQueDefensa_RestaVidaCorrectamente()
        {
            Enanos enano = new Enanos("Gimli");

            enano.RecibirDaño(80); // 80 - defensa 50 = 30

            Assert.AreEqual(70, enano.Vida);
        }

        [Test]
        public void RecibirDaño_MenorQueDefensa_NoRestaVida()
        {
            Enanos enano = new Enanos("Gimli");

            enano.RecibirDaño(40); // 40 - defensa 50 = daño real 0

            Assert.AreEqual(100, enano.Vida);
        }

        [Test]
        public void RecibirDaño_NoPermiteVidaNegativa()
        {
            Enanos enano = new Enanos("Gimli");

            enano.RecibirDaño(500);

            Assert.AreEqual(0, enano.Vida);
        }

        [Test]
        public void Atacar_RestaVidaDelEnemigo()
        {
            Enanos atacante = new Enanos("Gimli");
            Enanos defensor = new Enanos("Thorin");

            atacante.Atacar(defensor);

            // ataque = 100, defensa = 50, daño real = 50
            Assert.AreEqual(50, defensor.Vida);

            {

        public class ElfosTests
        {
            [Test]
            public void CrearElfoTest()
            {
                // Arrange & Act
                Elfos elfo = new Elfos("Legolas");

                // Assert
                Assert.AreEqual("Legolas", elfo.Name);
                Assert.AreEqual(100, elfo.HealthPoints);
                Assert.AreEqual(2, elfo.Inventario.Count);
            }

            [Test]
            public void CrearElfoConEquipoTest()
            {
                // Arrange
                Elfos elfo = new Elfos("Tauriel");

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

                int vidaInicial = tauriel.HealthPoints;

                // Act
                legolas.Atacar(tauriel);

                // Assert
                Assert.Less(tauriel.HealthPoints, vidaInicial,
                    "La vida de Tauriel debería haber disminuido después del ataque");
            }
        }
    }
}
