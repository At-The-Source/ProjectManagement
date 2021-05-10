using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Projects
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
    }
}
