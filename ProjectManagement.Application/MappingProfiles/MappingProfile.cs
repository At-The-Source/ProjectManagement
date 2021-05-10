using AutoMapper;
using ProjectManagement.Application.Features.Projects;
using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping for Projects, set to map in reverse.

            CreateMap<Project, ProjectListVM>().ReverseMap();
            // TODO: Add mapping for specific project
            //CreateMap<Project, SpecificProjectVM>().ReverseMap();
            //CreateMap<Domain.Entities.Task, TaskDto>();
        }
    }
}
