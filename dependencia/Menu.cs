using System;

namespace MenuSeleccionable
{
    public static class Menu
    {
        public static int MostrarMenu(string[] opciones)
        {
            Console.Clear();
            Console.ResetColor();

            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            // Determina el ancho máximo de las opciones para centrar el texto
            int maxOptionLength = 0;
            foreach (var opcion in opciones)
            {
                if (opcion.Length > maxOptionLength)
                {
                    maxOptionLength = opcion.Length;
                }
            }

            // Calcula el margen izquierdo para centrar el texto
            int marginLeft = (consoleWidth - maxOptionLength - 4) / 2; // 4 es por el número y punto

            // Imprime las opciones centradas
            for (int i = 0; i < opciones.Length; i++)
            {
                Console.SetCursorPosition(marginLeft, i + 2); // 2 es para dejar espacio en la parte superior
                Console.WriteLine($"{i + 1}. {opciones[i]}");
            }

            int seleccion;
            while (true)
            {
                Console.SetCursorPosition(marginLeft, opciones.Length + 3); // Posiciona el texto de entrada
                Console.Write("Selecciona una opción: ");
                if (int.TryParse(Console.ReadLine(), out seleccion) && seleccion >= 1 && seleccion <= opciones.Length)
                {
                    return seleccion - 1;
                }
                Console.SetCursorPosition(marginLeft, opciones.Length + 3); // Borra la línea anterior
                Console.Write(new string(' ', 30)); // Borra el texto anterior
                Console.SetCursorPosition(marginLeft, opciones.Length + 3);
                Console.WriteLine("Selección inválida. Por favor, elige una opción válida.");

                // Redibuja el menú centrado
                for (int i = 0; i < opciones.Length; i++)
                {
                    Console.SetCursorPosition(marginLeft, i + 2);
                    Console.WriteLine($"{i + 1}. {opciones[i]}");
                }
            }
        }
    }
}
