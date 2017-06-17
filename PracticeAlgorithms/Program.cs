using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AlgorithmsProvider;

namespace PracticeAlgorithms
{
        class Program
        { 
        public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
                return null;

            var head = new ListNode(((l1.val + l2.val) % 10));
            l1 = l1.next; l2 = l2.next;
            var cur = head;
            bool overFlow = false;
            while (l1 != null && l2 != null)
            {
                int number = l1.val + l2.val;
                if (number == 10)
                {
                    overFlow = true;
                    cur.next = new ListNode(number % 10);
                }else
                if (overFlow)
                {
                    cur.next = new ListNode((number % 10) + 1);
                    overFlow = false;
                }
                   
                cur = cur.next; l1 = l1.next; l2 = l2.next;
            }
            return head;

        }
            public static IList<IList<int>> LevelOrder(TNode root)
            {

                if (root == null)
                    return null;

                Queue<TNode> q = new Queue<TNode>();
                IList<IList<int>> l = new List<IList<int>>();
                while (q.Count() > 0)
                {
                    var len = q.Count();
                    IList<int> innerL = new List<int>();
                    while (len > 0)
                    {
                        var cur = q.Dequeue();
                        innerL.Add(cur.Data);
                        if (cur.Left != null)
                            q.Enqueue(cur.Left);
                        if (cur.Right != null)
                            q.Enqueue(cur.Right);
                        len--;
                    }
                    l.Add(innerL);
                }

                return l;
            }
        
        static void Main(String[] args)
        {
            try
            {
             //   var s = string.Split("");
               // Regex.Split(source, @"(?<!^)(?=[A-Z])");
              //  Console.ReadLine();
                //var buff = Regex.Matches(input, @"(.)\1");
                SortingAlgorithms.QuickSortMethod();
                BinarySearchTree b = new BinarySearchTree(8);
                b.Insert(4);
                b.Insert(9);
                b.Insert(1);
                b.Insert(2);
                b.Insert(3);
                b.Insert(6);
                b.Insert(5);
                var list = LevelOrder(b.Root);
                
                var lcaNode = TreeAlgorithms.LeastCommonAncestry(b.Root, 1, 2);
                var Distance = TreeAlgorithms.GetDistance(b.Root, 3);
                System.Console.WriteLine(string.Format("LCA : {0}\nDistance: {1}",lcaNode.Data, Distance));
                System.Console.ReadLine();

                int[] inOrder = { 4, 2, 5, 1, 3};
                int[] preOrder = {1, 2, 4, 5, 3};
                int len = inOrder.Count() -1;
                var tree = BinarySearchTree.BuildTree(inOrder, preOrder, 0, len);

                Display(tree);
                System.Console.WriteLine("Press any key...");
                var name = System.Console.ReadLine();
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.Message + ex.StackTrace);
                System.Console.WriteLine("Press any key...");
                var name = System.Console.ReadLine();
            }
        }

        static void Display(TNode root)
        {
            if (root == null)
                return;
            Display(root.Left);
            System.Console.WriteLine(root.Data);
            Display(root.Right);
        }

        



        //static int preOrderIndex = 0;
        //static Node BuildTree(int[] preOrderList, int[] inOrderList, int inOrderStartIndex, int inOrderEndIndex)
        //{
        //    if (inOrderStartIndex > inOrderEndIndex)
        //        return null;
        //    Node cur = new Node(preOrderList[preOrderIndex++]);

        //    if (inOrderStartIndex == inOrderEndIndex)
        //        return cur;

        //    var inOrderIndex = GetInOrderIndex(inOrderList, inOrderStartIndex, inOrderEndIndex,cur.Data);

        //    cur.Left = BuildTree(preOrderList, inOrderList, inOrderStartIndex, inOrderIndex - 1);
        //    cur.Right = BuildTree(preOrderList, inOrderList, inOrderIndex + 1, inOrderEndIndex);

        //    return cur;
        //}

        //static int GetInOrderIndex(int[] inOrderList, int start, int end, int value)
        //{
        //    for (int i = start; i < inOrderList.Count(); i++)
        //    {
        //        if (inOrderList[i] == value)
        //            return i;
        //    }
        //    return -1; // something went wrong
        //}

        public static void BFS(TNode node)
        {
            if (node == null)
                return;

            Queue<TNode> q = new Queue<TNode>();
            q.Enqueue(node);
            while(q.Count() > 0)
            {
                var len = q.Count();
                while(len > 0)
                {
                    var cur = q.Dequeue();
                    if(cur.Left != null)
                        q.Enqueue(cur.Left);
                    if(cur.Right != null)
                        q.Enqueue(cur.Right);

                    len--;
                }
            }
        }



        
    }
}
