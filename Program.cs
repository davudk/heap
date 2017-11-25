using System;
using System.Collections.Generic;

namespace heap {
    class Program {
        static void Main(string[] args) {
            string[] data = new[] {
                "Pear", "Apple", "Orange", "Banana",
                "Grape", "Watermelon", "Avocado", "Cherry"
            };

            // Create a min-heap of strings
            var h = HeapFactory.CreateMinHeap<string>();
            
            // Insert the data collection into the heap
            foreach (string item in data) {
                h.Insert(item);
            }

            // Empty the heap in sorted order
            while (h.Count > 0) {
                string i = h.Remove();
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
