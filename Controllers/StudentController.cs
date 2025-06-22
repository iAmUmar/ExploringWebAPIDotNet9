using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExploringWebAPIDotNet9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        static private List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "John Doe", DateOfBirth = new DateTime(2000, 1, 1), Address = "123 Main St", PhoneNumber = "123-456-7890", Course = "Computer Science", Fees = 1000 },
            new Student { Id = 2, Name = "Jane Smith", DateOfBirth = new DateTime(1999, 2, 2), Address = "456 Elm St", PhoneNumber = "987-654-3210", Course = "Mathematics", Fees = 1200 },
            new Student { Id = 3, Name = "Will Turner", DateOfBirth = new DateTime(1999, 2, 2), Address = "786 Elm St", PhoneNumber = "456-789-1400", Course = "History", Fees = 1500 },
            new Student { Id = 4, Name = "Muhammad Umar", DateOfBirth = new DateTime(1993, 8, 18), Address = "345 Dhoke Paracha", PhoneNumber = "312-4747-481", Course = "Litrature", Fees = 1100 },
            new Student { Id = 5, Name = "Jack Sparrow", DateOfBirth = new DateTime(1994, 2, 12), Address = "421 Satellite Town", PhoneNumber = "312-4324-567", Course = "Science", Fees = 1400 }
        };

        [HttpGet]
        public ActionResult<List<Student>> GetStudents()
        {
            return Ok(students);
        }


        //[HttpGet]
        //[Route("{id:int}")]
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student is null)
                return NotFound();
            else
                return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> CreateStudent(Student student)
        {
            if (student == null)
                return BadRequest("Student cannot be null");
            //students.Add(student);
            //return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);

            student.Id = students.Count > 0 ? students.Max(s => s.Id) + 1 : 1; // Assign a new ID
            students.Add(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            if (student == null || student.Id != id)
                return BadRequest("Invalid student data");
            var existingStudent = students.FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
                return NotFound();

            existingStudent.Name = student.Name;
            existingStudent.DateOfBirth = student.DateOfBirth;
            existingStudent.Address = student.Address;
            existingStudent.PhoneNumber = student.PhoneNumber;
            existingStudent.Course = student.Course;
            existingStudent.Fees = student.Fees;

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();
            students.Remove(student);
            return NoContent();
        }
    
    }
}
