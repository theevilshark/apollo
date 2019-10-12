namespace ResourceManagement
{
    internal class ResourceAdjustment : IResourceAdjustment
    {
        public ResourceAdjustment(double quantity) { Quantity = quantity; }

        public double Quantity { get; }
    }
}
