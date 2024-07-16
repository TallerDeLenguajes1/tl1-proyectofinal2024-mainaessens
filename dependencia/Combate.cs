using MenuSeleccionable; 
namespace CombateSimpson
{
    public class Combate
    {
        private Personaje jugador;
        private Personaje enemigo;
        private Random random = new Random();

        public Combate(Personaje p1, Personaje p2)
        {
            jugador = p1;
            enemigo = p2;
            Console.WriteLine($"¡Comienza la batalla entre {jugador.Nombre} y {enemigo.Nombre}!");
        }

        public string IniciarCombate()
        {
            while (jugador.Salud > 0 && enemigo.Salud > 0)
            {
                Turno(jugador, enemigo);
                if (enemigo.Salud <= 0) break;
                Turno(enemigo, jugador);
            }

            return jugador.Salud > 0 ? jugador.Nombre : enemigo.Nombre;
            // do
            // {
            //     Turno(jugador, enemigo);
            //     if (enemigo.Salud <= 0 || jugador.Salud <= 0){
            //         break; 
            //         //Ganador(enemigo, jugador); 
            //     }else{
            //         Turno(enemigo, jugador);
            //     }

            // } while (jugador.Salud > 0 && enemigo.Salud > 0);
            // if (enemigo.Salud == 0)
            // {
            //    return jugador.Nombre;
            //  }else {
            //   return enemigo.Nombre; 
            // }

            // return jugador.Salud > 0 ? jugador.Nombre : enemigo.Nombre;
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

        public void Ganador(Personaje atacante, Personaje defensor){
            if (atacante.Salud > 0)
            {
                Console.WriteLine($"\nGANASTE {atacante.Nombre}");
            }else {
                Console.WriteLine($"\nPERDISTE {atacante.Nombre}");
            }

            if (defensor.Salud > 0)
            {
                Console.WriteLine($"\nGANASTE {defensor.Nombre}");
            }else {
                Console.WriteLine($"\nPERDISTE {defensor.Nombre}");
            }
        }
    }
}