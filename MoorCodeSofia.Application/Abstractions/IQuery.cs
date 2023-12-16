using MediatR;
using MoorCodeSofia.Domain.Shared;

namespace MoorCodeSofia.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}