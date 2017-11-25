# Heap

A straightforward implementation of a heap. It is implemented generically, and accepts a custom constraint. The initial capacity can be specified at initialization and changed at any time. A initial array can be used to construct the heap.

**(Ex 1) a simple min-heap for strings**

```csharp
var h = HeapFactory.CreateMinHeap<string>();
```

**(Ex 2) explicitly specifying the heap constraint**

```csharp
HeapConstraint<string> cons = (parent, child) => {
    // this indicates that the parent must
    // alphabetically precede the child
    return parent.CompareTo(child) <= 0;
    
    // if the return value is true, then the
    // parent-child integrity constraint is satisfied
    // otherwise, shifts will occur to reach a valid state
};

var h = new Heap<string>(constraint: cons);
``
