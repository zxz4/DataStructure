using System;
using System.Linq;
using System.Text;

namespace DataStructure.Question
{
    /// <summary>
    /// qu4:在一个有序数组中,找出大于等于某个数最左侧位置
    /// </summary>
    public class Question004 : DataStructureTestBase
    {
        private readonly int[] arry;

        private int targetValue = 0, index  = 0;

        public Question004()
        {
            arry = RandomNumbersGenerator();

            Array.Sort(arry);
        }


        public override void Algorithm()
        {

            targetValue = RandomNumberGenerator();

            int low = 0, high = arry.Length;

            while (low < high)
            {
                int mid = low + ((high - low) >> 1);

                if (arry[mid] == targetValue)
                {
                    high = mid;
                }

                else if (targetValue > arry[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }

            index = low;
        }

        public override bool AlgorithmAssert()
        {
            if (arry[^1] < targetValue)
            {
                return index == arry.Length;
            }

            for (int i = 0; i < arry.Length; i++)
            {
                if (arry[i] >= targetValue)
                {
                    return i == index;
                }
            }

            return false;

        }
    }
}
