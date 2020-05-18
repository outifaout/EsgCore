using System;

namespace Esgcore.Logic.Sectors.Events
{
    public class SectorCreatedEvent
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime MyProperty { get; set; }
    }
}
