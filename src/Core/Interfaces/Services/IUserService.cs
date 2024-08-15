using Core.Entities;
using Core.Models.Requests;
using System.Threading.Tasks;

namespace Core.Interfaces.Services;
public interface IUserService
{
    Task<User> GetById(int id);
    Task<User> GetByEmailPassword(string email, string password);
    Task<User> Create(CreateAccountRequest request);
}
