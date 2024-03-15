namespace CodeCampRestora.Application.DTOs
{
    public class ImageRequestDto
    {
        public string? Name { get; set; } = default!;
        public string? Type { get; set; } = default!;
        public string? Base64 {get; set;} = default!;
    }
}