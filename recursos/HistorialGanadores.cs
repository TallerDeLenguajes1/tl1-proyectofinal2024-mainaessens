using System;
using System.Collections.Generic;
using System.IO;
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
        Console.WriteLine("---- HISTORIAL DE GANADORES ----");
        if (historial.Count == 0)
        {
            Console.WriteLine("El historial se encuentra vacío.");
        }
        else
        {
            foreach (var ganador in historial)
            {
                Console.WriteLine($"Nombre: {ganador.Nombre}, Fecha: {ganador.Fecha.ToShortDateString()}, Nivel Alcanzado: {ganador.NivelAlcanzado}");
            }
        }
        Console.WriteLine("Presione una tecla para volver");
        Thread.Sleep(2000);  // Pausa de 5 segundos (5000 milisegundos)
        Console.ReadKey();  // Espera a que el usuario presione una tecla
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