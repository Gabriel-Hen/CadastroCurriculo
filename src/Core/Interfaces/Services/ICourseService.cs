using Core.Entities;
using Core.Models.Requests;
using System.Threading.Tasks;

namespace Core.Interfaces.Services;
public interface ICourseService
{
    Task<Course> Create(int curricolumId, CourseRequest courseRequest); 
    Task<Course> Update(int curricolumId, CourseRequest courseRequest);
    Task<bool> Delete(int id);
}
