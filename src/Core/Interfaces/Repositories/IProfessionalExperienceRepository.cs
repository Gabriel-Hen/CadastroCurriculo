using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories;
public interface IProfessionalExperienceRepository
{
    Task<ProfessionalExperience> Create(ProfessionalExperience professionalExperience);
}
