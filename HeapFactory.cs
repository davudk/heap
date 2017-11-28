using System;

namespace heap {
    public static class HeapFactory {

        static bool MinConstraint<T>(T parent, T child) where T : IComparable<T>
            => parent.CompareTo(child) <= 0;
        public static Heap<T> CreateMinHeap<T>() where T : IComparable<T>
            => new Heap<T>(MinConstraint);
        public static Heap<T> CreateMinHeap<T>(int capacity) where T : IComparable<T>
            => new Heap<T>(capacity, MinConstraint);
        public static Heap<T> CreateMinHeap<T>(T[] src, int additionalCapacity = 0) where T : IComparable<T>
            => new Heap<T>(src, MinConstraint, additionalCapacity);

        static bool MaxConstraint<T>(T parent, T child) where T : IComparable<T>
            => parent.CompareTo(child) >= 0;
        public static Heap<T> CreateMaxHeap<T>() where T : IComparable<T>
            => new Heap<T>(MaxConstraint);
        public static Heap<T> CreateMaxHeap<T>(int capacity) where T : IComparable<T>
            => new Heap<T>(capacity, MaxConstraint);
        public static Heap<T> CreateMaxHeap<T>(T[] src, int additionalCapacity = 0) where T : IComparable<T>
            => new Heap<T>(src, MaxConstraint, additionalCapacity);
    }
}
