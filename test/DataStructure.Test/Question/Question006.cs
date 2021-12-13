using System;
using System.Linq;
using System.Text;

namespace DataStructure.Question
{
    /// <summary>
    /// 使用递归方法寻找一个数组中的最大值，剖析递归行为的时间复杂度。
    /// </summary>
    public class Question006 : DataStructureTestBase
    {
        private int[] arry;

        private int maxValue;

        public override void Algorithm()
        {
            arry = RandomNumbersGenerator();
            maxValue = Process(arry, 0, arry.Length - 1);
        }

        /// <summary>
        /// 寻找arry在Left~Right区间内的最大值
        /// </summary>
        /// <param name="arry"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private int Process(int[] arry, int left, int right)
        {
            if (left == right)
            {
                return arry[left];
            }

            int mid = left + ((right - left) >> 1);

            int leftMax = Process(arry, left, mid);
            int rightMax = Process(arry, mid + 1, right);

            //展开后得到一个多叉树
            return Math.Max(leftMax, rightMax);


            ///Master公式
            ///T(N)=a*T(N/b)+O(N^d)
            ///if:Logb(a)<d:O(N^d)
            ///if:Logb(a)>d:O(N^logb(a))
            ///if:logb(a)=d:O(N^d*logN)
            ///a:子问题的调用次数;b:子问题的规模;O(N^d)代表除去调用外剩下的操作
            ///这里需要满足子问题等价
            ///由公式可得O(n)=2T(N/2)+O(1):O(N)
        }

        public override bool AlgorithmAssert()
        {
            return maxValue == arry.Max();
        }
    }
}
