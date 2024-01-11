namespace MovieStore.Data.Entities;

public class Film
{
    public int FilmId { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }

    public virtual ICollection<Director> Directors { get; set; }
    public virtual ICollection<Actor> Actors { get; set; }
}