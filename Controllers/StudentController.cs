using System.Threading.Tasks;
using ExploringWebAPIDotNet9.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExploringWebAPIDotNet9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(StudentDbContext context) : ControllerBase
    {
        private readonly StudentDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            return Ok(await _context.Students.ToListAsync());
        }


        //[HttpGet]
        //[Route("{id:int}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            //var student = students.FirstOrDefault(s => s.Id == id);       // For static data
            var student = await _context.Students.FindAsync(id);

            if (student is null)
                return NotFound();
            else
                return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            if (student == null)
                return BadRequest("Student cannot be null");
            
            // For Static data
            //student.Id = students.Count > 0 ? students.Max(s => s.Id) + 1 : 1; // Assign a new ID
            //students.Add(student);

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            var studentObj = await _context.Students.FindAsync(id);
            if (studentObj is null)
                return NotFound();

            studentObj.Name = student.Name;
            studentObj.DateOfBirth = student.DateOfBirth;
            studentObj.Address = student.Address;
            studentObj.PhoneNumber = student.PhoneNumber;
            studentObj.Course = student.Course;
            studentObj.Fees = student.Fees;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
