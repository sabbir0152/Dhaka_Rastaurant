using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities.Orders;
using Mapster;

namespace CodeCampRestora.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, IResult<OrderDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeService _dateTimeService;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork,IDateTimeService dateTimeService)
        {
            _unitOfWork = unitOfWork;
            _dateTimeService = dateTimeService;
        }
        public async Task<IResult<OrderDTO>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.Adapt<Order>();
            
            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            var orderDto = order.Adapt<OrderDTO>();
            return Result<OrderDTO>.Success(orderDto);
        }
    }
}
