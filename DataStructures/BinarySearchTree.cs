
using System.Collections.Generic;
using MunicipalityServiceApp2.Models;

namespace MunicipalityServiceApp2.DataStructures
{
    public class BinarySearchTree
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

        public void Insert(Issue issue)
        {
            if (issue == null) return;

            Root = InsertRecursive(Root, issue);
        }

        private Node InsertRecursive(Node node, Issue issue)
        {
            if (node == null)
                return new Node(issue);

            if (issue.Id < node.Data.Id)
                node.Left = InsertRecursive(node.Left, issue);
            else if (issue.Id > node.Data.Id)
                node.Right = InsertRecursive(node.Right, issue);

            return node;
        }

        public Issue Search(int id)
        {
            Node current = Root;

            while (current != null)
            {
                if (id == current.Data.Id)
                    return current.Data;

                current = id < current.Data.Id
                    ? current.Left
                    : current.Right;
            }

            return null;
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
    }
}
