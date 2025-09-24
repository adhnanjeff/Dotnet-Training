using Dating.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dating.API.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options) // Used when there is only one base class or constructor
{
    public DbSet<AppUser> Users { get; set; }
}
