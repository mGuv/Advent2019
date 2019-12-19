using System;

namespace Advent2019.Problems.Day18
{
    /// <summary>
    /// Stack-style class that automatically orders elements as they are inserted from lowest to highest
    /// </summary>
    /// <typeparam name="T">Type of element stored in the heap</typeparam>
    public class Heap <T>
    {
        /// <summary>
        /// Comparer function used to decide how to order the elements in the heap
        /// </summary>
        private readonly Func<T, T, float> comparer;

        /// <summary>
        /// Raw structure of the heap itself
        /// </summary>
        private T[] data = new T[1];

        /// <summary>
        /// The number of elements currently in the Heap
        /// </summary>
        public int Count
        {
            private set;
            get;
        }

        /// <summary>
        /// Create a heap that can sort elements in the order governed by the Comparer
        /// </summary>
        /// <param name="comparer">The comparer that is used to distinguish the lowest to highest order</param>
        public Heap(Func<T, T, float> comparer)
        {
            this.comparer = comparer;
        }

        /// <summary>
        /// Resize the internal array to fit more elements
        /// </summary>
        private void Resize()
        {
            // Just double the array length for ease
            T[] resized = new T[this.data.Length * 2];
            // Copy current heap in to new array
            Array.Copy(this.data, 0, resized, 0, this.data.Length);
            // Assign new array
            this.data = resized;
        }

        /// <summary>
        /// Check if the given node requires updating.
        /// </summary>
        /// <param name="childIndex">Index of node to check</param>
        private void HeapUp(int childIndex)
        {
            if(childIndex > 0)
            {
                // Look up the heap
                int parentIndex = (childIndex - 1) / 2;

                // check if it needs swapping
                if(this.comparer(this.data[childIndex], this.data[parentIndex]) == -1)
                {
                    // Swap
                    T tempParent = this.data[parentIndex];
                    this.data[parentIndex] = this.data[childIndex];
                    this.data[childIndex] = tempParent;
                    // Propogate upwards
                    HeapUp(parentIndex);
                }
            }
        }

        /// <summary>
        /// Check if the given node requires it's position changed in a downwards direction
        /// </summary>
        /// <param name="parentIndex">Index of node to check</param>
        private void HeapDown(int parentIndex)
        {
            // Get the child nodes either side of this node
            int leftChildIndex = 2 * parentIndex + 1;
            int rightChildIndex = leftChildIndex + 1;
            int largestIndex = parentIndex;

            // Check if it needs reordering compared to the left
            if(leftChildIndex < Count && this.comparer(this.data[leftChildIndex], this.data[largestIndex]) == -1)
            {
                largestIndex = leftChildIndex;
            }

            // Check if it needs reordering to the right
            if(rightChildIndex < Count && this.comparer(this.data[rightChildIndex], this.data[largestIndex]) == -1)
            {
                largestIndex = rightChildIndex;
            }

            // Check if it needs reordering at all
            if(largestIndex != parentIndex)
            {
                // Reorder
                T tempParent = this.data[parentIndex];
                this.data[parentIndex] = this.data[largestIndex];
                this.data[largestIndex] = tempParent;
                // Propogate node downwards
                HeapDown(largestIndex);
            }
        }

        /// <summary>
        /// Add an Element in to the heap that will be automatically ordered
        /// </summary>
        /// <param name="element">The element to add to the heap</param>
        public void Insert(T element)
        {
            // If the heap is already full we need to resize it
            if (this.Count == this.data.Length)
            {
                Resize();
            }

            // Add the element at the end of the heap
            this.data[this.Count] = element;
            // Propogate the element upwards
            HeapUp(this.Count);
            this.Count++;
        }

        /// <summary>
        /// Get the element at the root of the heap
        /// </summary>
        /// <returns>The root element</returns>
        public T Pop()
        {
            // Get root element
            T toReturn = this.data[0];
            this.Count--;
            // Swap the end node and first node
            this.data[0] = this.data[this.Count];
            // Find the end node's new position
            HeapDown(0);
            return toReturn;
        }

        /// <summary>
        /// Empty the current Heap so it can be reused
        /// </summary>
        public void Clear()
        {
            // Clear data but keep size as if it grew once before, it will most likely be used again
            Array.Clear(this.data, 0, this.data.Length);
            // Reset count to zero
            this.Count = 0;
        }
    }
}
