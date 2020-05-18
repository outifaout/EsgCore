using Esgcore.DB.Entities;
using Esgcore.Logic.Sectors.Responses;

namespace Esgcore.Logic.Sectors
{
    public static class SectorMapper
    {
        public static SectorResponse ToResponse(this Sector Sector)
        {
            var result = new SectorResponse
            {
                Id = Sector.Id,
                Name = Sector.Name
            };

            return result;
        }
    }
}
