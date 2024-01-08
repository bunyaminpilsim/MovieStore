namespace MovieStore.Data.Entities;

public class Director
{
    public int DirectorID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public virtual List<Movie>? DirectedMovies { get; set; }
}