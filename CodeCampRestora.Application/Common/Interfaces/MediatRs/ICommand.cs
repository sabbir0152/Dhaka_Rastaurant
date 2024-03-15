using CodeCampRestora.Application.Features.ReviewComments;
using CodeCampRestora.Application.Models;
using MediatR;

namespace CodeCampRestora.Application.Common.Interfaces.MediatRs;

public interface ICommand : IRequest
{

}

public interface ICommand<TRequest> : IRequest<TRequest>
{

}

public interface ICommandHandler<TRequest>
    : IRequestHandler<TRequest> where TRequest : IRequest
{

}

public interface ICommandHandler<TRequest, TResponse>
    : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
}