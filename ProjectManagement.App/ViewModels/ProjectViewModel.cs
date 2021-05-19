﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.App.ViewModels
{
    public class ProjectViewModel
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
    }
}
