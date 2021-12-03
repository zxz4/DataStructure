using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.SortAlgorithm
{
    /// <summary>
    /// 冒泡排序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class BubbleSorting<T> : Sorting<T> where T : IComparable
    {
        public override void Algorithm(T[] arry, int n)
        {
            for (int i = n - 1; i > 0; i--) // N
            {
                for (int j = 0; j < i; j++)
                {
                    if (Comparator(arry[j], arry[j + 1])) // (1+2+...+N-1) + (1+2+...+N-2) = aN^2+bN+c
                    {
                        Swap(arry, j, j + 1);
                    }
                }
            }
            //时间复杂度O(n^2),额外空间复杂度O(0)
        }
    }
}
