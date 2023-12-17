using FluentValidation.TestHelper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoorCodeSofia.API.Abstractions;
using MoorCodeSofia.Application.UserTasks.Commands;
using MoorCodeSofia.Application.UserTasks.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MoorCodeSofia.API.Controllers
{
    [Route("api/userTasks")]
    public class UserTasksController : ApiController
    {
        private readonly CreateUserTaskCommandValidator _createValidator = new();
        private readonly UpdateUserTaskCommandValidator _updateValidator= new();
        private readonly DeleteUserTaskCommandValidator _deleteValidator = new();
        private readonly GetUserTaskCommandValidator  _getTaskByIdValidator= new();
        public UserTasksController(ISender sender) : base(sender)
        {
        }

        [HttpPost("create/")]
        public async Task<IActionResult> CreateUserTask(CreateUserTaskCommand command,
            CancellationToken cancellationToken)
        {

            var requestCheckResult = await Task.Run(() => _createValidator.TestValidate(command));
            if (!requestCheckResult.IsValid) return Ok(requestCheckResult.Errors);
             
                var createCommand = new CreateUserTaskCommand(

                    command.User,
                    command.Description,
                    command.StartDate,
                    command.EndDate,
                    command.Subject);

                var response = await Sender.Send(createCommand, cancellationToken);
                return Ok(response);

        }
        [HttpGet("getAllTasks")]
        public async Task<IActionResult> GetAllUserTasks(CancellationToken cancellationToken)
        {
            
            var query = new GetAllUserTasksQuery(0, 10);
            var response = await Sender.Send(query, cancellationToken);
            return response.IsSuccess ? Ok(response) : NotFound(response.Error);

        }
        [HttpGet("getTasksById")]
        public async Task<IActionResult> GeTasksById(GetUserTaskCommand command, CancellationToken cancellationToken)
        {
            var requestCheckResult = await Task.Run(() => _getTaskByIdValidator.TestValidate(command));
            if (!requestCheckResult.IsValid) return Ok(requestCheckResult.Errors);
            var getCommand = new GetUserTaskCommand(
               command.Id
              );

            var response = await Sender.Send(getCommand, cancellationToken);
            return Ok(response);

        }
        [HttpPost("updateTask/")]
        public async Task<IActionResult> UpdateUserTask(UpdateUserTaskCommand command,
            CancellationToken cancellationToken)
        {
            var requestCheckResult = await Task.Run(() => _updateValidator.TestValidate(command));
            if (!requestCheckResult.IsValid) return Ok(requestCheckResult.Errors);
            var createCommand = new UpdateUserTaskCommand(
                command.Id,
                command.User,
                command.Description,
                command.StartDate,
                command.EndDate,
                command.Subject);

            var response = await Sender.Send(createCommand, cancellationToken);
            return Ok(response);

        }

        [HttpPost("deleteTask/")]
        public async Task<IActionResult> DeleteUserTask(DeleteUserTaskCommand command,
            CancellationToken cancellationToken)
        {
            var requestCheckResult = await Task.Run(() => _deleteValidator.TestValidate(command));
            if (!requestCheckResult.IsValid) return Ok(requestCheckResult.Errors);
            var createCommand = new DeleteUserTaskCommand(
                command.id
               );

            var response = await Sender.Send(createCommand, cancellationToken);
            return Ok(response);

        }
    }
}
