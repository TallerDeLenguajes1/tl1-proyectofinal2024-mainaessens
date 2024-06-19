namespace LosSimpsonInvasionExtraterrestre
{
    public class Personaje
    {
        public string Nombre { get; set; }
        public string Apodo { get; set; }
        public int Edad { get; set; }
        public int Fuerza { get; set; }
        public int Velocidad { get; set; }
        public int Destreza { get; set; }
        public int Inteligencia { get; set; }
        public int Agresivo { get; set; }
        public double Salud { get; set; }

        public Personaje(string nombre, string apodo, int edad, int fuerza, int velocidad, int destreza, int inteligencia, int agresivo, double salud)
        {
            Nombre = nombre;
            Apodo = apodo;
            Edad = edad;
            Fuerza = fuerza;
            Velocidad = velocidad;
            Destreza = destreza;
            Inteligencia = inteligencia;
            Agresivo = agresivo;
            Salud = salud;
        }

        public double CalcularAtaque()
        {
            return Destreza * Fuerza * Agresivo;
        }

        public double CalcularDefensa()
        {
            return Inteligencia * Velocidad;
        }

        public void RecibirDanio(double danio)
        {
            Salud -= danio;
            if (Salud < 0) Salud = 0;
        }

        public bool EstaVivo()
        {
            return Salud > 0;
        }
    }
}
