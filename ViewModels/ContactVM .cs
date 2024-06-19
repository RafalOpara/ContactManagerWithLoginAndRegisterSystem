using System.ComponentModel.DataAnnotations;

namespace CustomIdentity.ViewModels;

public class ContactVM
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Category { get; set; }
    public string PhoneNumber { get; set; }

    public DateTime DateOfBirth { get; set; }
}
