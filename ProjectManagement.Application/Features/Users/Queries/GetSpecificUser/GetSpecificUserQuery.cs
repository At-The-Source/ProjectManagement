using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Users.Queries.GetSpecificUser
{
    public class GetSpecificUserQuery : IRequest<SpecificUserVM>
    {
        public Guid UserId { get; set; }
    }
}
