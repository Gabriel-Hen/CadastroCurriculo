using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models.Requests;
using System.Collections.Generic;
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

    public async Task<IEnumerable<Course>> CreateMultiple(int curricolumId, IEnumerable<CourseRequest> courseRequests)
    {
        List<Course> courses = new List<Course>();
        foreach (var request in courseRequests)
        {
            var course = _mapper.Map<Course>(request);
            course.CurricolumId = curricolumId;

            var courseCreated = await _courseRepository.Create(course);

            courses.Add(courseCreated);
        }
        
        return courses;
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

    public async Task<bool> DeleteMultiple(IEnumerable<int> ids)
    {
        foreach (var id in ids)
        {
            await _courseRepository.Delete(id);
        }

        return true;
    }

    public async Task<IEnumerable<Course>> UpdateMultiple(int curricolumId, IEnumerable<CourseRequest> courseRequests)
    {
        List<Course> courses = new List<Course>();
        foreach (var request in courseRequests)
        {
            Course course;
            if (request.Id == null)
            {
                course = await Create(curricolumId, request);
            }
            else
            {
                course = _mapper.Map<Course>(request);
                course.CurricolumId = curricolumId;
                course = await _courseRepository.Update(course);
            }

            courses.Add(course);
        }

        return courses;
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
            course.CurricolumId = curricolumId;
            course = await _courseRepository.Update(course);
        }

        return course;
    }
}
