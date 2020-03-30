using System.Security.Claims;
namespace SimpleBlazorServer.Shared.Services
{
    public interface IUserService
    {
        ClaimsPrincipal User { get; set; }
    }
    public class UserService : IUserService
    {
        public ClaimsPrincipal User { get; set; }
    }
}
