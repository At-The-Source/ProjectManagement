using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Application.Contracts.Persistence
{
    public interface ITaskRepository : IAsyncRepository<ProjectManagement.Domain.Entities.Task>
    {
    }
}
