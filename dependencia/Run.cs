using Fabrica;
using System.Diagnostics;
using CombateSimpson;
using TorneoSimpson;
using MenuSeleccionable;
using Mensajes; 

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
            List<CitaAPI> citasAPI = await CitaAPI.ObtenerCitasAPI(5);

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
                return; // Puedes manejar esta situación según lo que necesites en tu juego.
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
        catch (HttpRequestException ex)
        {
            Console.WriteLine("ERROR: No se pudo acceder a la API. " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR FATAL. Se detuvo la ejecución. " + ex.Message);
        }
    }
}

}