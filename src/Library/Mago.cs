namespace Library;
using System.Collections.Generic;
// Archivo: Mago.cs
public class Mago : Personaje
{
    // Propiedad única del Mago
    public List<Hechizo> Hechizos { get; set; }

    // El constructor del Mago llama al constructor de Personaje con 'base(nombre)'
    public Mago(string nombre) : base(nombre)
    {
        this.Hechizos = new List<Hechizo>(); 
    }
}
public class Hechizo
{
    public string Nombre { get; set; }
    public int Ataque { get; set; }
}

public class BastonMagico : Item, IMagico
{
    
}
