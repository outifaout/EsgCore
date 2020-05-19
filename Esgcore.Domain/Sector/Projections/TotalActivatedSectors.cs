using Esgcore.Domain.Sector.Events;
using Esgcore.Projections;

namespace Esgcore.Domain.Projections
{
    public class TotalActivatedSectors
    {
        public int Count { get; set; } = 0;
    }

    public class TotalActivatedSectorsProjection : Projection<TotalActivatedSectors>
    {
        public TotalActivatedSectorsProjection()
        {
            RegisterHandler<SectorActivated>(WhenActivated);
        }

        private void WhenActivated(SectorActivated sectorActivated, TotalActivatedSectors view)
        {
            view.Count += 1;
        }

        private void WhenDeregistered(SectorDeactivated sectorDeactivated, TotalActivatedSectors view)
        {
            view.Count -= 1;
        }
    }
}