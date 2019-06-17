using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainier.DynamicPlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FeiBoNaQiShuLie.getItemRecusive(24));
            Console.WriteLine(FeiBoNaQiShuLie.k);
            Console.ReadKey();
            //int[] array = new int[16] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 };
            //var msis = new MSIS();
            //var test = msis.getdp(array);
            //var positions = msis.getMaxPosition(test);
            //var maxIS = msis.maxSubIncreaseArray(array);
            //var maxIS2 = msis.maxSubIncreaseArray(array, test);
            

            //char[] arr1 = new char[8] { '1', 'C', 'D', 'A', '1', 'C', '2', 'F' };
            //char[] arr2 = new char[10] { '1', 'C', 'B', 'D', 'A', '2', 'F', 'K', 'D', 'A' };
            //var lcs = new LCS();
            //var lcsDP = lcs.getDp(arr1, arr2);
            //char[] result = lcs.getLCSArray(arr1, arr2, lcsDP);
            //foreach(var a in result)
            //{
            //    Console.Write(a);
            //}
            //Console.ReadKey();
        }
    }
}
