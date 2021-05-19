using AutoMapper;
using ProjectManagement.UI.Contracts;
using ProjectManagement.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.UI.Services
{
    public class ProjectDataService : IProjectDataService
    {
        private readonly IMapper _mapper;
        protected IClient _client;

        public ProjectDataService(IClient client, IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<ProjectViewModel>> GetAllProjects()
        {
            var projects = await _client.GetAllProjectsAsync();
            var projectsVM = _mapper.Map<ICollection<ProjectViewModel>>(projects);
            return projectsVM.ToList();
        }
    }
}
