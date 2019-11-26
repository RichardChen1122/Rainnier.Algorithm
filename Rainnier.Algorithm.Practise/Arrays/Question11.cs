using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.Practise.Arrays
{
    public class Question11
    {
        public int MaxArea(int[] height)
        {
            if (height == null || height.Length < 2)
            {
                return 0;
            }
            int max = 0;
            for (int i = 0; i < height.Length - 1; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    int area = (j - i) * Math.Min(height[i], height[j]);
                    max = Math.Max(max, area);
                }
            }

            return max;
        }
    }
}
