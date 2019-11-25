using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.Practise.Arrays
{
    public class Question1
    {
        public int[] TwoSum(int[] nums, int target)
        {
            if (nums == null || nums.Length < 2)
            {
                return null;
            }
            for(int i = 0; i < nums.Length; i++)
            {
                for(int j= i+1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[2] { i, j };
                    }
                }
            }

            return null;
        }
    }
}
