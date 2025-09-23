using NUnit.Framework;
using Library;

namespace LibraryTests
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