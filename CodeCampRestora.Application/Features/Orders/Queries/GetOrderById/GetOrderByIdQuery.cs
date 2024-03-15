using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.Orders.Queries.GetOrderById
{
    public record GetOrderByIdQuery : IQuery<IResult<OrderDTO>>
    {
        public Guid Id { get; set; }
        public GetOrderByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
