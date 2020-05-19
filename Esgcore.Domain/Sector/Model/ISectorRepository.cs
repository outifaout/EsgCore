using System.Threading.Tasks;

namespace Esgcore.Domain.Model
{
    public interface ISectorRepository
    {
        Task<Sector> LoadSectorAsync(string id);

        Task<bool> SaveSectorAsync(Sector meter);
    }
}