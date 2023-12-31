﻿using FluentValidation;

namespace MoorCodeSofia.Application.UserTasks.Commands
{
    public class CreateUserTaskCommandValidator : AbstractValidator<CreateUserTaskCommand>
    {
        public CreateUserTaskCommandValidator()
        {
            RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate).NotNull().WithMessage("EndDate cannot be null or less then StartDate");
            RuleFor(x => x.EndDate).Must(BeValidDate).WithMessage("EndDate must be a valid date. Valid date format  is dd/MM/yyyy ");
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate).NotNull().WithMessage("StartDate cannot be null or less then EndDate");
            RuleFor(x => x.StartDate).Must(BeValidDate).WithMessage("StartDate must be a valid date. Valid date format  is dd/MM/yyyy");

        }
        private bool BeValidDate(DateTime date) { return !date.Equals(default); }
    }
}
