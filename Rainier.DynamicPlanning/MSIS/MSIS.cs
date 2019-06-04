using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainier.DynamicPlanning
{
    //最长的递增子序列
    public class MSIS
    {
        public int[] getdp(int[] array)
        {
            var len = array.Length;
            var dp = new int[len];
            dp[0] = 1;
            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] < array[i])
                    {
                        if (dp[i] < dp[j] + 1)
                        {
                            dp[i] = dp[j] + 1;
                        }
                    }

                }
            }

            return dp;
        }

        public List<int> getMaxPosition(int[] dp)
        {
            List<int> result = new List<int>();
            int max = dp[0];
            result.Add(0);
            for(int i = 1; i < dp.Length; i++)
            {
                if (dp[i] == max)
                {
                    result.Add(i);
                }
                if (dp[i] > max)
                {
                    result.Clear();
                    max = dp[i];
                    result.Add(i);
                }
            }

            return result;
        }

        public List<int> maxSubIncreaseArray(int[] array)
        {
            var len = array.Length;
            var list = new int[len];
            List<List<int>> result = new List<List<int>>();
            var temp = new List<int>();
            int index = -1;//用于标记当前元素之前的第一个递增子序列的位置
            int maxIndex = 0;//用于标记该序列的最长递增子序列的位置
            int max = default(int);//最长递增子序列的长度
            list[0] = 1;//该列表用于标记包括当前元素在内的前半部分的最长递增子序列的长度
            temp.Add(array[0]);
            result.Add(temp);
            for (int i = 1; i < len; i++)
            {
                index = -1;
                temp = new List<int>();
                for (int j = 0; j < i; j++)
                {
                    if (array[j] < array[i])
                    {
                        if (list[i] < list[j] + 1)
                        {
                            list[i] = list[j] + 1;
                            index = j;
                        }
                    }

                }
                if (index > -1)
                {
                    temp.AddRange(result[index]);
                }
                temp.Add(array[i]);
                result.Add(temp);
                if (list[i] > max)
                {
                    max = list[i];
                    maxIndex = i;
                }
            }
            return result[maxIndex];
        }
    }
}
