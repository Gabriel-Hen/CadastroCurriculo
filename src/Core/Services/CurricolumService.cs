using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services;
public class CurricolumService : ICurricolumService
{
    private readonly ICurricolumRepository _curricolumRepository;
    private readonly IMapper _mapper;
    public CurricolumService(ICurricolumRepository curricolumRepository, IMapper mapper)
    {
        _curricolumRepository = curricolumRepository;
        _mapper = mapper;
    }

    public Task<Curricolum> Create(CurricolumRequest request)
    {
        throw new System.NotImplementedException();
    }

    public async Task<IEnumerable<Curricolum>> GetAll(int userId)
    {
        return await _curricolumRepository.GetAll(userId);
    }
}
