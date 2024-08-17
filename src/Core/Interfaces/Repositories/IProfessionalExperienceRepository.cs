using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories;
public interface IProfessionalExperienceRepository
{
    Task<ProfessionalExperience> Create(ProfessionalExperience professionalExperience);
    Task<bool> Delete(int id);
    Task<ProfessionalExperience> Update(ProfessionalExperience professionalExperience);
}
