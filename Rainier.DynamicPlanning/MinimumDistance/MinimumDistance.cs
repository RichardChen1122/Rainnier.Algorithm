
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainier.DynamicPlanning.MinimumDistance
{
    public class MinimumDistance
    {
        public static int Shortest(int[,] map, int n, int m)
        {
            int[,] dp = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    dp[i, 0] += dp[j, 0];
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    dp[0, i] += dp[0, j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dp[i, j] = min(dp[i - 1, j], dp[i, j - 1]) + map[i, j];
                }
            }
            return dp[n - 1, m - 1];

        }

        public static int min(int a, int b)
        {
            int result = a > b ? b : a;
            return result;
        }
    }
}
