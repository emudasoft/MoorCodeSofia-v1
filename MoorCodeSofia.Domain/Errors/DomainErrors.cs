using MoorCodeSofia.Domain.Shared;

namespace MoorCodeSofia.Domain.Errors
{
    public static class DomainErrors
    {

        public static class UserTask
        {

            public static readonly Error NotExist = new(
                "UserTask.NotExist",
                $"There is no user Task");
        }
    }
}
