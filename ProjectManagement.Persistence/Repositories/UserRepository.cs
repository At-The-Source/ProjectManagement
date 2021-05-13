using ProjectManagement.Application.Contracts.Persistence;
using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ProjectManagementDbContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> IsUserNameUnique(string username)
        {
            var user = _dbContext.Users.Any(users => users.UserName.Equals(username));
            return System.Threading.Tasks.Task.FromResult(user);
        }
    }
}
