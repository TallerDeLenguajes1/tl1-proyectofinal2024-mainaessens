namespace Fabrica
{
    
public static class FabricaDePersonajes
{
    public static Personaje CrearPersonaje(string nombre)
    {
        return new Personaje(nombre);
    }
    public static Personaje CrearEnemigo(string nombreEnemigo)
        {
            return new Personaje(nombreEnemigo);
        }
}

}