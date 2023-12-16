namespace MoorCodeSofia.Domain.Contracts;

public interface IUserTaskRepository
{
    Task<List<UserTask>> GetAllTasksAsync(CancellationToken cancellationToken = default);
    Task<UserTask> GetTaskByIdAsync(UserTask userTask, CancellationToken cancellationToken = default);
    Task<bool> DeleteTaskAsync(UserTask userTask, CancellationToken cancellationToken = default);
    Task<Guid> AddAsync(UserTask userTask, CancellationToken cancellationToken = default);
    Task<UserTask> Update(UserTask userTask, CancellationToken cancellationToken = default);
}