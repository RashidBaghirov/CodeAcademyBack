using AutoMapper;
using CodeAcademy.DTO;
using CodeAcademy.Entities;

namespace CodeAcademy.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Slider, SliderGet>();
            CreateMap<EducationMode, EducationModeGet>();
            CreateMap<EduModel, EduModelGet>();
            CreateMap<Category, CategoryGet>()
            .ForMember(dest => dest.Professions, opt => opt.MapFrom(src => src.Professions.Select(p => p.Id).ToList()));
            CreateMap<Request, RequestDto>().ReverseMap();

        }
    }
}
