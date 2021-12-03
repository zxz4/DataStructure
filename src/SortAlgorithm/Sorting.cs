using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.SortAlgorithm
{
    /// <summary>
    /// 排序算法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Sorting<T> where T : IComparable
    {

        /// <summary>
        /// 标识是否使用升序排序
        /// </summary>
        public static bool ASC = true;

        /// <summary>
        /// 排序算法
        /// </summary>
        /// <param name="arry"></param>
        /// <param name="n"></param>
        public abstract void Algorithm(T[] arry, int n);


        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="arry"></param>
        /// <param name="n"></param>
        public virtual void Sort(T[] arry, int n)
        {
            if (arry == null || arry.Length < n)
            {
                throw new ArgumentException();
            }

            Algorithm(arry, n);
        }

        /// <summary>
        /// 比较器
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <returns></returns>
        public static bool Comparator(T a1, T a2)
        {
            return a1.CompareTo(a2) > 0 && ASC;
        }

        /// <summary>
        /// 交换i,j所在的位置
        /// </summary>
        /// <param name="arry"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public static void Swap(T[] arry, int i, int j)
        {
            T temp = arry[i];
            arry[i] = arry[j];
            arry[j] = temp;
        }
    }
}
