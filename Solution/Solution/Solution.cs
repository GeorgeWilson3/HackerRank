using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    class Solution
    {
        Stack<char> stack = new Stack<char>();
        Queue<char> queue = new Queue<char>();

        public void pushCharacter(char ch)
        {
            stack.Push(ch);
        }

        public void enqueueCharacter(char ch)
        {
            queue.Enqueue(ch);
        }

        public char popCharacter()
        {
            return stack.Pop();
        }

        public char dequeueCharacter()
        {
            return queue.Dequeue();
        }
    }
}
