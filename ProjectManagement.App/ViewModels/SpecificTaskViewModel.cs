using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.App.ViewModels
{
    public class SpecificTaskViewModel
    {
        public Guid TaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public Guid ProjectId { get; set; }
        public ProjectViewModel Project { get; set; }
    }
}
