using AutoMapper;
using MediatR;
using MoorCodeSofia.Application.Abstractions;
using MoorCodeSofia.Domain;
using MoorCodeSofia.Domain.Contracts;
using MoorCodeSofia.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoorCodeSofia.Application.UserTasks.Commands
{
    public class DeleteUserTaskCommandHandler : ICommandHandler<DeleteUserTaskCommand, bool>
    {
        private readonly IMapper _mapper;
        IUserTaskRepository _userTaskRepository;
        public DeleteUserTaskCommandHandler(IUserTaskRepository userTaskRepository, IMapper mapper)
        {
            _userTaskRepository = userTaskRepository;
            _mapper = mapper;
        }

        public async Task<Result<bool>> Handle(DeleteUserTaskCommand request, CancellationToken cancellationToken)
        {
            var userTask = new UserTask()
            {

                Id = request.id

            };
            var res = await _userTaskRepository.DeleteTaskAsync(userTask, cancellationToken);
            return res;
        }


    }



}
