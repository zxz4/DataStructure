using System;
using System.Linq;
using System.Text;

namespace DataStructure.Question
{
    /// <summary>
    /// qu4:在一个无序数组中,找出任意一个局部最小值
    /// </summary>
    public class Question005 : DataStructureTestBase
    {
        private int[] arry;

        private int index;

        public override void Algorithm()
        {
            index = -1;

            arry = RandomNumbersGenerator().Distinct().ToArray();

            int length = arry.Length;

            if (length == 1 || length == 0)
            {
                index = 0;
                return;
            }
            if (arry[0] < arry[1])
            {
                index = 0;
                return;
            }
            if (arry[length - 1] < arry[length - 2])
            {
                index = length - 1;
                return;
            }

            //第一和最后一个个不用看
            int low = 1, high = length - 2;

            while (low <= high)
            {
                int mid = low + ((high - low) >> 1);

                if (arry[mid - 1] > arry[mid] && arry[mid] < arry[mid + 1])
                {
                    //如果MID是局部最小，直接返回MID
                    index = mid;
                    return;
                }
                else if (arry[mid - 1] < arry[mid])
                {
                    //如果[MID-1,MID]上升,取左边
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
        }

        public override bool AlgorithmAssert()
        {
            if (arry.Length == 0)

                return true;

            if (arry.Length == 1)

                return index == 0;

            if (index == 0)
            {
                return arry[0] < arry[1];
            }

            if (index + 1 == arry.Length)
            {
                return arry[index] < arry[index - 1];
            }


            return arry[index - 1] > arry[index] && arry[index] < arry[index + 1];
        }
    }
}
