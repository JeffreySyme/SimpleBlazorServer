using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SimpleBlazorServer.Commands.SampleForm
{
    public partial class CreateItem
    {
        public class Handler : IRequestHandler<Command, Response>
        {
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                await Task.Delay(1000);
                return new Response();
            }
        }
    }
}