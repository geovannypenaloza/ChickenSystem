using ChickenSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ChickenSystem.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Chicken> Chickens => Set<Chicken>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Food> Foods => Set<Food>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Shed> Sheds => Set<Shed>();

}