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

    partial class ConsList
    {
        public static ConsList<T> Cons<T>(T item1, T item2) =>
            Cons(item1, item2, ConsList<T>.Empty);
        public static ConsList<T> Cons<T>(T item1, T item2, ConsList<T> list) =>
            list.Prepend(item2).Prepend(item1);

        public static ConsList<T> Cons<T>(T item1, T item2, T item3) =>
            Cons(item1, item2, item3, ConsList<T>.Empty);
        public static ConsList<T> Cons<T>(T item1, T item2, T item3, ConsList<T> list) =>
            list.Prepend(item3).Prepend(item2).Prepend(item1);

        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4) =>
            Cons(item1, item2, item3, item4, ConsList<T>.Empty);
        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, ConsList<T> list) =>
            list.Prepend(item4).Prepend(item3).Prepend(item2).Prepend(item1);

        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5) =>
            Cons(item1, item2, item3, item4, item5, ConsList<T>.Empty);
        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, ConsList<T> list) =>
            list.Prepend(item5).Prepend(item4).Prepend(item3).Prepend(item2).Prepend(item1);

        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6) =>
            Cons(item1, item2, item3, item4, item5, item6, ConsList<T>.Empty);
        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, ConsList<T> list) =>
            list.Prepend(item6).Prepend(item5).Prepend(item4).Prepend(item3).Prepend(item2).Prepend(item1);

        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7) =>
            Cons(item1, item2, item3, item4, item5, item6, item7, ConsList<T>.Empty);
        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, ConsList<T> list) =>
            list.Prepend(item7).Prepend(item6).Prepend(item5).Prepend(item4).Prepend(item3).Prepend(item2).Prepend(item1);

        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8) =>
            Cons(item1, item2, item3, item4, item5, item6, item7, item8, ConsList<T>.Empty);
        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, ConsList<T> list) =>
            list.Prepend(item8).Prepend(item7).Prepend(item6).Prepend(item5).Prepend(item4).Prepend(item3).Prepend(item2).Prepend(item1);

        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, T item9) =>
            Cons(item1, item2, item3, item4, item5, item6, item7, item8, item9, ConsList<T>.Empty);
        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, T item9, ConsList<T> list) =>
            list.Prepend(item9).Prepend(item8).Prepend(item7).Prepend(item6).Prepend(item5).Prepend(item4).Prepend(item3).Prepend(item2).Prepend(item1);

        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, T item9, T item10) =>
            Cons(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, ConsList<T>.Empty);
        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, T item9, T item10, ConsList<T> list) =>
            list.Prepend(item10).Prepend(item9).Prepend(item8).Prepend(item7).Prepend(item6).Prepend(item5).Prepend(item4).Prepend(item3).Prepend(item2).Prepend(item1);

        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, T item9, T item10, T item11) =>
            Cons(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, ConsList<T>.Empty);
        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, T item9, T item10, T item11, ConsList<T> list) =>
            list.Prepend(item11).Prepend(item10).Prepend(item9).Prepend(item8).Prepend(item7).Prepend(item6).Prepend(item5).Prepend(item4).Prepend(item3).Prepend(item2).Prepend(item1);

        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, T item9, T item10, T item11, T item12) =>
            Cons(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, ConsList<T>.Empty);
        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, T item9, T item10, T item11, T item12, ConsList<T> list) =>
            list.Prepend(item12).Prepend(item11).Prepend(item10).Prepend(item9).Prepend(item8).Prepend(item7).Prepend(item6).Prepend(item5).Prepend(item4).Prepend(item3).Prepend(item2).Prepend(item1);

        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, T item9, T item10, T item11, T item12, T item13) =>
            Cons(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, ConsList<T>.Empty);
        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, T item9, T item10, T item11, T item12, T item13, ConsList<T> list) =>
            list.Prepend(item13).Prepend(item12).Prepend(item11).Prepend(item10).Prepend(item9).Prepend(item8).Prepend(item7).Prepend(item6).Prepend(item5).Prepend(item4).Prepend(item3).Prepend(item2).Prepend(item1);

        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, T item9, T item10, T item11, T item12, T item13, T item14) =>
            Cons(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14, ConsList<T>.Empty);
        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, T item9, T item10, T item11, T item12, T item13, T item14, ConsList<T> list) =>
            list.Prepend(item14).Prepend(item13).Prepend(item12).Prepend(item11).Prepend(item10).Prepend(item9).Prepend(item8).Prepend(item7).Prepend(item6).Prepend(item5).Prepend(item4).Prepend(item3).Prepend(item2).Prepend(item1);

        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, T item9, T item10, T item11, T item12, T item13, T item14, T item15) =>
            Cons(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14, item15, ConsList<T>.Empty);
        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, T item9, T item10, T item11, T item12, T item13, T item14, T item15, ConsList<T> list) =>
            list.Prepend(item15).Prepend(item14).Prepend(item13).Prepend(item12).Prepend(item11).Prepend(item10).Prepend(item9).Prepend(item8).Prepend(item7).Prepend(item6).Prepend(item5).Prepend(item4).Prepend(item3).Prepend(item2).Prepend(item1);

        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, T item9, T item10, T item11, T item12, T item13, T item14, T item15, T item16) =>
            Cons(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14, item15, item16, ConsList<T>.Empty);
        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, T item9, T item10, T item11, T item12, T item13, T item14, T item15, T item16, ConsList<T> list) =>
            list.Prepend(item16).Prepend(item15).Prepend(item14).Prepend(item13).Prepend(item12).Prepend(item11).Prepend(item10).Prepend(item9).Prepend(item8).Prepend(item7).Prepend(item6).Prepend(item5).Prepend(item4).Prepend(item3).Prepend(item2).Prepend(item1);

        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, T item9, T item10, T item11, T item12, T item13, T item14, T item15, T item16, T item17) =>
            Cons(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14, item15, item16, item17, ConsList<T>.Empty);
        public static ConsList<T> Cons<T>(T item1, T item2, T item3, T item4, T item5, T item6, T item7, T item8, T item9, T item10, T item11, T item12, T item13, T item14, T item15, T item16, T item17, ConsList<T> list) =>
            list.Prepend(item17).Prepend(item16).Prepend(item15).Prepend(item14).Prepend(item13).Prepend(item12).Prepend(item11).Prepend(item10).Prepend(item9).Prepend(item8).Prepend(item7).Prepend(item6).Prepend(item5).Prepend(item4).Prepend(item3).Prepend(item2).Prepend(item1);

    }

    partial class ConsList<T>
    {
        public TResult Cadr<TResult>(Func<T, T, ConsList<T>, TResult> selector)
            => Of(2, null, $"List has too few items ({Count}) when at least {2} are expected.")
                     .Cadr((a, ar)
                => ar.Cadr((b, br) => selector(a, b, br)));

        public TResult Cadr<TResult>(Func<T, T, T, ConsList<T>, TResult> selector)
            => Of(3, null, $"List has too few items ({Count}) when at least {3} are expected.")
                     .Cadr((a, ar)
                => ar.Cadr((b, br)
                => br.Cadr((c, cr) => selector(a, b, c, cr))));

        public TResult Cadr<TResult>(Func<T, T, T, T, ConsList<T>, TResult> selector)
            => Of(4, null, $"List has too few items ({Count}) when at least {4} are expected.")
                     .Cadr((a, ar)
                => ar.Cadr((b, br)
                => br.Cadr((c, cr)
                => cr.Cadr((d, dr) => selector(a, b, c, d, dr)))));

        public TResult Cadr<TResult>(Func<T, T, T, T, T, ConsList<T>, TResult> selector)
            => Of(5, null, $"List has too few items ({Count}) when at least {5} are expected.")
                     .Cadr((a, ar)
                => ar.Cadr((b, br)
                => br.Cadr((c, cr)
                => cr.Cadr((d, dr)
                => dr.Cadr((e, er) => selector(a, b, c, d, e, er))))));

        public TResult Cadr<TResult>(Func<T, T, T, T, T, T, ConsList<T>, TResult> selector)
            => Of(6, null, $"List has too few items ({Count}) when at least {6} are expected.")
                     .Cadr((a, ar)
                => ar.Cadr((b, br)
                => br.Cadr((c, cr)
                => cr.Cadr((d, dr)
                => dr.Cadr((e, er)
                => er.Cadr((f, fr) => selector(a, b, c, d, e, f, fr)))))));

        public TResult Cadr<TResult>(Func<T, T, T, T, T, T, T, ConsList<T>, TResult> selector)
            => Of(7, null, $"List has too few items ({Count}) when at least {7} are expected.")
                     .Cadr((a, ar)
                => ar.Cadr((b, br)
                => br.Cadr((c, cr)
                => cr.Cadr((d, dr)
                => dr.Cadr((e, er)
                => er.Cadr((f, fr)
                => fr.Cadr((g, gr) => selector(a, b, c, d, e, f, g, gr))))))));

        public TResult Cadr<TResult>(Func<T, T, T, T, T, T, T, T, ConsList<T>, TResult> selector)
            => Of(8, null, $"List has too few items ({Count}) when at least {8} are expected.")
                     .Cadr((a, ar)
                => ar.Cadr((b, br)
                => br.Cadr((c, cr)
                => cr.Cadr((d, dr)
                => dr.Cadr((e, er)
                => er.Cadr((f, fr)
                => fr.Cadr((g, gr)
                => gr.Cadr((h, hr) => selector(a, b, c, d, e, f, g, h, hr)))))))));

        public TResult Cadr<TResult>(Func<T, T, T, T, T, T, T, T, T, ConsList<T>, TResult> selector)
            => Of(9, null, $"List has too few items ({Count}) when at least {9} are expected.")
                     .Cadr((a, ar)
                => ar.Cadr((b, br)
                => br.Cadr((c, cr)
                => cr.Cadr((d, dr)
                => dr.Cadr((e, er)
                => er.Cadr((f, fr)
                => fr.Cadr((g, gr)
                => gr.Cadr((h, hr)
                => hr.Cadr((i, ir) => selector(a, b, c, d, e, f, g, h, i, ir))))))))));

        public TResult Cadr<TResult>(Func<T, T, T, T, T, T, T, T, T, T, ConsList<T>, TResult> selector)
            => Of(10, null, $"List has too few items ({Count}) when at least {10} are expected.")
                     .Cadr((a, ar)
                => ar.Cadr((b, br)
                => br.Cadr((c, cr)
                => cr.Cadr((d, dr)
                => dr.Cadr((e, er)
                => er.Cadr((f, fr)
                => fr.Cadr((g, gr)
                => gr.Cadr((h, hr)
                => hr.Cadr((i, ir)
                => ir.Cadr((j, jr) => selector(a, b, c, d, e, f, g, h, i, j, jr)))))))))));

        public TResult Cadr<TResult>(Func<T, T, T, T, T, T, T, T, T, T, T, ConsList<T>, TResult> selector)
            => Of(11, null, $"List has too few items ({Count}) when at least {11} are expected.")
                     .Cadr((a, ar)
                => ar.Cadr((b, br)
                => br.Cadr((c, cr)
                => cr.Cadr((d, dr)
                => dr.Cadr((e, er)
                => er.Cadr((f, fr)
                => fr.Cadr((g, gr)
                => gr.Cadr((h, hr)
                => hr.Cadr((i, ir)
                => ir.Cadr((j, jr)
                => jr.Cadr((k, kr) => selector(a, b, c, d, e, f, g, h, i, j, k, kr))))))))))));

        public TResult Cadr<TResult>(Func<T, T, T, T, T, T, T, T, T, T, T, T, ConsList<T>, TResult> selector)
            => Of(12, null, $"List has too few items ({Count}) when at least {12} are expected.")
                     .Cadr((a, ar)
                => ar.Cadr((b, br)
                => br.Cadr((c, cr)
                => cr.Cadr((d, dr)
                => dr.Cadr((e, er)
                => er.Cadr((f, fr)
                => fr.Cadr((g, gr)
                => gr.Cadr((h, hr)
                => hr.Cadr((i, ir)
                => ir.Cadr((j, jr)
                => jr.Cadr((k, kr)
                => kr.Cadr((l, lr) => selector(a, b, c, d, e, f, g, h, i, j, k, l, lr)))))))))))));

        public TResult Cadr<TResult>(Func<T, T, T, T, T, T, T, T, T, T, T, T, T, ConsList<T>, TResult> selector)
            => Of(13, null, $"List has too few items ({Count}) when at least {13} are expected.")
                     .Cadr((a, ar)
                => ar.Cadr((b, br)
                => br.Cadr((c, cr)
                => cr.Cadr((d, dr)
                => dr.Cadr((e, er)
                => er.Cadr((f, fr)
                => fr.Cadr((g, gr)
                => gr.Cadr((h, hr)
                => hr.Cadr((i, ir)
                => ir.Cadr((j, jr)
                => jr.Cadr((k, kr)
                => kr.Cadr((l, lr)
                => lr.Cadr((m, mr) => selector(a, b, c, d, e, f, g, h, i, j, k, l, m, mr))))))))))))));

        public TResult Cadr<TResult>(Func<T, T, T, T, T, T, T, T, T, T, T, T, T, T, ConsList<T>, TResult> selector)
            => Of(14, null, $"List has too few items ({Count}) when at least {14} are expected.")
                     .Cadr((a, ar)
                => ar.Cadr((b, br)
                => br.Cadr((c, cr)
                => cr.Cadr((d, dr)
                => dr.Cadr((e, er)
                => er.Cadr((f, fr)
                => fr.Cadr((g, gr)
                => gr.Cadr((h, hr)
                => hr.Cadr((i, ir)
                => ir.Cadr((j, jr)
                => jr.Cadr((k, kr)
                => kr.Cadr((l, lr)
                => lr.Cadr((m, mr)
                => mr.Cadr((n, nr) => selector(a, b, c, d, e, f, g, h, i, j, k, l, m, n, nr)))))))))))))));

        public TResult Cadr<TResult>(Func<T, T, T, T, T, T, T, T, T, T, T, T, T, T, T, ConsList<T>, TResult> selector)
            => Of(15, null, $"List has too few items ({Count}) when at least {15} are expected.")
                     .Cadr((a, ar)
                => ar.Cadr((b, br)
                => br.Cadr((c, cr)
                => cr.Cadr((d, dr)
                => dr.Cadr((e, er)
                => er.Cadr((f, fr)
                => fr.Cadr((g, gr)
                => gr.Cadr((h, hr)
                => hr.Cadr((i, ir)
                => ir.Cadr((j, jr)
                => jr.Cadr((k, kr)
                => kr.Cadr((l, lr)
                => lr.Cadr((m, mr)
                => mr.Cadr((n, nr)
                => nr.Cadr((o, or) => selector(a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, or))))))))))))))));

    }
}
