using System.Collections.Generic;
using Microsoft.Azure.Documents.ChangeFeedProcessor.FeedProcessing;

namespace Esgcore.Projections
{
    public class EventObserverFactory : IChangeFeedObserverFactory
    {
        private readonly List<IProjection> _projections;
        private readonly IViewRepository _viewRepository;

        public EventObserverFactory(List<IProjection> projections, IViewRepository viewRepository)
        {
            _projections = projections;
            _viewRepository = viewRepository;
        }

        public IChangeFeedObserver CreateObserver()
        {
            return new EventObserver(_projections, _viewRepository);
        }
    }
}