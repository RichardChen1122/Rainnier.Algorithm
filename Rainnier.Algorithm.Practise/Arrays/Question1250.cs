using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.Practise.Strings
{
    //给你一个正整数数组 nums，你需要从中任选一些子集，然后将子集中每一个数乘以一个 任意整数，并求出他们的和。

    //假如该和结果为 1，那么原数组就是一个「好数组」，则返回 True；否则请返回 False。

 

    //示例 1：

    //输入：nums = [12,5,7,23]
    //    输出：true
    //解释：挑选数字 5 和 7。
    //5*3 + 7* (-2) = 1
    //示例 2：

    //输入：nums = [29,6,10]
    //    输出：true
    //解释：挑选数字 29, 6 和 10。
    //29*1 + 6* (-3) + 10* (-1) = 1
    //示例 3：

    //输入：nums = [3,6]
    //    输出：false

    public class Question1250
    {
        //这个数组有元素互质的子数组（最大公约数为1） 那么就是好数组
        //那么就是是任选数组里两个元素，这两个数最大公约数是1 那么就是好数组

        //我的做法
        public bool IsGoodArray(int[] nums)
        {
            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = i+1; j < nums.Length; j++)
                {
                    if(check(nums[i], nums[j]) == 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        //获取两数的最大公约数
        private int check(int v1, int v2)
        {
            if (v1 < v2)
            {
                //交换两个数
                v1 = v1 + v2;
                v2 = v1 - v2;
                v1 = v1 - v2;
            }

            return (v1 % v2 == 0) ? v2 : check(v1 % v2, v2);
        }

        //大神做法
        public bool isGoodArray(int[] nums)
        {
            int dd = nums[0];
            for (int i = 0; i < nums.Length; i++)
                dd = gcd(dd, nums[i]);
            return dd == 1;
        }


        private int gcd(int m, int n)
        {
            return m % n == 0 ? n : gcd(n, m % n);
        }
    }
}
