using AutoMapper;
using MediatR;
using ProjectManagement.Application.Contracts.Persistence;
using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Projects
{
    public class GetProjectsListQueryHandler : IRequestHandler<GetProjectsListQuery, List<ProjectListVM>>
    {
        private readonly IAsyncRepository<Project> _projectRepository;
        private readonly IMapper _mapper;

        public GetProjectsListQueryHandler(IMapper mapper, IAsyncRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<List<ProjectListVM>> Handle(GetProjectsListQuery request, CancellationToken cancellationToken)
        {
            // get list of domain entities & return viewModels based on the entities via automapper 
            var projects = (await _projectRepository.ListAllAsync());
            return _mapper.Map<List<ProjectListVM>>(projects);
        }
    }
}
