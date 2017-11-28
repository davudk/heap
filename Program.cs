using System;
using System.Collections.Generic;

namespace heap {
    class Program {
        static void Main(string[] args) {
            string[] data = new[] {
                "Pear", "Apple", "Orange", "Banana",
                "Grape", "Watermelon", "Avocado", "Cherry"
            };

            // Create a min-heap of strings directly from the input array.
            // This is more efficient than inserting each with a loop.
            // Also: T is string, implicitly deduced.
            var h = HeapFactory.CreateMinHeap(data);

            // Empty the heap in sorted order
            while (h.Count > 0) {
                string i = h.Remove();
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
