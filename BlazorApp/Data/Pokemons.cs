namespace BlazorApp.Data;

public class Pokemons
{
    
    public int Count { get; set; }

    public string Next { get; set; }
    
    public string Previous { get; set; }
    
    public PokemonData[] Results { get; set; }
}