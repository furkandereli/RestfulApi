using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Entities;
using RestfulApi.Services;

namespace RestfulApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(string id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpGet("GetStudentsStartingWithLetterNamed")]
        public async Task<IActionResult> GetStudentsStartingWithLetterNamed(string letter)
        {
            var student = await _studentService.GetStudentsStartingWithLetterNamed(letter);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            var createdStudent = await _studentService.CreateStudentAsync(student);
            return Ok("Öğrenci başarıyla oluşturuldu !");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(string id, [FromBody] Student student)
        {
            if (id != student.Id)
                return BadRequest();

            try
            {
                await _studentService.UpdateStudentAsync(student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _studentService.GetStudentByIdAsync(id) == null)
                    return NotFound();

                throw;
            }

            return Ok("Öğrenci başarıyla güncellendi !");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound();

            await _studentService.DeleteStudentAsync(id);
            return Ok("Öğrenci başarıyla silindi !");
        }
    }
}
