using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Oeis.A002845
{
    /// <summary>
    /// A lazily computed sequence of terms of https://oeis.org/A002845: "Number of distinct values taken by 2^2^...^2
    /// (with n 2's and parentheses inserted in all possible ways)."
    /// </summary>
    /// <remarks>
    /// <para>
    /// The operator `^` in the sequence definition denotes exponentiation
    /// (raising its left operand to the power equal to its right operand).
    /// </para>
    /// <para>
    /// We refer to `n` as a size of expression `2^2^...^2`.
    /// Note that the sequence is only defined for positive integer indexes `n`.
    /// </para>
    /// </remarks>
    public sealed class SequenceA002845 : IEnumerable<int>
    {
        /// <summary>Gets a term of the sequence by its index <paramref name="n"/>.</summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="n"/> is zero or negative.</exception>
        public int this[int n] =>
            n > 0
                ? this.GetExpressionsOfSize(n).Count
                : throw new ArgumentOutOfRangeException(nameof(n), n, "Index n must be a positive integer.");

        /// <summary>
        /// A map from an expression size (of type <see cref="int"/>) to the set of all expressions of that size
        /// (represented as <see cref="HashSet{T}"/> where <c>T</c> is <see cref="SparseInteger"/>).
        /// </summary>
        private readonly Dictionary<int, HashSet<SparseInteger>> expressionsOfSize =
            new Dictionary<int, HashSet<SparseInteger>>
            {
                // `2` is the only expression of size 1, seed the dictionary with it.
                {1, new SparseInteger[] {2}.ToHashSet()}
            };

        /// <summary>Returns the set of all expressions of a given <paramref name="size"/>.</summary>
        /// <remarks>
        /// Fetches the result from <see cref="expressionsOfSize"/> if it has been already computed;
        /// otherwise computes the set by constructing expressions using smaller expressions for bases and exponents
        /// and removing duplicates, and then returns the result after storing it in <see cref="expressionsOfSize"/>.
        /// </remarks>
        private HashSet<SparseInteger> GetExpressionsOfSize(int size)
        {
            Debug.Assert(size > 0);

            if (!this.expressionsOfSize.TryGetValue(size, out HashSet<SparseInteger> result))
            {
                result = new HashSet<SparseInteger>(
                    from i in Enumerable.Range(1, size - 1)
                    from @base in this.GetExpressionsOfSize(i)
                    from exponent in this.GetExpressionsOfSize(size - i)
                    select @base.Power(exponent));

                this.expressionsOfSize.Add(size, result);
            }

            return result;
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            for (int i = 1; i < int.MaxValue; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<int>)this).GetEnumerator();
        }
    }
}