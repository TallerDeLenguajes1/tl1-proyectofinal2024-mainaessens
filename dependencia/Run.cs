using Fabrica;
using System.Diagnostics;
using CombateSimpson;
using TorneoSimpson;
using MenuSeleccionable;
using Mensajes;
using System.Text.Json; // Importar librería para manejar JSON

namespace Start
{
    public static class GameRun
    {
        public static async Task EmpezarAJugar()
        {
            try
            {
                Console.Clear();
                TerminalMensajes.CentradorDeTexto("Obteniendo personajes de la API...");
                List<CitaAPI> citasAPI;

                try
                {
                    // Intentar obtener los personajes desde la API
                    citasAPI = await CitaAPI.ObtenerCitasAPI(5);
                }
                catch (HttpRequestException)
                {
                    // Si falla, cargar los personajes desde el archivo JSON
                    Console.WriteLine("No se pudo acceder a la API, cargando personajes desde el archivo local.");
                    citasAPI = CargarPersonajesDesdeArchivo();
                }

                Console.WriteLine("Selecciona tu personaje:");
                HashSet<string> personajesSeleccionados = new HashSet<string>();
                List<string> personajesDisponibles = new List<string>();

                for (int i = 0; i < citasAPI.Count; i++)
                {
                    string personaje = citasAPI[i].Character;
                    if (!personajesSeleccionados.Contains(personaje))
                    {
                        personajesDisponibles.Add(personaje);
                        personajesSeleccionados.Add(personaje);
                    }
                }

                if (personajesDisponibles.Count == 0)
                {
                    Console.WriteLine("No hay personajes disponibles para seleccionar.");
                    return; // Manejar esta situación según lo que necesites en tu juego.
                }

                string[] personajes = personajesDisponibles.ToArray();

                int seleccion = Menu.MostrarMenu(personajes);
                CitaAPI citaSeleccionada = citasAPI.First(c => c.Character == personajes[seleccion]);

                string frase = citaSeleccionada.Quote;
                Console.Clear();
                TerminalMensajes.CentradorDeTexto($"Su personaje es: {citaSeleccionada.Character}");
                TerminalMensajes.CentradorDeTexto($"Frase: {frase}");
                Thread.Sleep(6000);

                string url = citaSeleccionada.Image;
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });

                Personaje personajeUsuario = FabricaDePersonajes.CrearPersonaje(citaSeleccionada.Character);

                Torneo torneo = new Torneo();
                torneo.IniciarTorneo(personajeUsuario);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR FATAL. Se detuvo la ejecución. " + ex.Message);
            }
        }

        private static List<CitaAPI> CargarPersonajesDesdeArchivo()
        {
            try
            {
                string json = File.ReadAllText("Personajes.json");
                return JsonSerializer.Deserialize<List<CitaAPI>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: No se pudo cargar el archivo de respaldo. " + ex.Message);
                throw;
            }
        }
    }
}
