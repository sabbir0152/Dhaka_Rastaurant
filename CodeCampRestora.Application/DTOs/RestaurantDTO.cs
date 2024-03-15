namespace CodeCampRestora.Application.Dtos;

public class RestaurantDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string ImagePath { get; set; } = default!;
}
