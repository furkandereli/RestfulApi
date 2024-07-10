using Microsoft.AspNetCore.Mvc;
using RestfulApi.BusinessLayer.Abstract;
using RestfulApi.DtoLayer.DTOs.LanguageDtos;

namespace RestfulApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //This controller for week 3 cohort homework
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLanguage()
        {
            var languages = await _languageService.GetAllLanguagesAsync();
            return Ok(languages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguageById(int id)
        {
            var language = await _languageService.GetLanguageByIdAsync(id);
            if (language == null)
                return NotFound();
            return Ok(language);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLanguage(CreateLanguageDto createLanguageDto)
        {
            await _languageService.CreateLanguageAsync(createLanguageDto);
            return Ok("Language created successfully !");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            await _languageService.DeleteLanguageAsync(id);
            return Ok("Language deleted successfully !");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLanguage(UpdateLanguageDto updateLanguageDto)
        {
            await _languageService.UpdateLanguageAsync(updateLanguageDto);
            return Ok("Language updated successfully !");
        }
    }
}
