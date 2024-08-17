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

    public async Task<bool> Delete(int id)
    {
        var professionalExperience = await _dbSet.FindAsync(id);
        if (professionalExperience == null)
        {
            return false;
        }
        else
        {
            _dbSet.Remove(professionalExperience);
            await _context.SaveChangesAsync();

            return true;
        }
    }

    public async Task<ProfessionalExperience> Update(ProfessionalExperience professionalExperience)
    {
        var professionalExperienceEntity = await _dbSet.FindAsync(professionalExperience.Id);
        if (professionalExperienceEntity == null)
        {
            throw new Exception($"Nao foi encontrado nenhuma experiencia profissional com o id {professionalExperience.Id}");
        }

        professionalExperienceEntity = professionalExperience;
        await _context.SaveChangesAsync();
        return professionalExperienceEntity;
    }
}
