﻿using Esgcore.EventStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esgcore.Domain.Sector.Events
{
    public class SectorDeleted : EventBase
    {
        public string SectorId { get; set; }

    }
}
