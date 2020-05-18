using MediatR;
using Esgcore.Logic.Sectors.Responses;

namespace Esgcore.Logic.Sectors.Queries
{
    public class GetSectorByIdQuery : IRequest<SectorResponse>
    {
        public long Id { get; set; }

        public GetSectorByIdQuery(long id)
        {
            Id = id;
        }
    }
}
