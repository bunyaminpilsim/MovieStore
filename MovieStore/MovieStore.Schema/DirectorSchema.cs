namespace MovieStore.Schema;

public class DirectorRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class DirectorResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<string> Films { get; set; }
}