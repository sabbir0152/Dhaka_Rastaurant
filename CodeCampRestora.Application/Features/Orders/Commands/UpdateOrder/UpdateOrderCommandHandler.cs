using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Exceptions;
using CodeCampRestora.Application.Models;
using Mapster;

namespace CodeCampRestora.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<IResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {

            var order = await _unitOfWork.Orders.GetByIdAsync(request.Id);
            if (order == null)
            {
                throw new ResourceNotFoundException("No Order found");
            }

            order.OrderStatus = request.OrderStatus;
            await _unitOfWork.Orders.UpdateAsync(request.Id, order);
            await _unitOfWork.SaveChangesAsync();

            var orderDto = order.Adapt<OrderDTO>();
            return Result.Success();
        }
    }
}
