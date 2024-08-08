using System;

namespace MenuSeleccionable
{
    public static class Menu
    {
        public static int MenuTorneo(string[] opciones)
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
                for (int i = 0; i < opciones.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {opciones[i]}");
                }
            }
        }
        public static int MostrarMenu(string[] opciones)
        {
            int seleccion = 0;
            ConsoleKey tecla;

            while (true)
            {
                Console.Clear();

                int anchoConsola = Console.WindowWidth;

                int[] posInicioX = new int[opciones.Length];
                for (int i = 0; i < opciones.Length; i++)
                {
                    posInicioX[i] = (anchoConsola - opciones[i].Length - 2) / 2; 
                }

                for (int i = 0; i < opciones.Length; i++)
                {
                    Console.SetCursorPosition(posInicioX[i], Console.CursorTop);
                    if (i == seleccion)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"> {opciones[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {opciones[i]}");
                    }
                }

                tecla = Console.ReadKey(true).Key;

                switch (tecla)
                {
                    case ConsoleKey.UpArrow:
                        seleccion = (seleccion == 0) ? opciones.Length - 1 : seleccion - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        seleccion = (seleccion == opciones.Length - 1) ? 0 : seleccion + 1;
                        break;
                    case ConsoleKey.Enter:
                        return seleccion;
                }
            }
        }


    
    }
}
