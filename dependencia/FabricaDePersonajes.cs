public static class FabricaDePersonajes
{
    public static Personaje CrearPersonaje(string nombre)
    {
        return new Personaje(nombre);
    }
}
