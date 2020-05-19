using System;
using System.Collections.Generic;
using Esgcore.Domain.Sector.Events;
using Esgcore.EventStore;

namespace Esgcore.Domain.Model
{
    public class Sector
    {
        public string SectorId { get; private set; }

        public string PostalCode { get; private set; }

        public string HouseNumber { get; private set; }

        public bool IsActivated { get; private set; }

        public int FailedActivationAttempts { get; private set; }

        internal int Version { get; private set; }

        internal List<IEvent> Changes { get; }

        private string _activationCode;

        public Sector(string sectorId, string postalCode, string houseNumber, string activationCode)
        {
            Changes = new List<IEvent>();

            Apply(new SectorCreated
            {
                SectorId = sectorId
            });
        }

        public Sector(IEnumerable<IEvent> events)
        {
            Changes = new List<IEvent>();

            foreach (var @event in events)
            {
                Mutate(@event);
                Version += 1;
            }
        }

        public bool Activate(string activationCode)
        {
            if (IsActivated) throw new InvalidOperationException("Already activated.");

            if (activationCode == _activationCode)
            {
                Apply(new SectorActivated());
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Apply(IEvent @event)
        {
            Changes.Add(@event);
            Mutate(@event);
        }

        private void Mutate(IEvent @event)
        {
            ((dynamic)this).When((dynamic)@event);
        }

        private void When(SectorCreated @event)
        {
            SectorId = @event.SectorId;
        }

        private void When(SectorActivated @event)
        {
            IsActivated = true;
        }

    }
}