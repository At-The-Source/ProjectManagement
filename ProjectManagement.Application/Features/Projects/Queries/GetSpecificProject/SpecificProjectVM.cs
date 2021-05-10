using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Projects
{
    public class SpecificProjectVM
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public Guid TaskId { get; set; }
        public TaskDto Tasks { get; set; }
    }
}
