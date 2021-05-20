using System;
using System.Collections.Generic;
using System.Text;

namespace Libraries.TreesDataModel
{
    public class Node<T>
    {
        public T Val { get; private set; }

        public Node<T> Right { get; private set; }

        public Node<T> Left { get; private set; }

        public Node(T val, Node<T> left, Node<T> right){
            Val = val;
            Right = right;
            Left = left; 
        }
        

    }
}
