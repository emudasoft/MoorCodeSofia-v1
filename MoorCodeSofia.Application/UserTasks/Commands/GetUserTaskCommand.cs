using MoorCodeSofia.Application.Abstractions;
using MoorCodeSofia.Domain;


namespace MoorCodeSofia.Application.UserTasks.Commands
{
    public sealed record GetUserTaskCommand(
       Guid Id
       ) : ICommand<UserTask>;
}
