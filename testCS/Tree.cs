using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace testCS
{
    public class Node
    {
        public Node left;
        public Node right;
        public int value;

        public Node(int value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }
    }

    public class Tree
    {
        public Node root;
        int size;

        public Tree()
        {
            root = null;
            size = 0;
        }

        public Tree(int startValue)
        {
            root = new Node(startValue);
            size = 1;
        }

        public void Add(int input)
        {
            Node current = root;

            while(current!=null && current.value != input)
            {
                if (current.value > input && current.left == null)
                {
                    current.left = new Node(input);
                    ++size;
                    return;
                }

                if (current.value <= input && current.right == null)
                {
                    current.right = new Node(input);
                    ++size;
                    return;
                }

                if (current.value > input)
                    current = current.left;
                else
                    current = current.right;
            }
        }

        public void AddByArr(int[] arr)
        {
            foreach(int element in arr)
            {
                Add(element);
            }
        }

        public void AddByArr(List<int> arr)
        {
            foreach (int element in arr)
            {
                Add(element);
            }
        }

        public void Print()
        {
            AcrossPrint(root);
        }

        private void AcrossPrint(Node current)
        {
            var queue = new Queue<Node>();
            var levels = new Queue<int>();
            List<int> map = new List<int>();
            List<int> keys = new List<int>();

            queue.Enqueue(root);
            levels.Enqueue(0);

            while (queue.Count != 0)
            {
                if (queue.Peek().left != null)
                {
                    queue.Enqueue(queue.Peek().left);
                    levels.Enqueue(levels.Peek() + 1);
                }

                if (queue.Peek().right != null)
                {
                    queue.Enqueue(queue.Peek().right);
                    levels.Enqueue(levels.Peek() + 1);
                }

                keys.Add(queue.Dequeue().value);
                map.Add(levels.Dequeue());

                
            }

            int maxLevel = map.Max();
            int curLevel = maxLevel;
            int counter = map.Count()-1;
            Console.Write($"Level {curLevel + 1}: ");
            while (counter >= 0)
            {
                if (curLevel != map[counter])
                {
                    curLevel--;
                    Console.Write($"\nLevel {curLevel+1}: ");
                }
                Console.Write($"{keys[counter]} ");
                counter--;

            }
        }
    }
}