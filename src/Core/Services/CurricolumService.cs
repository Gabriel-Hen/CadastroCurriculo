using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models.Requests;
using System;
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
        curricolum.CreatedAt = DateTime.UtcNow;

        var curricolumCreated = await _curricolumRepository.Create(curricolum);
        if (request.ProfessionalExperiences.Any())
        {
            _professionExperienceService.CreateMultiple(curricolumCreated.Id, request.ProfessionalExperiences);
        }

        if (request.Courses.Any())
        {
            _courseService.CreateMultiple(curricolumCreated.Id, request.Courses);
        }

        return curricolumCreated;
    }

    public async Task<bool> Delete(int id)
    {
        return await _curricolumRepository.Delete(id);
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

    public async Task<Curricolum> Update(int authenticatedUserId, CurricolumUpdateRequest request)
    {
        var curricolum = _mapper.Map<Curricolum>(request);
        curricolum.UserId = authenticatedUserId;
        curricolum.UpdatedAt = DateTime.UtcNow;

        var curricolumUpdated = await _curricolumRepository.Update(curricolum);

        if (request.ProfessionalExperiences.Any())
        {
            await _professionExperienceService.UpdateMultiple(curricolumUpdated.Id, request.ProfessionalExperiences);
        }

        if (request.Courses.Any())
        {
            await _courseService.UpdateMultiple(curricolumUpdated.Id, request.Courses);
        }

        if (!string.IsNullOrEmpty(request.CoursesRemoved))
        {
            var coursesToBeDeleted = request.CoursesRemoved.Split('-');
            
            var idsAsInt = coursesToBeDeleted.Select(x => int.Parse(x));
            await _courseService.DeleteMultiple(idsAsInt);

        }

        if (!string.IsNullOrEmpty(request.ProfessionalExperienceRemoved))
        {
            var experiencesToBeDeleted = request.ProfessionalExperienceRemoved.Split('-');

            var idsAsInt = experiencesToBeDeleted.Select(x => int.Parse(x));
            await _professionExperienceService.DeleteMultiple(idsAsInt);
        }

        return curricolumUpdated;
    }
}
