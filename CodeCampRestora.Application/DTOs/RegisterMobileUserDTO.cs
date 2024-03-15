namespace CodeCampRestora.Application.DTOs;

public class RegisterMobileUserDTO
{
    public required string FullName { get; set; } = default!;
    public required string Email { get; set; } = default!;
    public required string Password { get; set; } = default!;
    public required string Phone { get; set;} = default!;
}