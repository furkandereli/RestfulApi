using Microsoft.AspNetCore.JsonPatch;
using RestfulApi.Entities;

namespace RestfulApi.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
        Task<List<Student>> GetStudentsStartingWithLetterNamed(string letter);
        Task<bool> UpdateStudentPartialAsync(int id, JsonPatchDocument<Student> patchDocument);
    }
}
