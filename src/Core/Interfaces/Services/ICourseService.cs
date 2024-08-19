using Core.Entities;
using Core.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Services;
public interface ICourseService
{
    Task<IEnumerable<Course>> CreateMultiple(int curricolumId, IEnumerable<CourseRequest> courseRequests);
    Task<Course> Create(int curricolumId, CourseRequest courseRequest);
    Task<IEnumerable<Course>> UpdateMultiple(int curricolumId, IEnumerable<CourseRequest> courseRequests);
    Task<Course> Update(int curricolumId, CourseRequest courseRequest);
    Task<bool> Delete(int id);
    Task<bool> DeleteMultiple(IEnumerable<int> ids);
}
