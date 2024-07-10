namespace RestfulApi.DtoLayer.DTOs.LanguageDtos
{
    public class CreateLanguageDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DifficultyLevel { get; set; }
        public bool IsPopular { get; set; }
    }
}
