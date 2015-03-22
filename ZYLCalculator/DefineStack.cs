using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZYLCalculator;

namespace Utils
{
    /**
     * 用链表来构造自定义栈
     */
    class DefineStack
    {
        private Stack<Object> stack = new Stack<Object>();
        public int top = -1;

        public void push(Object obj)
        {
            top++;
            stack.Push(obj);
        }

        public Object pop()
        {
            if (stack.Count == 0)
            {
                return null;
            }
            else
            {
                Object obj = stack.Peek();
                top--;
                stack.Pop();
                return obj;
            }
        }
        
        public Object getTop()
        {
            Object obj = stack.Peek();
            return obj;
        }
    }
}
