using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Projects.Queries.GetProjectsListWithTasks
{
    public class ProjectTaskDTO
    {
        public Guid TaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
    }
}
