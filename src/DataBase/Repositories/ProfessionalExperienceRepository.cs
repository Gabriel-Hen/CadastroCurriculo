using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repositories;
public class ProfessionalExperienceRepository : IProfessionalExperienceRepository
{
    private readonly DatabaseContext _context;
    private readonly DbSet<ProfessionalExperience> _dbSet;

    public ProfessionalExperienceRepository(DatabaseContext databaseContext)
    {
        _context = databaseContext;
        _dbSet = _context.ProfessionalExperiences;
    }
    public async Task<ProfessionalExperience> Create(ProfessionalExperience professionalExperience)
    {
        await _dbSet.AddAsync(professionalExperience);
        await _context.SaveChangesAsync();

        return professionalExperience;
    }
}
