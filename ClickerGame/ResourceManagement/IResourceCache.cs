namespace ResourceManagement
{
    public interface IResourceCache
    {
        decimal Quantity { get; }

        void Apply(IResourceAdjustment adjustment);
    }
}
