using System;
using CombateSimpson;
using Fabrica; 
using Mensajes; 
using Ganadores; 

namespace TorneoSimpson
{
    public class Torneo
    {
        public void IniciarTorneo(Personaje jugador)
        {
            string[] nombresEnemigos = { "Kang", "Kodos", "Serak" };
            int nivel = 0;

            foreach (var nombreEnemigo in nombresEnemigos)
            {
                Personaje jugadorNivel = FabricaDePersonajes.CrearPersonaje(jugador.Nombre);
                Console.Clear();
                Console.WriteLine($"Nivel {nivel}: {nombreEnemigo}");
                Personaje enemigo = FabricaDePersonajes.CrearEnemigo(nombreEnemigo);
                enemigo.Fuerza += 1;
                enemigo.Velocidad += 1;
                enemigo.Destreza += 1;
                enemigo.Inteligencia += 1;
                enemigo.Agresivo += 1;

                Combate combate = new Combate(jugadorNivel, enemigo);
                string ganador = combate.IniciarCombate();

                if (ganador == jugador.Nombre)
                {
                    Console.WriteLine($"¡Felicidades! Has ganado el nivel {nivel + 1}");
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
                    Console.WriteLine("Iniciando pausa de 5 segundos...");
                    Thread.Sleep(5000);  // Pausa de 5 segundos (5000 milisegundos)
                    Console.WriteLine("Pausa terminada.");

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
