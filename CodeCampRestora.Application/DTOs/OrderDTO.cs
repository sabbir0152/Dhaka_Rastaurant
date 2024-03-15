using CodeCampRestora.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCampRestora.Application.DTOs;

public class OrderDTO
{
    public OrderDTO()
    {
        OrderItems = new List<OrderItemDTO>();
    }
    public Guid BranchId { get; set; }
    public Guid UserId { get; set; }
    public string CustomerName { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string Time { get; set; } = default!;
    public string Date { get; set; } = default!;
    public BookingType BookingType { get; set; }
    public int Seats { get; set; }
    public OrderStatus OrderStatus { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderTrackingNumber { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string ServingTime { get; set; } = string.Empty;
    public double SubTotal { get; set; }
    public double VAT { get; set; }
    public double DeliveryCharge { get; set; }
    public double Discount { get; set; }
    public double TotalPrice { get; set; }
    public List<OrderItemDTO>? OrderItems { get; set; }
    // public User User { get; set; }
    // public Branch Branch { get; set; }
}

public class OrderItemDTO
{
    public string ItemName { get; set; } = default!;
    public int Quantity { get; set; } = default!;
    public double UnitPrice { get; set; } = default!;
    public double TotalItemPrice { get; set; } = default!;
    // public Guid OrderId { get; set; }
    // public Guid MenuItemId { get; set; }
}

