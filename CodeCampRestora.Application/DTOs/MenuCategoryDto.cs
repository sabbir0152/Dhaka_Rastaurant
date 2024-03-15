namespace CodeCampRestora.Application.DTOs
{
    public class MenuCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public Guid ImageId { get; set; }
        public Guid RestaurantId { get; set; }
    }
}