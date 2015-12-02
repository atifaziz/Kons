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
    // Difference (John Huges) List inspired from:
    // http://stackoverflow.com/a/2484281/6682

    public delegate ConsList<T> DList<T>(ConsList<T> list);

    public static class DList
    {
        public static DList<T> Empty<T>()                               => xs => xs;
        public static DList<T> Append<T>(this DList<T> xs, DList<T> ys) => tail => xs(ys(tail));
        public static DList<T> Singleton<T>(T x)                        => tail => ConsList.Cons(x, tail);
        public static DList<T> Cons<T>(T x, DList<T> xs)                => Singleton(x).Append(xs);
        public static DList<T> Snoc<T>(this DList<T> xs, T x)           => xs.Append(Singleton(x));
        public static ConsList<T> ToList<T>(this DList<T> hlist)        => hlist(ConsList<T>.Empty);
    }
}