using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Question
{
    /// <summary>
    /// qu2:存在一个数组[arry]其中有两个数组出现奇数次其他的数字都出现了偶数次,请找出这两个奇数a,b
    /// 要求解法的时间复杂度为O(n),空间复杂度为O(1) 
    /// </summary>
    public class Question002 : DataStructureTestBase
    {
        private readonly int[] arry = new int[100];

        readonly int odd1 = MaxValue + 102, odd2 = -MaxValue - 100;

        int result1, result2;

        //生成数据
        public Question002()
        {
            arry[0] = odd1;
            arry[1] = odd2;

            for (int i = 2; i < arry.Length;)
            {
                int evenNum = (int)((MaxValue + 1) * new Random().NextDouble()) - (int)(MaxValue * new Random().NextDouble());

                arry[i++] = evenNum;
                arry[i++] = evenNum;
            }
        }


        public override void Algorithm()
        {
            int xor = 0, amongOne = 0;

            foreach (int i in arry)
            {
                xor ^= i;
            }

            //假设这两个数为 a,b;此时xor=a^b;
            //由于a!=b,所以xor!=0
            //取xor最低一位的1
            int rightOne = xor & (~xor + 1);

            foreach (int i in arry)
            {
                if ((i & rightOne) == 0)
                {
                    amongOne ^= i;
                }
            }

            result1 = amongOne; result2 = amongOne ^ xor;
        }

        public override bool AlgorithmAssert()
        {
            return result1 + result2 == odd1 + odd2 && (result1 == odd1 || result1 == odd2);
        }
    }
}
