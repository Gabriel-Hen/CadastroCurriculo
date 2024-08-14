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
    }
}
