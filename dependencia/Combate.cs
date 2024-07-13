namespace Combate
{
    public class Combate
    {
        private Personaje personaje1;
        private Personaje personaje2;
        private Random random = new Random();

        public Combate(Personaje p1, Personaje p2)
        {
            personaje1 = p1;
            personaje2 = p2;
        }

        public string IniciarCombate()
        {
            while (personaje1.Salud > 0 && personaje2.Salud > 0)
            {
                Turno(personaje1, personaje2);
                if (personaje2.Salud <= 0) break;
                Turno(personaje2, personaje1);
            }

            return personaje1.Salud > 0 ? personaje1.Nombre : personaje2.Nombre;
        }

        private void Turno(Personaje atacante, Personaje defensor)
        {
            Console.WriteLine($"{atacante.Nombre} ataca a {defensor.Nombre}");
            int ataque = atacante.Destreza * atacante.Fuerza * atacante.Agresivo;
            int efectividad = random.Next(1, 101);
            int defensa = defensor.Inteligencia * defensor.Velocidad;
            int dañoProvocado = (ataque * efectividad - defensa) / 500;
            dañoProvocado = dañoProvocado < 0 ? 0 : dañoProvocado;

            Console.WriteLine($"{atacante.Nombre} causa {dañoProvocado} de daño a {defensor.Nombre}");
            defensor.Salud -= dañoProvocado;
            Console.WriteLine($"{defensor.Nombre} ahora tiene {defensor.Salud} de salud");
        }
    }
}