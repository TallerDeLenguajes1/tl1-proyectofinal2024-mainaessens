namespace Mensajes
{
    public static class TerminalMensajes
    {
        public static void TituloJuego()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string[] letraASCII = {
                @"_____ .   . .___       __  . .    . .__   __   __  .   .  __",
                @"  |   |   | |         (__` | |\  /| |  \ (__` /  \ |\  | (__ ",
                @"  |   |---| |---         \ | | \/ | |__/    \ |  | | \ |    \",
                @"  |   |   | |___      \__/ | |    | |    \__/ \__/ |  \| \__/"
            };

            Console.WriteLine(letraASCII);
        }

        public static void ErrorSalir()
        {
            Console.WriteLine("Ouch");
            Console.WriteLine("Saliendo del juego...");
            Environment.Exit(0);
        }
    }
}
