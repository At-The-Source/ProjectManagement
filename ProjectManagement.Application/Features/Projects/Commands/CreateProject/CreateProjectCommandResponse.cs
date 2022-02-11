using ProjectManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Projects.Commands.CreateProject
{
    public class CreateProjectCommandResponse : BaseResponse
    {
        public CreateProjectDto Project { get; set; }
        public CreateProjectCommandResponse() : base()
        {

        }
    }
}
