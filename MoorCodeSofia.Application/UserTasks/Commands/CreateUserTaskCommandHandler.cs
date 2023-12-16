using AutoMapper;
using MoorCodeSofia.Application.Abstractions;
using MoorCodeSofia.Domain;
using MoorCodeSofia.Domain.Contracts;
using MoorCodeSofia.Domain.Shared;

namespace MoorCodeSofia.Application.UserTasks.Commands;

public sealed class CreateUserTaskCommandHandler : ICommandHandler<CreateUserTaskCommand, Guid>
{
    private readonly IUserTaskRepository _userTaskRepository;
    private readonly IMapper _mapper;
    private readonly CreateUserTaskCommandValidator _validator;
    public CreateUserTaskCommandHandler(IUserTaskRepository userTaskRepository, IMapper mapper
    )
    {
        _userTaskRepository = userTaskRepository;
        _mapper = mapper;
        _validator = new CreateUserTaskCommandValidator();
    }
    public async Task<Result<Guid>> Handle(CreateUserTaskCommand request, CancellationToken cancellationToken)
    {


        var userTask = new UserTask()
        {
            User = request.User,
            Id = Guid.NewGuid(),
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Description = request.Description,
            Subject = request.Subject
        };

        var res = await _userTaskRepository.AddAsync(userTask, cancellationToken);

        return res;

    }
}