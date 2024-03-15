using CodeCampRestora.Domain.Entities.Common;
using CodeCampRestora.Infrastructure.Entities;

namespace CodeCampRestora.Domain.Entities
{
    public class MenuCategory : AuditableEntity<Guid>
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public string ImagePath { get; set; }
        public Guid RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}