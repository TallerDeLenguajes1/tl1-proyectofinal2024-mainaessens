using MenuSeleccionable;

namespace CombateSimpson
{
    public class Combate
    {
        private Personaje jugador;
        private Personaje enemigo;
        private Random random = new Random();
        private bool jugadorDefendiendo = false;

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
                MostrarCuadroDeEstadisticas(jugador, enemigo);
                TurnoConOpciones(jugador, enemigo);
                if (enemigo.Salud <= 0) break;
                Turno(enemigo, jugador);
            }

            MostrarCuadroDeEstadisticas(jugador, enemigo);
            string ganador = jugador.Salud > 0 ? jugador.Nombre : enemigo.Nombre;
            Console.WriteLine($"¡{ganador} ha ganado el combate!");
            return ganador;
        }

        private void Turno(Personaje atacante, Personaje defensor)
        {
            int dañoProvocado;
            if (jugadorDefendiendo && defensor == jugador)
            {
                dañoProvocado = CalcularDaño(atacante, defensor) / 2;
                Console.WriteLine($"{defensor.Nombre} se defiende y recibe {dañoProvocado} de daño reducido.");
                jugadorDefendiendo = false; // Reseteamos la defensa del jugador
            }
            else
            {
                dañoProvocado = CalcularDaño(atacante, defensor);
                Console.WriteLine($"{atacante.Nombre} causa {dañoProvocado} de daño a {defensor.Nombre}");
            }

            defensor.Salud -= dañoProvocado;
        }

        private void TurnoConOpciones(Personaje atacante, Personaje defensor)
        {
            string[] opciones = { "Atacar", "Defender", "Rendirse" };

            while (true)
            {
                Console.Clear(); 
                Console.SetCursorPosition(0, 0); // Volver al inicio de la pantalla
                MostrarCuadroDeEstadisticas(jugador, enemigo);
                Console.WriteLine($"{atacante.Nombre}, ¿qué quieres hacer?");
                int seleccion = Menu.MostrarMenu(opciones);

                switch (seleccion)
                {
                    case 0: // Atacar
                        RealizarAtaque(atacante, defensor);
                        return; // Salir del bucle después de la acción
                    case 1: // Defender
                        RealizarDefensa(atacante);
                        return; // Salir del bucle después de la acción
                    case 2: // Rendirse
                        Console.WriteLine($"{atacante.Nombre} se rinde. ¡Has perdido el combate!");
                        Environment.Exit(0); 
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Se asumirá que te rindes.");
                        Environment.Exit(0); 
                        break;
                }
            }
        }

        private void RealizarAtaque(Personaje atacante, Personaje defensor)
        {
            int dañoProvocado = CalcularDaño(atacante, defensor);
            Console.WriteLine($"{atacante.Nombre} causa {dañoProvocado} de daño a {defensor.Nombre}");
            defensor.Salud -= dañoProvocado;
        }

        private void RealizarDefensa(Personaje defensor)
        {
            Console.WriteLine($"{defensor.Nombre} se defiende y recibirá menos daño en el próximo turno.");
            jugadorDefendiendo = true;
        }

        private int CalcularDaño(Personaje atacante, Personaje defensor)
        {
            int ataque = atacante.Destreza * atacante.Fuerza * atacante.Agresivo;
            int efectividad = random.Next(1, 101);
            int defensa = defensor.Inteligencia * defensor.Velocidad;
            int dañoProvocado = (ataque * efectividad - defensa) / 500;
            return Math.Max(dañoProvocado, 0); // Asegurarse de que el daño no sea negativo
        }

        private void MostrarCuadroDeEstadisticas(Personaje p1, Personaje p2)
        {
            Console.WriteLine("--------------------------------------------------");

            // Mostrar estadísticas del jugador
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"| {p1.Nombre.PadRight(20)} | {p2.Nombre.PadRight(20)} |");
            Console.ResetColor();

            Console.WriteLine("--------------------------------------------------");
            
            // Mostrar salud del jugador y del enemigo
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"| Salud: {BarraDeSalud(p1.Salud, 100)} {p1.Salud}/100 ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"| Salud: {BarraDeSalud(p2.Salud, 100)} {p2.Salud}/100 |");
            Console.ResetColor();
            
            Console.WriteLine("--------------------------------------------------");
        }

        private string BarraDeSalud(int salud, int saludMaxima)
        {
            int totalCaracteres = 20; // Longitud de la barra de salud
            int caracteresLlenos = (salud * totalCaracteres) / saludMaxima;
            int caracteresVacios = totalCaracteres - caracteresLlenos;

            return "[" + new string('█', caracteresLlenos) + new string(' ', caracteresVacios) + "]";
        }
    }
}
