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
        if (request.ProfessionalExperiences.Any())
        {
            request.ProfessionalExperiences.Select(
                async professionalExperience => await _professionExperienceService.Create(
                    curricolumCreated.Id,
                    professionalExperience
                )
            );
        }

        if (request.Courses.Any())
        {
            request.Courses.Select(
                async course => await _courseService.Create(
                    curricolumCreated.Id,
                    course
                )
            );
        }

        return curricolumCreated;
    }

    public async Task<IEnumerable<Curricolum>> GetAll()
    {
        return await _curricolumRepository.GetAll();
    }

    public async Task<IEnumerable<Curricolum>> GetAllByUserId(int userId)
    {
        return await _curricolumRepository.GetAllByUserId(userId);
    }

    public async Task<Curricolum> GetById(int id)
    {
        return await _curricolumRepository.GetById(id);
    }

    public async Task<Curricolum> Update(CurricolumUpdateRequest request)
    {
        var curricolum = _mapper.Map<Curricolum>(request);
        var curricolumCreated = await _curricolumRepository.Update(curricolum);

        if (request.ProfessionalExperiences.Any())
        {
            request.ProfessionalExperiences.Select(
                async professionalExperience => await _professionExperienceService.Update(
                    curricolumCreated.Id,
                    professionalExperience
                )
            );
        }

        if (request.Courses.Any())
        {
            request.Courses.Select(
                async course => await _courseService.Update(
                    curricolumCreated.Id,
                    course
                )
            );
        }


        var coursesToBeDeleted = request.CoursesRemoved.Split('-');
        var experiencesToBeDeleted = request.ProfessionalExperienceRemoved.Split('-');

        if (coursesToBeDeleted.Any()) 
        {
            coursesToBeDeleted.Select(async x => await _courseService.Delete(int.Parse(x)));
        }

        if (experiencesToBeDeleted.Any())
        {
            experiencesToBeDeleted.Select(async x => await _professionExperienceService.Delete(int.Parse(x)));
        }

        return curricolumCreated;
    }
}
