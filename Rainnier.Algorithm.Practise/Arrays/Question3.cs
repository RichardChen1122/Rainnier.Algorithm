using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.Practise.Arrays
{
    public class Question3
    {
        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> charPosition = new Dictionary<char, int>();
            int left = -1;
            int max = 0;
            for(int i = 0; i < s.Length; i++)
            {

                if (!charPosition.ContainsKey(s[i]))
                {
                    charPosition.Add(s[i], i);
                }
                else
                {
                    if (charPosition[s[i]] > left)
                    {
                        left = charPosition[s[i]];
                    }
                    charPosition[s[i]] = i;
                    
                }
                max = Math.Max(max, i - left);
            }

            return max;
        }
    }
}
