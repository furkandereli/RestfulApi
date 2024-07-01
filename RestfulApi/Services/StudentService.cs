using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Context;
using RestfulApi.Entities;

namespace RestfulApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentContext _studentContext;

        public StudentService(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            _studentContext.Students.Add(student);
            await _studentContext.SaveChangesAsync();
            return student;
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _studentContext.Students.FindAsync(id);
            
            if (student != null)
            {
                _studentContext.Students.Remove(student);
                await _studentContext.SaveChangesAsync();
            }
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _studentContext.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentContext.Students.FindAsync(id);
        }

        public async Task<List<Student>> GetStudentsStartingWithLetterNamed(string letter)
        {
            return await _studentContext.Students.Where(x => x.Name.StartsWith(letter)).ToListAsync();
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            _studentContext.Entry(student).State = EntityState.Modified;
            await _studentContext.SaveChangesAsync();
            return student;
        }

        public async Task<bool> UpdateStudentPartialAsync(int id, JsonPatchDocument<Student> patchDocument)
        {
            var existStudent = await GetStudentByIdAsync(id);
            if (existStudent == null)
                return false;

            patchDocument.ApplyTo(existStudent);

            return true;
        }
    }
}
