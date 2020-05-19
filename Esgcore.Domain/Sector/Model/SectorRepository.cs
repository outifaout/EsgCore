using System.Linq;
using System.Threading.Tasks;
using Esgcore.EventStore;

namespace Esgcore.Domain.Model
{
    public class SectorRepository : ISectorRepository
    {
        private readonly IEventStore _eventStore;

        public SectorRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public async Task<Sector> LoadSectorAsync(string id)
        {
            var streamId = $"sector:{id}";

            var stream = await _eventStore.LoadStreamAsync(streamId);

            return new Sector(stream.Events);
        }

        public async Task<bool> SaveSectorAsync(Sector sector)
        {
            if (sector.Changes.Any())
            {
                var streamId = $"sector:{sector.SectorId}";

                return await _eventStore.AppendToStreamAsync(
                    streamId,
                    sector.Version,
                    sector.Changes);
            }

            return true;
        }
    }
}