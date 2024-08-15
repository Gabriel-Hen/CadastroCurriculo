using Core.Entities;
using Core.Models.Requests;
using System.Threading.Tasks;

namespace Core.Interfaces.Services;
public interface IProfessionExperienceService
{
    Task<ProfessionalExperience> Create(int curricolumId, ProfessionalExperienceRequest request);
}
