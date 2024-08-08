using System;
using CombateSimpson;
using Fabrica; 
using Mensajes; 
using Ganadores;
using System.Diagnostics;

namespace TorneoSimpson
{
    public class Torneo
    {
        private bool pocionUsada = false; // Indica si la poción ha sido utilizada
        public void IniciarTorneo(Personaje jugador)
        {
            string[] nombresEnemigos = { "Kang", "Kodos", "Serak" };
            int nivel = 0;

            foreach (var nombreEnemigo in nombresEnemigos)
            {
                Personaje jugadorNivel = FabricaDePersonajes.CrearPersonaje(jugador.Nombre);
                Console.Clear();
                Thread.Sleep(2000);
                TerminalMensajes.Niveles(nivel); 
                Personaje enemigo = FabricaDePersonajes.CrearEnemigo(nombreEnemigo);
                enemigo.Fuerza += nivel;
                enemigo.Velocidad += nivel;
                enemigo.Destreza += nivel;
                enemigo.Inteligencia += nivel;
                enemigo.Agresivo += nivel;

                Combate combate = new Combate(jugadorNivel, enemigo, ref pocionUsada);

                string ganador = combate.IniciarCombate();

                if (ganador == jugador.Nombre)
                {
                    Console.WriteLine($"¡Felicidades! Has ganado el nivel {nivel + 1}");
                    Thread.Sleep(5000);
                    jugadorNivel.Fuerza += 5;
                    jugadorNivel.Velocidad += 5;
                    jugadorNivel.Destreza += 5;
                    jugadorNivel.Inteligencia += 5;
                    jugadorNivel.Agresivo += 5; 
                    nivel++;
                }
                else
                {
                    Console.WriteLine("Has perdido el torneo.");
                    Thread.Sleep(5000);  // Pausa de 5 segundos (5000 milisegundos)
                    //TerminalMensajes.GanaPierde(jugador, jugador.Nombre); 

                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();  // Espera a que el usuario presione una tecla
                    Console.WriteLine("Continuando...");
                    Console.Clear(); 
                    return;
                }
            }

            Ganador ganadorTorneo = new Ganador
            {
                Nombre = jugador.Nombre,
                Fecha = DateTime.Now,
                NivelAlcanzado = nivel
            };

            Console.WriteLine("¡Felicidades! Has ganado el torneo.");
            TerminalMensajes.GanaPierde(jugador, jugador.Nombre);
            HistorialDeGanadores.GuardarGanador(ganadorTorneo);  
            
        }
    }
}
