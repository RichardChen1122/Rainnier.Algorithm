using Rainier.DynamicPlanning.Coins;
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
            int[] arr = new int[3] { 5,2,1};
            int[] arr2 = new int[9] { 7, 3, 2, 1, 5, 4, 10, 6, 7 };
            int[] arr3 = new int[10] { 7, 3, 1, 5, 6, 7, 4, 10, 6, 7 };
            int[] arr4 = new int[10] { 1, 2, 4, 2, 5, 7, 2, 4, 9, 0 };
            int[] arr5 = new int[11] { 1, 2, 4, 2, 5, 7, 2, 4, 9, 0, 4 };
            int aim = 16;
            Console.WriteLine(FeiBoNaQiShuLie.getItemRecusive(24));
            Console.WriteLine(CoinAim.MinCoinCount(arr,aim));
            Console.WriteLine(GreatestPointOfBuySaleStock.MaxIncome(arr2));
            Console.WriteLine(GreatestPointOfBuySaleStock.MaxIncome2(arr2));
            Console.WriteLine(GreatestPointOfBuySaleStock.MaxIncome3(arr4));
            Console.WriteLine(GreatestPointOfBuySaleStock.MaxIncome5(arr5));
            Console.WriteLine(GreatestPointOfBuySaleStock.MaxIncome5(new int[3] { 5, 2, 1 }));
            Console.WriteLine(GreatestPointOfBuySaleStock.MaxIncome5(new int[1] { 1 }));
            Console.WriteLine(GreatestPointOfBuySaleStock.MaxIncome5(new int[2] { 1,2 }));
            Console.WriteLine(GreatestPointOfBuySaleStock.MaxIncome5(new int[4] { 1, 2,1,5 }));
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
