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
        await _dbSet.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<User> GetByEmailPassword(string email, string password)
    {
        return await _dbSet.Where(user => user.Email == email && user.Password == password).FirstOrDefaultAsync();
    }

    public async Task<User> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }
}
