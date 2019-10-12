namespace ResourceManagement
{
    internal class ResourceAdjustment : IResourceAdjustment
    {
        public ResourceAdjustment(decimal quantity) { Quantity = quantity; }

        public decimal Quantity { get; }
    }
}
