namespace MenuSeleccionable
{    
    public static class Menu
    {
        public static int MostrarMenu(string[] opciones)
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
    }
}
