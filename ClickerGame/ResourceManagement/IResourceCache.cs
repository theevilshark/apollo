namespace ResourceManagement
{
    public interface IResourceCache
    {
        double Quantity { get; }

        void Apply(IResourceAdjustment adjustment);
    }
}
