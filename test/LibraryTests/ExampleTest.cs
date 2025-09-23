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
        }
    }
}
