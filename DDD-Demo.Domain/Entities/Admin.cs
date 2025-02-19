namespace Core.Domain.Entities;

public class Admin : User
{
    public Admin(string firstName, string lastName, string email) 
        : base(firstName, lastName, email)
    {
    }
    
    // For EF Core
    private Admin() : base() { }
}