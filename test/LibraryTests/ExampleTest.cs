namespace LibraryTests;

public class Tests
{
    using NUnit.Framework;
using Library;
using System.Collections.Generic;

namespace LibraryTests
{
    public class Tests
    {
        // Test 1: Verifica que el ataque total se calcule correctamente
        [Test]
        public void GetTotalAttack_ShouldReturnSumOfItemAttacks()
        {
            // Arrange: crear un enano con items conocidos
            Enanos enano = new Enanos("Gimli");
            enano.AddItem(new Item("Hacha", 50, 0));

            // Act: calcular ataque total
            int totalAttack = enano.GetTotalAttack();

            // Assert: espada(100)+hacha(50)+escudo(0) = 150
            Assert.AreEqual(150, totalAttack);
        }

        // Test 2: Verifica que recibir daño reste vida correctamente considerando defensa
        [Test]
        public void ReceiveAttack_ShouldReduceHealthConsideringDefense()
        {
            // Arrange
            Enanos enano = new Enanos("Gimli");
            int incomingDamage = 120; // defensa: escudo(50)+espada(0) = 50

            // Act
            enano.ReceiveAttack(incomingDamage);

            // Assert: daño real = 120-50=70, vida final 100-70=30
            Assert.AreEqual(30, enano.HealthPoints);
        }

        // Test 3: Verifica que no reste vida si defensa es mayor que daño
        [Test]
        public void ReceiveAttack_DefenseGreaterThanDamage_ShouldNotReduceHealth()
        {
            // Arrange
            Enanos enano = new Enanos("Gimli");
            int incomingDamage = 30; // defensa total = 50

            // Act
            enano.ReceiveAttack(incomingDamage);

            // Assert: vida no cambia
            Assert.AreEqual(100, enano.HealthPoints);
        }

        // Test 4: Verifica que un enano ataque correctamente a otro enano
        [Test]
        public void Attack_ShouldReduceTargetEnanoHealth()
        {
            // Arrange
            Enanos atacante = new Enanos("Gimli");
            Enanos objetivo = new Enanos("Thorin");

            // Act
            atacante.Attack(objetivo);

            // Ataque total atacante: espada(100)+escudo(0)=100
            // Defensa objetivo: espada(0)+escudo(50)=50
            // Daño real = 100-50=50, vida objetivo 100-50=50
            Assert.AreEqual(50, objetivo.HealthPoints);
        }

        // Test 5: Verifica que la vida no caiga por debajo de 0
        [Test]
        public void ReceiveAttack_ShouldNotSetHealthBelowZero()
        {
            // Arrange
            Enanos enano = new Enanos("Gimli");
            int incomingDamage = 1000;

            // Act
            enano.ReceiveAttack(incomingDamage);

            // Assert
            Assert.AreEqual(0, enano.HealthPoints);
        }
    }
}