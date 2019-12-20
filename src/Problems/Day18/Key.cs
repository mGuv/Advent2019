using System;

namespace Advent2019.Problems.Day18
{
    [Flags]
    public enum Key
    {
        None = 0b0,
        All = Key.a | Key.b | Key.c | Key.d | Key.e | Key.f | Key.g | Key.h | Key.i | Key.j | Key.k | Key.l | Key.m | Key.n | Key.o | Key.p | Key.q | Key.r | Key.s | Key.t | Key.u | Key.v | Key.w | Key.x | Key.y | Key.z,
        a = 0b1,
        b = Key.a << 1,
        c = Key.b << 1,
        d = Key.c << 1,
        e = Key.d << 1,
        f = Key.e << 1,
        g = Key.f << 1,
        h = Key.g << 1,
        i = Key.h << 1,
        j = Key.i << 1,
        k = Key.j << 1,
        l = Key.k << 1,
        m = Key.l << 1,
        n = Key.m << 1,
        o = Key.n << 1,
        p = Key.o << 1,
        q = Key.p << 1,
        r = Key.q << 1,
        s = Key.r << 1,
        t = Key.s << 1,
        u = Key.t << 1,
        v = Key.u << 1,
        w = Key.v << 1,
        x = Key.w << 1,
        y = Key.x << 1,
        z = Key.y << 1
    }
}
