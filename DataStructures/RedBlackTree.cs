
using System.Collections.Generic;
using MunicipalityServiceApp2.Models;

namespace MunicipalityServiceApp2.DataStructures
{
    public class RedBlackTree
    {
        private enum NodeColor
        {
            Red,
            Black
        }

        private class Node
        {
            public Issue Data;
            public Node Left;
            public Node Right;
            public Node Parent;
            public NodeColor Color;

            public Node(Issue issue)
            {
                Data = issue;
                Color = NodeColor.Red;
            }
        }

        private Node root;

        public void Insert(Issue issue)
        {
            if (issue == null) return;

            Node node = new Node(issue);
            Node parent = null;
            Node current = root;

            while (current != null)
            {
                parent = current;

                if (issue.Id < current.Data.Id)
                    current = current.Left;
                else if (issue.Id > current.Data.Id)
                    current = current.Right;
                else
                    return;
            }

            node.Parent = parent;

            if (parent == null)
                root = node;
            else if (issue.Id < parent.Data.Id)
                parent.Left = node;
            else
                parent.Right = node;

            FixInsertion(node);
        }

        private void FixInsertion(Node node)
        {
            while (node != root &&
                   node.Parent.Color == NodeColor.Red)
            {
                if (node.Parent == node.Parent.Parent.Left)
                {
                    Node uncle = node.Parent.Parent.Right;

                    if (uncle != null &&
                        uncle.Color == NodeColor.Red)
                    {
                        node.Parent.Color = NodeColor.Black;
                        uncle.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Right)
                        {
                            node = node.Parent;
                            RotateLeft(node);
                        }

                        node.Parent.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        RotateRight(node.Parent.Parent);
                    }
                }
                else
                {
                    Node uncle = node.Parent.Parent.Left;

                    if (uncle != null &&
                        uncle.Color == NodeColor.Red)
                    {
                        node.Parent.Color = NodeColor.Black;
                        uncle.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Left)
                        {
                            node = node.Parent;
                            RotateRight(node);
                        }

                        node.Parent.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        RotateLeft(node.Parent.Parent);
                    }
                }
            }

            root.Color = NodeColor.Black;
        }

        private void RotateLeft(Node x)
        {
            Node y = x.Right;
            x.Right = y.Left;

            if (y.Left != null)
                y.Left.Parent = x;

            y.Parent = x.Parent;

            if (x.Parent == null)
                root = y;
            else if (x == x.Parent.Left)
                x.Parent.Left = y;
            else
                x.Parent.Right = y;

            y.Left = x;
            x.Parent = y;
        }

        private void RotateRight(Node y)
        {
            Node x = y.Left;
            y.Left = x.Right;

            if (x.Right != null)
                x.Right.Parent = y;

            x.Parent = y.Parent;

            if (y.Parent == null)
                root = x;
            else if (y == y.Parent.Right)
                y.Parent.Right = x;
            else
                y.Parent.Left = x;

            x.Right = y;
            y.Parent = x;
        }

        public Issue Search(int id)
        {
            Node current = root;

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
            TraverseInOrder(root, results);
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
