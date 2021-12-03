
using DataStructure.SortAlgorithm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataStructure.SortAlgorithm
{
    public abstract class SortingTestBase : DataStructureTestBase
    {
        protected Sorting<int> alg;

        protected int[] result1, result2;

        public override void Algorithm()
        {
            alg.Sort(result1, result1.Length);
        }


        [Fact]
        public override long TestAlgorithm()
        {
            Stopwatch stopwatch = new();

            for (int i = 0; i < TestTimes; i++)
            {
                result1 = RandomNumbersGenerator();

                result2 = new int[result1.Length];

                Array.Copy(result1, result2, result1.Length);

                stopwatch.Start();

                Algorithm();

                stopwatch.Stop();

                Array.Sort(result2);

                Assert.True(AlgorithmAssert());

            }
            return stopwatch.ElapsedMilliseconds / TestTimes;
        }

        public override bool AlgorithmAssert()
        {
            for (int i = 0; i < result1.Length; i++)
            {
                if (result1[i] != result2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
