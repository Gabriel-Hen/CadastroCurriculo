using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories;
public interface ICourseRepository
{
    Task<Course> Create(Course course);
    Task<Course> Update(Course course);
    Task<bool> Delete(int id);
}
