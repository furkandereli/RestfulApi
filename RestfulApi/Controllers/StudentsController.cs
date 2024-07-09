using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.CustomAttributes;
using RestfulApi.Entities;
using RestfulApi.Services.StudentServices;

namespace RestfulApi.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentsStartingWithLetterNamed(string letter)
        {
            var student = await _studentService.GetStudentsStartingWithLetterNamed(letter);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        [FakeAuth]
        public async Task<IActionResult> CreateStudent([FromHeader] string username, [FromHeader] string password, [FromBody] Student student)
        {
            await _studentService.CreateStudentAsync(student);
            return Ok("Öğrenci başarıyla oluşturuldu !");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            if (id != student.Id)
                return BadRequest("Idler eşleşmiyor !");

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

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchStudent(int id, [FromBody] JsonPatchDocument<Student> patchDocument)
        {
            if (patchDocument == null)
                return BadRequest();

            var result = await _studentService.UpdateStudentPartialAsync(id, patchDocument);

            if(!result)
                return NotFound();

            return Ok("Öğrenci başarıyla güncellendi !");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound();

            await _studentService.DeleteStudentAsync(id);
            return Ok("Öğrenci başarıyla silindi !");
        }
    }
}
