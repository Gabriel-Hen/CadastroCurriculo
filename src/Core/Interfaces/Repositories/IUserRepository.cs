using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories;
public interface IUserRepository
{
    Task<User> GetById(int id);
    Task<User> GetByEmailPassword(string email, string password);
    Task<User> Create(User user);
    Task<IEnumerable<User>> GetByEmail(string email);

}
