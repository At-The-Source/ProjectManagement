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

namespace ProjectManagement.Application.Features.Users.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserListVM>>
    {
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IMapper mapper, IAsyncRepository<User> userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserListVM>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = (await _userRepository.ListAllAsync());
            return _mapper.Map<List<UserListVM>>(users);
        }
    }
}
