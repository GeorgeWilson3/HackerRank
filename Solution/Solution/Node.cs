using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    class Node
    {
        public Node left, right;
        public int data;

        public Node(int data)
        {
            this.data = data;
            left = right = null;
        }

        //public Node left, right;
        //public int data;
        //public Node(int data)
        //{
        //    this.data = data;
        //    left = right = null;
        //}
        //public int data;
        //public Node next;
        //public Node(int d)
        //{
        //    data = d;
        //    next = null;
        //}


    }
}
