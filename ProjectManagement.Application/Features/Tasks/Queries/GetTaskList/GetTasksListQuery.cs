using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Tasks.Queries.GetTaskList
{
    public class GetTasksListQuery : IRequest<List<TaskListVM>>
    {
    }
}
