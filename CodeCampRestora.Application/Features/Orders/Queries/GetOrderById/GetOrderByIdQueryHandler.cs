using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Exceptions;
using CodeCampRestora.Application.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, IResult<OrderDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetOrderByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<IResult<OrderDTO>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Orders.IncludeProps(entity => entity.OrderItems).FirstOrDefaultAsync(x => x.Id == request.Id); 
            if (order == null)
            {
                throw new ResourceNotFoundException("No Order Found");
            }

            var bookingOrderDto = order.Adapt<OrderDTO>();
            return Result<OrderDTO>.Success(bookingOrderDto);

        }
    }
}
