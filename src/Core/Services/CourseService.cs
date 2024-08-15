using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models.Requests;
using System.Threading.Tasks;

namespace Core.Services;
public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;
    public CourseService(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task<Course> Create(int curricolumId, CourseRequest courseRequest)
    {
        var course = _mapper.Map<Course>(courseRequest);
        course.CurricolumId = curricolumId;

        var courseCreated = await _courseRepository.Create(course);

        return courseCreated;
    }
}
