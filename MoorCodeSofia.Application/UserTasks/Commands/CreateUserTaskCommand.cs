using MoorCodeSofia.Application.Abstractions;

namespace MoorCodeSofia.Application.UserTasks.Commands;

public sealed record CreateUserTaskCommand(

    string User,
    string Description,
    DateTime StartDate,
    DateTime EndDate,
    string Subject) : ICommand<Guid>;