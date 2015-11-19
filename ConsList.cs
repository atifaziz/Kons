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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    static partial class ConsList
    {
        public static ConsList<T> Return<T>(T item) => ConsList<T>.Empty.Cons(item);

        public static ConsList<T> Cons<T>(T item1, T item2)                   => Return(item2).Cons(item1);
        public static ConsList<T> Cons<T>(T item1, T item2, T item3)          => Return(item3).Cons(item2).Cons(item1);
        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4) => Return(item4).Cons(item3).Cons(item2).Cons(item1);
        public static ConsList<T> Cons<T>(ConsList<T> source)                 => Cons(source.AsEnumerable());
        public static ConsList<T> Cons<T>(IEnumerable<T> source)              => source.Aggregate(ConsList<T>.Empty, (list, e) => list.Cons(e));

        public static ConsList<T> List<T>(params T[] items)
        {
            var result = ConsList<T>.Empty;
            for (var i = items.Length - 1; i >= 0; i--)
                result = result.Cons(items[i]);
            return result;
        }
    }

    sealed partial class ConsList<T> : ICollection<T>, IEquatable<ConsList<T>>
    {
        public static readonly ConsList<T> Empty = new ConsList<T>();

        readonly T _item;
        readonly ConsList<T> _next;

        ConsList() {}

        ConsList(T item, ConsList<T> tail)
        {
            if (tail == null) throw new ArgumentNullException(nameof(tail));
            _item = item;
            _next = tail;
            Count = _next.Count + 1;
        }

        public ConsList<T> Cons(T item) =>
            new ConsList<T>(item, this);

        public ConsList<T> Cons(IEnumerable<T> items) =>
            items.Aggregate(this, (current, item) => current.Cons(item));

        public Tuple<T, ConsList<T>> Cadr() => Cadr(Tuple.Create);

        public TResult Cadr<TResult>(Func<T, ConsList<T>, TResult> selector)
        {
            if (IsEmpty) throw new InvalidOperationException();
            return selector(_item, _next);
        }

        public bool IsEmpty => _next == null;

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
            foreach (var item in this)
                array[arrayIndex++] = item;
        }

        public int Count { get; private set; }
        bool ICollection<T>.IsReadOnly => true;

        void ICollection<T>.Add(T item) { throw ReadOnlyError(); }
        void ICollection<T>.Clear() { throw ReadOnlyError(); }
        bool ICollection<T>.Remove(T item) { throw ReadOnlyError(); }

        static NotSupportedException ReadOnlyError() => new NotSupportedException("Cannot modify a read-only list.");
    }

#if KONS_PUBLIC

    public partial class ConsList { }
    public partial class ConsList<T> { }

    #endif
}
