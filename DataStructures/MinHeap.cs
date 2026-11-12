
using System.Collections.Generic;
using MunicipalityServiceApp2.Models;

namespace MunicipalityServiceApp2.DataStructures
{
    public class MinHeap
    {
        private readonly List<Issue> heap = new List<Issue>();

        public int Count
        {
            get { return heap.Count; }
        }

        public bool IsEmpty
        {
            get { return heap.Count == 0; }
        }

        // Adds a service request to the heap.
        public void Insert(Issue issue)
        {
            if (issue == null)
                return;

            heap.Add(issue);
            HeapifyUp(heap.Count - 1);
        }

        // Returns the highest-priority request without removing it.
        public Issue Peek()
        {
            return heap.Count == 0 ? null : heap[0];
        }

        // Removes and returns the highest-priority request.
        public Issue ExtractMin()
        {
            if (heap.Count == 0)
                return null;

            Issue minimum = heap[0];
            Issue last = heap[heap.Count - 1];

            heap.RemoveAt(heap.Count - 1);

            if (heap.Count > 0)
            {
                heap[0] = last;
                HeapifyDown(0);
            }

            return minimum;
        }

        // Returns all requests in priority order without
        // modifying the original heap.
        public List<Issue> GetPrioritisedIssues()
        {
            MinHeap copy = new MinHeap();

            foreach (Issue issue in heap)
            {
                copy.Insert(issue);
            }

            List<Issue> results = new List<Issue>();

            while (!copy.IsEmpty)
            {
                results.Add(copy.ExtractMin());
            }

            return results;
        }

        // Restores heap order after insertion.
        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;

                if (Compare(heap[index], heap[parent]) >= 0)
                    break;

                Swap(index, parent);

                index = parent;
            }
        }

        // Restores heap order after removing the root.
        private void HeapifyDown(int index)
        {
            while (true)
            {
                int left = (index * 2) + 1;
                int right = (index * 2) + 2;

                int smallest = index;

                if (left < heap.Count &&
                    Compare(heap[left], heap[smallest]) < 0)
                {
                    smallest = left;
                }

                if (right < heap.Count &&
                    Compare(heap[right], heap[smallest]) < 0)
                {
                    smallest = right;
                }

                if (smallest == index)
                    break;

                Swap(index, smallest);

                index = smallest;
            }
        }

        // Determines which request should be processed first.
        // Pending -> In Progress -> Resolved.
        // Older requests are processed first within each status.
        private int Compare(Issue first, Issue second)
        {
            int result = GetStatusPriority(first.Status)
                .CompareTo(GetStatusPriority(second.Status));

            if (result != 0)
                return result;

            result = first.DateReported.CompareTo(
                second.DateReported);

            if (result != 0)
                return result;

            return first.Id.CompareTo(second.Id);
        }

        // Assigns a numeric priority to each request status.
        private int GetStatusPriority(string status)
        {
            switch ((status ?? "").Trim().ToLowerInvariant())
            {
                case "pending":
                    return 1;

                case "in progress":
                    return 2;

                case "resolved":
                    return 3;

                default:
                    return 4;
            }
        }

        // Exchanges two elements in the heap.
        private void Swap(int first, int second)
        {
            Issue temp = heap[first];

            heap[first] = heap[second];
            heap[second] = temp;
        }

        // Removes all elements from the heap.
        public void Clear()
        {
            heap.Clear();
        }
    }
}
