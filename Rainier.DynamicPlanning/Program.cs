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
            int[] array = new int[16] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 };
            var msis = new MSIS();
            var test = msis.getdp(array);
            var positions = msis.getMaxPosition(test);
            var maxIS = msis.maxSubIncreaseArray(array);
            Console.ReadKey();
        }
    }
}
