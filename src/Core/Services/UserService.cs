using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models.Requests;
using System;
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

        user.Password = HashPassword.GetHashedPassword(user.Email, user.Password);
        user.CreatedAt = DateTime.UtcNow;
        var createdUser = await _userRepository.Create(user);

        return createdUser;
    }

    public Task<User> GetByEmailPassword(string email, string password)
    {
        return _userRepository.GetByEmailPassword(email, HashPassword.GetHashedPassword(email, password));
    }

    public async Task<User> GetById(int id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task<User> Update(UpdateUserRequest request)
    {
        var user = _mapper.Map<User>(request);

        if (await UserAlreadyExists(user))
        {
            throw new ValidationException("mesmo-email", "Já existe outro usuário com o mesmo e-mail.");
        }

        if (!string.IsNullOrEmpty(request.Password))
        {
            user.Password = HashPassword.GetHashedPassword(user.Email, user.Password);
        }

        user.UpdatedAt = DateTime.UtcNow;
        var userUpdated = await _userRepository.Update(user);

        return userUpdated;
    }

    private async Task<bool> UserAlreadyExists(User user)
    {
        var usersWithSameEmail = await _userRepository.GetByEmail(user.Email);
        return usersWithSameEmail.Where(x => x.Id != user.Id).Any();
    }
}
