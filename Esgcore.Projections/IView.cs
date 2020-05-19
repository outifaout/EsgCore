using Newtonsoft.Json.Linq;

namespace Esgcore.Projections
{
    public interface IView
    {
        JObject Payload { get; set; }
    }
}