namespace MovieStore.Data.Entities;

public class FavoriteGenre
{
    public int FavoriteGenreId { get; set; }
    public int CustomerId { get; set; }
    public string Genre { get; set; }

    public virtual Customer Customer { get; set; }
}