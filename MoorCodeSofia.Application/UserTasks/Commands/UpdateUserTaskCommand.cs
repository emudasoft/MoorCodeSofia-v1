using MoorCodeSofia.Application.Abstractions;
using MoorCodeSofia.Domain;

namespace MoorCodeSofia.Application.UserTasks.Commands;

public sealed record  UpdateUserTaskCommand
       (
        Guid Id,
        string User,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        string Subject) : ICommand<UserTask>;


