using AutoFixture;
using AutoMapper;
using FluentValidation.TestHelper;
using MoorCodeSofia.Application.UserTasks.Commands;
using MoorCodeSofia.Domain;
using MoorCodeSofia.Domain.Contracts;
using MoorCodeSofia.Domain.Shared;
using Moq;

namespace MoorCodeSofia.Tests.Unit.UserTasks.Queries
{
    public class GetUserCommandHandlerTests
    {
        private readonly Mock<IUserTaskRepository> _userTaskRepositoryMock = new();
        private readonly Mock<IMapper> _mapper = new();
        private readonly Fixture _fixture = new();

        [Fact]
        public async Task Handle_Should_GetUserTask_Successfully()
        {
            // arrange
            var command = _fixture.Create<GetUserTaskCommand>();

            var handler = new GetUserTaskCommandHandler(
                _userTaskRepositoryMock.Object,
                _mapper.Object);

            // act
            Result<UserTask> result = await handler.Handle(command, default);

            // assert
            Assert.True(result.IsSuccess);


        }
        [Fact]
        public async Task Id_Should_Be_NotNull_GetUserTask()
        {
            // arrange
            GetUserTaskCommandValidator validator = new();
            var command = _fixture.Create<GetUserTaskCommand>();

            // act
            var result = await Task.Run(() => validator.TestValidate(command));

            // assert
            result.ShouldNotHaveValidationErrorFor(x => x.Id);

        }
    }
}
