
namespace Mensajes
{
    public static class TerminalMensajes{

        public static void TituloJuego(){
            Console.ForegroundColor = ConsoleColor.Magenta; 
        string[] letraASCII = [
            @"_____ .   . .___       __  . .    . .__   __   __  .   .  __",
            @"  |   |   | |         (__` | |\  /| |  \ (__` /  \ |\  | (__ ",
            @"  |   |---| |---         \ | | \/ | |__/    \ |  | | \ |    \", 
            @"  |   |   | |___      \__/ | |    | |    \__/ \__/ |  \| \__/"
        ]; 
            int anchoTerminal = Console.WindowWidth;
            string centrado = "";

            foreach (string linea in letraASCII)
                {
                    int padding = (anchoTerminal - linea.Length) / 2;
                    centrado += new string(' ', padding) + linea + Environment.NewLine; //Enviroment.NewLine remplaza el uso de \n.
                }
        }

        public static void ErrorSalir()
            {
                Console.WriteLine("Ouch");
                Console.WriteLine("Saliendo del juego...");
                Environment.Exit(0);
            }
    }
}

