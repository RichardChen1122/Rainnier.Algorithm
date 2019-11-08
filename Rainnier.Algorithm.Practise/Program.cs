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
            var q = new Question70();
            Console.Write(q.ClimbStairs(5));

            Console.ReadKey();
        }
    }
}
