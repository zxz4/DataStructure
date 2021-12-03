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
        /// ���Դ���
        /// </summary>
        public const int TestTimes = 1000;

        /// <summary>
        /// ������鳤��
        /// </summary>
        public const int MaxArraySize = 1000;


        /// <summary>
        /// �������ֵ
        /// </summary>
        public const int MaxValue = 1000;


        /// <summary>
        /// ����һ����󳤶�ΪMaxSize���ֵΪMaxValue���������
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
        /// ����һ�����ֵΪMaxValue�����
        /// </summary>
        /// <returns></returns>
        public static int RandomNumberGenerator()
        {
            return (int)((MaxValue + 1) * new Random().NextDouble()) - (int)(MaxValue * new Random().NextDouble());
        }

        /// <summary>
        /// ���Ե��㷨
        /// </summary>
        public abstract void Algorithm();


        /// <summary>
        /// �ж��㷨�Ƿ���ȷ
        /// </summary>
        /// <returns></returns>
        public abstract bool AlgorithmAssert();


        /// <summary>
        /// ���в���
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
