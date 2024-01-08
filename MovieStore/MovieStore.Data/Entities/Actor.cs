namespace MovieStore.Data.Entities;

public class Actor
{
    public int ActorID  { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public virtual List<Movie>? MoviesPlayed { get; set; }
}