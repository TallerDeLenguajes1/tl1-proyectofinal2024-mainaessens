using System;
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
            while (true)
            {
                MostrarCuadroDeEstadisticas(jugador, enemigo);
                Console.WriteLine($"{atacante.Nombre}, ¿qué quieres hacer?");
                string[] opciones = { "Atacar", "Defender", "Rendirse" };
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
                        Environment.Exit(0); // Opción rápida para salir del programa; considera manejarlo de manera más elegante
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Se asumirá que te rindes.");
                        Environment.Exit(0); // Igualmente, considera manejar este caso mejor
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
            return dañoProvocado < 0 ? 0 : dañoProvocado;
        }

        private void MostrarCuadroDeEstadisticas(Personaje p1, Personaje p2)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"| {p1.Nombre.PadRight(20)} | {p2.Nombre.PadRight(20)} |");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"| Salud: {BarraDeSalud(p1.Salud, 100)} {p1.Salud}/100 | Salud: {BarraDeSalud(p2.Salud, 100)} {p2.Salud}/100 |");
            Console.WriteLine($"| Fuerza: {p1.Fuerza.ToString().PadRight(3)} | Fuerza: {p2.Fuerza.ToString().PadRight(3)} |");
            Console.WriteLine($"| Velocidad: {p1.Velocidad.ToString().PadRight(3)} | Velocidad: {p2.Velocidad.ToString().PadRight(3)} |");
            Console.WriteLine($"| Destreza: {p1.Destreza.ToString().PadRight(3)} | Destreza: {p2.Destreza.ToString().PadRight(3)} |");
            Console.WriteLine($"| Inteligencia: {p1.Inteligencia.ToString().PadRight(3)} | Inteligencia: {p2.Inteligencia.ToString().PadRight(3)} |");
            Console.WriteLine($"| Agresivo: {p1.Agresivo.ToString().PadRight(3)} | Agresivo: {p2.Agresivo.ToString().PadRight(3)} |");
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
