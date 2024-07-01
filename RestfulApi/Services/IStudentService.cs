using RestfulApi.Entities;

namespace RestfulApi.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(string id);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(string id);
        Task<List<Student>> GetStudentsStartingWithLetterNamed(string letter);
    }
}
