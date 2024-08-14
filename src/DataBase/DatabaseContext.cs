using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Courses> Courses { get; set; }
    public DbSet<Curricolum> Curricolums { get; set; }
    public DbSet<ProfessionalExperiencies> ProfessionalExperiencies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseLazyLoadingProxies();
    }
}
