using NUnit.Framework;
using ResourceManagement;
using System;
using System.Linq;

namespace ResourceManagmentTests
{
    [TestFixture]
    public class ResourceCacheTests
    {
        [TestFixture]
        public class Initialise
        {
            [Test]
            public void QuantityIsZero()
            {
                var resourceCache = new ResourceCache();

                Assert.That(resourceCache.Quantity, Is.EqualTo(0));
            }
        }

        [TestFixture]
        public class Apply
        {
            [TestCase(-1)]
            [TestCase(-15.12)]
            public void QuantityWouldBeBelowZero_ThrowsException(decimal adjustmentQuantity)
            {
                var adjustment = new ResourceAdjustment { Quantity = adjustmentQuantity };

                var resourceCache = new ResourceCache();

                Assert.Throws<Exception>(() => resourceCache.Apply(adjustment));
            }

            [TestCase(15.7)]
            [TestCase(185)]
            public void AppliesAdjustmentToQuantity(decimal adjustmentQuantity)
            {
                var adjustment = new ResourceAdjustment { Quantity = adjustmentQuantity };

                var resourceCache = new ResourceCache();

                resourceCache.Apply(adjustment);

                Assert.That(resourceCache.Quantity, Is.EqualTo(adjustmentQuantity));
            }

            [TestCase(2.3, 14.1, -11.8)]
            [TestCase(861.82, 847.12, 28.1, -31.4, 18)]
            public void MultipleAdjustments_AppliesAdjustmentsCorrectly(decimal expectedQuantity, params double[] adjustmentQuantities)
            {
                var adjustments = adjustmentQuantities
                    .Select(x => new ResourceAdjustment { Quantity = (decimal)x });

                var resourceCache = new ResourceCache();

                foreach (var adjustment in adjustments)
                    resourceCache.Apply(adjustment);

                Assert.That(resourceCache.Quantity, Is.EqualTo(expectedQuantity));
            }
        }

        private class ResourceAdjustment : IResourceAdjustment
        {
            public decimal Quantity { get; set; }
        }
    }
}
