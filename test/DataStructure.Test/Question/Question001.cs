using System;

namespace DataStructure.Question
{

    /// <summary>
    /// q1:存在一个数组[arry]其中有一个数只出现奇数次另外的数字都出现了偶数次,请找出这个奇数a
    /// 要求解法的时间复杂度为O(n),空间复杂度为O(1) 
    /// </summary>
    public class Question001 : DataStructureTestBase
    {
        readonly int[] arry = new int[99];
        private readonly int odd = MaxValue + 100;
        private int result;

        //生成数据
        public Question001()
        {
            arry[0] = odd;

            for (int i = 1; i < arry.Length;)
            {
                int evenNum =RandomNumberGenerator();

                arry[i++] = evenNum;
                arry[i++] = evenNum;
            }
        }

        public override bool AlgorithmAssert()
        {
            return result == odd;
        }

        public override void Algorithm()
        {
            int xor = 0;

            //1 ^ 0 = 1
            //0 ^ 1 = 1
            //0 ^ 0 = 0
            //1 ^ 1 = 0

            //a ^ 0 = a
            //a ^ a = 0

            //a ^ b ^ c = a ^ c ^ b
            //a ^ b ^ a = b ^ 0 = b

            foreach (int i in arry)
            {
                xor ^= i;
            }

            result = xor;
        }
    }
}
