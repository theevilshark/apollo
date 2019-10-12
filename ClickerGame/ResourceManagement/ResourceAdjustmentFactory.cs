namespace ResourceManagement
{
    public class ResourceAdjustmentFactory
    {
        public IResourceAdjustment CreateIncreaseEqualTo(double adjustment) =>
            new ResourceAdjustment(adjustment);

        public IResourceAdjustment CreateDecreaseEqualTo(double adjustment) =>
            new ResourceAdjustment(adjustment * -1);
    }
}
