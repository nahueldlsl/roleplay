namespace Library;
using System.Collections.Generic;
public class Mago : Heroe 
{
    public List<Hechizo> Hechizos { get; set; }


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
