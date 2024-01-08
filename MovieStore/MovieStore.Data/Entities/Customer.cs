namespace MovieStore.Data.Entities;

public class Customer
{
    public int CustomerID  { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public virtual List<Movie>? PurchasedMovies { get; set; }
    public List<string> FavoriteGenres { get; set; }

}