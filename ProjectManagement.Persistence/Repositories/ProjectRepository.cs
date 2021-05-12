using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.Contracts.Persistence;
using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectManagementDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Project>> GetProjectsWithTasks(bool includeTaskHistory)
        {
            var projects = await _dbContext.Projects.Include(p => p.Tasks).ToListAsync();
            if (!includeTaskHistory)
            {
                // TODO: Not to be implemented before date is added to projects
                //projects.ForEach(p => p.Tasks.ToList().RemoveAll(pr => pr.Date < DateTime.Today));
            }
            return projects;
        }

        public Task<bool> IsNameAndDescriptionUnique(string name, string eventDescription)
        {
            var projects = _dbContext.Projects.Any(projects => projects.ProjectName.Equals(name) &&
                projects.Description.Equals(eventDescription));
            return System.Threading.Tasks.Task.FromResult(projects);
        }
    }
}
