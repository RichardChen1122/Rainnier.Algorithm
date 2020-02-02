using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainier.DynamicPlanning.Coins
{
    //给出一个数组arr， 里面的元素为所有的面值， 给出aim，给出获取aim 面值的最少张数

    //如 arr=[5,2,3], aim =15, return = 3, 三张5元是最低张数
    public class CoinAim
    {
        public static int MinCoinCount(int[] arr, int aim)
        {
            var max = int.MaxValue-1;
            int[,] dp = new int[arr.Length, aim + 1];
            
            for(int i = 0; i < arr.Length; i++)
            {
                dp[i, 0] = 0;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1; j <= aim; j++)
                {
                    int compare = i == 0 ? max : dp[i - 1, j];
                    if (j - arr[i] < 0)
                    {
                        dp[i, j] = compare;
                    }
                    else
                    {
                        dp[i, j] = Math.Min(compare, dp[i, j - arr[i]] + 1);
                    }
                }
            }

            return dp[arr.Length-1,aim];
        }
    }
}
