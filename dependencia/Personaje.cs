using System;

public class Personaje
{
    public string Nombre { get; set; }
    public int Fuerza { get; set; }
    public int Velocidad { get; set; }
    public int Destreza { get; set; }
    public int Inteligencia { get; set; }
    public int Agresivo { get; set; }
    public int Salud { get; set; }

    public Personaje(string nombre)
    {
        Nombre = nombre;
        Fuerza = new Random().Next(1, 10);
        Velocidad = new Random().Next(1, 10);
        Destreza = new Random().Next(1, 5);
        Inteligencia = new Random().Next(1, 10);
        Agresivo = new Random().Next(1, 5);
        Salud = 100;
    }
}
