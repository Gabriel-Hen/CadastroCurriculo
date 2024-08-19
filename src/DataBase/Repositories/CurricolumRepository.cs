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

    public async Task<IEnumerable<Curricolum>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Curricolum> GetById(int id)
    {
        return await _dbSet.Include(c => c.ProfessionalExperiences).Include(c => c.Courses).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Curricolum>> GetAllByUserId(int userId)
    {
        return await _dbSet.Where(c => c.UserId == userId).ToListAsync();
    }

    public async Task<bool> Delete(int id)
    {
        var curricolum = await _dbSet.FindAsync(id);
        if (curricolum == null)
        {
            return false;
        }
        else
        {
            _dbSet.Remove(curricolum);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }

    public async Task<Curricolum> Update(Curricolum curricolum)
    {
        var curricolumEntity = await _dbSet.FindAsync(curricolum.Id);
        if (curricolumEntity == null)
        {
            throw new Exception($"Nao foi encontrado nenhum curriculo com o id {curricolum.Id}");
        }

        _dbContext.Entry(curricolumEntity).CurrentValues.SetValues(curricolum);
        await _dbContext.SaveChangesAsync();
        return curricolumEntity;
    }
}
