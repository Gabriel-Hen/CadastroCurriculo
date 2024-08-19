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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Curricolums)
            .WithOne(u => u.User);

        modelBuilder.Entity<Curricolum>()
            .HasOne(c => c.User)
            .WithMany(c => c.Curricolums)
            .HasForeignKey(c => c.UserId);

        modelBuilder.Entity<Course>()
            .HasOne(c => c.Curricolum)
            .WithMany(c => c.Courses)
            .HasForeignKey(c => c.CurricolumId);

        modelBuilder.Entity<ProfessionalExperience>()
            .HasOne(p => p.Curricolum)
            .WithMany(p => p.ProfessionalExperiences)
            .HasForeignKey(p => p.CurricolumId);
    }
}
