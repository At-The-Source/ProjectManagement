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
            CreateMap<ProjectListVM, ProjectViewModel>().ReverseMap();
            CreateMap<ProjectTaskDTO, TaskNestedViewModel>().ReverseMap();
            CreateMap<ProjectTaskListVM, ProjectTaskViewModel>().ReverseMap();

        }
    }
}
