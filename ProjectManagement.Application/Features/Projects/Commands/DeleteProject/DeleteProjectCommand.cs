using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest
    {
        public Guid ProjectId { get; set; }
    }
}
