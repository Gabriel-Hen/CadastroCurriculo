using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repositories;
public class CurricolumRepository : ICurricolumRepository
{
    private readonly DatabaseContext _dbContext;
    private readonly DbSet<Curricolum> _dbSet;

    public CurricolumRepository(DatabaseContext dbContext, DbSet<Curricolum> dbSet)
    {
        _dbContext = dbContext;
        _dbSet = dbSet;
    }

    public async Task<Curricolum> Create(Curricolum curricolum)
    {
        Curricolum entity = _dbSet.CreateProxy();
        _dbContext.Entry(entity).CurrentValues.SetValues(user);

        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<IEnumerable<Curricolum>> GetAll(int userId)
    {
        return await _dbSet.Where(curricolum => curricolum.PersonId == userId).ToListAsync();
    }
}
