using MoorCodeSofia.Domain;
using MoorCodeSofia.Domain.Contracts;
using System.Runtime.CompilerServices;

namespace MoorCodeSofia.Infrastructure.Repositories
{
    public class UserTaskRepository : IUserTaskRepository
    {
        public IList<UserTask> GetAll() => DataSet.AllUserTasks;

        public async Task<List<UserTask>> GetAllTasksAsync(CancellationToken cancellationToken = default)
        {
            // return await _dbContext.Set<UserTask>().ToListAsync(cancellationToken: cancellationToken);

            return
              await Task.FromResult(
                GetAll()
                .OrderByDescending(p => p.StartDate)
                .ThenBy(p => p.User).ToList());
        }

        public async Task<UserTask> GetTaskByIdAsync(UserTask userTask, CancellationToken cancellationToken = default)
        {
            if (userTask == null) return null;
            return
              await Task.FromResult(
                GetAll().Where(x => x.Id == userTask.Id)
                .OrderByDescending(p => p.StartDate)
                .ThenBy(p => p.User).FirstOrDefault());
        }

        public async Task<bool> DeleteTaskAsync(UserTask userTask, CancellationToken cancellationToken = default)
        {
            UserTask usrtask = DataSet.AllUserTasks.Where(x => x.Id == userTask.Id).FirstOrDefault();
            var returnVal = false;
            await Task.Run(() => {
                returnVal = DataSet.AllUserTasks.Remove(usrtask);
            });
            return returnVal;
        }

        public async Task<Guid> AddAsync(UserTask userTask, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
                DataSet.AllUserTasks.Add(userTask), cancellationToken).ConfigureAwait(false);

            return userTask.Id;
            //._dbContext.Set<UserTask>().AddAsync(userTask, cancellationToken);

        }
        public async Task<UserTask> Update(UserTask userTask, CancellationToken camCancellationToken = default)
        {
            var dataToUpdate = DataSet.AllUserTasks.Where(x => x.Id == userTask.Id).FirstOrDefault();
            await Task.Run(() =>
            {
                dataToUpdate.Subject = userTask.Subject;
                dataToUpdate.User = userTask.User;
                dataToUpdate.Description = userTask.Description;
                dataToUpdate.EndDate = userTask.EndDate;
                dataToUpdate.StartDate = userTask.StartDate;
            });
            return dataToUpdate;
        }
    }
}

