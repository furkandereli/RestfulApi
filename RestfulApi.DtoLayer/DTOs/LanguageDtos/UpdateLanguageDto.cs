namespace RestfulApi.DtoLayer.DTOs.LanguageDtos
{
    public class UpdateLanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DifficultyLevel { get; set; }
        public bool IsPopular { get; set; }
    }
}
