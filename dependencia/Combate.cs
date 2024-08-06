using MenuSeleccionable;

namespace CombateSimpson
{
    public class Combate
    {
        private Personaje jugador;
        private Personaje enemigo;
        private Random random = new Random();
        private bool jugadorDefendiendo = false;
        private bool pocionUsada; // Indica si la poción ha sido utilizada

        public Combate(Personaje p1, Personaje p2, ref bool pocionUsada)
        {
            jugador = p1;
            enemigo = p2;
            this.pocionUsada = pocionUsada;
            Console.Clear(); 
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

            //MostrarCuadroDeEstadisticas(jugador, enemigo);
            string ganador; 
            if (jugador.Salud > 0)
            {
                ganador = jugador.Nombre; 
            }else {
                ganador = enemigo.Nombre; 
            }
            //string ganador = jugador.Salud > 0 ? jugador.Nombre : enemigo.Nombre;
            //Console.WriteLine($"¡{ganador} ha ganado el combate!");
            //Console.Clear();
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
            string[] opciones = { "Atacar", "Defender", "Ataque Especial" ,"Usar poción mágica","Rendirse" };

            while (true)
            {
                //Console.SetCursorPosition(0, 0); // Volver al inicio de la pantalla
                //MostrarCuadroDeEstadisticas(jugador, enemigo);
                Console.WriteLine($"\t{atacante.Nombre}, ¿qué quieres hacer?");
                int seleccion = Menu.MostrarMenu(opciones);

                switch (seleccion)
                {
                    case 0: // Atacar
                        RealizarAtaque(atacante, defensor);
                        return; 
                    case 1: // Defender
                        RealizarDefensa(atacante);
                        return; 
                    case 2: 
                        RealizarAtaqueEspecial(atacante, defensor); 
                        return; 
                    case 3: 
                        if (pocionUsada)
                        {
                            Console.WriteLine("Ya has usado la poción mágica.");
                            Thread.Sleep(500);
                        }
                        else
                        {
                            jugador.Salud = 100; // Recuperar la salud al 100%
                            pocionUsada = true; // Marcar la poción como usada
                            Console.WriteLine($"{atacante.Nombre} ha usado una poción mágica y recuperado toda su salud.");
                            Thread.Sleep(500);
                        }
                        Console.Clear(); 
                        return;
                    case 4: // Rendirse
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
            Console.Clear(); 
        }

        private void RealizarDefensa(Personaje defensor)
        {
            Console.WriteLine($"{defensor.Nombre} se defiende y recibirá menos daño en el próximo turno.");
            jugadorDefendiendo = true;
            Console.Clear(); 
        }

        private void RealizarAtaqueEspecial(Personaje atacante, Personaje defensor){
        int dañoProvocado = CalcularDaño(atacante, defensor) * 5; 
        Console.WriteLine($"{atacante.Nombre} usa un ataque especial y causa {dañoProvocado} de daño a {defensor.Nombre}");
        defensor.Salud -= dañoProvocado;
        Thread.Sleep(500);
        Console.Clear(); 
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
            
            // Mostrar salud del jugador y del enemigo
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{p1.Nombre.PadRight(20)}| Salud: {BarraDeSalud(p1.Salud, 100)} {p1.Salud}/100 ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{p2.Nombre.PadRight(20)}| Salud: {BarraDeSalud(p2.Salud, 100)} {p2.Salud}/100 |");
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
