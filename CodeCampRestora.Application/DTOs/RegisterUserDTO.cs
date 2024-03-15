namespace CodeCampRestora.Application.DTOs;

public class RegisterUserDTO
{
        public required string FullName { get; set; } = default!;
        public required string Email { get; set; } = default!;
        public required string Password { get; set; } = default!;
}