using MediatR;
using MoorCodeSofia.Domain.Shared;

namespace MoorCodeSofia.Application.Abstractions;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}