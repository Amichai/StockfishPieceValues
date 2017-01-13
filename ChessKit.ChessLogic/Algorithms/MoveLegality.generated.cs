/* This code is auto-generated! 
 * It is strongly adviced not to change it manually! */
using ChessKit.ChessLogic.Primitives;
using static ChessKit.ChessLogic.Primitives.MoveAnnotations;

namespace ChessKit.ChessLogic.Algorithms
{
    static partial class MoveLegality
    {
        private static MoveAnnotations ValidateWhiteBishopMove(byte[] cells, int fromSquare, int toSquare)
        {
            var dx = toSquare - fromSquare;
            if (dx % 17 == 0)
            {
                var steps = dx / 17;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + 17; (i & 0x88) == 0; i += 17)
                        if (i == toSquare) return Bishop;
                        else if (cells[i] != 0)
                            return Bishop | DoesNotJump;
            }
            if (dx % -15 == 0)
            {
                var steps = dx / -15;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + -15; (i & 0x88) == 0; i += -15)
                        if (i == toSquare) return Bishop;
                        else if (cells[i] != 0)
                            return Bishop | DoesNotJump;
            }
            if (dx % -17 == 0)
            {
                var steps = dx / -17;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + -17; (i & 0x88) == 0; i += -17)
                        if (i == toSquare) return Bishop;
                        else if (cells[i] != 0)
                            return Bishop | DoesNotJump;
            }
            if (dx % 15 == 0)
            {
                var steps = dx / 15;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + 15; (i & 0x88) == 0; i += 15)
                        if (i == toSquare) return Bishop;
                        else if (cells[i] != 0)
                            return Bishop | DoesNotJump;
            }
            return Bishop | DoesNotMoveThisWay;
        }
        private static MoveAnnotations ValidateWhiteKnightMove(int fromSquare, int toSquare)
        {
            var dx = toSquare - fromSquare;
            switch (dx)
            {
                case 33: return Knight;
                case 31: return Knight;
                case -31: return Knight;
                case -33: return Knight;
                case 18: return Knight;
                case 14: return Knight;
                case -14: return Knight;
                case -18: return Knight;
            }
            return Knight | DoesNotMoveThisWay;
        }
        private static MoveAnnotations ValidateWhiteRookMove(byte[] cells, int fromSquare, int toSquare)
        {
            var dx = toSquare - fromSquare;
            if (dx % 16 == 0)
            {
                var steps = dx / 16;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + 16; (i & 0x88) == 0; i += 16)
                        if (i == toSquare) return Rook;
                        else if (cells[i] != 0)
                            return Rook | DoesNotJump;
            }
            if (dx % 1 == 0)
            {
                var steps = dx / 1;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + 1; (i & 0x88) == 0; i += 1)
                        if (i == toSquare) return Rook;
                        else if (cells[i] != 0)
                            return Rook | DoesNotJump;
            }
            if (dx % -16 == 0)
            {
                var steps = dx / -16;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + -16; (i & 0x88) == 0; i += -16)
                        if (i == toSquare) return Rook;
                        else if (cells[i] != 0)
                            return Rook | DoesNotJump;
            }
            if (dx % -1 == 0)
            {
                var steps = dx / -1;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + -1; (i & 0x88) == 0; i += -1)
                        if (i == toSquare) return Rook;
                        else if (cells[i] != 0)
                            return Rook | DoesNotJump;
            }
            return Rook | DoesNotMoveThisWay;
        }
        private static MoveAnnotations ValidateWhiteQueenMove(byte[] cells, int fromSquare, int toSquare)
        {
            var dx = toSquare - fromSquare;
            if (dx % 16 == 0)
            {
                var steps = dx / 16;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + 16; (i & 0x88) == 0; i += 16)
                        if (i == toSquare) return Queen;
                        else if (cells[i] != 0)
                            return Queen | DoesNotJump;
            }
            if (dx % 1 == 0)
            {
                var steps = dx / 1;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + 1; (i & 0x88) == 0; i += 1)
                        if (i == toSquare) return Queen;
                        else if (cells[i] != 0)
                            return Queen | DoesNotJump;
            }
            if (dx % -16 == 0)
            {
                var steps = dx / -16;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + -16; (i & 0x88) == 0; i += -16)
                        if (i == toSquare) return Queen;
                        else if (cells[i] != 0)
                            return Queen | DoesNotJump;
            }
            if (dx % -1 == 0)
            {
                var steps = dx / -1;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + -1; (i & 0x88) == 0; i += -1)
                        if (i == toSquare) return Queen;
                        else if (cells[i] != 0)
                            return Queen | DoesNotJump;
            }
            if (dx % 17 == 0)
            {
                var steps = dx / 17;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + 17; (i & 0x88) == 0; i += 17)
                        if (i == toSquare) return Queen;
                        else if (cells[i] != 0)
                            return Queen | DoesNotJump;
            }
            if (dx % -15 == 0)
            {
                var steps = dx / -15;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + -15; (i & 0x88) == 0; i += -15)
                        if (i == toSquare) return Queen;
                        else if (cells[i] != 0)
                            return Queen | DoesNotJump;
            }
            if (dx % -17 == 0)
            {
                var steps = dx / -17;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + -17; (i & 0x88) == 0; i += -17)
                        if (i == toSquare) return Queen;
                        else if (cells[i] != 0)
                            return Queen | DoesNotJump;
            }
            if (dx % 15 == 0)
            {
                var steps = dx / 15;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + 15; (i & 0x88) == 0; i += 15)
                        if (i == toSquare) return Queen;
                        else if (cells[i] != 0)
                            return Queen | DoesNotJump;
            }
            return Queen | DoesNotMoveThisWay;
        }
        private static MoveAnnotations ValidateWhiteKingMove(int fromSquare, int toSquare)
        {
            var dx = toSquare - fromSquare;
            switch (dx)
            {
                case 16: return King;
                case 17: return King;
                case 1: return King;
                case -15: return King;
                case -16: return King;
                case -17: return King;
                case -1: return King;
                case 15: return King;
            }
            return King | DoesNotMoveThisWay;
        }
        private static MoveAnnotations ValidateBlackBishopMove(byte[] cells, int fromSquare, int toSquare)
        {
            var dx = toSquare - fromSquare;
            if (dx % 17 == 0)
            {
                var steps = dx / 17;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + 17; (i & 0x88) == 0; i += 17)
                        if (i == toSquare) return Bishop;
                        else if (cells[i] != 0)
                            return Bishop | DoesNotJump;
            }
            if (dx % -15 == 0)
            {
                var steps = dx / -15;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + -15; (i & 0x88) == 0; i += -15)
                        if (i == toSquare) return Bishop;
                        else if (cells[i] != 0)
                            return Bishop | DoesNotJump;
            }
            if (dx % -17 == 0)
            {
                var steps = dx / -17;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + -17; (i & 0x88) == 0; i += -17)
                        if (i == toSquare) return Bishop;
                        else if (cells[i] != 0)
                            return Bishop | DoesNotJump;
            }
            if (dx % 15 == 0)
            {
                var steps = dx / 15;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + 15; (i & 0x88) == 0; i += 15)
                        if (i == toSquare) return Bishop;
                        else if (cells[i] != 0)
                            return Bishop | DoesNotJump;
            }
            return Bishop | DoesNotMoveThisWay;
        }
        private static MoveAnnotations ValidateBlackKnightMove(int fromSquare, int toSquare)
        {
            var dx = toSquare - fromSquare;
            switch (dx)
            {
                case 33: return Knight;
                case 31: return Knight;
                case -31: return Knight;
                case -33: return Knight;
                case 18: return Knight;
                case 14: return Knight;
                case -14: return Knight;
                case -18: return Knight;
            }
            return Knight | DoesNotMoveThisWay;
        }
        private static MoveAnnotations ValidateBlackRookMove(byte[] cells, int fromSquare, int toSquare)
        {
            var dx = toSquare - fromSquare;
            if (dx % 16 == 0)
            {
                var steps = dx / 16;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + 16; (i & 0x88) == 0; i += 16)
                        if (i == toSquare) return Rook;
                        else if (cells[i] != 0)
                            return Rook | DoesNotJump;
            }
            if (dx % 1 == 0)
            {
                var steps = dx / 1;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + 1; (i & 0x88) == 0; i += 1)
                        if (i == toSquare) return Rook;
                        else if (cells[i] != 0)
                            return Rook | DoesNotJump;
            }
            if (dx % -16 == 0)
            {
                var steps = dx / -16;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + -16; (i & 0x88) == 0; i += -16)
                        if (i == toSquare) return Rook;
                        else if (cells[i] != 0)
                            return Rook | DoesNotJump;
            }
            if (dx % -1 == 0)
            {
                var steps = dx / -1;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + -1; (i & 0x88) == 0; i += -1)
                        if (i == toSquare) return Rook;
                        else if (cells[i] != 0)
                            return Rook | DoesNotJump;
            }
            return Rook | DoesNotMoveThisWay;
        }
        private static MoveAnnotations ValidateBlackQueenMove(byte[] cells, int fromSquare, int toSquare)
        {
            var dx = toSquare - fromSquare;
            if (dx % 16 == 0)
            {
                var steps = dx / 16;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + 16; (i & 0x88) == 0; i += 16)
                        if (i == toSquare) return Queen;
                        else if (cells[i] != 0)
                            return Queen | DoesNotJump;
            }
            if (dx % 1 == 0)
            {
                var steps = dx / 1;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + 1; (i & 0x88) == 0; i += 1)
                        if (i == toSquare) return Queen;
                        else if (cells[i] != 0)
                            return Queen | DoesNotJump;
            }
            if (dx % -16 == 0)
            {
                var steps = dx / -16;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + -16; (i & 0x88) == 0; i += -16)
                        if (i == toSquare) return Queen;
                        else if (cells[i] != 0)
                            return Queen | DoesNotJump;
            }
            if (dx % -1 == 0)
            {
                var steps = dx / -1;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + -1; (i & 0x88) == 0; i += -1)
                        if (i == toSquare) return Queen;
                        else if (cells[i] != 0)
                            return Queen | DoesNotJump;
            }
            if (dx % 17 == 0)
            {
                var steps = dx / 17;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + 17; (i & 0x88) == 0; i += 17)
                        if (i == toSquare) return Queen;
                        else if (cells[i] != 0)
                            return Queen | DoesNotJump;
            }
            if (dx % -15 == 0)
            {
                var steps = dx / -15;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + -15; (i & 0x88) == 0; i += -15)
                        if (i == toSquare) return Queen;
                        else if (cells[i] != 0)
                            return Queen | DoesNotJump;
            }
            if (dx % -17 == 0)
            {
                var steps = dx / -17;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + -17; (i & 0x88) == 0; i += -17)
                        if (i == toSquare) return Queen;
                        else if (cells[i] != 0)
                            return Queen | DoesNotJump;
            }
            if (dx % 15 == 0)
            {
                var steps = dx / 15;
                if (steps >= 0 && steps < 8)
                    for (var i = fromSquare + 15; (i & 0x88) == 0; i += 15)
                        if (i == toSquare) return Queen;
                        else if (cells[i] != 0)
                            return Queen | DoesNotJump;
            }
            return Queen | DoesNotMoveThisWay;
        }
        private static MoveAnnotations ValidateBlackKingMove(int fromSquare, int toSquare)
        {
            var dx = toSquare - fromSquare;
            switch (dx)
            {
                case 16: return King;
                case 17: return King;
                case 1: return King;
                case -15: return King;
                case -16: return King;
                case -17: return King;
                case -1: return King;
                case 15: return King;
            }
            return King | DoesNotMoveThisWay;
        }

        private static MoveAnnotations ValidateMove(byte[] cells, Piece piece, int fromSquare, int toSquare, Piece capture, Castlings availableCastlings)
        {
            switch (piece)
            {
                case Piece.WhitePawn:
                    return ValidateWhitePawnMove(cells, fromSquare, toSquare, capture);

                case Piece.WhiteBishop:
                    return ValidateWhiteBishopMove(cells, fromSquare, toSquare);

                case Piece.WhiteKnight:
                    return ValidateWhiteKnightMove(fromSquare, toSquare);

                case Piece.WhiteRook:
                    return ValidateWhiteRookMove(cells, fromSquare, toSquare);

                case Piece.WhiteQueen:
                    return ValidateWhiteQueenMove(cells, fromSquare, toSquare);

                case Piece.WhiteKing:
                    if (ValidateWhiteKingMove(fromSquare, toSquare) == King)
                        return King;
                    return ValidateWhiteCastlingMove(cells, fromSquare, toSquare, availableCastlings);

                case Piece.BlackPawn:
                    return ValidateBlackPawnMove(cells, fromSquare, toSquare, capture);

                case Piece.BlackBishop:
                    return ValidateBlackBishopMove(cells, fromSquare, toSquare);

                case Piece.BlackKnight:
                    return ValidateBlackKnightMove(fromSquare, toSquare);

                case Piece.BlackRook:
                    return ValidateBlackRookMove(cells, fromSquare, toSquare);

                case Piece.BlackQueen:
                    return ValidateBlackQueenMove(cells, fromSquare, toSquare);

                case Piece.BlackKing:
                    if (ValidateBlackKingMove(fromSquare, toSquare) == King)
                        return King;
                    return ValidateBlackCastlingMove(cells, fromSquare, toSquare, availableCastlings);

                default: throw new System.InvalidOperationException("Unknown piece: " + piece);
            }
        }
    }
}