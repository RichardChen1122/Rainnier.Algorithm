using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.Practise.Arrays
{
    //给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。

    //示例 1：

    //输入: "babad"
    //输出: "bab"
    //注意: "aba" 也是一个有效答案。
    //示例 2：

    //输入: "cbbd"
    //输出: "bb"

    public class Question5
    {
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            string s2 = string.Empty;
            int max = 0;
            int maxPosition = -1;
            for(int i = s.Length - 1; i >= 0; i--)
            {
                s2 += s[i];
            }

            int[,] dp = new int[s.Length+1, s.Length+1];

            for(int i=0;i<= s.Length; i++)
            {
                dp[0, i] = 0;
            }
            for (int i = 0; i <= s.Length; i++)
            {
                dp[i,0] = 0;
            }

            for (int i=1; i<= s.Length; i++)
            {
                for(int j = 1; j <= s.Length; j++)
                {
                    if (s2[i-1] == s[j-1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                        if (dp[i, j] > max)
                        {
                            int beforeRev = s.Length - j;
                            //********关键的判断********
                            if (beforeRev + dp[i, j] == i)
                            {
                                max = dp[i, j];
                                maxPosition = j;
                            }
                        }
                    }
                    else
                    {
                        dp[i, j] = 0;
                    }

                }
            }

            string result = string.Empty;
            while (max > 0)
            {
                result += s[--maxPosition];
                max--;
            }

            return result;
        }
    }
}
