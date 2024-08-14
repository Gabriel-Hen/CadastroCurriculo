using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repositories;
public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _dbContext;
    private readonly DbSet<User> _dbSet;

    public UserRepository(DatabaseContext context)
    {
        _dbContext = context;
        _dbSet = context.Users;
    }
    public async Task<User> Create(User user)
    {
        User entity = _dbSet.CreateProxy();
        _dbContext.Entry(entity).CurrentValues.SetValues(user);

        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<User> GetByEmailPassword(string email, string password)
    {
        return await _dbSet.Where(user => user.Email == email && user.Password == password).FirstAsync();
    }
}
