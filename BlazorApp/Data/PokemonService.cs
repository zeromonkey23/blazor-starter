using System.Text.Json;

namespace BlazorApp.Data;

public class PokemonService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _options;
    
    public PokemonService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }
    public async Task<Pokemons> GetPokemonAsync()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon/");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        var pokemons = JsonSerializer.Deserialize<Pokemons>(content, _options);
        return pokemons;
    }
    
}