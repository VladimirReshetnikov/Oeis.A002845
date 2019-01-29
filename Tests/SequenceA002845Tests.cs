using Xunit;

namespace Oeis.A002845.Tests
{
    public sealed class SequenceA002845Tests
    {
        /// <summary>Check a few first elements of the sequence that are quick to compute.</summary>
        [Fact]
        public void TestElements()
        {
            var sequence = new SequenceA002845();

            // See https://oeis.org/A002845
            long[] expectedValues =
            {
                1, 1, 1, 2, 4, 8, 17, 36, 78, 171, 379, 851, 1928,
                4396, 10087, 23273, 53948, 125608, 293543, 688366
            };

            for (int i = 0; i < expectedValues.Length; i++)
            {
                Assert.Equal(expectedValues[i],sequence[i + 1]);
            }
        }
    }
}