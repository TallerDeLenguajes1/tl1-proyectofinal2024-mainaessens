using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mensajes;
using Start;
using MenuSeleccionable;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.CursorVisible = false;
        string[] letraASCII = {
                @"_____ .   . .___       __  . .    . .__   __   __  .   .  __",
                @"  |   |   | |         (__` | |\  /| |  \ (__` /  \ |\  | (__ ",
                @"  |   |---| |---         \ | | \/ | |__/    \ |  | | \ |    \",
                @"  |   |   | |___      \__/ | |    | |    \__/ \__/ |  \| \__/"
            };
        foreach (string linea in letraASCII)
        {
            Console.WriteLine(linea);
        }

        bool salir = false;
        List<string> historialGanadores = new List<string>();

        while (!salir)
        {
            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Bienvenido al juego de Los Simpsons!");

            string[] opciones = { "Empezar a jugar", "Ver historial de ganadores", "Salir" };
            int seleccion = Menu.MostrarMenu(opciones);

            switch (seleccion)
            {
                case 0:
                    await GameRun.EmpezarAJugar(historialGanadores);
                    break;
                case 1:
                    Historial.VerHistorial(historialGanadores);
                    break;
                case 2:
                    salir = true;
                    break;
            }
        }
    }
}
