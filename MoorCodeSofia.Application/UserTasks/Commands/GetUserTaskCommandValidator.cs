using FluentValidation;

namespace MoorCodeSofia.Application.UserTasks.Commands
{
    public class GetUserTaskCommandValidator : AbstractValidator<GetUserTaskCommand>
    {
        public GetUserTaskCommandValidator()
        {
            RuleFor(d => d.Id)
                .NotNull() //validates whether Ids collection is null
                .NotEmpty().WithMessage("id can not be null "); //validates whether Ids collection is empty 
        }
    }
}
