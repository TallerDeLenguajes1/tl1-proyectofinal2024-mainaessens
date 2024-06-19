
public class FabricaDePersonajes
{
    private Random random = new Random();

    public List<Personaje> CrearPersonajes()
    {
        return new List<Personaje>
        {
                new Personaje("Homer Jay Simpson", "Homero", 36, 5, 2, 2, 1, 5, 100),
                new Personaje("Bartholomew JoJo Simpson", "Bart", 10, 3, 5, 5, 2, 3, 100),
                new Personaje("Lisa Marie Simpson", "Lisa", 8, 1, 5, 2, 5, 1, 100),
                new Personaje("Marjorie Jacqueline Bouvier", "Marge", 34, 3, 3, 5, 4, 3, 100),
                new Personaje("Margaret Simpson", "Maggie", 1, 4, 5, 5, 3, 5, 100),
                new Personaje("Kang", "Kang", 100, 4, 3, 4, 3, 5, 100),
                new Personaje("Kodos", "Kodos", 80, 3, 3, 5, 1, 1, 100),
                new Personaje("Serak the preparer", "Serak", 60, 3, 5, 4, 3, 5, 100),
                new Personaje("Kamala", "Kamala", 40, 5, 5, 4, 3, 2, 100),
                new Personaje("Ozmodiar", "Ozmodiar", 120, 2, 5, 3, 2, 5, 100)
        };
    }

    Personaje ObtenerPersonajeAleatorio(List<Personaje> personajes)
    {
            int index = random.Next(personajes.Count);
            Personaje personaje = personajes[index];
            personajes.RemoveAt(index);
            return personaje;
        }
 }
