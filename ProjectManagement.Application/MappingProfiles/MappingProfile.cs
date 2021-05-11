using AutoMapper;
using ProjectManagement.Application.Features.Projects;
using ProjectManagement.Application.Features.Projects.Commands.CreateProject;
using ProjectManagement.Application.Features.Projects.Commands.UpdateProject;
using ProjectManagement.Application.Features.Projects.Queries.GetProjectsListWithTasks;
using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.MappingProfiles
{
    // Mapping profiles used by AutoMapper
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Project queries
            CreateMap<Project, ProjectListVM>().ReverseMap();
            // TODO: Add mapping for specific project
            //CreateMap<Project, SpecificProjectVM>().ReverseMap();
            //CreateMap<Domain.Entities.Task, TaskDto>();
            CreateMap<Project, ProjectTaskListVM>();

            // Project commands
            CreateMap<Project, CreateProjectCommand>().ReverseMap();
            CreateMap<Project, UpdateProjectCommand>().ReverseMap();
            //CreateMap<Project, DeleteProjectCommand>().ReverseMap();
        }
    }
}
