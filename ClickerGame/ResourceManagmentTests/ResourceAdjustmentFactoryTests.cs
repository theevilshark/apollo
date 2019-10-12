using NUnit.Framework;
using ResourceManagement;

namespace ResourceManagmentTests
{
    [TestFixture]
    public class ResourceAdjustmentFactoryTests
    {
        [TestFixture]
        public class CreateIncreaseEqualTo
        {
            [TestCase(0)]
            [TestCase(847)]
            [TestCase(0.1)]
            [TestCase(5.2)]
            [TestCase(195146.2848)]
            [TestCase(-17.8)]
            public void ReturnsAdjustmentWithCorrectQuantity(decimal quantity)
            {
                var resourceAdjustmentFactory = new ResourceAdjustmentFactory();

                var adjustment = resourceAdjustmentFactory.CreateIncreaseEqualTo(quantity);

                Assert.That(adjustment.Quantity, Is.EqualTo(quantity));
            }
        }

        [TestFixture]
        public class CreateDecreaseEqualTo
        {
            [TestCase(0, 0)]
            [TestCase(49, -49)]
            [TestCase(19581.412, -19581.412)]
            [TestCase(-14.61, 14.61)]
            public void ReturnsAdjustmentWithCorrectQuantity(decimal inputQuantity, decimal resultQuantity)
            {
                var resourceAdjustmentFactory = new ResourceAdjustmentFactory();

                var adjustment = resourceAdjustmentFactory.CreateDecreaseEqualTo(inputQuantity);

                Assert.That(adjustment.Quantity, Is.EqualTo(resultQuantity));
            }
        }
    }
}
