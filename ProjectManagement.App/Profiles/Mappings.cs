using ProjectManagement.App.Services;
using ProjectManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ProjectManagement.App.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            // Projects
            CreateMap<ProjectListVM, ProjectViewModel>().ReverseMap();
            CreateMap<ProjectTaskDTO, TaskNestedViewModel>().ReverseMap();
            CreateMap<ProjectTaskListVM, ProjectTaskViewModel>().ReverseMap();
            CreateMap<ProjectViewModel, CreateProjectCommand>().ReverseMap();
            CreateMap<CreateProjectDto, ProjectDTO>().ReverseMap();

            // Tasks
            CreateMap<SpecificTaskVM, SpecificTaskViewModel>().ReverseMap();
            CreateMap<SpecificTaskViewModel, CreateTaskCommand>().ReverseMap();
            CreateMap<CreateTaskDto, TaskDto>().ReverseMap();
            CreateMap<SpecificTaskViewModel, UpdateTaskCommand>().ReverseMap();
        }
    }
}
