using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.Sort
{
    class MergeSort
    {
        public static void SortMethod(int[] arr, int left, int right)
        {
            if (left == right)
            {
                return;
            }
            int mid = left + (right - left) / 2;

            SortMethod(arr, left, mid);
            SortMethod(arr, mid+1, right);
            merge(arr, left, mid, right);
        }

        private static void merge(int[] arr, int left, int mid, int right)
        {
            int[] temp = new int[right - left + 1];
            int i = left;
            int j = mid+1;
            int current = 0;

            while (i < mid+1 && j < right+1)
            {
                if (arr[i] < arr[j])
                {
                    temp[current] = arr[i++];
                }
                else
                {
                    temp[current] = arr[j++];
                }

                current++;
            }

            if (i == mid+1)
            {
                for(int k = j; k < right + 1; k++)
                {
                    temp[current] = arr[k];
                    current++;
                }
            }

            if (j == right+1)
            {
                for (int k = i; k < mid+1;
                    k++)
                {
                    temp[current] = arr[k];
                    current++;
                }
            }

            int n = left;
            for(int m = 0; m < temp.Length; m++)
            {
                arr[n] = temp[m];
                n++;
            }
        }
    }
}
