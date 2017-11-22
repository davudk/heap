using System;
using System.Collections.Generic;

namespace heap {
    class Program {
        static string[] data = new[] {
            "Pear", "Apple", "Orange", "Banana",
            "Grape", "Watermelon", "Avocado", "Cherry"
        };
        static HeapConstraint<string> cons = (parent, child) => {
            // this indicates that the parent must
            // alphabetically-preceede the child
            return parent.CompareTo(child) <= 0;
        };

        static void Main(string[] args) {
            
            // Create a min-heap of strings
            var h = new Heap<string>(cons);
            
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
