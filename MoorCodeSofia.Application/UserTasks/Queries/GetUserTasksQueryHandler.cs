using AutoMapper;
using MoorCodeSofia.Application.Abstractions;
using MoorCodeSofia.Application.Models;
using MoorCodeSofia.Domain.Contracts;
using MoorCodeSofia.Domain.Errors;
using MoorCodeSofia.Domain.Shared;

namespace MoorCodeSofia.Application.UserTasks.Queries;

internal sealed class GetUserTasksQueryHandler : IQueryHandler<GetAllUserTasksQuery, List<TaskClientResponse>>
{
    private readonly IUserTaskRepository _userTasksRepository;
    private readonly IMapper _mapper;
    public GetUserTasksQueryHandler(
        IUserTaskRepository userTasksRepository,
        IMapper mapper)
    {
        _userTasksRepository = userTasksRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<TaskClientResponse>>> Handle(GetAllUserTasksQuery request, CancellationToken cancellationToken)
    {

        var userTasks = await _userTasksRepository.GetAllTasksAsync(cancellationToken);
        if (!userTasks.Any())
        {
            return Result.Failure<List<TaskClientResponse>>(
                DomainErrors.UserTask.NotExist);
        }

        return _mapper.Map<List<TaskClientResponse>>(userTasks);
    }
}