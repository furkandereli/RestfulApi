using Microsoft.AspNetCore.Mvc;
using RestfulApi.BusinessLayer.Abstract;
using RestfulApi.DtoLayer.DTOs.LanguageDtos;
using RestfulApi.EntityLayer.Entities;
using RestfulApi.Validators.LanguageValidators;

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
            var validator = new GetLanguageByIdValidator();
            var validationResult = validator.Validate(id);

            if(!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));

            var language = await _languageService.GetLanguageByIdAsync(id);

            if (language == null)
                return NotFound("Language not found !");

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
            var language = new Language { Id = id };
            var validator = new DeleteLanguageValidator();
            var validationResult = validator.Validate(language);

            if(!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));

            await _languageService.DeleteLanguageAsync(id);
            return Ok("Language deleted successfully !");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLanguage(UpdateLanguageDto updateLanguageDto)
        {
            var validator = new UpdateLanguageValidator();
            var validationResult = await validator.ValidateAsync(updateLanguageDto);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));

            await _languageService.UpdateLanguageAsync(updateLanguageDto);
            return Ok("Language updated successfully !");
        }
    }
}
