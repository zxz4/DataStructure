using System;
using System.Linq;
using System.Text;

namespace DataStructure.Question
{
    /// <summary>
    /// 给定一个数组arry，和一个数num
    /// 请把小于等于num放在数组左边
    /// 大于等于num的放在数组右边
    /// </summary>
    public class Question009 : DataStructureTestBase
    {
        private int[] arry;

        int num;


        public override void Algorithm()
        {
            arry = RandomNumbersGenerator();
            num = RandomNumberGenerator();

            int lBorder = 0;

            for (int i = 0; i < arry.Length; i++)
            {
                if (arry[i] <= num)
                {
                    int temp = arry[i];
                    arry[i] = arry[lBorder];
                    arry[lBorder] = temp;
                    lBorder++;
                }
            }

        }

        public override bool AlgorithmAssert()
        {
            return true;
        }
    }
}
