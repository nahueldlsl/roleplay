using NUnit.Framework;
using Library;
using System.Collections.Generic;

public class EnanosTests
{
    [Test]
    public void ObtenerAtaqueTotal_SumaAtaquesDeItems()
    {
        // Arrange
        Enano enano = new Enano("Gimli");
        enano.EquiparItem(new Item { Nombre = "Hacha", Ataque = 60 });
        enano.EquiparItem(new Item { Nombre = "Martillo", Ataque = 40 });

        // Act
        int ataqueTotal = enano.ObtenerAtaqueTotal();

        // Assert
        Assert.AreEqual(100, ataqueTotal);
    }

    [Test]
    public void ObtenerDefensaTotal_SumaDefensasDeItems()
    {
        // Arrange
        Enano enano = new Enano("Gimli");
        enano.EquiparItem(new Item { Nombre = "Escudo", Defensa = 30 });
        enano.EquiparItem(new Item { Nombre = "Armadura", Defensa = 20 });

        // Act
        int defensaTotal = enano.ObtenerDefensaTotal();

        // Assert
        Assert.AreEqual(50, defensaTotal);
    }

    [Test]
    public void RecibirDaño_RestaVidaCorrectamente()
    {
        // Arrange
        Enano enano = new Enano("Gimli");
        enano.EquiparItem(new Item { Nombre = "Armadura", Defensa = 50 });

        // Act
        enano.RecibirDaño(80); // Daño de 80 - 50 de defensa = 30 de daño real.

        // Assert
        Assert.AreEqual(70, enano.Vida); // 100 de vida inicial - 30 de daño = 70.
    }

    [Test]
    public void RecibirDaño_NoRestaVidaSiElDañoEsMenorQueLaDefensa()
    {
        // Arrange
        Enano enano = new Enano("Gimli");
        enano.EquiparItem(new Item { Nombre = "Armadura", Defensa = 50 });

        // Act
        enano.RecibirDaño(40); // Daño de 40 - 50 de defensa = daño real 0.

        // Assert
        Assert.AreEqual(100, enano.Vida);
    }

    [Test]
    public void RecibirDaño_NoPermiteVidaNegativa()
    {
        // Arrange
        Enano enano = new Enano("Gimli");
        enano.EquiparItem(new Item { Nombre = "Armadura", Defensa = 50 });

        // Act
        enano.RecibirDaño(500); // 500 - 50 = 450 de daño. La vida debería ser 0, no -350.

        // Assert
        Assert.AreEqual(0, enano.Vida);
    }

    [Test]
    public void Atacar_RestaVidaDelEnemigoCorrectamente()
    {
        // Arrange
        Enano atacante = new Enano("Gimli");
        Enano defensor = new Enano("Thorin");
        atacante.EquiparItem(new Item { Nombre = "Hacha", Ataque = 100 });
        defensor.EquiparItem(new Item { Nombre = "Escudo", Defensa = 50 });

        // Act
        atacante.Atacar(defensor);

        // Assert: 100 de ataque - 50 de defensa = 50 de daño. 100 de vida - 50 = 50.
        Assert.AreEqual(50, defensor.Vida);
    }
}