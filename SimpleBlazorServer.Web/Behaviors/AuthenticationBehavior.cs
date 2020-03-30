using SimpleBlazorServer.Shared.Services;
using MediatR;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleBlazorServer.Web.Behaviors
{
    public class AuthenticationBehavior<IRequest, TResponse> : IPipelineBehavior<IRequest, TResponse>
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IUserService _userService;
        public AuthenticationBehavior(AuthenticationStateProvider authenticationStateProvider, IUserService userService)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _userService = userService;
        }
        public async Task<TResponse> Handle(IRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();

            _userService.User = authenticationState.User;

            return await next();
        }
    }
}
