using System;
using System.Linq;

namespace DataStructure.Question
{
    /// <summary>
    /// qu3:在一个有序数组中,判断某个值是否存在
    /// </summary>
    public class Question003 : DataStructureTestBase
    {
        private readonly int[] arry = new int[100];

        private int targetValue = 0;

        private bool findTag = false;

        public Question003()
        {
            arry = RandomNumbersGenerator();

            Array.Sort(arry);
        }


        public override void Algorithm()
        {
            targetValue = RandomNumberGenerator();

            findTag = BinarySearch(arry, 0, arry.Length - 1, targetValue) != -1;
        }

        public override bool AlgorithmAssert()
        {
            return findTag == arry.Contains(targetValue);
        }


        /// <summary>
        /// 二分查找
        /// </summary>
        /// <param name="arry"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int BinarySearch(int[] arry, int low, int high, int target)
        {
            while (low <= high)
            {
                int mid = low + ((high - low) >> 1);

                // low+hight在极端情况可能导致Int溢出 <=> (low + high) / 2;

                if (arry[mid] == target)
                {
                    return mid;
                }

                else if (target > arry[mid])
                {
                    low = mid + 1;
                }

                else
                {
                    high = mid - 1;
                }
            }

            //时间复杂度O(LogN)

            return -1;
        }
    }
}
