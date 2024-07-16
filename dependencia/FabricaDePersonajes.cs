namespace Fabrica
{
    
public static class FabricaDePersonajes
{
    public static Personaje CrearPersonaje(string nombre)
    {
        return new Personaje(nombre);
    }
    public static Personaje CrearEnemigo()
        {
            string[] nombresEnemigos = { "Kang", "Kodos", "Serak", "Kamala", "Ozmodiar" };
            Random random = new Random();
            string nombre = nombresEnemigos[random.Next(nombresEnemigos.Length)];
            return new Personaje (nombre);
        }
}

}