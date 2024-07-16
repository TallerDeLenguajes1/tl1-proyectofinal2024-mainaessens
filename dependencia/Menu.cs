using System;

namespace MenuSeleccionable
{
    public static class Menu
    {
        public static int MostrarMenu(string[] opciones)
        {
            Console.ResetColor();
            for (int i = 0; i < opciones.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {opciones[i]}");
            }

            int seleccion;
            while (true)
            {
                Console.Write("Selecciona una opción: ");
                if (int.TryParse(Console.ReadLine(), out seleccion) && seleccion >= 1 && seleccion <= opciones.Length)
                {
                    return seleccion - 1;
                }
                Console.WriteLine("Selección inválida. Por favor, elige una opción válida.");
                Console.Clear();
            }
        }

        public static int MostrarMenu2(string[] opciones)
        {
            int seleccion = 0;
            ConsoleKey tecla;
            do
            {
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
            Console.Clear();

            return seleccion;
        }
    }
}