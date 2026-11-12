
using System.Collections.Generic;
using MunicipalityServiceApp2.Models;

namespace MunicipalityServiceApp2.DataStructures
{
    public class AVLTree
    {
        public class Node
        {
            public Issue Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Height { get; set; }

            public Node(Issue issue)
            {
                Data = issue;
                Height = 1;
            }
        }

        public Node Root { get; private set; }

        private int Height(Node node)
        {
            return node == null ? 0 : node.Height;
        }

        private int BalanceFactor(Node node)
        {
            return node == null
                ? 0
                : Height(node.Left) - Height(node.Right);
        }

        private void UpdateHeight(Node node)
        {
            node.Height = 1 +
                System.Math.Max(Height(node.Left), Height(node.Right));
        }

        private Node RotateRight(Node y)
        {
            Node x = y.Left;
            Node temp = x.Right;

            x.Right = y;
            y.Left = temp;

            UpdateHeight(y);
            UpdateHeight(x);

            return x;
        }

        private Node RotateLeft(Node x)
        {
            Node y = x.Right;
            Node temp = y.Left;

            y.Left = x;
            x.Right = temp;

            UpdateHeight(x);
            UpdateHeight(y);

            return y;
        }

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
            else
                return node;

            UpdateHeight(node);

            int balance = BalanceFactor(node);

            if (balance > 1 && issue.Id < node.Left.Data.Id)
                return RotateRight(node);

            if (balance < -1 && issue.Id > node.Right.Data.Id)
                return RotateLeft(node);

            if (balance > 1 && issue.Id > node.Left.Data.Id)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            if (balance < -1 && issue.Id < node.Right.Data.Id)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

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
