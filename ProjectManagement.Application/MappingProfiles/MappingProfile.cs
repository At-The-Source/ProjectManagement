using AutoMapper;
using ProjectManagement.Application.Features.Projects;
using ProjectManagement.Application.Features.Projects.Commands.CreateProject;
using ProjectManagement.Application.Features.Projects.Commands.UpdateProject;
using ProjectManagement.Application.Features.Projects.Queries.GetProjectsListWithTasks;
using ProjectManagement.Application.Features.Tasks.Commands.CreateTask;
using ProjectManagement.Application.Features.Tasks.Commands.UpdateTask;
using ProjectManagement.Application.Features.Tasks.Queries.GetSpecificTask;
using ProjectManagement.Application.Features.Tasks.Queries.GetTaskList;
using ProjectManagement.Application.Features.Users.Commands.CreateUser;
using ProjectManagement.Application.Features.Users.Commands.UpdateUser;
using ProjectManagement.Application.Features.Users.Queries.GetSpecificUser;
using ProjectManagement.Application.Features.Users.Queries.GetUserList;
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
            CreateMap<Project, SpecificProjectVM>().ReverseMap();
            CreateMap<Domain.Entities.Project, CreateProjectDto>().ReverseMap();
            CreateMap<Domain.Entities.Task, TaskDto>();
            CreateMap<Project, ProjectTaskListVM>();
            CreateMap<Project, ProjectDTO>();
            // Project commands
            CreateMap<Project, CreateProjectCommand>().ReverseMap();
            CreateMap<Project, UpdateProjectCommand>().ReverseMap();
            //CreateMap<Project, DeleteProjectCommand>().ReverseMap();

            // Task queries
            CreateMap<Domain.Entities.Task, TaskListVM>().ReverseMap();
            CreateMap<Domain.Entities.Task, SpecificTaskVM>().ReverseMap();
            CreateMap<Domain.Entities.Task, ProjectTaskDTO>().ReverseMap();
            // Task commands
            CreateMap<Domain.Entities.Task, CreateTaskCommand>().ReverseMap();
            CreateMap<Domain.Entities.Task, CreateTaskDto>().ReverseMap();
            CreateMap<Domain.Entities.Task, UpdateTaskCommand>().ReverseMap();

            // User queries
            CreateMap<User, UserListVM>().ReverseMap();
            CreateMap<User, SpecificUserVM>().ReverseMap();
            // User commands
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
        }
    }
}