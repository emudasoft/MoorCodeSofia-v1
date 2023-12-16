using MediatR;
using MoorCodeSofia.Domain.Shared;

namespace MoorCodeSofia.Application.Abstractions;

public interface ICommand : IRequest<Result>
{ }

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{ }