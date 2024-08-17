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

    public async Task<bool> Delete(int id)
    {
        return await _courseRepository.Delete(id);
    }

    public async Task<Course> Update(int curricolumId, CourseRequest courseRequest)
    {
        Course course;
        if (courseRequest.Id == null)
        {
            course = await Create(curricolumId, courseRequest);
        }
        else 
        {
            course = _mapper.Map<Course>(courseRequest);
            course = await _courseRepository.Update(course);
        }

        return course;
    }
}
