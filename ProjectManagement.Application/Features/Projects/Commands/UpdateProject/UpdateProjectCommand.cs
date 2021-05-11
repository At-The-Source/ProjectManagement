using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
    }
}
