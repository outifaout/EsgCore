using System;
using System.Threading.Tasks;

namespace Esgcore.EventStore
{
    public interface IEvent
    {
        DateTime Timestamp { get; }
    }
}