namespace CodeCampRestora.Application.DTOs;

public class LoginDTO
{
    public required string Username { get; set; } = default!;
    public required string Password { get; set; } = default!;
}