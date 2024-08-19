using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models.Requests;
using System.Collections.Generic;
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

    public async Task<IEnumerable<ProfessionalExperience>> CreateMultiple(int curricolumId, IEnumerable<ProfessionalExperienceRequest> requests)
    {
        List<ProfessionalExperience> professionalExperiences = new List<ProfessionalExperience>();
        foreach (var request in requests)
        {
            var professionalExperience = _mapper.Map<ProfessionalExperience>(request);
            professionalExperience.CurricolumId = curricolumId;

            var professionalExperienceCreated = await _professionalExperienceRepository.Create(professionalExperience);

            professionalExperiences.Add(professionalExperience);
        }

        return professionalExperiences;
    }

    public async Task<bool> Delete(int id)
    {
        return await _professionalExperienceRepository.Delete(id);
    }

    public async Task<bool> DeleteMultiple(IEnumerable<int> ids)
    {
        foreach (var id in ids)
        {
            await _professionalExperienceRepository.Delete(id);
        }

        return  true;
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
            professionalExperience.CurricolumId = curricolumId;
            professionalExperience = await _professionalExperienceRepository.Update(professionalExperience);
        }

        return professionalExperience;
    }

    public async Task<IEnumerable<ProfessionalExperience>> UpdateMultiple(int curricolumId, IEnumerable<ProfessionalExperienceRequest> requests)
    {
        List<ProfessionalExperience> professionalExperiences = new List<ProfessionalExperience>();
        foreach (var request in requests) 
        {
            ProfessionalExperience professionalExperience;
            if (request.Id == null)
            {
                professionalExperience = await Create(curricolumId, request);
            }
            else
            {
                professionalExperience = _mapper.Map<ProfessionalExperience>(request);
                professionalExperience.CurricolumId = curricolumId;
                professionalExperience = await _professionalExperienceRepository.Update(professionalExperience);
            }

            professionalExperiences.Add(professionalExperience);
        }

        return professionalExperiences;
    }
}
