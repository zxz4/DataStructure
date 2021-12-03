using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.SortAlgorithm
{
    /// <summary>
    /// 选择排序 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class SelectionSorting<T> : Sorting<T> where T : IComparable
    {
        public override void Algorithm(T[] arry, int n)
        {
            for (int i = 0; i < n; i++)  //(N+N-1+N-2+N-3+...1)=N(1+N)/2
            {
                //遍历每个没排序的元素,找出最小值的位置
                int index = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (Comparator(arry[index], arry[j])) //(N-1+N-2+N-3...1)
                    {
                        index = j;
                    }
                }
                Swap(arry, i, index); 
            }
            //时间复杂度 aN^2+bN+c=O(N^2),额外空间复杂度O(1)
        }
    }
}
