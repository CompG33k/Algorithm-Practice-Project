using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsProvider
{
    public class Node
        {
            public int Level;
            public int Data;
            public Node Prev;
            public Node Next;

            public Node() { }
            public Node(int data)
            {
                Level = 0;
                Data = data;
                Prev = null;
                Next = null;
            }
            public Node(int data, int level)
            {
                Level = level;
                Data = data;
                Prev = null;
                Next = null;
            }
        }

       

    public class LinkedListAlgorithms
    {
        public static Node Head;
        public static Node Tail;
        public static Node Insert(Node head, int data)
        {
            if (head == null)
            {
                Node newNode = new Node(data);

                head = new Node();
                head.Next = newNode;
                return newNode;
            }

            var tail = Insert(head.Next, data);

            return null;

        }

        public static Node InsertAtHead(int data, int level)
        {
            Node newNode = new Node(data,level);
            
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Head.Prev = newNode;
                newNode.Next = Head;
                Head = newNode;
            }
                return newNode;
        }
        
        public static void DisplayDoublyLinkedList(Node node)
        {
            if (node == null)
                return;
            System.Console.WriteLine(string.Format("Level: {0}  Node: {1} ",node.Level,node.Data));
            DisplayDoublyLinkedList(node.Next);
        }


    }
}
