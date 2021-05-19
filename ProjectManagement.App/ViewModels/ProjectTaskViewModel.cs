using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.App.ViewModels
{
    public class ProjectTaskViewModel
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public ICollection<TaskNestedViewModel> Tasks { get; set; }
    }
}
