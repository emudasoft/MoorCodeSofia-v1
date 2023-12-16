using MoorCodeSofia.Domain;

namespace MoorCodeSofia.Infrastructure
{
    public static class DataSet
    {
        public static readonly List<UserTask> AllUserTasks =
            new()
            {
                new UserTask
                {
                    Id = Guid.Parse("a907d1a4-2874-48a6-abc7-f76045bdbe8e"),
                    StartDate = DateTime.Parse("08/12/2023"),
                    Description = "Nazdar Description",
                    EndDate = DateTime.Parse("18/12/2023"),
                    Subject = "Nazdar Subject",
                    User = "Nazdar"
                },
                new UserTask
                {
                    Id =Guid.Parse("b3c9322c-9743-48c3-aa48-a903418549f6"),
                    StartDate = DateTime.Parse("08/12/2023"),
                    Description = "Murat Description",
                    EndDate = DateTime.Parse("18/12/2023"),
                    Subject = "Murat Subject",
                    User = "Murat"
                }

            };
    }
}
