using AutoMapper;
using ProjectManagement.UI.Models;
using ProjectManagement.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.UI.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<ProjectListVM, ProjectViewModel>().ReverseMap();
        }
    }
}
