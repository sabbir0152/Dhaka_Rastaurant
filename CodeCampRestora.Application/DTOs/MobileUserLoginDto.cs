namespace CodeCampRestora.Application.DTOs;
public class MobileUserLoginDto
{
    public required string Phone { get; set; } = default!;
    public required string Password { get; set; } = default!;
}
