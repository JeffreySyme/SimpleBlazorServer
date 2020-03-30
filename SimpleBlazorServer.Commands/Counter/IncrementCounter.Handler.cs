using AutoMapper;
using SimpleBlazorServer.Shared.Services;
using MediatR;

namespace SimpleBlazorServer.Commands.Counter
{
    public partial class IncrementCounter
    {
        public class Handler : RequestHandler<Command, Response>
        {
            private readonly IMapper _mapper;
            private readonly IUserService _userService;
            public Handler(IMapper mapper, IUserService userService)
            {
                _mapper = mapper;
                _userService = userService;
            }

            protected override Response Handle(Command request)
            {
                var counterValue = _mapper.Map<CounterValue>(request);

                var user = _userService.User;

                counterValue.Value += 1;

                return _mapper.Map<Response>(counterValue);
            }
        }
    }
}
