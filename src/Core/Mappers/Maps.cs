using AutoMapper;
using Core.Entities;
using Core.Models.Requests;

namespace Core.Mappers;
public class Maps : Profile
{
    public Maps()
    {
        CreateMap<CreateAccountRequest, User>().ReverseMap();

        CreateMap<CurricolumRequest, Curricolum>().ReverseMap();
        CreateMap<ProfessionalExperienceRequest, ProfessionalExperience>().ReverseMap();
        CreateMap<CourseRequest, Course>().ReverseMap();
        CreateMap<CurricolumUpdateRequest, Curricolum>().ReverseMap();
    }
}
