using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.SortAlgorithm
{
    /// <summary>
    /// 归并排序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class MergeSorting<T> : Sorting<T> where T : IComparable
    {
        public override void Algorithm(T[] arry, int n)
        {
            Process(arry, 0, n - 1);
        }


        public void Process(T[] arry, int left, int right)
        {
            if (left == right)
            {
                return;
            }

            int mid = left + ((right - left) >> 1);
            Process(arry, left, mid);
            Process(arry, mid + 1, right);
            Merge(arry, left, mid, right);

            ///Master公式
            ///T(N)=a*T(N/b)+O(N^d)
            ///if:Logb(a)<d:O(N^d)
            ///if:Logb(a)>d:O(N^logb(a))
            ///if:logb(a)=d:O(N^d*logN)
            ///a:子问题的调用次数;b:子问题的规模;O(N^d)代表除去调用外剩下的操作
            ///这里需要满足子问题等价
            ///由公式可得O(n)=2T(N/2)+O(N):O(N*logN)
        }


        public void Merge(T[] arry, int left, int mid, int right)
        {
            T[] helper = new T[right - left + 1];

            int hIndex = 0, lIndex = left, rIndex = mid + 1;

            while (lIndex <= mid && rIndex <= right)
            {

                //如果右边比较小，先放右边
                helper[hIndex++] = Comparator(arry[lIndex], arry[rIndex]) ? arry[rIndex++] : arry[lIndex++];
            }

            while (lIndex <= mid)
            {
                helper[hIndex++] = arry[lIndex++];
            }

            while (rIndex <= right)
            {
                helper[hIndex++] = arry[rIndex++];
            }

            for (hIndex = 0; hIndex < helper.Length; hIndex++)
            {
                arry[left + hIndex] = helper[hIndex];
            }
        }
    }
}
