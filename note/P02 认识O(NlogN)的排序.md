## P02 认识O(NlogN)的排序

### MASTER公式

T(N) = a*T(N/b)+O(N^d),a:子问题的调用次数;b:子问题的规模;O(N^d)代表除去调用外剩下的操作(要求子问题等价)
1. Logb(a)<d:O(N^d)
2. Logb(a)>d:O(N^logb(a))
3. Logb(a)=d:O(N^d*logN)

### 归并排序
```
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
```

### 快速排序
```
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
```

## 问题
6.  qu6:使用递归方法寻找一个数组中的最大值，剖析递归行为的时间复杂度。
7.  qu7:小和问题
8.  qu8:逆序对问题
9.  qu9:米兰国旗问题
10. qu10:米兰国旗问题2