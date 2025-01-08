using API.Extensions;

namespace API.Models;

public class AppUser
{
    public int Id { get; set; }
    public required string UserName { get; set; }

    public byte[] PasswordHash { get; set; } = [];
    public byte[] PasswordSalt { get; set; } = [];

    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public required string Email { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public required string Gender { get; set; }
    public required string Address { get; set; } = "";
    public required string City { get; set; } = "";
    public required string PostalCode { get; set; } = "";
    public required string Country { get; set; } = "";
    public string Role { get; set; } = "";  // Admin, User
    public string Status { get; set; } = ""; // Active, Inactive
    public DateOnly DateOfBirth { get; set; } = DateOnly.MinValue;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime LastActive { get; set; } = DateTime.Now;

    public string FullName => $"{FirstName} {LastName}";

    public string Age => DateOfBirth.CalculateAge().ToString();

    public List<Portfolio> Portfolios { get; set; } = [];

}