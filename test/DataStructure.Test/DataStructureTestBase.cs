using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace DataStructure
{
    public abstract class DataStructureTestBase
    {

        /// <summary>
        /// 测试次数
        /// </summary>
        public const int TestTimes = 1000;

        /// <summary>
        /// 最大数组长度
        /// </summary>
        public const int MaxArraySize = 1000;


        /// <summary>
        /// 最大生成值
        /// </summary>
        public const int MaxValue = 1000;


        /// <summary>
        /// 生成一个最大长度为MaxSize最大值为MaxValue的随机数组
        /// </summary>
        /// <returns></returns>
        public static int[] RandomNumbersGenerator()
        {
            int[] arry = new int[(int)((MaxArraySize + 1) * new Random().NextDouble())];

            for (int i = 0; i < arry.Length; i++)
            {
                arry[i] = (int)((MaxValue + 1) * new Random().NextDouble()) - (int)(MaxValue * new Random().NextDouble());
            }

            return arry;
        }


        /// <summary>
        /// 生成一个最大值为MaxValue随机数
        /// </summary>
        /// <returns></returns>
        public static int RandomNumberGenerator()
        {
            return (int)((MaxValue + 1) * new Random().NextDouble()) - (int)(MaxValue * new Random().NextDouble());
        }

        /// <summary>
        /// 测试的算法
        /// </summary>
        public abstract void Algorithm();


        /// <summary>
        /// 判断算法是否正确
        /// </summary>
        /// <returns></returns>
        public abstract bool AlgorithmAssert();


        /// <summary>
        /// 运行测试
        /// </summary>
        /// <returns></returns>
        [Fact]
        public virtual long TestAlgorithm()
        {
            Stopwatch stopwatch = new();

            for (int i = 0; i < TestTimes; i++)
            {
                stopwatch.Start();

                Algorithm();

                stopwatch.Stop();

                Assert.True(AlgorithmAssert());

            }
            return stopwatch.ElapsedMilliseconds / TestTimes;
        }
    }
}
