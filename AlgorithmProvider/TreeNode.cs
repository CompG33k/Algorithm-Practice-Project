using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsProvider
{
    
        public class BinarySearchTree
        {
            public TNode Root;
            public BinarySearchTree(int data)
            {
                Root = new TNode(data);
            }

            static int preIndex = 0;
            public static TNode BuildTree(int[] inOrder, int[] preOrder, int inOrderStart, int inOrderEnd)
            {
                
                if(inOrderStart > inOrderEnd)
                    return null;
                TNode node = new TNode(preOrder[preIndex++]);

                int inOrderIndex = GetInOrderIndex(inOrder,inOrderStart,inOrderEnd,node.Data);
                node.Left = BuildTree(inOrder,preOrder,inOrderStart,inOrderIndex-1);
                node.Right = BuildTree(inOrder,preOrder,inOrderIndex+1,inOrderEnd);

                return node;
            }

            private static int GetInOrderIndex(int[] inOrder, int inOrderStart, int inOrderEnd, int value)
            {
                int i = inOrderStart;
                for (; i < inOrderEnd; i++)
                    if (inOrder[i] == value)
                        return i;

                return i; // something went wrong
            }

            public TNode Insert(TNode root, int value)
            {
                TNode n = new TNode(value);
                if (root == null)
                {
                    root = new TNode(value);
                    return root;
                }

                TNode cur = root;
                while (cur != null)
                {
                    if (cur.Data < value)
                    {
                        if (cur.Left == null)
                        {

                            cur.Left = n;
                            return root;
                        }
                        else
                            cur = cur.Left;

                    }
                    else
                        if (cur.Data > value)
                        {

                            if (cur.Right == null)
                            {
                                cur.Right = n;
                                return root;
                            }
                            else
                                cur = cur.Right;
                        }
                        else
                            break;
                }

                return root;
            }

            public void Insert(int data)
            {
                if (Root == null)
                {
                    Root = new TNode(data);
                }
                else
                {
                    Insert(data, Root);
                }
            }

            private void Insert(int data, TNode node)
            {
                if (node == null)
                {
                    node = new TNode(data);
                }
                else if (data < node.Data)
                {
                    if (node.Left == null)
                    {
                        node.Left = new TNode(data);
                    }
                    else
                    {
                        Insert(data, node.Left);
                    }
                }
                else if (data > node.Data)
                {
                    if (node.Right == null)
                    {
                        node.Right = new TNode(data);
                    }
                    else
                    {
                        Insert(data, node.Right);
                    }
                }
            }


        }
}
