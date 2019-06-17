using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainier.DynamicPlanning
{
    public class FeiBoNaQiShuLie
    {
        //时间复杂度是2的n次方
        public static int k = 0;
        public static int getItemRecusive(int n)
        {
            k++;
            int item = default(int);
            if (n <= 2)
            {
                item = 1;
            }
            if (n >= 3)
            {
                item = getItemRecusive(n - 1) + getItemRecusive(n - 2);
            }

            return item;
        }

        public static int getItem(int n)
        {
            int item = default(int);
            if (n <= 2)
            {
                item = 1;
                return item;
            }
            int previous = 1;
            int result = 1;
            int temp = 0;
            for(int i = 3; i <= n; i++)
            {
                temp = result;
                result = previous + result;
                previous = temp;
            }

            return result;
        }
    }
}
