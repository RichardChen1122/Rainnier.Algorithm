using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainier.DynamicPlanning
{
    class GreatestPointOfBuySaleStock
    {
        //给定一个整形数组，其中的第i个元素代表股票第i天的价格。在一开始，你手里有足够的钱，但没有股票。
        //你仅有一次买股票和一次卖股票的机会（每次只能买/卖1股），或者不买不卖。输出你可能的最大盈利值。
        //尽量降低程序的时间复杂度.

        //[7, 1, 5, 3, 6, 4]，在价格为1的时候买入，在价格为6的时候卖出，可以得到最大盈利值为5。（5 = 6 - 1）
        public static int MaxIncome(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return 0;
            }
            int local = 0;
            int global = 0; 

            for(int i = 0; i < arr.Length-1; i++)
            {
                local = Math.Max(local + arr[i + 1] - arr[i], 0);
                global = Math.Max(local, global);
            }

            return global;
        }

        //可以买卖很多次，并且每次必须卖掉所有存量
        public static int MaxIncome2(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return 0;
            }
            int local = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                local +=Math.Max( arr[i + 1] - arr[i], 0);
            }

            return local;
        }

        //最多可以买卖2次，并且每次必须卖掉所有存量
        public static int MaxIncome3(int[] prices)
        {
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }
            int[] dp = new int[prices.Length];
            dp[0] = 0;
            int local = 0;

            for(int i = 0; i < prices.Length-1; i++)
            {
                if (dp[i] != 0 && ((prices[i + 1] - prices[i]) > 0))
                {
                    dp[i + 1] = dp[i] + prices[i + 1] - prices[i];
                    dp[i] = 0;
                }
                else
                {
                    dp[i + 1] = Math.Max(prices[i + 1] - prices[i], 0);
                }
            }

            int max = 0;
            int secondmax = 0;

            for(int i = 0; i < prices.Length; i++)
            {
                if (dp[i] >= max)
                {
                    secondmax = max;
                    max = dp[i];
                }
                else if(dp[i]<max && dp[i]>secondmax)
                {
                    secondmax = dp[i];
                }
            }

            return max + secondmax;
        }
    }
}
