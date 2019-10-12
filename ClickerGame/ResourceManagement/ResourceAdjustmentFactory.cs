namespace ResourceManagement
{
    public class ResourceAdjustmentFactory
    {
        public IResourceAdjustment CreateIncreaseEqualTo(decimal adjustment) =>
            new ResourceAdjustment(adjustment);

        public IResourceAdjustment CreateDecreaseEqualTo(decimal adjustment) =>
            new ResourceAdjustment(adjustment * -1);
    }
}
