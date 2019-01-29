using System.Numerics;
using Xunit;

namespace Oeis.A002845.Tests
{
    /// <summary>Tests for <see cref="SparseInteger"/>.</summary>
    public sealed class SparseIntegerTests
    {
        [Fact]
        public void TestSmallArithmetic()
        {
            var one = (SparseInteger) 1;
            var two = (SparseInteger) 2;
            var three = one + two;

            var alsoOne = (SparseInteger) 1;
            var alsoThree = (SparseInteger) 3;
            
            Assert.True(1 == one);
            Assert.True(one == 1);
            Assert.True(one != 2);
            Assert.True(one < 2);

            Assert.True(one.Equals(alsoOne));
            Assert.True(one.Equals((object) alsoOne));
            Assert.Equal(0, one.CompareTo(alsoOne));
            Assert.False(one > alsoOne);
            Assert.False(one < alsoOne);
            Assert.True(one == alsoOne);
            Assert.True(one >= alsoOne);
            Assert.True(one <= alsoOne);

            Assert.True(three.Equals(alsoThree));
            Assert.True(three.Equals((object) alsoThree));
            Assert.Equal(0, three.CompareTo(alsoThree));
            Assert.False(three < alsoThree);
            Assert.False(three > alsoThree);
            Assert.True(three == alsoThree);
            Assert.True(three >= alsoThree);
            Assert.True(three <= alsoThree);

            Assert.True(three == 3);
            Assert.True(three == 3UL);
            Assert.True(three > 2);
            Assert.False(three < 3);

            Assert.False(one.Equals(three));
            Assert.False(one.Equals((object) three));
            Assert.False(one.Equals((object) 3));
            Assert.False(one.Equals((object) 3UL));
            Assert.False(one.Equals(null));
            Assert.True(one.CompareTo(two) < 0);
            Assert.True(one.CompareTo(2) < 0);
            Assert.True(one.CompareTo(2UL) < 0);
            Assert.True(alsoThree.CompareTo(two) > 0);

            var six = two * three;

            Assert.True(6 == six);
            Assert.True(0 == six.CompareTo(six));
            Assert.True(six.Equals(six));
            Assert.True(six.Equals(6));

            BigInteger big = ulong.MaxValue;
            var huge = (SparseInteger)(big * big);
            
            Assert.True(0 == huge.CompareTo(huge));
            Assert.True(huge.Equals(huge));
            Assert.Equal(0, huge.CompareTo(huge));
            Assert.True(three.CompareTo(huge) < 0);
            Assert.True(huge.CompareTo(two) > 0);
        }

        [Fact]
        public void TestLargeArithmetic()
        {
            var two = (SparseInteger) 2;

            BigInteger big = (BigInteger) decimal.MaxValue;
            var huge = (SparseInteger)(big * big);

            Assert.True(huge.Equals(huge));
            Assert.True(huge.Equals((object) huge));
            Assert.Equal(0, huge.CompareTo(huge));
            Assert.True(two.CompareTo(huge) < 0);
            Assert.True(huge.CompareTo(two) > 0);
        }
    }
}