using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

Console.WriteLine(@"
_____ .   . .___       __  . .    . .__   __   __  .   .  __
  |   |   | |         (__` | |\  /| |  \ (__` /  \ |\  | (__`
  |   |---| |---         \ | | \/ | |__/    \ |  | | \ |    \
  |   |   | |___      \__/ | |    | |    \__/ \__/ |  \| \__/
"); 


CoinDesk salida = await GetCurrecyRateAsync(); 
Console.WriteLine("USD = "  + salida.Bpi.USD.RateFloat);


static async Task<CoinDesk> GetCurrecyRateAsync()
{
    var url = "https://thesimpsonsquoteapi.glitch.me/quotes?count=num";
    try
    {
        var coinDesk = new CoinDesk();
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        //CoinDesk coinDesk = JsonSerializer.Deserialize<CoinDesk>(responseBody);
        return coinDesk;
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("Problemas de acceso a la API");
        Console.WriteLine("Message :{0} ", e.Message);
        return null;
    }

}