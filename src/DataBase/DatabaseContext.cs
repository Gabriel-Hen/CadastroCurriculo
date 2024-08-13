using Microsoft.EntityFrameworkCore;

namespace DataBase;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
}
