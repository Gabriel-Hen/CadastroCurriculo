using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repositories;
public class CourseRepository : ICourseRepository
{
    private readonly DatabaseContext _context;
    private readonly DbSet<Course> _dbSet;

    public CourseRepository(DatabaseContext context)
    {
        _context = context;
        _dbSet = _context.Courses;
    }
    public async Task<Course> Create(Course course)
    {
        await _dbSet.AddAsync(course);
        await _context.SaveChangesAsync();

        return course;
    }
}
