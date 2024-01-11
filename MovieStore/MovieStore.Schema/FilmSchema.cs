namespace MovieStore.Schema;

public class FilmRequest
{
    public string Name { get; set; }
    public int Year { get; set; }
    public string Genre { get; set; }
    public List<int> DirectorIds { get; set; }
    public List<int> ActorIds { get; set; }
    public decimal Price { get; set; }
}

public class FilmResponse
{
    public int FilmId { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public string Genre { get; set; }
    public List<string> Directors { get; set; } // Yönetmenlerin İsimleri
    public List<string> Actors { get; set; } // Oyuncuların İsimleri
    public decimal Price { get; set; }
}