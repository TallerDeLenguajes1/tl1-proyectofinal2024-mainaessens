using Mensajes;
using Ganadores; 
using Start;
using MenuSeleccionable;

internal class Program
{
    static async Task Main(string[] args)
    {
        TerminalMensajes.TituloJuego(); 

        bool salir = false;
        List<string> historialGanadores = new List<string>();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Bienvenido al juego de Los Simpsons!");
        
        while (!salir)
        {
            string[] opciones = { "Jugar", "Ver historial de ganadores", "Salir" };
            int seleccion = Menu.MostrarMenu(opciones);

            switch (seleccion)
            {
                case 0:
                    await GameRun.EmpezarAJugar(historialGanadores);
                    break;
                case 1:
                    HistorialDeGanadores.MostrarHistorial(); 
                    // Historial.VerHistorial(historialGanadores);
                    break;
                case 2:
                    salir = true;
                    break;
            }
        }
    }
}
