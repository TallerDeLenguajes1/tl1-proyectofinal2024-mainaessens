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
           // Por simplicidad, aquí creamos un enemigo genérico
            Random random = new Random();
            string nombre = "Alien";

            return new Personaje(nombre);
        }
}

}