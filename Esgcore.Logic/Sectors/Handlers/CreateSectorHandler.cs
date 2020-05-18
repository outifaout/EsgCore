using MediatR;
using Esgcore.DB;
using Esgcore.DB.Entities;
using Esgcore.Logic.Sectors.Commands;
using Esgcore.Logic.Sectors.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Esgcore.Logic.Sectors.Handlers
{
    public class CreateSectorHandler : IRequestHandler<CreateSectorCommand, SectorResponse>
    {
        private readonly EsgcoreDbContext _dbContext;

        public CreateSectorHandler(EsgcoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SectorResponse> Handle(CreateSectorCommand request, CancellationToken cancellationToken)
        {
            var entity = new Sector
            {
                Name = request.Name
            };

            _dbContext.Sectors.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var response = entity.ToResponse();

            return response;
        }
    }
}
