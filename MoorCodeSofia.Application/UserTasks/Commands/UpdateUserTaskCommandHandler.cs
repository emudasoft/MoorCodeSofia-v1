using AutoMapper;
using MoorCodeSofia.Application.Abstractions;
using MoorCodeSofia.Domain;
using MoorCodeSofia.Domain.Contracts;
using MoorCodeSofia.Domain.Shared;

namespace MoorCodeSofia.Application.UserTasks.Commands
{
    public class UpdateUserTaskCommandHandler : ICommandHandler<UpdateUserTaskCommand, UserTask>
    {
        private readonly IUserTaskRepository _userTaskRepository;
        private readonly IMapper _mapper;
        public UpdateUserTaskCommandHandler(IUserTaskRepository userTaskRepository, IMapper mapper)
        {
            _userTaskRepository = userTaskRepository;
            _mapper = mapper;

        }
        public async Task<Result<UserTask>> Handle(UpdateUserTaskCommand request, CancellationToken cancellationToken)
        {
            var userTask = new UserTask()
            {
                User = request.User,
                Id = request.Id,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Description = request.Description,
                Subject = request.Subject
            };


            var res = await _userTaskRepository.Update(userTask, cancellationToken);
            return res;
        }
    }
}
