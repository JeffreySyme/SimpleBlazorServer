using MediatR;

namespace SimpleBlazorServer.Commands.SampleForm
{
    public partial class CreateItem
    {
        public class Command : IRequest<Response>
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
        }
    }
}