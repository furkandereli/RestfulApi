using System.ComponentModel.DataAnnotations;

namespace RestfulApi.EntityLayer.Entities
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
