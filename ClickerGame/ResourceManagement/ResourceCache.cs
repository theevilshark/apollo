namespace ResourceManagement
{
    public class ResourceCache : IResourceCache
    {
        public double Quantity { get; private set; }

        public void Apply(IResourceAdjustment adjustment)
        {
            Quantity += adjustment.Quantity;
        }
    }
}
