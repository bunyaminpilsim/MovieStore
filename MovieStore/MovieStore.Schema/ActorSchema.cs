namespace MovieStore.Schema;

public class ActorRequest
{
    public int ActorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public virtual List<MovieRequest> MoviesPlayed { get; set; }

}

public class ActorResponse
{
    public int ActorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public virtual List<MovieResponse> MoviesPlayed { get; set; }
}