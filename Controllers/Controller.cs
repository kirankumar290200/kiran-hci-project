public class StudentController : Controller
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public IActionResult AddStudent(string firstName, string lastName, string email, string phone)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
            string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone))
        {
            return BadRequest("All fields are required");
        }

        var student = new Student
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Phone = phone
        };

        _studentService.AddStudent(student);
        return Ok("Student added successfully");
    }
}
