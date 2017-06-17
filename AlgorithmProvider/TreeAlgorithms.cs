using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsProvider
{
    public class TNode
    {
        public int Data;
        public TNode Left;
        public TNode Right;

        public TNode() { }
        public TNode(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
        public TNode(int data, int level)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    public class TreeAlgorithms
    {
        public static int HeightOfTree(TNode node)
        {
            if (node == null)
                return -1;

            var hLeft = HeightOfTree(node.Left);
            var hRight = HeightOfTree(node.Right);
            return ((hLeft > hRight) ? hLeft : hRight) + 1;
        }
       
        public static int GetDistance(TNode root, int value)
        {
            if (root == null)
                return -1;

            if (root.Data == value)
                return 0;

            int lHeight = GetDistance(root.Left, value);
            int rHeight = GetDistance(root.Right, value);


            if (lHeight == -1 && rHeight == -1)
                return -1;

            return ((lHeight > rHeight) ? lHeight : rHeight) + 1;
        }


        public static void InOrderTraversal(TNode node)
        {
            if (node == null)
                return;
            InOrderTraversal(node.Left);
            System.Console.WriteLine(node.Data);
            InOrderTraversal(node.Right);
        }
       
        public static TNode LeastCommonAncestry(TNode root, int v1, int v2)
        {
            if (root == null)
                return root;

            if (v1 < root.Data && v2 < root.Data)
            {
                root = LeastCommonAncestry(root.Left, v1, v2);
            }
            else if (v1 > root.Data && v2 > root.Data)
            {
                root = LeastCommonAncestry(root.Right, v1, v2);
            }

            return root;
        }

        public static void LevelOrderTraversalToLinkList(TNode node)
        {
            if (node == null)
                return;

            Queue<TNode> q = new Queue<TNode>();
            q.Enqueue(node);
            while (q.Count() > 0)
            {
                var length = q.Count();
                while (length > 0)
                {
                    var cur = q.Dequeue();

                  //  InsertAtHead(cur.Data, level);
                    if (cur.Left != null)
                        q.Enqueue(cur.Left);
                    if (cur.Right != null)
                        q.Enqueue(cur.Right);

                    length--;
                }
            }
        }

        /// <summary>
        /// Finds the distance.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <param name="n1">The n1.</param>
        /// <param name="n2">The n2.</param>
        /// <returns></returns>
        public static int findDistanceBetweenTwoNodes(TNode root, int n1, int n2)
        {
            int x = GetDistance(root, n1);
            int y = GetDistance(root, n2);
            int lcaData = LeastCommonAncestry(root, n1, n2).Data;
            int lcaDistance = Pathlength(root, lcaData);
            return (x + y) - 2 * lcaDistance;
        }

        private static int Pathlength(TNode root, int lcaData)
        {
            throw new NotImplementedException();
        }


      

   
    }
}
