using MediatR;
using Esgcore.DB;
using Esgcore.Logic.Sectors.Queries;
using Esgcore.Logic.Sectors.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Esgcore.Logic.Sectors.Handlers
{
    public class GetSectorByIdHandler : IRequestHandler<GetSectorByIdQuery, SectorResponse>
    {
        private readonly EsgcoreDbContext _dbContext;

        public GetSectorByIdHandler(EsgcoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SectorResponse> Handle(GetSectorByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Sectors.FindAsync(request.Id);
            var response = entity?.ToResponse();
            return response;
        }
    }
}
