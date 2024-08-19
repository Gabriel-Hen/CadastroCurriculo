using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services;
public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<User> Create(CreateAccountRequest request)
    {
        var user = _mapper.Map<User>(request);
        var userWithSameEmail = await _userRepository.GetByEmail(request.Email);
        if (userWithSameEmail.Any())
        {
            throw new ValidationException("mesmo-email", "Já existe outro usuário com o mesmo e-mail.");
        }
        var createdUser = await _userRepository.Create(user);

        return createdUser;
    }

    public Task<User> GetByEmailPassword(string email, string password)
    {
        return _userRepository.GetByEmailPassword(email, password);
    }

    public async Task<User> GetById(int id)
    {
        return await _userRepository.GetById(id);
    }
}
