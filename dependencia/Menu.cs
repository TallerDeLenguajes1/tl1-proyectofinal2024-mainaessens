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
                //Console.Clear(); // Comentar para evitar limpiar la consola antes de regresar
            }
        }
    }
}
