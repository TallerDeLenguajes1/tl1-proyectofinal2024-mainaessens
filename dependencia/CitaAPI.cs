using System.Text.Json.Serialization;
using System.Text.Json;

public class CitaAPI
{
    [JsonPropertyName("quote")]
    public string Quote { get; set; }

    [JsonPropertyName("character")]
    public string Character { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("characterDirection")]
    public string CharacterDirection { get; set; }

    public void Listar()
    {
        Console.WriteLine($"Personaje: {Character}");
        Console.WriteLine($"Cita: {Quote}");
        
    }

    public static async Task<CitaAPI> ObtenerCitaAPI()
    {
        var url = "https://thesimpsonsquoteapi.glitch.me/quotes";
        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "C# App");
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<CitaAPI> listaCitaAPI = JsonSerializer.Deserialize<List<CitaAPI>>(responseBody);
            return listaCitaAPI.First();
        }
        catch (HttpRequestException)
        {
            Console.WriteLine("ERROR: No se pudo acceder a la API.");
            throw;
        }
    }

    public static async Task<List<CitaAPI>> ObtenerCitasAPI(int cantidad)
    {
        var url = $"https://thesimpsonsquoteapi.glitch.me/quotes?count={cantidad}";
        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "C# App");
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<CitaAPI> listaCitaAPI = JsonSerializer.Deserialize<List<CitaAPI>>(responseBody);
            return listaCitaAPI;
        }
        catch (HttpRequestException)
        {
            Console.WriteLine("ERROR: No se pudo acceder a la API.");
            throw;
        }
    }
}