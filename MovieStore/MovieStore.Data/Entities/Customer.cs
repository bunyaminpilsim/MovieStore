namespace MovieStore.Data.Entities;

public class Customer
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public virtual ICollection<Purchase> Purchases { get; set; }
    public virtual ICollection<FavoriteGenre> FavoriteGenres { get; set; }
}
