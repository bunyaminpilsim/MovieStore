namespace MovieStore.Schema;

public class CustomerRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<string> FavoriteGenres { get; set; }
}
public class CustomerResponse
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<string> PurchasedFilms { get; set; } // Satın Alınan Filmler
    public List<string> FavoriteGenres { get; set; } // Favori Türler
}

