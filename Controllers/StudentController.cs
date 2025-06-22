using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExploringWebAPIDotNet9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase {

        static private List<Student> students = new List<Student>
        { 
            new Student { Id = 1, Name = "John Doe", DateOfBirth = new DateTime(2000, 1, 1), Address = "123 Main St", PhoneNumber = "123-456-7890", Course = "Computer Science", Fees = 1000 },
            new Student { Id = 2, Name = "Jane Smith", DateOfBirth = new DateTime(1999, 2, 2), Address = "456 Elm St", PhoneNumber = "987-654-3210", Course = "Mathematics", Fees = 1200 },
            new Student { Id = 2, Name = "Will Turner", DateOfBirth = new DateTime(1999, 2, 2), Address = "786 Elm St", PhoneNumber = "456-789-1400", Course = "History", Fees = 1500 }
        };

        [HttpGet]
        public ActionResult<List<Student>> GetStudents()
        {
            return Ok(students);
        }
    }
}
