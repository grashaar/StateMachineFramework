using System;
using System.Collections.Generic;

namespace StateMachineFramework
{
    public readonly struct Direction<T> : IEquatable<Direction<T>>, IEqualityComparer<Direction<T>>
    {
        public readonly T From;
        public readonly T To;

        public Direction(T from, T to)
        {
            this.From = from;
            this.To = to;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = (int)2166136261;
                hash = (hash * 16777619) ^ this.From.GetHashCode();
                hash = (hash * 16777619) ^ this.To.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Direction<T> other)
                return this.From.Equals(other.From) && this.To.Equals(other.To);

            return false;
        }

        public bool Equals(Direction<T> other)
            => this.From.Equals(other.From) && this.To.Equals(other.To);

        public void Deconstruct(out T from, out T to)
        {
            from = this.From;
            to = this.To;
        }

        public override string ToString()
            => $"({this.From}, {this.To})";

        public bool Equals(Direction<T> a, Direction<T> b)
            => a.From.Equals(b.From) && a.To.Equals(b.To);

        public int GetHashCode(Direction<T> obj)
            => obj.GetHashCode();

        public static implicit operator Direction<T>(in (T from, T to) value)
            => new Direction<T>(value.from, value.to);

        public static bool operator ==(in Direction<T> lhs, in Direction<T> rhs)
            => lhs.From.Equals(rhs.From) && lhs.To.Equals(rhs.To);

        public static bool operator !=(in Direction<T> lhs, in Direction<T> rhs)
            => !lhs.From.Equals(rhs.From) || !lhs.To.Equals(rhs.To);
    }
}
