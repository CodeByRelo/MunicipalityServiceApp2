
using System.Collections.Generic;
using MunicipalityServiceApp2.DataStructures;
using MunicipalityServiceApp2.Models;
using MunicipalityServiceApp2.Services;

namespace MunicipalityServiceApp2.Services
{
    public class IssueAlgorithmService
    {
        private readonly IssueService issueService =
            new IssueService();

        public BinaryTree BinaryTree { get; private set; }
        public BinarySearchTree BinarySearchTree { get; private set; }
        public AVLTree AVLTree { get; private set; }
        public RedBlackTree RedBlackTree { get; private set; }
        public MinHeap PriorityHeap { get; private set; }

        public Graph MunicipalGraph { get; private set; }

        private readonly GraphTraversal graphTraversal =
            new GraphTraversal();

        private readonly MinimumSpanningTree mstAlgorithm =
            new MinimumSpanningTree();

        public IssueAlgorithmService()
        {
            MunicipalGraph = new Graph();
            RefreshIssueStructures();
        }

        public void RefreshIssueStructures()
        {
            List<Issue> issues = issueService.GetAllIssues();

            BinaryTree = new BinaryTree();
            BinarySearchTree = new BinarySearchTree();
            AVLTree = new AVLTree();
            RedBlackTree = new RedBlackTree();
            PriorityHeap = new MinHeap();

            BuildBinaryTree(issues);

            foreach (Issue issue in issues)
            {
                BinarySearchTree.Insert(issue);
                AVLTree.Insert(issue);
                RedBlackTree.Insert(issue);
                PriorityHeap.Insert(issue);
            }
        }

        private void BuildBinaryTree(List<Issue> issues)
        {
            if (issues == null || issues.Count == 0)
                return;

            BinaryTree.SetRoot(issues[0]);

            Queue<BinaryTree.Node> nodes =
                new Queue<BinaryTree.Node>();

            nodes.Enqueue(BinaryTree.Root);

            int index = 1;

            while (index < issues.Count && nodes.Count > 0)
            {
                BinaryTree.Node parent = nodes.Dequeue();

                if (index < issues.Count)
                {
                    BinaryTree.InsertLeft(
                        parent,
                        issues[index]);

                    nodes.Enqueue(parent.Left);
                    index++;
                }

                if (index < issues.Count)
                {
                    BinaryTree.InsertRight(
                        parent,
                        issues[index]);

                    nodes.Enqueue(parent.Right);
                    index++;
                }
            }
        }

        public Issue FindIssueById(int id)
        {
            return AVLTree.Search(id);
        }

        public Issue FindIssueUsingBST(int id)
        {
            return BinarySearchTree.Search(id);
        }

        public Issue FindIssueUsingRedBlackTree(int id)
        {
            return RedBlackTree.Search(id);
        }

        public List<Issue> GetIssuesSortedById()
        {
            return BinarySearchTree.InOrder();
        }

        public List<Issue> GetIssuesByPriority()
        {
            return PriorityHeap.GetPrioritisedIssues();
        }

        public Issue GetNextPriorityIssue()
        {
            return PriorityHeap.Peek();
        }

        public void AddMunicipalConnection(
            string source,
            string destination,
            double weight)
        {
            MunicipalGraph.AddEdge(
                source,
                destination,
                weight);
        }

        public List<string> ExploreLocationsBFS(
            string startingLocation)
        {
            return graphTraversal.BreadthFirstSearch(
                MunicipalGraph,
                startingLocation);
        }

        public List<string> ExploreLocationsDFS(
            string startingLocation)
        {
            return graphTraversal.DepthFirstSearch(
                MunicipalGraph,
                startingLocation);
        }

        public List<GraphEdge> GetMinimumSpanningTree()
        {
            return mstAlgorithm.Kruskal(MunicipalGraph);
        }

        public double GetMinimumNetworkWeight()
        {
            return mstAlgorithm.GetTotalWeight(
                GetMinimumSpanningTree());
        }
    }
}
