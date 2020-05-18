using System.Collections.Generic;
using MediatR;
using Esgcore.Logic.Sectors.Responses;

namespace Esgcore.Logic.Sectors.Queries
{
    public class GetAllSectorsQuery : IRequest<List<SectorResponse>>
    {
    }
}
