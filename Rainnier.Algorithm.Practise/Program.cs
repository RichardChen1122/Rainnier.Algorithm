using Rainnier.Algorithm.Practise.Arrays;
using Rainnier.Algorithm.Practise.DP;
using Rainnier.Algorithm.Practise.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.Practise
{
    class Program
    {
        static void Main(string[] args)
        {
            //var q = new Question3();
            //Console.Write(q.LengthOfLongestSubstring("abcabcbb"));
            //Console.Write(q.LengthOfLongestSubstring("bbbbb"));
            //Console.Write(q.LengthOfLongestSubstring("pwwkew"));


            var y = new Question5();

            Console.Write(y.LongestPalindrome("aacdefcaa"));

            
            Console.ReadKey();
        }
    }
}
