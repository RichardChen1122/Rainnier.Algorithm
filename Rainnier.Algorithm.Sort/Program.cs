using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            //CodeTimer.Initialize();
            //CodeTimer.Time("Bubble", 1000000, ()=>RegularSort.BubbleSort());
            //int[] array = new int[10] { 5, 4, 35, 48, 22, 16, 34, 10, 77, 100 };

            //RegularSort.BubbleSort();
            TestMethod();


            Console.ReadKey();
        }

        static void TestMethod()
        {
            //int[] array = new int[10] { 10,9,8,7,6,5,4,3,2,1};
            int[] array = new int[10] { 5, 4, 35, 48, 22, 16, 34, 10, 77, 100 };
            //QuickSort.QuickSortMethod(array, 0, 9);
            MergeSort.SortMethod(array, 0, 9);

            foreach(var a in array)
            {
                Console.WriteLine(a);
            }
        }
    }
}
