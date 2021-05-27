using ProjectManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.App.Contracts
{
    public interface IProjectDataService
    {
        Task<List<ProjectViewModel>> GetAllProjects();
        Task<List<ProjectTaskViewModel>> GetAllProjectsWithTasks();
    }
}
