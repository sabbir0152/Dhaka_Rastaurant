using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Domain.Entities.Orders
{
    public class OrderItem : AuditableEntity<Guid>
    {
        public string ItemName { get; set; } = default!;
        public int Quantity { get; set; } = default!;
        public double UnitPrice { get; set; } = default!;
        public double TotalItemPrice { get; set; } = default!;
        public Guid OrderId { get; set; }
        public Guid MenuItemId { get; set; }
    }
}
