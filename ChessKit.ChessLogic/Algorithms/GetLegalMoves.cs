using System.Collections.Generic;
using System.Linq;
using ChessKit.ChessLogic.Primitives;

namespace ChessKit.ChessLogic.Algorithms
{
    public static class GetLegalMoves
    {
        static List<GeneratedMove> InternalGetLegalMoves(this Position position)
        {
            var res = new List<GeneratedMove>(50);
            var turn = position.Core.Turn;
            for (var moveFrom = 0; moveFrom < 64; moveFrom++)
            {
                var moveFromSq = moveFrom + (moveFrom & ~7);
                var piece =(Piece) position.Core.Cells[moveFromSq];
                if (piece == 0) continue;
                if (piece.Color() != turn) continue;
                MoveGeneration.GenerateMoves(position.Core.Cells,
                    position.Core.WhiteKing, position.Core.BlackKing,
                    piece, moveFromSq, position.Core.EnPassant,
                    position.Core.CastlingAvailability, res);
            }
            return res;
        }
        static List<GeneratedMove> InternalGetLegalMoves(this Position position, int moveFrom)
        {
            var sideToMove = position.Core.Turn;
            var piece = (Piece)position.Core.Cells[moveFrom];
            if (piece == Piece.EmptyCell) return new List<GeneratedMove>();
            if (piece.Color() != sideToMove) return new List<GeneratedMove>();
            var res = new List<GeneratedMove>(28);
            MoveGeneration.GenerateMoves(position.Core.Cells,
                position.Core.WhiteKing, position.Core.BlackKing,
                piece, moveFrom, position.Core.EnPassant,
                position.Core.CastlingAvailability, res);
            return res;
        }

        public static List<LegalMove> GetLegalMovesFromSquare(this Position position, int fromSquare)
        {
            var makeMove = position.InternalGetLegalMoves(fromSquare);
            return makeMove.Select(
                m => position.ValidateLegal(new Move(m.From, m.To)))
                .ToList();
        }
        public static List<LegalMove> GetAllLegalMoves(this Position position)
        {
            var makeMove = position.InternalGetLegalMoves();
            return makeMove.Select(
                m => position.ValidateLegal(new Move(m.From, m.To)))
                .ToList();
        }
    }
}
