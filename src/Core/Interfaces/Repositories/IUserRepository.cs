using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories;
public interface IUserRepository
{
    Task<User> GetByEmailPassword(string email, string password);
    Task<User> Create(User user);

}
