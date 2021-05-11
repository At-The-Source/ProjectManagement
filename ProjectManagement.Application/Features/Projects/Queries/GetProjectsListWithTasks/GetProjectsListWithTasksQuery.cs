using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Projects.Queries.GetProjectsListWithTasks
{
    public class GetProjectsListWithTasksQuery : IRequest<List<ProjectTaskListVM>>
    {
        public bool IncludeHistory { get; set; }
    }
}
