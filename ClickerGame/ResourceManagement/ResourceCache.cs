namespace ResourceManagement
{
    public interface IResourceCache
    {
        double Quantity { get; }

        void Apply(double adjustment);
    }

    public class ResourceCache : IResourceCache
    {
        public double Quantity { get; private set; }

        public void Apply(double adjustment)
        {
            Quantity += adjustment;
        }
    }
}
