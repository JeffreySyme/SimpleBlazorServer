using AutoMapper;
using SimpleBlazorServer.Shared.Services;

namespace SimpleBlazorServer.Commands.Counter
{
    public partial class IncrementCounter
    {
        public class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Command, CounterValue>();
                CreateMap<CounterValue, Response>();
            }
        }
    }
}
