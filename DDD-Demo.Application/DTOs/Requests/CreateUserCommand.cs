namespace Core.DTOs.Requests;


public class CreateUserCommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserType { get; set; } // "Admin", "Teacher", or "Student"
}