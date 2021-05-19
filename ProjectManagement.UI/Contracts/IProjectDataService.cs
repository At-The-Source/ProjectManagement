using ProjectManagement.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.UI.Contracts
{
    public interface IProjectDataService
    {
        Task<List<ProjectViewModel>> GetAllProjects();
    }
}
