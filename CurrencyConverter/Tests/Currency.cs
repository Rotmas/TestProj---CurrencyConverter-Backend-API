using System.Net.Http.Json;

namespace CurrencyConverter.Tests;

public class Currency
{
    readonly HttpClient Client;

    public Currency(HttpClient client)
        => Client = client;
    public async Task<Response> GetSumAndConvert(Request request)
    {
        var response = await Client.PostAsJsonAsync($"/api/Currency/convert", request)
            ?? throw new Exception("Unexpected");

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Response>()
            ?? throw new Exception("Unexpected"); ;
    }
}
