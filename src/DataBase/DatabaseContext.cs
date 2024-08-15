using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Curricolum> Curricolums { get; set; }
    public DbSet<ProfessionalExperience> ProfessionalExperiences { get; set; }
}
