using MediatR;
using Esgcore.Logic.Sectors.Responses;

namespace Esgcore.Logic.Sectors.Commands
{
    public class CreateSectorCommand : IRequest<SectorResponse>
    {
        public string Name { get; set; }

        public CreateSectorCommand(string name)
        {
            Name = name;
        }
    }
}
