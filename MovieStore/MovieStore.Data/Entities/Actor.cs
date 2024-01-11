namespace MovieStore.Data.Entities;

public class Actor
{
    public int ActorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public virtual ICollection<Film> Films { get; set; }
}
