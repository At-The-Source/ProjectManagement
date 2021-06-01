using ProjectManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandResponse : BaseResponse
    {
        public CreateTaskDto Task { get; set; }
        public CreateTaskCommandResponse() : base()
        {

        }
    }
}
