using System;
using System.Collections.Generic;
using System.Text;

namespace Libraries.TreesDataModel
{
    /// <summary>
    /// This Class Represent a Binary Search Tree where the Values of it nodes are of type T 
    /// Definition : Every Node contains a key of type T which is greater than all the keys in it's left subtree 
    /// and smaller than all the keys in it's right subtree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T>
    {
        public Node<T> Root { get; private set; }
        
        public BinarySearchTree(Node<T> node)
        {
            Root = node; 
        }

        
    }
}
