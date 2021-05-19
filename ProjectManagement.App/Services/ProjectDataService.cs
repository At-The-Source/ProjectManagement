using AutoMapper;
using Blazored.LocalStorage;
using ProjectManagement.App.Contracts;
using ProjectManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.App.Services
{
    //public class ProjectDataService : BaseDataService, IProjectDataService
    //{
    //    private readonly IMapper _mapper;

    //    public ProjectDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
    //    {
    //        _mapper = mapper;
    //    }

    //    public async Task<List<ProjectViewModel>> GetAllProjects()
    //    {
    //        var projects = await _client.GetAllProjectsAsync();
    //        var projectsVM = _mapper.Map<ICollection<ProjectViewModel>>(projects);
    //        return projectsVM.ToList();
    //    }
    //}
}
