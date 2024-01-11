using Microsoft.EntityFrameworkCore;
using MovieStore.Data.Entities;

namespace MovieStore.Data.Context;

public class MovieStoreContext : DbContext
{
    public MovieStoreContext(DbContextOptions<MovieStoreContext> options) : base(options)
    {
    }

    public DbSet<Actor> Actors { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<FavoriteGenre> FavoriteGenres { get; set; }
}