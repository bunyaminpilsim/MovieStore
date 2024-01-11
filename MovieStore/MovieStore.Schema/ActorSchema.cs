namespace MovieStore.Schema;

public class ActorRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

}

public class ActorResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<string> Films { get; set; } 
}