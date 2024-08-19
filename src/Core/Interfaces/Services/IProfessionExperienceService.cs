using Core.Entities;
using Core.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Services;
public interface IProfessionExperienceService
{
    Task<IEnumerable<ProfessionalExperience>> CreateMultiple(int curricolumId, IEnumerable<ProfessionalExperienceRequest> requests);
    Task<ProfessionalExperience> Create(int curricolumId, ProfessionalExperienceRequest request);
    Task<IEnumerable<ProfessionalExperience>> UpdateMultiple(int curricolumId, IEnumerable<ProfessionalExperienceRequest> requests);
    Task<ProfessionalExperience> Update(int curricolumId, ProfessionalExperienceRequest request);
    Task<bool> Delete(int id);
    Task<bool> DeleteMultiple(IEnumerable<int> ids);
}
