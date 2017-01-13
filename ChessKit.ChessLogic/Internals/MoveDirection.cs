using System;

namespace ChessKit.ChessLogic.Internals
{
    /// <summary>Represents one of directions of moves piece can do </summary>
    [Immutable]
    public sealed class MoveDirection : IEquatable<MoveDirection>
    {
        internal MoveDirection(int dx, int dy, int count, bool takesThisWay, bool isSpecial = false)
        {
            CapturesThisWay = takesThisWay;
            IsSpecial = isSpecial;
            DeltaX = dx;
            DeltaY = dy;
            Count = count;
        }

        public bool IsSpecial { get; }
        public bool CapturesThisWay { get; }

        /// <summary>Delta X of the move</summary>
        public int DeltaX { get; }

        /// <summary>Delta Y of the move</summary>
        public int DeltaY { get; }

        /// <summary>Maximum count of moves in this direction </summary>
        public int Count { get; }

        public bool Equals(MoveDirection other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return IsSpecial.Equals(other.IsSpecial)
                   && CapturesThisWay.Equals(other.CapturesThisWay)
                   && DeltaX == other.DeltaX
                   && DeltaY == other.DeltaY && Count == other.Count;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is MoveDirection && Equals((MoveDirection) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = IsSpecial.GetHashCode();
                hashCode = (hashCode*397) ^ CapturesThisWay.GetHashCode();
                hashCode = (hashCode*397) ^ DeltaX;
                hashCode = (hashCode*397) ^ DeltaY;
                hashCode = (hashCode*397) ^ Count;
                return hashCode;
            }
        }

        public static bool operator ==(MoveDirection left, MoveDirection right) => Equals(left, right);
        public static bool operator !=(MoveDirection left, MoveDirection right) => !Equals(left, right);
    }
}