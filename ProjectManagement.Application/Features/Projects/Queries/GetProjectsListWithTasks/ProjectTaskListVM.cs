using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Projects.Queries.GetProjectsListWithTasks
{
    public class ProjectTaskListVM
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public ICollection<ProjectTaskDTO> Tasks { get; set; }
    }
}
