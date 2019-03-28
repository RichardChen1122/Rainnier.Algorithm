using Rainnier.Algorithm.Stack.LinkList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.Stack
{
    class Program
    {
        static void Main(string[] args)
        {

            float x = 100.1f;

            double y = 100.1d;

            decimal z = 100.1m;

            Console.WriteLine("X:" + x + " Y:" + y + " Z:" + z);//X:100.1 Y:100.1 Z:100.1

            Console.WriteLine("Double X:" + (double)x + " Float Y:" + (float)y + " Double Z:" + (double)z + " Float Z:" + (float)z);//Double X:100.099998474121 Float Y:100.1 Double Z:100.1 Float Z:100.1

            Console.WriteLine("Float To Double To Float: " + (float)((double)x));//Float To Double To Float: 100.1

            Console.WriteLine("Double To Float To Double: " + (double)((float)y)); //Double To Float To Double: 100.099998474121

            Console.WriteLine("(Decimal)Float Equals (Decimal)Double: " + ((decimal)x == (decimal)y));//(Decimal)Float Equals (Decimal)Double: True

            Console.WriteLine("(Double)Decimal Equals (Float)Decimal: " + ((double)z == (float)z));//(Double)Decimal Equals (Float)Decimal: False

            Console.WriteLine("Double Equals Float: " + (x == y));//Double Equals Float: False

            Console.WriteLine("Double Equals Float Transfer: " + ((double)x == y));//Double Equals Float Transfer: False

            Console.WriteLine("Float Equals Double Transfer: " + (x == (float)y));//Double Equals Float Transfer: True

            Console.WriteLine("Float Equals Decimal Transfer: " + (x == (float)z));//Float Equals Decimal Transfer: True

            Console.WriteLine("Double Equals Decimal Transfer: " + (y == (double)z));//Double Equals Decimal Transfer: True

            var a = 100.111d * x;

            var b = 100.111d * y;

            var c = 100.111m * z;

            var d = 100.111f * x;

            var e = 100.111f * x;

            Console.WriteLine("A:" + a + " B:" + b + " C:" + c + " D:" + d + " E:" + e);//A:10021.1109472427 B:10021.1111 C:10021.1111 D:10021.11 E:10021.11

            Console.WriteLine("Double*Float Equals Double*Double: " + (a == b));//Double*Float Equals Double*Double:  False

            //Console.WriteLine("Double*Double Equals Double*Double: " + (b == c));//Double*Double Equals Double*Double: True

            Console.WriteLine("Float*Float Equals Float*Float: " + (e == d));//Float*Float Equals Float*Float: True

            Console.WriteLine("Double*Double Equals Float*Float: " + (b == d));//Double*Double Equals Float*Float: False

            Console.ReadKey();
            //var stack = new MyLinkStack<char>();
            //var left = new char[3] { '(', '[', '{' };
            //var right = new char[3] { ')', ']', '}' };

            //string test = "[({)]}";

            //char[] testArray = test.ToArray<char>();

            //foreach (var item in testArray)
            //{

            //    if (IsInArray(item, left))
            //    {
            //        stack.Push(item);
            //    }
            //    if (item == ')')
            //    {
            //        if (!stack.IsEmpty() && stack.Peek() == '(')
            //        {
            //            stack.Pop();
            //        }
            //        else
            //        {
            //            Console.Write("Not good string");
            //            return;
            //        }
            //    }
            //    if (item == '}')
            //    {
            //        if (!stack.IsEmpty() && stack.Peek() == '{')
            //        {
            //            stack.Pop();
            //        }
            //        else
            //        {
            //            Console.Write("Not good string");
            //            return;
            //        }
            //    }

            //    if (item == ']')
            //    {
            //        if (!stack.IsEmpty() && stack.Peek() == '[')
            //        {
            //            stack.Pop();
            //        }
            //        else
            //        {
            //            Console.Write("Not good string");
            //            return;
            //        }
            //    }
            //}
            //if (stack.IsEmpty())
            //{
            //    Console.Write("good String");
            //}
            //else
            //{
            //    Console.Write("Not good String");

            //}
            //Console.ReadKey();
        }

        static bool IsInArray(char item, char[] array)
        {
            int i = 0;
            bool result = false;
            while (i < array.Length)
            {
                if (item == array[i])
                {
                    result = true;
                    break;
                }

                i++;
            }

            return result;
        }
    }
}
