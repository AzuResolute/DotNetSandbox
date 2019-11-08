using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refresher
{
    public static class TreeSearch
    {
        private static Node sample_tree()
        {
            Node root =
            new Node("A",
                new Node("B",
                    new Node("C"), new Node("D")
                ),
                new Node("E",
                    new Node("F"), new Node("G",
                        new Node("H"), null
                    )
                )
            );

            return root;
        }

        public static List<string> RunBreadthFirstSearch()
        {
            Node node = sample_tree();
            List<string> results = new List<string>();
            Queue<Node> pending = new Queue<Node>();
            pending.Enqueue(node);

            while(pending.Count > 0)
            {
                node = pending.Dequeue();
                results.Add(node._data);

                if(node._left != null) pending.Enqueue(node._left);
                if(node._right != null) pending.Enqueue(node._right);
            }

            return results;
        }

        public static List<string> RunDepthFirstSearchRecursive()
        {
            Node node = sample_tree();

            return RecursiveDFS(node);
        }

        private static List<string> RecursiveDFS(Node node)
        {
            List<string> results = new List<string>();

            if (node != null) results.Add(node._data);
            if(node._left != null) results.AddRange(RecursiveDFS(node._left));
            if (node._right != null) results.AddRange(RecursiveDFS(node._right));

            return results;
        }


    }
    public class Node
    {
        public Node _left;
        public Node _right;
        public string _data;

        public Node(string data, Node left, Node right)
        {
            _data = data;
            _left = left;
            _right = right;
        }
        public Node(string data)
        {
            _data = data;
            _left = null;
            _right = null;
        }
    }
}
