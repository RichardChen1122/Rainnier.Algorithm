﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.Sort
{
    //堆一定是一个完全二叉树，完全二叉树有一定的性质：
    //左节点的下标一定是基数，右节点的下标一定是偶数
    //父节点的下标是i，那么: 他的左子节点下标为2i+1，他的右子节点下标为2i+2
    public class HeapSort
    {
        public static void SortMethod(int[] array)
        {
            //1.构建大顶堆
            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                //从第一个非叶子结点从下至上，从右至左调整结构(非叶子节点一定在最前面)
                AdjustHeap(array, i, array.Length);
            }
            //2.调整堆结构+交换堆顶元素与末尾元素
            for (int j = array.Length - 1; j > 0; j--)
            {
                Swap(array, 0, j);//将堆顶元素与末尾元素进行交换
                AdjustHeap(array, 0, j);//重新对堆进行调整
            }
        }

        public static void AdjustHeap(int[] array, int i, int length)
        {
            int temp = array[i];

            for(int k = i * 2 + 1; k < length; k = k * 2 + 1)//从i结点的左子结点开始，也就是2i+1处开始
            {
                if (k + 1 < length && array[k] < array[k + 1])
                {//如果左子结点小于右子结点，k指向右子结点
                    k++;
                }
                if (array[k] > temp)
                {//如果子节点大于父节点，将子节点值赋给父节点（不用进行交换）
                    array[i] = array[k];
                    i = k;
                }
                else
                {
                    break;
                }
            }
            array[i] = temp;//将temp值放到最终的位置
        }

        public static void Swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
