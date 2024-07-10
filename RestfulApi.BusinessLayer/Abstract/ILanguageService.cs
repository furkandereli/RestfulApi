using RestfulApi.DtoLayer.DTOs.LanguageDtos;
using RestfulApi.EntityLayer.Entities;

namespace RestfulApi.BusinessLayer.Abstract
{
    public interface ILanguageService
    {
        Task<List<ResultLanguageDto>> GetAllLanguagesAsync();
        Task<GetLanguageByIdDto> GetLanguageByIdAsync(int id);
        Task CreateLanguageAsync(CreateLanguageDto createLanguageDto);
        Task UpdateLanguageAsync(UpdateLanguageDto updateLanguageDto);
        Task DeleteLanguageAsync(int id);
    }
}
