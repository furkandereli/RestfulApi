using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestfulApi.BusinessLayer.Abstract;
using RestfulApi.DataAccessLayer.Context;
using RestfulApi.DtoLayer.DTOs.LanguageDtos;
using RestfulApi.EntityLayer.Entities;

namespace RestfulApi.BusinessLayer.Concrete
{
    public class LanguageService : ILanguageService
    {
        private readonly StudentContext _studentContext;
        private readonly IMapper _mapper;

        public LanguageService(StudentContext studentContext, IMapper mapper)
        {
            _studentContext = studentContext;
            _mapper = mapper;
        }

        public async Task CreateLanguageAsync(CreateLanguageDto createLanguageDto)
        {
            var language = _mapper.Map<Language>(createLanguageDto);
            _studentContext.Languages.Add(language);
            await _studentContext.SaveChangesAsync();
        }

        public async Task DeleteLanguageAsync(int id)
        {
            var language = await _studentContext.Languages.FindAsync(id);
            _studentContext.Languages.Remove(language);
            await _studentContext.SaveChangesAsync();
        }

        public async Task<List<ResultLanguageDto>> GetAllLanguagesAsync()
        {
            var languages = await _studentContext.Languages.ToListAsync();
            return _mapper.Map<List<ResultLanguageDto>>(languages);
        }

        public async Task<GetLanguageByIdDto> GetLanguageByIdAsync(int id)
        {
            var language = await _studentContext.Languages.FindAsync(id);
            return _mapper.Map<GetLanguageByIdDto>(language);
        }

        public async Task UpdateLanguageAsync(UpdateLanguageDto updateLanguageDto)
        {
            var language = _mapper.Map<Language>(updateLanguageDto);
            _studentContext.Languages.Update(language);
            await _studentContext.SaveChangesAsync();
        }
    }
}
