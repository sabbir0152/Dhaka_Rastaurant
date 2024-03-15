using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Enums;

namespace CodeCampRestora.Application.Features.Orders.Commands.UpdateOrder
{
    public record UpdateOrderCommand : ICommand<IResult>
    {
        public Guid Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
