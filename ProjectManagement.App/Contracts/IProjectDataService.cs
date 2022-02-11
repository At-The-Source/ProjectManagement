using ProjectManagement.App.Services;
using ProjectManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.App.Contracts
{
    public interface IProjectDataService
    {
        Task<ProjectViewModel> GetProjectById(Guid id);
        Task<ApiResponse<ProjectDTO>> CreateProject(ProjectViewModel projectViewModel);
        Task<ApiResponse<Guid>> DeleteProject(Guid id);
        Task<ApiResponse<Guid>> UpdateProject(ProjectViewModel projectViewModel);
        Task<List<ProjectViewModel>> GetAllProjects();
        Task<List<ProjectTaskViewModel>> GetAllProjectsWithTasks();
    }
}
