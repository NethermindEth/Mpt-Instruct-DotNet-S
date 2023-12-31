//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (https://www.swig.org).
// Version 4.1.1
//
// Do not make changes to this file unless you know what you are doing - modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace MptLibrary {

public class Tokens : global::System.IDisposable, global::System.Collections.IEnumerable, global::System.Collections.Generic.IList<int>
 {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Tokens(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Tokens obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(Tokens obj) {
    if (obj != null) {
      if (!obj.swigCMemOwn)
        throw new global::System.ApplicationException("Cannot release ownership as memory is not owned");
      global::System.Runtime.InteropServices.HandleRef ptr = obj.swigCPtr;
      obj.swigCMemOwn = false;
      obj.Dispose();
      return ptr;
    } else {
      return new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
    }
  }

  ~Tokens() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libmpt_libraryPINVOKE.delete_Tokens(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public Tokens(global::System.Collections.IEnumerable c) : this() {
    if (c == null)
      throw new global::System.ArgumentNullException("c");
    foreach (int element in c) {
      this.Add(element);
    }
  }

  public Tokens(global::System.Collections.Generic.IEnumerable<int> c) : this() {
    if (c == null)
      throw new global::System.ArgumentNullException("c");
    foreach (int element in c) {
      this.Add(element);
    }
  }

  public bool IsFixedSize {
    get {
      return false;
    }
  }

  public bool IsReadOnly {
    get {
      return false;
    }
  }

  public int this[int index]  {
    get {
      return getitem(index);
    }
    set {
      setitem(index, value);
    }
  }

  public int Capacity {
    get {
      return (int)capacity();
    }
    set {
      if (value < 0 || (uint)value < size())
        throw new global::System.ArgumentOutOfRangeException("Capacity");
      reserve((uint)value);
    }
  }

  public int Count {
    get {
      return (int)size();
    }
  }

  public bool IsSynchronized {
    get {
      return false;
    }
  }

  public void CopyTo(int[] array)
  {
    CopyTo(0, array, 0, this.Count);
  }

  public void CopyTo(int[] array, int arrayIndex)
  {
    CopyTo(0, array, arrayIndex, this.Count);
  }

  public void CopyTo(int index, int[] array, int arrayIndex, int count)
  {
    if (array == null)
      throw new global::System.ArgumentNullException("array");
    if (index < 0)
      throw new global::System.ArgumentOutOfRangeException("index", "Value is less than zero");
    if (arrayIndex < 0)
      throw new global::System.ArgumentOutOfRangeException("arrayIndex", "Value is less than zero");
    if (count < 0)
      throw new global::System.ArgumentOutOfRangeException("count", "Value is less than zero");
    if (array.Rank > 1)
      throw new global::System.ArgumentException("Multi dimensional array.", "array");
    if (index+count > this.Count || arrayIndex+count > array.Length)
      throw new global::System.ArgumentException("Number of elements to copy is too large.");
    for (int i=0; i<count; i++)
      array.SetValue(getitemcopy(index+i), arrayIndex+i);
  }

  public int[] ToArray() {
    int[] array = new int[this.Count];
    this.CopyTo(array);
    return array;
  }

  global::System.Collections.Generic.IEnumerator<int> global::System.Collections.Generic.IEnumerable<int>.GetEnumerator() {
    return new TokensEnumerator(this);
  }

  global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator() {
    return new TokensEnumerator(this);
  }

  public TokensEnumerator GetEnumerator() {
    return new TokensEnumerator(this);
  }

  // Type-safe enumerator
  /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
  /// whenever the collection is modified. This has been done for changes in the size of the
  /// collection but not when one of the elements of the collection is modified as it is a bit
  /// tricky to detect unmanaged code that modifies the collection under our feet.
  public sealed class TokensEnumerator : global::System.Collections.IEnumerator
    , global::System.Collections.Generic.IEnumerator<int>
  {
    private Tokens collectionRef;
    private int currentIndex;
    private object currentObject;
    private int currentSize;

    public TokensEnumerator(Tokens collection) {
      collectionRef = collection;
      currentIndex = -1;
      currentObject = null;
      currentSize = collectionRef.Count;
    }

    // Type-safe iterator Current
    public int Current {
      get {
        if (currentIndex == -1)
          throw new global::System.InvalidOperationException("Enumeration not started.");
        if (currentIndex > currentSize - 1)
          throw new global::System.InvalidOperationException("Enumeration finished.");
        if (currentObject == null)
          throw new global::System.InvalidOperationException("Collection modified.");
        return (int)currentObject;
      }
    }

    // Type-unsafe IEnumerator.Current
    object global::System.Collections.IEnumerator.Current {
      get {
        return Current;
      }
    }

    public bool MoveNext() {
      int size = collectionRef.Count;
      bool moveOkay = (currentIndex+1 < size) && (size == currentSize);
      if (moveOkay) {
        currentIndex++;
        currentObject = collectionRef[currentIndex];
      } else {
        currentObject = null;
      }
      return moveOkay;
    }

    public void Reset() {
      currentIndex = -1;
      currentObject = null;
      if (collectionRef.Count != currentSize) {
        throw new global::System.InvalidOperationException("Collection modified.");
      }
    }

    public void Dispose() {
        currentIndex = -1;
        currentObject = null;
    }
  }

  public void Clear() {
    libmpt_libraryPINVOKE.Tokens_Clear(swigCPtr);
  }

  public void Add(int x) {
    libmpt_libraryPINVOKE.Tokens_Add(swigCPtr, x);
  }

  private uint size() {
    uint ret = libmpt_libraryPINVOKE.Tokens_size(swigCPtr);
    return ret;
  }

  private uint capacity() {
    uint ret = libmpt_libraryPINVOKE.Tokens_capacity(swigCPtr);
    return ret;
  }

  private void reserve(uint n) {
    libmpt_libraryPINVOKE.Tokens_reserve(swigCPtr, n);
  }

  public Tokens() : this(libmpt_libraryPINVOKE.new_Tokens__SWIG_0(), true) {
  }

  public Tokens(Tokens other) : this(libmpt_libraryPINVOKE.new_Tokens__SWIG_1(Tokens.getCPtr(other)), true) {
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  public Tokens(int capacity) : this(libmpt_libraryPINVOKE.new_Tokens__SWIG_2(capacity), true) {
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  private int getitemcopy(int index) {
    int ret = libmpt_libraryPINVOKE.Tokens_getitemcopy(swigCPtr, index);
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private int getitem(int index) {
    int ret = libmpt_libraryPINVOKE.Tokens_getitem(swigCPtr, index);
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private void setitem(int index, int val) {
    libmpt_libraryPINVOKE.Tokens_setitem(swigCPtr, index, val);
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  public void AddRange(Tokens values) {
    libmpt_libraryPINVOKE.Tokens_AddRange(swigCPtr, Tokens.getCPtr(values));
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  public Tokens GetRange(int index, int count) {
    global::System.IntPtr cPtr = libmpt_libraryPINVOKE.Tokens_GetRange(swigCPtr, index, count);
    Tokens ret = (cPtr == global::System.IntPtr.Zero) ? null : new Tokens(cPtr, true);
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Insert(int index, int x) {
    libmpt_libraryPINVOKE.Tokens_Insert(swigCPtr, index, x);
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  public void InsertRange(int index, Tokens values) {
    libmpt_libraryPINVOKE.Tokens_InsertRange(swigCPtr, index, Tokens.getCPtr(values));
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveAt(int index) {
    libmpt_libraryPINVOKE.Tokens_RemoveAt(swigCPtr, index);
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveRange(int index, int count) {
    libmpt_libraryPINVOKE.Tokens_RemoveRange(swigCPtr, index, count);
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  public static Tokens Repeat(int value, int count) {
    global::System.IntPtr cPtr = libmpt_libraryPINVOKE.Tokens_Repeat(value, count);
    Tokens ret = (cPtr == global::System.IntPtr.Zero) ? null : new Tokens(cPtr, true);
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Reverse() {
    libmpt_libraryPINVOKE.Tokens_Reverse__SWIG_0(swigCPtr);
  }

  public void Reverse(int index, int count) {
    libmpt_libraryPINVOKE.Tokens_Reverse__SWIG_1(swigCPtr, index, count);
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetRange(int index, Tokens values) {
    libmpt_libraryPINVOKE.Tokens_SetRange(swigCPtr, index, Tokens.getCPtr(values));
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool Contains(int value) {
    bool ret = libmpt_libraryPINVOKE.Tokens_Contains(swigCPtr, value);
    return ret;
  }

  public int IndexOf(int value) {
    int ret = libmpt_libraryPINVOKE.Tokens_IndexOf(swigCPtr, value);
    return ret;
  }

  public int LastIndexOf(int value) {
    int ret = libmpt_libraryPINVOKE.Tokens_LastIndexOf(swigCPtr, value);
    return ret;
  }

  public bool Remove(int value) {
    bool ret = libmpt_libraryPINVOKE.Tokens_Remove(swigCPtr, value);
    return ret;
  }

}

}
