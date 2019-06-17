using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainier.DynamicPlanning
{
    //最长公共子序列
    public class LCS
    {
        public int[,] getDp(char[] array1, char[] array2)
        {
            int n = array1.Length;
            int m = array2.Length;

            int[,] dp = new int[n, m];

            int longest = default(int);
            for (int i = 0; i < n; i++)
            {
                if (array1[i] == array2[0])
                {
                    dp[i, 0] = 1;
                    longest = dp[i, 0];
                }
                else
                {
                    dp[i, 0] = longest;
                }
            }

            for (int i = 0; i < m; i++)
            {
                //和上面的方法是一个意思
                dp[0, i] = Math.Max(dp[0, i], array1[0] == array2[i] ? 1 : 0);
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (array2[j] == array1[i])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    //else if (j > i)
                    //{
                    //    dp[i, j] = dp[i, j - 1];
                    //}
                    //else if (j < i)
                    //{
                    //    dp[i, j] = dp[i - 1, j];
                    //}
                    else
                    {
                        //关键点在这里
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp;
        }

        public char[] getLCSArray(char[] array1, char[] array2, int[,] dp)
        {
            int n = array1.Length;
            int m = array2.Length;
            int maxLength = dp[n - 1, m - 1];
            char[] result = new char[maxLength];
            int i = n - 1;
            int j = m - 1;
            while (i >= 0 && j >= 0)
            {

                if (array1[i] != array2[j])
                {
                    if (dp[i - 1, j] == maxLength)
                    {
                        i--;
                        continue;
                    }
                    if (dp[i, j - 1] == maxLength)
                    {
                        j--;
                        continue;
                    }
                }
                else
                {
                    result[--maxLength] = array1[i];
                    i--;
                    j--;
                    
                }

            }

            return result;
        }
    }
}
