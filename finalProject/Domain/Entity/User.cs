using Microsoft.AspNetCore.Identity;

namespace Domain.Entity;

public class User : IdentityUser 
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string IdNo  { get; set; } = string.Empty; 
    public string LicencePlate { get; set;} = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public ICollection<Apartment>? Apartments { get; set; } 
}