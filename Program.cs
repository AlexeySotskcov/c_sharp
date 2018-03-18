using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace startedTree
{
  
    public class BinaryTree
    {
        public long? Data { get; private set; }
        public BinaryTree Right { get; set; }
        public BinaryTree Left { get; set; }
        public BinaryTree Parent { get; set; }

        public void Insert(long data)
        {
            if (Data == null || Data == data)
            {
                Data = data;
                return;
            }

            if (Data > data)
            {
                if (Left == null)
                {
                    Left = new BinaryTree();
                }
                Insert(data, Left, this);
            }
            else
            {
                if (Right == null)
                {
                    Right = new BinaryTree();
                }
                if (Right.Data == data)
                {
                    var rght = Right;
                    Right = new BinaryTree();
                    Right.Right = rght;
                }
                Insert(data, Right, this);
            }
        }

        private void Insert(long data, BinaryTree node, BinaryTree parent)
        {
            if (node.Data == null || node.Data == data) 
            {
                node.Data = data;
                node.Parent = parent;
                return;
            }
         
            if (node.Data > data)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTree();
                }
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryTree(); 
                }
                if (node.Right.Data == data)
                {
                    if (node.Right.Right != null) 
                    {
                        var right_right = node.Right.Right;
                        node.Right.Right = new BinaryTree();
                        node.Right.Right.Right = right_right;
                    }
                           
                }
                Insert(data, node.Right, node);     
            }
        }
    }

    public class BinaryTreeExtensions
    {
        public static void Print(BinaryTree node, int height, int left, int right)
        {
            if (node != null)
            {
                var offset = left + (right - left) / 2;
                Console.SetCursorPosition(offset, height);
                Console.Out.Write(node.Data);
                Print("/", height + 1, left, offset, node.Left);
                Print("\\", height + 1, offset, right, node.Right);
                Print(node.Left, height + 2, left, offset);
                Print(node.Right, height + 2, offset, right);
                
            }

        }
        public static void Print(string value, int height, int left, int right, BinaryTree node)
        {
            int offset;
            
            if (node == null)
            {
                return;
            }
            string s = Convert.ToString(node.Data);
            if (value == "/")
            {
                offset = (left + (right - left) / 2 + (right - left) / 4);
            }
            else
            {
                offset = (left + (right - left) / 2 - (right - left) / 4);
            }
            Console.SetCursorPosition(offset, height);
            Console.Out.Write(value, Console.WindowHeight);
        }
        
    }


    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Enter element count in binary tree(if insert value equal 'root', it will be not inserted");
            int x = Convert.ToInt32(Console.ReadLine());
            var tree = new BinaryTree();
            Random rnd = new Random();
            for (int i = 0; i < x; i++)
            {
                int n = rnd.Next(0, 100);
                tree.Insert(n);
            }
            
            Console.CursorVisible = false;
            BinaryTreeExtensions.Print(tree, 2, 0, Console.WindowWidth);
            Console.ReadLine();
            
        }
    }
}
