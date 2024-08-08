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
            string[] personajes = new string[citasAPI.Count];
            for (int i = 0; i < citasAPI.Count; i++)
            {
                personajes[i] = citasAPI[i].Character;
            }

            int seleccion = Menu.MostrarMenu(personajes);
            CitaAPI citaSeleccionada = citasAPI[seleccion];

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