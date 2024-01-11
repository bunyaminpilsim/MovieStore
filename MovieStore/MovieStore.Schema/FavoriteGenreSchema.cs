namespace MovieStore.Schema;

public class FavoriteGenreRequest
{
    public int? FavoriteGenreId { get; set; } // Güncelleme için kullanılır, null olabilir.
    public int CustomerId { get; set; }
    public string Genre { get; set; }
}

public class FavoriteGenreResponse
{
    public int FavoriteGenreId { get; set; }
    public int CustomerId { get; set; }
    public string Genre { get; set; }
}