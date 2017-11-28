# Heap

A straightforward implementation of a heap. It is implemented generically, and accepts a custom constraint. The initial capacity can be specified at initialization and changed at any time. A initial array can be used to construct the heap.

**(Ex 1) Using the heap factory (on type `T`, where `T : IComparable<T>`)**

```csharp
var h = HeapFactory.CreateMinHeap<string>();
```

**(Ex 2) Explicitly specifying the heap constraint**

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


// cons is a delegate of form: bool HeapConstraint<T>(T parent, T child)
// it can be embedded directly into the constructor:
var h2 = new Heap<string>((p, c) => p.CompareTo(c) <= 0);
```
