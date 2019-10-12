using System;

namespace ResourceManagement
{
    public class ResourceCache : IResourceCache
    {
        public decimal Quantity { get; private set; }

        public void Apply(IResourceAdjustment adjustment)
        {
            if (Quantity + adjustment.Quantity < 0)
                throw new Exception("Insufficient resources");

            Quantity += adjustment.Quantity;
        }
    }
}
