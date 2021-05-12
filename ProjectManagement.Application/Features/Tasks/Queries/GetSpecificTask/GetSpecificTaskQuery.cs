using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Tasks.Queries.GetSpecificTask
{
    public class GetSpecificTaskQuery : IRequest<SpecificTaskVM>
    {
        public Guid TaskId { get; set; }
    }
}
