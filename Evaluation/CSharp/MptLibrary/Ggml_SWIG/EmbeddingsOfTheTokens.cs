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

public class EmbeddingsOfTheTokens : global::System.IDisposable, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<SWIGTYPE_p_gpt_vocab__id>
 {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal EmbeddingsOfTheTokens(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(EmbeddingsOfTheTokens obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(EmbeddingsOfTheTokens obj) {
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

  ~EmbeddingsOfTheTokens() {
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
          libmpt_libraryPINVOKE.delete_EmbeddingsOfTheTokens(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public EmbeddingsOfTheTokens(global::System.Collections.IEnumerable c) : this() {
    if (c == null)
      throw new global::System.ArgumentNullException("c");
    foreach (SWIGTYPE_p_gpt_vocab__id element in c) {
      this.Add(element);
    }
  }

  public EmbeddingsOfTheTokens(global::System.Collections.Generic.IEnumerable<SWIGTYPE_p_gpt_vocab__id> c) : this() {
    if (c == null)
      throw new global::System.ArgumentNullException("c");
    foreach (SWIGTYPE_p_gpt_vocab__id element in c) {
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

  public SWIGTYPE_p_gpt_vocab__id this[int index]  {
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

  public void CopyTo(SWIGTYPE_p_gpt_vocab__id[] array)
  {
    CopyTo(0, array, 0, this.Count);
  }

  public void CopyTo(SWIGTYPE_p_gpt_vocab__id[] array, int arrayIndex)
  {
    CopyTo(0, array, arrayIndex, this.Count);
  }

  public void CopyTo(int index, SWIGTYPE_p_gpt_vocab__id[] array, int arrayIndex, int count)
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

  public SWIGTYPE_p_gpt_vocab__id[] ToArray() {
    SWIGTYPE_p_gpt_vocab__id[] array = new SWIGTYPE_p_gpt_vocab__id[this.Count];
    this.CopyTo(array);
    return array;
  }

  global::System.Collections.Generic.IEnumerator<SWIGTYPE_p_gpt_vocab__id> global::System.Collections.Generic.IEnumerable<SWIGTYPE_p_gpt_vocab__id>.GetEnumerator() {
    return new EmbeddingsOfTheTokensEnumerator(this);
  }

  global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator() {
    return new EmbeddingsOfTheTokensEnumerator(this);
  }

  public EmbeddingsOfTheTokensEnumerator GetEnumerator() {
    return new EmbeddingsOfTheTokensEnumerator(this);
  }

  // Type-safe enumerator
  /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
  /// whenever the collection is modified. This has been done for changes in the size of the
  /// collection but not when one of the elements of the collection is modified as it is a bit
  /// tricky to detect unmanaged code that modifies the collection under our feet.
  public sealed class EmbeddingsOfTheTokensEnumerator : global::System.Collections.IEnumerator
    , global::System.Collections.Generic.IEnumerator<SWIGTYPE_p_gpt_vocab__id>
  {
    private EmbeddingsOfTheTokens collectionRef;
    private int currentIndex;
    private object currentObject;
    private int currentSize;

    public EmbeddingsOfTheTokensEnumerator(EmbeddingsOfTheTokens collection) {
      collectionRef = collection;
      currentIndex = -1;
      currentObject = null;
      currentSize = collectionRef.Count;
    }

    // Type-safe iterator Current
    public SWIGTYPE_p_gpt_vocab__id Current {
      get {
        if (currentIndex == -1)
          throw new global::System.InvalidOperationException("Enumeration not started.");
        if (currentIndex > currentSize - 1)
          throw new global::System.InvalidOperationException("Enumeration finished.");
        if (currentObject == null)
          throw new global::System.InvalidOperationException("Collection modified.");
        return (SWIGTYPE_p_gpt_vocab__id)currentObject;
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
    libmpt_libraryPINVOKE.EmbeddingsOfTheTokens_Clear(swigCPtr);
  }

  public void Add(SWIGTYPE_p_gpt_vocab__id x) {
    libmpt_libraryPINVOKE.EmbeddingsOfTheTokens_Add(swigCPtr, SWIGTYPE_p_gpt_vocab__id.getCPtr(x));
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  private uint size() {
    uint ret = libmpt_libraryPINVOKE.EmbeddingsOfTheTokens_size(swigCPtr);
    return ret;
  }

  private uint capacity() {
    uint ret = libmpt_libraryPINVOKE.EmbeddingsOfTheTokens_capacity(swigCPtr);
    return ret;
  }

  private void reserve(uint n) {
    libmpt_libraryPINVOKE.EmbeddingsOfTheTokens_reserve(swigCPtr, n);
  }

  public EmbeddingsOfTheTokens() : this(libmpt_libraryPINVOKE.new_EmbeddingsOfTheTokens__SWIG_0(), true) {
  }

  public EmbeddingsOfTheTokens(EmbeddingsOfTheTokens other) : this(libmpt_libraryPINVOKE.new_EmbeddingsOfTheTokens__SWIG_1(EmbeddingsOfTheTokens.getCPtr(other)), true) {
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  public EmbeddingsOfTheTokens(int capacity) : this(libmpt_libraryPINVOKE.new_EmbeddingsOfTheTokens__SWIG_2(capacity), true) {
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  private SWIGTYPE_p_gpt_vocab__id getitemcopy(int index) {
    SWIGTYPE_p_gpt_vocab__id ret = new SWIGTYPE_p_gpt_vocab__id(libmpt_libraryPINVOKE.EmbeddingsOfTheTokens_getitemcopy(swigCPtr, index), true);
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private SWIGTYPE_p_gpt_vocab__id getitem(int index) {
    SWIGTYPE_p_gpt_vocab__id ret = new SWIGTYPE_p_gpt_vocab__id(libmpt_libraryPINVOKE.EmbeddingsOfTheTokens_getitem(swigCPtr, index), false);
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private void setitem(int index, SWIGTYPE_p_gpt_vocab__id val) {
    libmpt_libraryPINVOKE.EmbeddingsOfTheTokens_setitem(swigCPtr, index, SWIGTYPE_p_gpt_vocab__id.getCPtr(val));
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  public void AddRange(EmbeddingsOfTheTokens values) {
    libmpt_libraryPINVOKE.EmbeddingsOfTheTokens_AddRange(swigCPtr, EmbeddingsOfTheTokens.getCPtr(values));
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  public EmbeddingsOfTheTokens GetRange(int index, int count) {
    global::System.IntPtr cPtr = libmpt_libraryPINVOKE.EmbeddingsOfTheTokens_GetRange(swigCPtr, index, count);
    EmbeddingsOfTheTokens ret = (cPtr == global::System.IntPtr.Zero) ? null : new EmbeddingsOfTheTokens(cPtr, true);
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Insert(int index, SWIGTYPE_p_gpt_vocab__id x) {
    libmpt_libraryPINVOKE.EmbeddingsOfTheTokens_Insert(swigCPtr, index, SWIGTYPE_p_gpt_vocab__id.getCPtr(x));
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  public void InsertRange(int index, EmbeddingsOfTheTokens values) {
    libmpt_libraryPINVOKE.EmbeddingsOfTheTokens_InsertRange(swigCPtr, index, EmbeddingsOfTheTokens.getCPtr(values));
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveAt(int index) {
    libmpt_libraryPINVOKE.EmbeddingsOfTheTokens_RemoveAt(swigCPtr, index);
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveRange(int index, int count) {
    libmpt_libraryPINVOKE.EmbeddingsOfTheTokens_RemoveRange(swigCPtr, index, count);
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  public static EmbeddingsOfTheTokens Repeat(SWIGTYPE_p_gpt_vocab__id value, int count) {
    global::System.IntPtr cPtr = libmpt_libraryPINVOKE.EmbeddingsOfTheTokens_Repeat(SWIGTYPE_p_gpt_vocab__id.getCPtr(value), count);
    EmbeddingsOfTheTokens ret = (cPtr == global::System.IntPtr.Zero) ? null : new EmbeddingsOfTheTokens(cPtr, true);
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Reverse() {
    libmpt_libraryPINVOKE.EmbeddingsOfTheTokens_Reverse__SWIG_0(swigCPtr);
  }

  public void Reverse(int index, int count) {
    libmpt_libraryPINVOKE.EmbeddingsOfTheTokens_Reverse__SWIG_1(swigCPtr, index, count);
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetRange(int index, EmbeddingsOfTheTokens values) {
    libmpt_libraryPINVOKE.EmbeddingsOfTheTokens_SetRange(swigCPtr, index, EmbeddingsOfTheTokens.getCPtr(values));
    if (libmpt_libraryPINVOKE.SWIGPendingException.Pending) throw libmpt_libraryPINVOKE.SWIGPendingException.Retrieve();
  }

}

}
