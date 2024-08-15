using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models.Requests;
using System;
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
    public Task<User> Create(CreateAccountRequest request)
    {
        var user = _mapper.Map<User>(request);
        var createdUser = _userRepository.Create(user);

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
