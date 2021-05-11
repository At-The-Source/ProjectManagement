using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Contracts.Persistence
{
    public interface IProjectRepository : IAsyncRepository<Project>
    {
        Task<List<Project>> GetProjectsWithTasks(bool includeTaskHistory);
        
        // Validation
        Task<bool> IsNameAndDescriptionUnique(string name, string description);
    }
}
