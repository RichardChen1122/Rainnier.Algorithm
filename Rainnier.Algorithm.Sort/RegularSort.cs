using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.Sort
{
    public static class RegularSort
    {
        public static void BubbleSort()
        {
            int[] array = new int[10] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int temp = default(int);
            for(int i = 0; i < array.Length-1; i++)
            {
                for (int j = 0; j < array.Length-1-i; j++)
                {
                    if (array[j] > array[j+1])
                    {
                        temp = array[j];
                        array[j] = array[j+1];
                        array[j+1] = temp;
                    }
                }
            }
        }

        public static void SelectSort()
        {
            int[] array = new int[10] { 5, 4, 35, 48, 22, 16, 34, 10, 77, 100 };
            int temp = default(int);
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
