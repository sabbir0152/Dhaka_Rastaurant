using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Application.Features.Orders.Queries.GetAllOrder
{
    public class GetAllOrdersQueryHandler : IQueryHandler<GetAllOrdersQuery, IResult<List<OrderDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<IResult<List<OrderDTO>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.Orders.GetOrdersByBranchId(request.BranchId,"OrderItems", request.PageNumber, request.PageSize);
            var bookingOrdersDto = orders.Adapt<List<OrderDTO>>();
            return Result<List<OrderDTO>>.Success(bookingOrdersDto);
        }
    }
}
