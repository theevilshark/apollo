using ResourceManagement;
using System;

namespace ClickerGame.ViewModel
{
    class ObservableResourceCache : IResourceCache
    {
        private readonly IResourceCache _resourceCache;
        private readonly Action _notify;

        public ObservableResourceCache(IResourceCache resourceCache, Action notify)
        {
            _resourceCache = resourceCache;
            _notify = notify;
        }

        public double Quantity => _resourceCache.Quantity;

        public void Apply(IResourceAdjustment adjustment)
        {
            _resourceCache.Apply(adjustment);
            _notify();
        }
    }
}
