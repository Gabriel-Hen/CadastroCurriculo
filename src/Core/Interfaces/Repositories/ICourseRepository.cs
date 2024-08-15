using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories;
public interface ICourseRepository
{
    Task<Course> Create(Course course);
}
