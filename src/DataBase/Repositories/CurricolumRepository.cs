using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repositories;
public class CurricolumRepository : ICurricolumRepository
{
    private readonly DatabaseContext _dbContext;
    private readonly DbSet<Curricolum> _dbSet;

    public CurricolumRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Curricolums;
    }

    public async Task<Curricolum> Create(Curricolum curricolum)
    {
        await _dbSet.AddAsync(curricolum);
        await _dbContext.SaveChangesAsync();

        return curricolum;
    }

    public async Task<IEnumerable<Curricolum>> GetAll(int userId)
    {
        return await _dbSet.Where(curricolum => curricolum.UserId == userId).ToListAsync();
    }

    public async Task<Curricolum> GetById(int id)
    {
        return await _dbSet.Include(c => c.ProfessionalExperience).Include(c => c.Courses).FirstOrDefaultAsync(c => c.Id == id);
    }
}
