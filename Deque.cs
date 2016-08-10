#region Copyright (c) 2015 Atif Aziz. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

namespace Kons
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    // Very much inspired by the finger tree implementation presented by
    // Eric Lippert on his blog:
    // http://blogs.msdn.com/b/ericlippert/archive/2008/02/12/immutability-in-c-part-eleven-a-working-double-ended-queue.aspx
    // Re-created here from scratch after reading the article.

    partial interface IDeque<T> : IEnumerable<T>
    {
        T Head { get; }
        T Tail { get; }
        int Count { get; }
        T this[int index] { get; }
        IDeque<T> Unshift(T value);
        IDeque<T> Shift();
        IDeque<T> Push(T value);
        IDeque<T> Pop();
    }

    static partial class Deque
    {
        public static IDeque<T> Singleton<T>(T value) => Deque<T>.Empty.Unshift(value);

        public static string ToDelimitedString<T>(this IDeque<T> deque, string delimiter)
        {
            if (deque == null) throw new ArgumentNullException(nameof(deque));
            return string.Join(delimiter, deque);
        }

        public static int IndexOf<T>(this IDeque<T> deque, T item) =>
            IndexOf(deque, item, null);

        public static int IndexOf<T>(this IDeque<T> deque, T item, IEqualityComparer<T> comparer)
        {
            comparer = comparer ?? EqualityComparer<T>.Default;
            var index = 0;
            foreach (var e in deque)
            {
                if (comparer.Equals(e, item))
                    return index;
                index++;
            }
            return -1;
        }
    }

    sealed partial class Deque<T> : IDeque<T>, IList<T>
    {
        abstract class Dequelette : IEnumerable<T>
        {
            // ReSharper disable once MemberHidesStaticFromOuterClass
            // ReSharper disable once StaticMemberInGenericType
            public static readonly Dequelette Empty = new EmptyDequelette();

            sealed class EmptyDequelette : Dequelette
            {
                public override T Head { get { throw new InvalidOperationException(); } }
                public override T Tail { get { throw new InvalidOperationException(); } }
                public override int Count => 0;
                public override T this[int index] { get { throw new ArgumentOutOfRangeException(nameof(index)); } }
                public override Dequelette Unshift(T value) => new One(value);
                public override Dequelette Shift() { throw new InvalidOperationException(); }
                public override Dequelette Push(T value) => new One(value);
                public override Dequelette Pop() { throw new InvalidOperationException(); }
                public override IEnumerator<T> GetEnumerator() { yield break; }
            }

            public abstract T Head { get; }
            public abstract T Tail { get; }
            public abstract int Count { get; }
            public bool IsEmpty => Count == 0;
            public virtual bool IsFull => false;
            public abstract T this[int index] { get; }
            public abstract Dequelette Unshift(T value);
            public abstract Dequelette Shift();
            public abstract Dequelette Push(T value);
            public abstract Dequelette Pop();
            public abstract IEnumerator<T> GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            public override string ToString() => "[" + string.Join(", ", this.AsEnumerable()) + "]";
        }

        sealed class One : Dequelette
        {
            readonly T _a;

            public One(T a) { _a = a; }
            public override T Head => _a;
            public override T Tail => _a;
            public override int Count => 1;
            public override T this[int index] => _a;
            public override Dequelette Unshift(T value) => new Two(value, _a);
            public override Dequelette Shift() => Empty;
            public override Dequelette Push(T value) => new Two(_a, value);
            public override Dequelette Pop() => Empty;
            public override IEnumerator<T> GetEnumerator() { yield return _a; }
        }

        sealed class Two : Dequelette
        {
            public Two(T a, T b) { Head = a; Tail = b; }
            public override T Head { get; }
            public override T Tail { get; }
            public override int Count => 2;
            public override T this[int index] => index == 0 ? Head : Tail;
            public override Dequelette Unshift(T value) => new Three(value, Head, Tail);
            public override Dequelette Shift() => new One(Tail);
            public override Dequelette Push(T value) => new Three(Head, Tail, value);
            public override Dequelette Pop() => new One(Head);
            public override IEnumerator<T> GetEnumerator() { yield return Head;
                                                             yield return Tail; }
        }

        sealed class Three : Dequelette
        {
            readonly T _a; readonly T _b; readonly T _c;

            public Three(T a, T b, T c) { _a = a; _b = b; _c = c; }
            public override T Head => _a;
            public override T Tail => _c;
            public override int Count => 3;
            public override T this[int index] => index == 0 ? _a : index == 1 ? _b : _c;
            public override Dequelette Unshift(T value) => new Four(value, _a, _b, _c);
            public override Dequelette Shift() => new Two(_b, _c);
            public override Dequelette Push(T value) => new Four(_a, _b, _c, value);
            public override Dequelette Pop() => new Two(_a, _b);
            public override IEnumerator<T> GetEnumerator() { yield return _a;
                                                             yield return _b;
                                                             yield return _c; }
        }

        sealed class Four : Dequelette
        {
            readonly T _a; readonly T _b; readonly T _c; readonly T _d;

            public Four(T a, T b, T c, T d) { _a = a; _b = b; _c = c; _d = d; }
            public override T Head => _a;
            public override T Tail => _d;
            public override int Count => 4;
            public override bool IsFull => true;
            public override T this[int index] => index == 0 ? _a : index == 1 ? _b : index == 2 ? _c : _d;
            public override Dequelette Unshift(T value) { throw new InvalidOperationException(); }
            public override Dequelette Shift() => new Three(_b, _c, _d);
            public override Dequelette Push(T value) { throw new InvalidOperationException(); }
            public override Dequelette Pop() => new Three(_a, _b, _c);
            public override IEnumerator<T> GetEnumerator() { yield return _a;
                                                             yield return _b;
                                                             yield return _c;
                                                             yield return _d; }
        }

        public static readonly IDeque<T> Empty = new EmptyDeque();

        sealed class EmptyDeque : IDeque<T>
        {
            public T Head { get { throw new InvalidOperationException(); } }
            public T Tail { get { throw new InvalidOperationException(); } }
            public int Count => 0;
            public T this[int index] { get { throw new ArgumentOutOfRangeException(nameof(index)); } }
            public IDeque<T> Unshift(T value) => new Deque<T>(1, new One(value), Deque<Dequelette>.Empty, Dequelette.Empty);
            public IDeque<T> Shift() { throw new InvalidOperationException(); }
            public IDeque<T> Push(T value) => new Deque<T>(1, Dequelette.Empty, Deque<Dequelette>.Empty, new One(value));
            public IDeque<T> Pop() { throw new InvalidOperationException(); }
            public IEnumerator<T> GetEnumerator() { yield break; }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        readonly Dequelette _head;
        readonly IDeque<Dequelette> _middle;
        readonly Dequelette _tail;

        public Deque() : this(0, Dequelette.Empty, Deque<Dequelette>.Empty, Dequelette.Empty) {}

        Deque(int count, Dequelette head, IDeque<Dequelette> middle, Dequelette tail)
        {
            Count   = count;
            _head   = head;
            _middle = middle;
            _tail   = tail;
        }

        public T    Head => _head.Head;
        public T    Tail => _tail.Tail;
        public int  Count { get; }
        public bool IsEmpty => Count == 0;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                if (index < _head.Count)
                    return _head[index];

                index -= _head.Count;

                foreach (var d in _middle)
                {
                    if (index < d.Count)
                        return d[index];
                    index -= d.Count;
                }

                return _tail[index];
            }
        }

        public IDeque<T> Unshift(T value)
        {
            return _head.IsFull
                 ? new Deque<T>(Count + 1, new One(value), _middle.Unshift(_head), _tail)
                 : new Deque<T>(Count + 1, _head.Unshift(value), _middle, _tail);
        }

        public IDeque<T> Shift()
        {
            var head = _head.Shift();
            return head.IsEmpty
                 ? new Deque<T>(Count - 1, _middle.Head, _middle.Shift(), _tail)
                 : new Deque<T>(Count - 1, head, _middle, _tail);
        }

        public IDeque<T> Push(T value)
        {
            return _tail.IsFull
                 ? new Deque<T>(Count + 1, _head, _middle.Push(_tail), new One(value))
                 : new Deque<T>(Count + 1, _head, _middle, _tail.Push(value));
        }

        public IDeque<T> Pop()
        {
            var tail = _tail.Pop();
            return tail.IsEmpty
                 ? new Deque<T>(Count - 1, _head, _middle.Pop(), _middle.Tail)
                 : new Deque<T>(Count - 1, _head, _middle, tail);
        }

        public IEnumerator<T> GetEnumerator() =>
            _head.Concat(_middle.SelectMany(d => d)).Concat(_tail).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Contains(T item) => Contains(item, null);

        public bool Contains(T item, IEqualityComparer<T> comparer) =>
            ContainsCore(item, comparer ?? EqualityComparer<T>.Default);

        bool ContainsCore(T item, IEqualityComparer<T> comparer) =>
            this.Any(e => comparer.Equals(e, item));

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (arrayIndex + Count > array.Length) throw new ArgumentException("Destination array not long enough.");

            foreach (var item in this)
                array[arrayIndex++] = item;
        }

        static readonly T[] EmptyArray = new T[0];

        public T[] ToArray()
        {
            if (IsEmpty)
                return EmptyArray;
            var array = new T[Count];
            CopyTo(array, 0);
            return array;
        }

        public int IndexOf(T item) => this.IndexOf(item, comparer: null);

        bool ICollection<T>.IsReadOnly => true;

        void ICollection<T>.Add(T item) { throw ReadOnlyError(); }
        void ICollection<T>.Clear() { throw ReadOnlyError(); }
        bool ICollection<T>.Remove(T item) { throw ReadOnlyError(); }

        void IList<T>.Insert(int index, T item) { throw ReadOnlyError(); }
        void IList<T>.RemoveAt(int index) { throw ReadOnlyError(); }

        T IList<T>.this[int index]
        {
            get { return this[index]; }
            set { throw ReadOnlyError(); }
        }

        static NotSupportedException ReadOnlyError() => new NotSupportedException("Cannot modify a read-only list.");
    }
}
