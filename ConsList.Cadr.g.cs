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
