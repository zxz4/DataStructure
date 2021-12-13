using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.SortAlgorithm
{
    /// <summary>
    /// 快速排序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class QuickSorting<T> : Sorting<T> where T : IComparable
    {
        public override void Algorithm(T[] arry, int n)
        {
            QuickSort(arry, 0, n - 1);
        }


        public void QuickSort(T[] arry, int left, int right)
        {
            if (left < right)
            {
                //随机选择一个数与最后一位交换
                Swap(arry, left + (int)(new Random().NextDouble() * (right - left + 1)), right);

                var p = Partition(arry, left, right);

                //递归左侧依次确认边界最右侧数字位置
                QuickSort(arry, left, p[0] - 1);

                //递归右侧依次确认边界最右侧数字位置
                QuickSort(arry, p[1] + 1, right);
            }
        }


        /// <summary>
        /// 使用arry[right]做划分值,确认arry[right]的位置同时返回arry[right]的左右边界
        /// 将大于arry[right]的放在right右侧
        /// 将小于arry[right]的放在left左侧
        /// </summary>
        /// <param name="arry"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public int[] Partition(T[] arry, int left, int right)
        {

            int less = left - 1; //左边界

            int more = right;    //右边界

            while (left < more)
            {
                int compareResult = arry[right].CompareTo(arry[left]);

                //如果[Arry[left]]小于于划分值，左侧边界扩充同时交换位置
                if (compareResult > 0)
                {
                    Swap(arry, ++less, left++);
                }
                else if (compareResult < 0)
                {
                    //由于交换了位置,所有当前left所在值是没有比较过的。
                    Swap(arry, --more, left);
                }
                else
                {
                    left++;
                }
            }

            //arry[right]的位置确定
            Swap(arry, more, right);

            return new int[] { less + 1, more };
        }
    }
}
