using Microsoft.AspNetCore.Components;
using ProjectManagement.App.Contracts;
using ProjectManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManagement.App.Services;

namespace ProjectManagement.App.Pages
{
    public partial class FetchData
    {
        //[Inject]
        //public IProjectDataService ProjectDataService { get; set; }
        
        public ICollection<ProjectListVM> Projects { get; set; }
        public ICollection<ProjectTaskListVM> Projects2 { get; set; }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            //ICollection<ProjectViewModel> projz = await ProjectDataService.GetAllProjects();
            //Projects = await ProjectDataService.GetAllProjects();
            Client client = new Client("https://localhost:44360");
            Projects = await client.GetAllProjectsAsync();
            Projects2 = await client.GetAllProjectsWithTasksAsync(false);
        }
    }
}
