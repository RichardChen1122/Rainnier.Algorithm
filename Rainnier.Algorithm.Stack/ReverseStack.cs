using Rainnier.Algorithm.Stack.LinkList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.Algorithm.Stack
{
    //需求是不用任何其他的数据结构,完成一个stack 的倒转
    //这两个方法应该能一次写成，没有bug
    public class ReverseStack
    {
        public void Reverse(MyLinkStack<int> myLinkStack)
        {
            if (myLinkStack.IsEmpty())
            {
                return;
            }

            int last = getAndRemoveLastItem(myLinkStack);
            
                Reverse(myLinkStack);

            myLinkStack.Push(last);
        }

        public int getAndRemoveLastItem(MyLinkStack<int> stack)
        {
            int last = stack.Pop();
            if (stack.IsEmpty())
            {
                return last;
            }

            int result = getAndRemoveLastItem(stack);

            stack.Push(last);

            return result;           
        }
    }
}
