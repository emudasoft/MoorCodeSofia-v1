using MoorCodeSofia.Application.Mappings;
using MoorCodeSofia.Domain;

namespace MoorCodeSofia.Application.Models;

//public sealed record TaskClientResponse(

//    Guid Id, string User, string Description);



public class TaskClientResponse : IMapFrom<UserTask>
{
    public Guid Id { get; set; }
    public string User { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}