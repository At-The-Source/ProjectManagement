using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Tasks.Queries.GetSpecificTask
{
    public class SpecificTaskVM
    {
        public Guid TaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public Guid ProjectId { get; set; }
        public ProjectDTO Project { get; set; }
    }
}
