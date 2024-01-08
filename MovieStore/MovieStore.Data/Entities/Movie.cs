namespace MovieStore.Data.Entities;

public class Movie
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
    
    public int DirectorId { get; set; }
    public virtual Director? Director { get; set; }
    public virtual List<Actor>? Actors { get; set; }
    
   
}