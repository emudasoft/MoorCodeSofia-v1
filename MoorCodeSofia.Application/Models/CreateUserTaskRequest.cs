namespace MoorCodeSofia.Application.Models
{
    public record CreateUserTaskRequest(
        Guid Id,
        string User,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        string Subject);
}
