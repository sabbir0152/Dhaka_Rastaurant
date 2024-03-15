using CodeCampRestora.Domain.Entities.Branches;
using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Domain.Entities
{
    public class MenuItem : AuditableEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string ImagePath { get; set; }
        public double Price { get; set; }
        public int? DisplayOrder { get; set; }
        public bool Availability { get; set; }
        public Guid CategoryId { get; set; }
        public MenuCategory Category { get; set; }
        public Guid BranchId { get; set; }
        public Branch? Branch { get; set; }
    }
}