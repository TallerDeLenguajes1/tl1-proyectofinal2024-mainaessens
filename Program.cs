using Mensajes;
using Ganadores; 
using Start;
using MenuSeleccionable;
using Musica; 

internal class Program
{
    static async Task Main(string[] args)
    {
        Audio.MostrarOpcionesMusica();

        bool salir = false;
        
        while (!salir)
        {
            string[] opciones = { "Jugar", "Ver historial de ganadores", "Salir" };
            int seleccion = Menu.MostrarMenu(opciones);

            switch (seleccion)
            {
                case 0:
                    await GameRun.EmpezarAJugar();
                    break;
                case 1:
                    HistorialDeGanadores.MostrarHistorial(); 
                    break;
                case 2:
                    salir = true;
                    break;
            }
        }
    }
}
