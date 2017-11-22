# Heap

A straightforward implementation of a heap. It is implemented generically, and accepts a custom constraint. The initial capacity can be specified at initialization and changed at any time. A initial array can be used to construct the heap.

**Example:** a simple min-heap for strings.

```csharp
HeapConstraint<string> cons = (parent, child) => {
    // this indicates that the parent must
    // alphabetically precede the child
    return parent.CompareTo(child) <= 0;
    
    // if the return value is true, then the
    // parent-child integrity constraint is satisfied
    // otherwise, a shift must occur to reach a valid state
};

var h = new Heap<string>(constraint: cons);
``
