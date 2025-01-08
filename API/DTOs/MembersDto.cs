using System;

namespace API.DTOs;

public class MembersDto
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? Age { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Gender { get; set; }
    public string? City { get; set; } = "";
    public string? Country { get; set; } = "";
    public string Role { get; set; } = "";  // Admin, User
    public string Status { get; set; } = ""; // Active, Inactive
    public DateOnly DateOfBirth { get; set; } = DateOnly.MinValue;
    public DateTime Created { get; set; }
    public DateTime LastActive { get; set; }

    public List<PortfolioDto>? Portfolios { get; set; }
}
// Compare this snippet from API/DTOs/PortfolioDto.cs:
