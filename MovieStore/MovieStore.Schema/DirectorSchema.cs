namespace MovieStore.Schema;

public class DirectorRequest 
{
    public int DirectorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public virtual List<MovieRequest>? MoviesDirected { get; set; }
}

public class DirectorResponse 
{
    public int DirectorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public virtual List<MovieResponse> MoviesDirected { get; set; }
}