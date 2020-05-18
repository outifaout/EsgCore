using MediatR;
using Esgcore.DB;
using Esgcore.Logic.Sectors.Queries;
using Esgcore.Logic.Sectors.Responses;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Esgcore.Logic.Sectors.Handlers
{
    public class GetAllSectorsHandler : IRequestHandler<GetAllSectorsQuery, List<SectorResponse>>
    {
        private readonly EsgcoreDbContext _dbContext;

        public GetAllSectorsHandler(EsgcoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SectorResponse>> Handle(GetAllSectorsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dbContext.Sectors.ToListAsync(cancellationToken: cancellationToken);

            var responses = entities.Select(x => x.ToResponse()).ToList();

            return responses;
        }
    }
}
