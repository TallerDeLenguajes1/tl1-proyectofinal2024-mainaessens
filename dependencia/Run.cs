using System.Diagnostics;
using CombateSimpson; 

namespace Start
{       
    public static class GameRun
    {
        public static async Task EmpezarAJugar(List<string> historialGanadores)
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
    }
}
