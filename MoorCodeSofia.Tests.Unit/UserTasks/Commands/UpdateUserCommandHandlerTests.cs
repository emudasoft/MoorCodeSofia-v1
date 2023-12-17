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

    public class UpdateUserCommandHandlerTests
    {
        private readonly Mock<IUserTaskRepository> _userTaskRepositoryMock = new();
        private readonly Mock<IMapper> _mapper = new();
        private readonly Fixture _fixture = new();

        [Fact]
        public async Task Handle_Should_UpdateUserTask_Successfully()
        {
            // arrange
            var userTask = _fixture.Create<UserTask>();
            var command = _fixture.Create<UpdateUserTaskCommand>();

            _userTaskRepositoryMock.Setup(s => s.Update(
                It.IsAny<UserTask>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(userTask);

            var handler = new UpdateUserTaskCommandHandler(
                _userTaskRepositoryMock.Object,
                _mapper.Object);

            // act
            Result<UserTask> result = await handler.Handle(command, default);

            // assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task StartDate_Should_Be_LessThen_EndDate_And_NotNull_UpdateUserTask()
        {
            // arrange
            UpdateUserTaskCommandValidator validator = new();
            var command = new UpdateUserTaskCommand(Guid.Empty, string.Empty, string.Empty,
            DateTime.Now.AddDays(-1),
            DateTime.Now,
            string.Empty);

            // act
            var result = await Task.Run(() => validator.TestValidate(command));

            // assert
            result.ShouldNotHaveValidationErrorFor(x => x.StartDate);
        }

        [Fact]
        public async Task Invalid_StartDate_Should_Be_ReturnInValid_Error()
        {
            // arrange
            UpdateUserTaskCommandValidator validator = new();
            var command = new UpdateUserTaskCommand(Guid.Empty, string.Empty, string.Empty,
                DateTime.Now.AddDays(1),
                DateTime.Now,
                string.Empty);
            // act
            var result = await Task.Run(() => validator.TestValidate(command));

            // assert
            result.ShouldHaveValidationErrorFor(x => x.StartDate);
        }

        [Fact]
        public async Task EndDate_Should_Be_GreaterThan_StartDate_And_NotNull_UpdateUserTask()
        {
            // arrange
            UpdateUserTaskCommandValidator validator = new();
            var command = new UpdateUserTaskCommand(Guid.Empty, string.Empty, string.Empty,
                DateTime.Now.AddDays(1),
                DateTime.Now.AddDays(2),
                string.Empty);
            // act
            var result = await Task.Run(() => validator.TestValidate(command));

            // assert
            result.ShouldNotHaveValidationErrorFor(x => x.EndDate);

        }

        [Fact]
        public async Task UpdateUserTask_When_EndDate_LessThan_StartDate_Should_Be_Return_Error()
        {
            // arrange
            UpdateUserTaskCommandValidator validator = new();
            var command = new UpdateUserTaskCommand(Guid.Empty, string.Empty, string.Empty,
                DateTime.Now,
                DateTime.Now.AddDays(-1),
                string.Empty);
            // act
            var result = await Task.Run(() => validator.TestValidate(command));

            // assert
            result.ShouldHaveValidationErrorFor(x => x.EndDate);

        }
        [Fact]
        public async Task User_Cannot_Be_Null_UpdateUserTask()
        {
            // arrange
            UpdateUserTaskCommandValidator validator = new();
            var command = _fixture.Create<UpdateUserTaskCommand>();
            // act
            var result = await Task.Run(() => validator.TestValidate(command));

            // assert
            result.ShouldNotHaveValidationErrorFor(x => x.User);

        }
    }
}
