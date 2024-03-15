using MediatR;

namespace CodeCampRestora.Application.Common.Interfaces.MediatRs;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}

public interface IQueryHandler<TRequest, TResponse>
    : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{

}