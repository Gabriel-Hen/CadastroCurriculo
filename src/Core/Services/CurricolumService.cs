using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services;
public class CurricolumService : ICurricolumService
{
    private readonly ICurricolumRepository _curricolumRepository;
    private readonly IMapper _mapper;
    private readonly IProfessionExperienceService _professionExperienceService;
    private readonly ICourseService _courseService;
    public CurricolumService(
        ICurricolumRepository curricolumRepository,
        IMapper mapper,
        IProfessionExperienceService professionExperienceService,
        ICourseService courseService
    )
    {
        _curricolumRepository = curricolumRepository;
        _mapper = mapper;
        _professionExperienceService = professionExperienceService;
        _courseService = courseService;
    }

    public async Task<Curricolum> Create(CurricolumRequest request, int authenticatedUserId)
    {
        var curricolum = _mapper.Map<Curricolum>(request);
        curricolum.UserId = authenticatedUserId;
        var curricolumCreated = await _curricolumRepository.Create(curricolum);
        //request.ProfessionalExperiences.Select(
        //    async professionalExperience => await _professionExperienceService.Create(
        //        curricolumCreated.Id,
        //        professionalExperience
        //    )
        //);

        //request.Courses.Select(
        //    async course => await _courseService.Create(
        //        curricolumCreated.Id,
        //        course
        //    )
        //);

        return curricolumCreated;
    }

    public async Task<IEnumerable<Curricolum>> GetAll(int userId)
    {
        return await _curricolumRepository.GetAll(userId);
    }
}
