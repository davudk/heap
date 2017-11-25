using System;

namespace heap {
    public static class HeapFactory {

        public static Heap<T> CreateMinHeap<T>() where T : IComparable<T> {

            return new Heap<T>(MinConstraint);

            bool MinConstraint(T parent, T child) {
                return parent.CompareTo(child) <= 0;
            }
        }

        public static Heap<T> CreateMaxHeap<T>() where T : IComparable<T> {

            return new Heap<T>(MaxConstraint);

            bool MaxConstraint(T parent, T child) {
                return parent.CompareTo(child) >= 0;
            }
        }
    }
}
