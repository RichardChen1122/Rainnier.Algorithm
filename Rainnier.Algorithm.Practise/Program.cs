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


            var y = new Question11();

            var input = new int[9] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };

            Console.Write(y.MaxArea(input));

            
            Console.ReadKey();
        }
    }
}
