using System;

namespace heap {
    public delegate bool HeapConstraint<T>(T parent, T child);

    public class Heap<T> {
        const int DefaultSize = 16;
        HeapConstraint<T> cons;
        int capacity;
        T[] arr;

        public int Capacity {
            get => capacity;
            set {
                if (value <= 0) {
                    throw new ArgumentOutOfRangeException(nameof(capacity));
                }

                Resize(value);
            }
        }
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public Heap(HeapConstraint<T> constraint) : this(DefaultSize, constraint) {

        }

        public Heap(int capacity, HeapConstraint<T> constraint) {
            if (capacity <= 0) {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            Initialize(new T[capacity], 0, constraint);
        }

        public Heap(T[] src, HeapConstraint<T> constraint) {
            if (src == null) {
                throw new ArgumentNullException(nameof(src));
            }

            Initialize((T[])src.Clone(), src.Length, constraint);
        }

        void Initialize(T[] src, int count, HeapConstraint<T> constraint) {
            arr = src ?? throw new ArgumentNullException(nameof(src));
            cons = constraint ?? throw new ArgumentNullException(nameof(constraint));

            Capacity = arr.Length;
            Count = count;
        }

        public void Insert(T item) {
            if (Count == Capacity) {
                Resize(Capacity * 2);
            }

            arr[Count] = item;
            ShiftUp(Count++);
        }

        public T Remove() {
            if (Count <= 0) {
                throw new InvalidOperationException("The Heap is empty");
            }

            T item = arr[0];
            arr[0] = arr[--Count];
            arr[Count] = default(T); // remove it, this helps garbage collector
            ShiftDown(0);

            return item;
        }

        public void Clear() {
            // reset array elements (to aid garbage collection)
            for (int i =0; i < Count; i++) {
                arr[i] = default(T);
            }
            Count = 0;
        }

        void ShiftUp(int i) {
            int iparent = (i - 1) / 2;

            if (!Constraint(iparent, i)) {
                Swap(iparent, i);
                ShiftUp(iparent);
            }
        }

        void ShiftDown(int i) {
            int ileft = i * 2 + 1,
                iright = i * 2 + 2;

            if (ileft < Count) {
                if (iright < Count) {
                    // both left and right exist
                    bool consleft = Constraint(i, ileft);
                    bool consright = Constraint(i, iright);

                    if (!consleft && !consright) {
                        // both children do not meet integrity constraint
                        // determine one of the children to make the parent
                        if (Constraint(ileft, iright)) {
                            // prefer left child
                            Swap(i, ileft);
                            ShiftDown(ileft);
                        } else {
                            // prefer right child
                            Swap(i, iright);
                            ShiftDown(iright);
                        }
                    } else if (!consleft && consright) {
                        // left child does not meet integrity constraint
                        Swap(i, ileft);
                        ShiftDown(ileft);
                    } else if (consleft && !consright) {
                        // right child does not meet integrity constraint
                        Swap(i, iright);
                        ShiftDown(iright);
                    }
                } else {
                    // only left exists
                    if (!Constraint(i, ileft)) {
                        Swap(i, ileft);
                        // dont shift down on left, because left has no children
                    }
                }
            }
        }

        void Resize(int newsize) {
            capacity = newsize;
            Count = Math.Max(Count, newsize);

            T[] newarr = new T[newsize];
            Array.Copy(arr, newarr, Count);
            arr = newarr;
        }

        void Swap(int i0, int i1) {
            T temp = arr[i0];
            arr[i0] = arr[i1];
            arr[i1] = temp;
        }

        bool Constraint(int iparent, int ichild) {
            return cons(arr[iparent], arr[ichild]);
        }
    }
}
