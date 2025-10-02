using NUnit.Framework;
using Library;
using System.Collections.Generic;

public class ElfosTests
{
    [Test]
    public void Constructor_CreaElfoCorrectamente()
    {
        // Arrange & Act
        Elfos elfo = new Elfos("Legolas");

        // Assert
        Assert.AreEqual("Legolas", elfo.Nombre);
        Assert.AreEqual(100, elfo.Vida);
        Assert.AreEqual(0, elfo.Inventario.Count);
    }

    [Test]
    public void EquiparItem_AñadeItemAlInventario()
    {
        // Arrange
        Elfos elfo = new Elfos("Legolas");
        Item arco = new Item { Nombre = "Arco", Ataque = 20, Defensa = 0 };

        // Act
        elfo.EquiparItem(arco);

        // Assert
        Assert.AreEqual(1, elfo.Inventario.Count);
        Assert.AreEqual("Arco", elfo.Inventario[0].Nombre);
    }

    [Test]
    public void Atacar_ReduceLaVidaDelEnemigo()
    {
        // Arrange
        Elfos atacante = new Elfos("Legolas");
        Elfos defensor = new Elfos("Tauriel");
        Item arco = new Item { Nombre = "Arco", Ataque = 25, Defensa = 0 };
        atacante.EquiparItem(arco);
        
        int vidaInicialDefensor = defensor.Vida;

        // Act
        atacante.Atacar(defensor);

        // Assert
        Assert.AreEqual(vidaInicialDefensor - 25, defensor.Vida);
    }
}