using System.Text.Json;

namespace Ganadores{

public class Ganador
{
    public string Nombre { get; set; }
    public DateTime Fecha { get; set; }
    public int NivelAlcanzado { get; set; }
}

public class HistorialDeGanadores
{
    public static void MostrarHistorial()
{
    List<Ganador> historial = LeerGanadoresDelHistorial();
    Console.Clear();

    int anchoRecuadro = 60;
    string titulo = "---- HISTORIAL DE GANADORES ----";
    int espacioTitulo = (anchoRecuadro - titulo.Length) / 2;

    // Establecer el color de fondo a celeste
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Clear();

    // Centrar y mostrar el título
    Console.WriteLine(new string(' ', espacioTitulo) + titulo);
    Console.WriteLine(new string('-', anchoRecuadro));

    if (historial.Count == 0)
    {
        string mensajeVacio = "El historial se encuentra vacío.";
        int espacioMensaje = (anchoRecuadro - mensajeVacio.Length) / 2;
        Console.WriteLine(new string(' ', espacioMensaje) + mensajeVacio);
    }
    else
    {
        foreach (var ganador in historial)
        {
            string linea = $"Nombre: {ganador.Nombre}, Fecha: {ganador.Fecha.ToShortDateString()}, Nivel Alcanzado: {ganador.NivelAlcanzado}";
            int espacioLinea = (anchoRecuadro - linea.Length) / 2;
            Console.WriteLine(new string(' ', espacioLinea) + linea);
        }
    }

    Console.WriteLine(new string('-', anchoRecuadro));
    string mensajeVolver = "Presione una tecla para volver";
    int espacioVolver = (anchoRecuadro - mensajeVolver.Length) / 2;
    Console.WriteLine(new string(' ', espacioVolver) + mensajeVolver);

    Thread.Sleep(2000);  // Pausa de 2 segundos (2000 milisegundos)
    Console.ReadKey();   // Espera a que el usuario presione una tecla
    Console.ResetColor();  // Restablecer colores por defecto
    Console.Clear();
}


    public static void GuardarGanador(Ganador ganador)
    {
        List<Ganador> historial = LeerGanadoresDelHistorial();
        historial.Add(ganador);
        string jsonHistorial = JsonSerializer.Serialize(historial, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("recursos/historial.json", jsonHistorial);
    }

    private static List<Ganador> LeerGanadoresDelHistorial()
    {
        try
        {
            string jsonHistorial = File.ReadAllText("recursos/historial.json");
            return JsonSerializer.Deserialize<List<Ganador>>(jsonHistorial) ?? new List<Ganador>();
        }
        catch (FileNotFoundException)
        {
            return new List<Ganador>();
        }
    }
}

}