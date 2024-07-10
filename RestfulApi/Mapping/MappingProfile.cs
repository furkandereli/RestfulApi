using AutoMapper;
using RestfulApi.DtoLayer.DTOs.LanguageDtos;
using RestfulApi.EntityLayer.Entities;

namespace RestfulApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Language, ResultLanguageDto>().ReverseMap();
            CreateMap<Language, CreateLanguageDto>().ReverseMap();
            CreateMap<Language, UpdateLanguageDto>().ReverseMap();
            CreateMap<Language, GetLanguageByIdDto>().ReverseMap();
        }
    }
}
