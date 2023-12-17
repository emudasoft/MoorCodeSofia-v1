using AutoFixture;
using AutoMapper;
using FluentAssertions;
using FluentValidation.TestHelper;
using MoorCodeSofia.Application.UserTasks.Commands;
using MoorCodeSofia.Domain;
using MoorCodeSofia.Domain.Contracts;
using MoorCodeSofia.Domain.Shared;
using Moq;

namespace MoorCodeSofia.Tests.Unit.UserTasks.Commands
{
    public class DeleteUserCommandHandlerTests
    {
        private readonly Mock<IUserTaskRepository> _userTaskRepositoryMock = new();
        private readonly Mock<IMapper> _mapper = new();
        private readonly DeleteUserTaskCommandValidator _validator = new();
        private readonly Fixture _fixture = new();

        [Fact]
        public async Task Handle_Should_DeleteUserTask_Successfully()
        {
            // arrange
            var command = new DeleteUserTaskCommand(Guid.NewGuid());

            _userTaskRepositoryMock.Setup(m => m.DeleteTaskAsync(
                It.IsAny<UserTask>(),
                It.IsAny<CancellationToken>())).ReturnsAsync(true)
                .Verifiable();

            var handler = new DeleteUserTaskCommandHandler(

                _userTaskRepositoryMock.Object,
                _mapper.Object);

            // act
            Result<bool> result = await handler.Handle(command, default);

            // assert

            _userTaskRepositoryMock.Verify(x =>
                    x.DeleteTaskAsync(
                        It.IsAny<UserTask>(),
                        It.IsAny<CancellationToken>()), Times.Once);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Id_Should_Be_NotNull_DeleteUserTask()
        {
            // arrange
            var command = _fixture.Create<DeleteUserTaskCommand>();
            // act
            var result = await Task.Run(() => _validator.TestValidate(command));

            // assert
            result.ShouldNotHaveValidationErrorFor(x => x.id);

        }

    }
}
