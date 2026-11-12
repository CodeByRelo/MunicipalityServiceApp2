
using System.Collections.Generic;
using MunicipalityServiceApp2.Models;

namespace MunicipalityServiceApp2.DataStructures
{
    public class BinaryTree
    {
        public class Node
        {
            public Issue Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(Issue issue)
            {
                Data = issue;
            }
        }

        public Node Root { get; private set; }

        public void SetRoot(Issue issue)
        {
            Root = issue == null ? null : new Node(issue);
        }

        public void InsertLeft(Node parent, Issue issue)
        {
            if (parent != null && issue != null)
                parent.Left = new Node(issue);
        }

        public void InsertRight(Node parent, Issue issue)
        {
            if (parent != null && issue != null)
                parent.Right = new Node(issue);
        }

        public List<Issue> PreOrder()
        {
            var results = new List<Issue>();
            TraversePreOrder(Root, results);
            return results;
        }

        private void TraversePreOrder(Node node, List<Issue> results)
        {
            if (node == null) return;

            results.Add(node.Data);
            TraversePreOrder(node.Left, results);
            TraversePreOrder(node.Right, results);
        }

        public List<Issue> InOrder()
        {
            var results = new List<Issue>();
            TraverseInOrder(Root, results);
            return results;
        }

        private void TraverseInOrder(Node node, List<Issue> results)
        {
            if (node == null) return;

            TraverseInOrder(node.Left, results);
            results.Add(node.Data);
            TraverseInOrder(node.Right, results);
        }

        public List<Issue> PostOrder()
        {
            var results = new List<Issue>();
            TraversePostOrder(Root, results);
            return results;
        }

        private void TraversePostOrder(Node node, List<Issue> results)
        {
            if (node == null) return;

            TraversePostOrder(node.Left, results);
            TraversePostOrder(node.Right, results);
            results.Add(node.Data);
        }
    }
}
