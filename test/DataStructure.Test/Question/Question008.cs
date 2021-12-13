using System;
using System.Linq;
using System.Text;

namespace DataStructure.Question
{
    /// <summary>
    /// 逆序对问题
    /// </summary>
    public class Question008 : DataStructureTestBase
    {
        private int[] arry;

        private int inversionPair, correct;

        public override void Algorithm()
        {
            arry = RandomNumbersGenerator();

            correct = 0;

            for (int i = 0; i < arry.Length; i++)
            {
                for (int j = i + 1; j < arry.Length; j++)
                {
                    if (arry[i] > arry[j])
                    {
                        correct++;
                    }
                }
            }

            inversionPair = Process(arry, 0, arry.Length - 1);
        }

        private int Process(int[] arry, int left, int right)
        {
            if (left == right)
            {
                return 0;
            }

            int mid = left + ((right - left) >> 1);

            return Process(arry, left, mid)
                + Process(arry, mid + 1, right)
                + Merge(arry, left, mid, right);
        }

        private int Merge(int[] arry, int left, int mid, int right)
        {
            int[] helper = new int[right - left + 1];

            int hIndex = 0, lIndex = left, rIndex = mid + 1;

            int sum = 0;

            while (lIndex <= mid && rIndex <= right)
            {
                if (arry[lIndex] > arry[rIndex])
                {
                    sum += mid - lIndex + 1;
                }

                helper[hIndex++] = arry[lIndex] <= arry[rIndex] ? arry[lIndex++] : arry[rIndex++];
            }

            while (lIndex <= mid)
            {
                helper[hIndex++] = arry[lIndex++];
            }

            while (rIndex <= right)
            {
                helper[hIndex++] = arry[rIndex++];
            }

            for (hIndex = 0; hIndex < helper.Length; hIndex++)
            {
                arry[left + hIndex] = helper[hIndex];
            }

            return sum;
        }

        public override bool AlgorithmAssert()
        {
            return inversionPair == correct;
        }
    }
}
