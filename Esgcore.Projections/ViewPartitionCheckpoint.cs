using System;
using System.Collections.Generic;
using Esgcore.EventStore;

namespace Esgcore.Projections
{
    public class ViewPartitionCheckpoint
    {
        public ViewPartitionCheckpoint()
        {
            DocumentIds = new List<string>();
        }

        public DateTime Timestamp { get; set; }

        public List<string> DocumentIds { get; }
    }
}