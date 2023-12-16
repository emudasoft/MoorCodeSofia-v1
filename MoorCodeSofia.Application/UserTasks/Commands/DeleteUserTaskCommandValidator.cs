using FluentValidation;


namespace MoorCodeSofia.Application.UserTasks.Commands
{
    public class DeleteUserTaskCommandValidator : AbstractValidator<DeleteUserTaskCommand>
    {
        public DeleteUserTaskCommandValidator()
        {
            RuleFor(d => d.id)
                .NotNull() //validates whether Ids collection is null
                .NotEmpty().WithMessage("id can not be null "); //validates whether Ids collection is empty
        }
    }

}
