using MoorCodeSofia.Application.Abstractions;


namespace MoorCodeSofia.Application.UserTasks.Commands
{
    public sealed record DeleteUserTaskCommand(
        Guid id
        ) : ICommand<bool>;

}


