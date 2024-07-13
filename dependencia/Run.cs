using System.Diagnostics;
using System.Text.Json;
using CombateSimpson; 

namespace Start
{
    
    class GameStart
    {
        public static void GameRun(){

            static async Task Main(string[] args)
            {
                bool salir = false;
                List<string> historialGanadores = new List<string>();

                while (!salir)
                {
                    Console.Clear();
                    Console.WriteLine("Bienvenido al juego de Los Simpsons!");
                    string[] opciones = { "Empezar a jugar", "Ver historial de ganadores", "Salir" };
                    int seleccion = MostrarMenu(opciones);

                    switch (seleccion)
                    {
                        case 0:
                            await EmpezarAJugar(historialGanadores);
                            break;
                        case 1:
                            VerHistorial(historialGanadores);
                            break;
                        case 2:
                            salir = true;
                            break;
                    }
                }
            }

            static int MostrarMenu(string[] opciones)
            {
                int seleccion = 0;
                ConsoleKey tecla;
                do
                {
                    Console.Clear();
                    for (int i = 0; i < opciones.Length; i++)
                    {
                        if (i == seleccion)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine($"=> {opciones[i]}");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine($"   {opciones[i]}");
                        }
                    }

                    tecla = Console.ReadKey(true).Key;

                    if (tecla == ConsoleKey.UpArrow)
                    {
                        seleccion = (seleccion == 0) ? opciones.Length - 1 : seleccion - 1;
                    }
                    else if (tecla == ConsoleKey.DownArrow)
                    {
                        seleccion = (seleccion == opciones.Length - 1) ? 0 : seleccion + 1;
                    }
                } while (tecla != ConsoleKey.Enter);

                return seleccion;
            }

            static async Task EmpezarAJugar(List<string> historialGanadores)
            {
                try
                {
                    Console.WriteLine("Obteniendo personaje de la API...");
                    CitaAPI nuevaCitaAPI = await CitaAPI.ObtenerCitaAPI();
                    nuevaCitaAPI.Listar();
                    string url = nuevaCitaAPI.Image;
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });

                    Personaje personajeUsuario = FabricaDePersonajes.CrearPersonaje(nuevaCitaAPI.Character);
                    Personaje personajeMaquina = FabricaDePersonajes.CrearPersonaje("Alien");

                    Combate combate = new Combate(personajeUsuario, personajeMaquina);
                    string ganador = combate.IniciarCombate();

                    historialGanadores.Add(ganador);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR FATAL. Se detuvo la ejecución. " + ex.Message);
                }
            }

            static void VerHistorial(List<string> historialGanadores)
            {
                Console.WriteLine("Historial de ganadores:");
                foreach (var ganador in historialGanadores)
                {
                    Console.WriteLine(ganador);
                }
            }
        }
    }
}
