using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.Orders.Queries.GetAllOrder
{
    public record GetAllOrdersQuery : IQuery<IResult<List<OrderDTO>>>
    {
        public Guid BranchId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllOrdersQuery(Guid branchId, int pageNumber, int pageSize)
        {
            BranchId = branchId;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
