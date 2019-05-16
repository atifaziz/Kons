#region Copyright (c) 2013 Atif Aziz. All rights reserved.
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
    #region Imports

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    #endregion

    // ReSharper disable PartialTypeWithSinglePart

    static partial class ConsList
    {
        public static ConsList<T> Cons<T>(T item) => ConsList<T>.Empty.Prepend(item);
        public static ConsList<T> Cons<T>(T item, ConsList<T> list) => list.Prepend(item);

        public static ConsList<T> Cons<T>(params T[] items)
        {
            var result = ConsList<T>.Empty;
            for (var i = items.Length - 1; i >= 0; i--)
                result = result.Prepend(items[i]);
            return result;
        }

        public static ConsList<T> From<T>(IList<T> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            var result = ConsList<T>.Empty;
            for (var i = list.Count - 1; i >= 0; i--)
                result = result.Prepend(list[i]);
            return result;
        }

        public static ConsList<T> From<T>(IEnumerable<T> source)
            => source is null ? throw new ArgumentNullException(nameof(source))
             : source is T[] array ? Cons(array)
             : source is IList<T> list ? From(list)
             : From(source.ToList());

        public static (ConsList<T> TrueList, ConsList<T> FalseList)
            Partition<T>(this ConsList<T> list,
                         Func<T, bool> predicate) =>
            list.Partition(predicate, ValueTuple.Create);

        public static TResult
            Partition<T, TResult>(
                this ConsList<T> list,
                Func<T, bool> predicate,
                Func<ConsList<T>, ConsList<T>, TResult> resultSelector)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

            List<T> ts = null, fs = null;

            foreach (var item in list)
            {
                ref var lst = ref predicate(item) ? ref ts : ref fs;
                if (lst == null)
                    lst = new List<T>();
                lst.Add(item);
            }

            return resultSelector(ts is List<T> tr ? From(tr) : ConsList<T>.Empty,
                                  fs is List<T> fr ? From(fr) : ConsList<T>.Empty);
        }

        public static (ConsList<T>, ConsList<T>)
            CadrWhile<T>(this ConsList<T> list,
                         Func<T, bool> predicate) =>
            list.CadrWhile(predicate, ValueTuple.Create);

        public static (ConsList<T>, ConsList<T>)
            CadrWhile<T>(this ConsList<T> list,
                         Func<T, int, bool> predicate) =>
            list.CadrWhile(predicate, ValueTuple.Create);

        public static TResult
            CadrWhile<T, TResult>(
                this ConsList<T> list,
                Func<T, bool> predicate,
                Func<ConsList<T>, ConsList<T>, TResult> resultSelector) =>
            list.CadrWhile((e, i) => predicate(e), resultSelector);

        public static TResult
            CadrWhile<T, TResult>(
                this ConsList<T> list,
                Func<T, int, bool> predicate,
                Func<ConsList<T>, ConsList<T>, TResult> resultSelector)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

            List<T> cars = null;

            foreach (var item in list.TakeWhile(predicate))
            {
                (cars ?? (cars = new List<T>())).Add(item);
                list = list.Cdr;
            }

            return resultSelector(cars is List<T> hs ? From(hs) : ConsList<T>.Empty, list);
        }
    }

    [DebuggerDisplay("Count = {" + nameof(Count) + "}")]
    sealed partial class ConsList<T> :
        IEquatable<ConsList<T>>,
        IReadOnlyCollection<T>,
        ICollection<T>
    {
        public static readonly ConsList<T> Empty = new ConsList<T>();

        readonly T _item;
        readonly ConsList<T> _next;

        ConsList() {}

        ConsList(T item, ConsList<T> tail)
        {
            _next = tail ?? throw new ArgumentNullException(nameof(tail));
            _item = item;
            Count = _next.Count + 1;
        }

        public int Count { get; }
        public bool IsEmpty => _next == null;

        public ConsList<T> Prepend(T item) =>
            new ConsList<T>(item, this);

        public ConsList<T> PrependAll(IEnumerable<T> items) =>
            items.Aggregate(this, (current, item) => current.Prepend(item));

        public ConsList<T> Concat(ConsList<T> list)
            => list.IsEmpty ? this
             : IsEmpty      ? list
             : this.Reverse().Aggregate(list, (a, e) => a.Prepend(e));

        ConsList<T> NonEmpty => Of(1, null, "List is empty.");

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        ConsList<T> Of(int min, int? max, string message = null)
        {
            if (Count < min || Count > max) throw new InvalidOperationException(message);
            return this;
        }

        public (T Car, ConsList<T> Cdr) Cadr() => (Car, Cdr);
        public TResult Cadr<TResult>(Func<T, ConsList<T>, TResult> selector) => selector(Car, Cdr);

        public void Deconstruct(out T car, out ConsList<T> cdr, out int count) =>
            ((car, cdr), count) = (Count >= 1 ? Cadr() : (default, Empty), Count);

        public T Car => NonEmpty._item;
        public ConsList<T> Cdr => NonEmpty._next;

        public override bool Equals(object obj) => Equals(obj as ConsList<T>);

        public bool Equals(ConsList<T> other) =>
            other != null
            && EqualityComparer<T>.Default.Equals(_item, other._item)
            && Equals(_next, other._next);

        public override int GetHashCode() =>
            unchecked ((EqualityComparer<T>.Default.GetHashCode(_item) * 397) ^ (_next?.GetHashCode() ?? 0));

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<T> GetEnumerator()
        {
            for (var current = this; !current.IsEmpty; current = current._next)
                yield return current._item;
        }

        bool ICollection<T>.Contains(T item) =>
            this.Any(e => EqualityComparer<T>.Default.Equals(e, item));

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

        bool ICollection<T>.IsReadOnly => true;

        void ICollection<T>.Add(T item) { throw ReadOnlyError(); }
        void ICollection<T>.Clear() { throw ReadOnlyError(); }
        bool ICollection<T>.Remove(T item) { throw ReadOnlyError(); }

        static NotSupportedException ReadOnlyError() => new NotSupportedException("Cannot modify a read-only list.");
    }
}
