namespace MovieStore.Data.Entities;

public class Director
{
    public int DirectorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public virtual ICollection<Film> DirectedFilms { get; set; }
}