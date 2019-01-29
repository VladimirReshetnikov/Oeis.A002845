using System;
using System.Diagnostics;

namespace Oeis.A002845.ConsoleApp
{
    /// <summary>
    /// This program prints values of an integer sequence https://oeis.org/A002845:
    /// "Number of distinct values taken by 2^2^...^2 (with n 2's and parentheses inserted in all possible ways)."
    /// </summary>
    /// <remarks>
    /// The operator `^` in the sequence definition denotes exponentiation
    /// (raising its left operand to the power equal to its right operand).
    /// </remarks>
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Console.WriteLine("Values                Time Spent     Memory Used");
            Console.WriteLine("─────────────────     ──────────     ───────────");

            var timer = Stopwatch.StartNew();
            var sequence = new SequenceA002845();

            for (int i = 1; i < int.MaxValue; i++)
            {
                Console.WriteLine(
                    $"a({i}) = ".PadRight(8) +
                    $"{sequence[i]}".PadRight(14) +
                    $"{timer.Elapsed:h\\:mm\\:ss\\.ff}".PadRight(14) +
                    $"{GC.GetTotalMemory(true) * 1E-6M:F2} MB".PadLeft(12));
            }
        }
    }
}