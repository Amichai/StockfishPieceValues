using System;
using ChessKit.ChessLogic.Primitives;

namespace ChessKit.ChessLogic
{
    public sealed class Move
    {
        public int FromCell { get; }
        public int ToCell { get; }
        public PieceType PromoteTo { get; }

        public Move(int fromCell, int toCell, PieceType promoteTo = PieceType.None)
        {
            FromCell = fromCell;
            ToCell = toCell;
            PromoteTo = promoteTo;
        }
        public override string ToString()
        {
            string s = $"{FromCell.ToCoordinateString()}-{ToCell.ToCoordinateString()}";
            return PromoteTo != PieceType.None 
                ? $"{s}={PromoteTo.With(Color.White).GetSymbol()}" 
                : s;
        }

        public static Move Parse(string canString)
        {
            if (string.IsNullOrEmpty(canString))
                throw new ArgumentException(
                    "should not be null or empty", 
                    nameof(canString));

            if (canString.Length == 5)
                return new Move(
                    canString.Substring(0, 2).ParseCoordinate(),
                    canString.Substring(3, 2).ParseCoordinate());
            if (canString.Length != 7)
                throw new ArgumentOutOfRangeException(nameof(canString));
            Piece piece;
            if (!canString[6].TryParsePiece(out piece))
                throw new ArgumentOutOfRangeException(nameof(canString));
            return new Move(
                canString.Substring(0, 2).ParseCoordinate(),
                canString.Substring(3, 2).ParseCoordinate(),
                piece.PieceType());
        }
    }
}