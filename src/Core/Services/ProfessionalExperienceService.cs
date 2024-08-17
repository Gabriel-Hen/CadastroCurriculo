using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models.Requests;
using System.Threading.Tasks;

namespace Core.Services;
public class ProfessionalExperienceService : IProfessionExperienceService
{
    private readonly IProfessionalExperienceRepository _professionalExperienceRepository;
    private readonly IMapper _mapper;

    public ProfessionalExperienceService(
        IProfessionalExperienceRepository professionalExperienceRepository,
        IMapper mapper
    )
    {
        _professionalExperienceRepository = professionalExperienceRepository;
        _mapper = mapper;
    }

    public async Task<ProfessionalExperience> Create(int curricolumId, ProfessionalExperienceRequest request)
    {
        var professionalExperience = _mapper.Map<ProfessionalExperience>(request);
        professionalExperience.CurricolumId = curricolumId;

        var professionalExperienceCreated = await _professionalExperienceRepository.Create(professionalExperience);

        return professionalExperience;
    }

    public async Task<bool> Delete(int id)
    {
        return await _professionalExperienceRepository.Delete(id);
    }

    public async Task<ProfessionalExperience> Update(int curricolumId, ProfessionalExperienceRequest request)
    {
        ProfessionalExperience professionalExperience;
        if (request.Id == null)
        {
            professionalExperience = await Create(curricolumId, request);
        }
        else
        {
            professionalExperience = _mapper.Map<ProfessionalExperience>(request);
            professionalExperience = await _professionalExperienceRepository.Update(professionalExperience);
        }

        return professionalExperience;
    }
}
