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

    public async Task<bool> Delete(int id)
    {
        var course = await _dbSet.FindAsync(id);
        if (course == null)
        {
            return false;
        }
        else
        {
            _dbSet.Remove(course);
            await _context.SaveChangesAsync();

            return true;
        }
    }

    public async Task<Course> Update(Course course)
    {
        var courseEntity = await _dbSet.FindAsync(course.Id);
        if (courseEntity == null)
        {
            throw new Exception($"Nao foi encontrado nenhum curso com o id {course.Id}");
        }

        courseEntity = course;
        await _context.SaveChangesAsync();
        return courseEntity;
    }
}
