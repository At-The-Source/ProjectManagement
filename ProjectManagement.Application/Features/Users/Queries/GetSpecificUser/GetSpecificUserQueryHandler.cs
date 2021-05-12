using AutoMapper;
using MediatR;
using ProjectManagement.Application.Contracts.Persistence;
using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Users.Queries.GetSpecificUser
{
    public class GetSpecificUserQueryHandler : IRequestHandler<GetSpecificUserQuery, SpecificUserVM>
    {
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public GetSpecificUserQueryHandler(IMapper mapper, IAsyncRepository<User> userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<SpecificUserVM> Handle(GetSpecificUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            var specificUserVM = _mapper.Map<SpecificUserVM>(user);
            return specificUserVM;
        }
    }
}
