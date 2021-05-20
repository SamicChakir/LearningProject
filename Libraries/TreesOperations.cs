using Libraries.TreesDataModel;
using System;
using System.Collections.Generic;
using System.Text;


namespace Libraries
{
    public static class TreesOperations
    {
        public static void Insert(this BinarySearchTree<int> tree, int val)
        {

        }

        public static Node<int> Search(this BinarySearchTree<int> tree, int val)
        {
            var cur_node = tree.Root;
            while ( cur_node != null)
            {
                if ( cur_node.Val == val)
                {
                    return cur_node;
                }
                else if (val < cur_node.Val )
                {
                    cur_node = cur_node.Left;
                }
                else
                {
                    cur_node = cur_node.Right;
                }
            }

            return cur_node;
        }

        public static BinarySearchTree<int> Delete(this BinarySearchTree<int> tree, int val)
        {
            var nodeToDelete = tree.Search(val);
            if (nodeToDelete != null)
            {
                if ( nodeToDelete.Left != null)
                {
                    var parent = nodeToDelete;
                    var cur_node = nodeToDelete.Left;
                    while(cur_node.Right != null)
                    {
                        parent = cur_node;
                        cur_node = cur_node.Right;
                    }
                    nodeToDelete = new Node<int>(cur_node.Val, nodeToDelete.Right, nodeToDelete.Left);
                    parent = new Node<int>(parent.Val,null,parent.Left);

                    return tree;
                }
                else if ( nodeToDelete.Right != null)
                {
                    var parent = nodeToDelete;
                    var cur_node = nodeToDelete.Right;
                    while (cur_node.Left != null)
                    {
                        parent = cur_node;
                        cur_node = cur_node.Left;
                    }
                    nodeToDelete = new Node<int>(cur_node.Val, nodeToDelete.Right, nodeToDelete.Left);
                    parent = new Node<int>(parent.Val, parent.Right,null);

                    return tree;
                }
                else
                {
                    nodeToDelete = null;
                }
            }
            return tree;

        }

        public static BinarySearchTree<int> TreeFromString(string s)
        {
            int end = 0;
            return new BinarySearchTree<int>(NodeFromIndex(s, 0, ref end));
        }

        public static Node<int> NodeFromIndex(string s, int start,ref int end)
        {
            var openParanthesesCount = 1;
            
            var index = start;
            var cur_value = "";
            if ( s[index] == '(')
            {
                index += 1;
            }
            while(s[index] != '(' && s[index] != ')')
            {
                cur_value += s[index];
                index += 1;
            }
            
            if (s[index] == ')')//Leaf node detected
            {
                if (string.IsNullOrEmpty(cur_value))
                {
                    end = index + 1;
                    return null;
                }
                end = index+1; 
                return new Node<int>(int.Parse(cur_value), null, null);

            }
            else
            {
                var left = NodeFromIndex(s, index + 1, ref end);
                var newStart = end;
                var right = NodeFromIndex(s, newStart, ref end);
                end += 1; 
                return new Node<int>(int.Parse(cur_value), left, right);
            }


            
        }
       
    }
}
