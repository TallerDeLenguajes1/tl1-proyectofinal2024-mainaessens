namespace Mensajes
{
    public static class Historial
    {
        public static void VerHistorial(List<string> historial)
        {
            Console.WriteLine("Historial de ganadores:");
            foreach (var ganador in historial)
            {
                Console.WriteLine(ganador);
            }
            Console.WriteLine("Presiona cualquier tecla para continuar.");
            Console.ReadKey(true);
        }
    }
}