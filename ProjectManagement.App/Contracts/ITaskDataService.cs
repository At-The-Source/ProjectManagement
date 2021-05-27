using ProjectManagement.App.Services;
using ProjectManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.App.Contracts
{
    public interface ITaskDataService
    {
        Task<SpecificTaskViewModel> GetTaskById(Guid id);
        Task<ApiResponse<Guid>> CreateTask(SpecificTaskViewModel specificTaskViewModel);
        Task<ApiResponse<Guid>> DeleteTask(Guid id);
        Task<ApiResponse<Guid>> UpdateTask(SpecificTaskViewModel specificTaskViewModel);
    }
}
