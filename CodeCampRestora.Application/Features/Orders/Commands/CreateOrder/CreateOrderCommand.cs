using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCampRestora.Application.Features.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand : ICommand<IResult<OrderDTO>>
    {
        public Guid BranchId { get; set; }
        public Guid UserId { get; set; }
        public string CustomerName { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Time { get; set; } = default!;
        public string Date { get; set; } = default!;
        public BookingType BookingType { get; set; }
        public int Seats { get; set; } = default!;
        public OrderStatus OrderStatus { get; set; }
        public string Comment { get; set; } = string.Empty;
        public string ServingTime { get; set; } = string.Empty;
        public double SubTotal { get; set; }
        public double VAT { get; set; }
        public double DeliveryCharge { get; set; }
        public double Discount { get; set; }
        public double TotalPrice { get; set; }
        public List<OrderItemDTO>? OrderItems { get; set; }
    }
}
