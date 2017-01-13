using System;
using ChessKit.ChessLogic.Primitives;

// ReSharper disable IntroduceOptionalParameters.Global

namespace ChessKit.ChessLogic
{
    internal sealed class GeneratedMove : IEquatable<GeneratedMove>
    {
        internal GeneratedMove(int from, int to, MoveAnnotations annotations)
        {
            To = to;
            From = from;
            Annotations = annotations;
        }

        public int From { get; }
        public int To { get; }
        internal MoveAnnotations Annotations { get; }

        public override string ToString()
            => $"{From.ToCoordinateString()}-{To.ToCoordinateString()}";

        #region ' Equality '

        public bool Equals(GeneratedMove other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return From.Equals(other.From)
                   && To.Equals(other.To);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((GeneratedMove) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = From.GetHashCode();
                hashCode = (hashCode*397) ^ To.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(GeneratedMove left, GeneratedMove right) => Equals(left, right);

        public static bool operator !=(GeneratedMove left, GeneratedMove right) => !Equals(left, right);

        #endregion
    }
}