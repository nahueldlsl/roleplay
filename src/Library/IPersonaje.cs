namespace Library;
using System.Collections.Generic;

public interface IPersonaje
{
    // Propiedades que debe tener
    string Nombre { get; set; }
    int Vida { get; } // Solo 'get' para que no se pueda modificar desde fuera.
    List<Item> Inventario { get; set; }

    // Métodos que debe implementar
    void RecibirDaño(int daño);
    void Curar();
    void Atacar(IPersonaje enemigo); // Nota: Ahora ataca a cualquier cosa que sea un IPersonaje.
    int ObtenerAtaqueTotal();
    int ObtenerDefensaTotal();

    void EquiparItem(Item item);
}