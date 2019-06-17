using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.Sort
{
    public class QuickSort
    {
        public static int Division(int[] array, int left,int right)
        {
            int b = array[left];
            while (left<right)
            {
                while (left < right && array[right] >= b)
                {
                    right--;
                }

                array[left] = array[right];
                while (left < right && array[left] <= b)
                {
                    left++;
                }

                array[right] = array[left];
            }
            array[left] = b;
            return left;
        }
        public static void QuickSortMethod(int[] array, int left, int right)
        {
            if (left < right)
            {
                int i = Division(array, left, right);

                QuickSortMethod(array, left, i - 1);
                QuickSortMethod(array, i+1, right);
            }
        }
    }
}
