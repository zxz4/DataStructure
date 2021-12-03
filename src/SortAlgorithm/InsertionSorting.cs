using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.SortAlgorithm
{
    /// <summary>
    /// 插入排序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class InsertionSorting<T> : Sorting<T> where T : IComparable
    {
        public override void Algorithm(T[] arry, int n)
        {
            for (int i = 1; i < n; i++)
            {
                //分别使数组在0~i区间内有序
                for (int j = i - 1; j >= 0 && Comparator(arry[j], arry[j + 1]); j--)
                {
                    Swap(arry, j, j + 1);
                }
            }
        }
        //时间复杂度最好情况为O(n),最差为O(n^2),情况会应输入不同而改变,实际性能优于冒泡和选择排序
    }
}
