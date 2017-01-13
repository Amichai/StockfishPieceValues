/* This code is auto-generated! 
 * It is strongly adviced not to change it manually! */
using static ChessKit.ChessLogic.Primitives.Piece;

namespace ChessKit.ChessLogic.Algorithms
{
    static partial class Attacks
    {
        public static bool IsSquareAttackedByWhite(this byte[] cells, int square)
        {
            {
                var sq = square - 17;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) WhitePawn)
                        return true;
            }
            {
                var sq = square - 15;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) WhitePawn)
                        return true;
            }
            for (var i = square + 17; (i & 0x88) == 0; i += 17)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) WhiteBishop) return true;
                break;
            }
            for (var i = square + -15; (i & 0x88) == 0; i += -15)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) WhiteBishop) return true;
                break;
            }
            for (var i = square + -17; (i & 0x88) == 0; i += -17)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) WhiteBishop) return true;
                break;
            }
            for (var i = square + 15; (i & 0x88) == 0; i += 15)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) WhiteBishop) return true;
                break;
            }
            {
                var sq = square - 33;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) WhiteKnight)
                        return true;
            }
            {
                var sq = square - 31;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) WhiteKnight)
                        return true;
            }
            {
                var sq = square - -31;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) WhiteKnight)
                        return true;
            }
            {
                var sq = square - -33;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) WhiteKnight)
                        return true;
            }
            {
                var sq = square - 18;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) WhiteKnight)
                        return true;
            }
            {
                var sq = square - 14;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) WhiteKnight)
                        return true;
            }
            {
                var sq = square - -14;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) WhiteKnight)
                        return true;
            }
            {
                var sq = square - -18;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) WhiteKnight)
                        return true;
            }
            for (var i = square + 16; (i & 0x88) == 0; i += 16)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) WhiteRook) return true;
                break;
            }
            for (var i = square + 1; (i & 0x88) == 0; i += 1)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) WhiteRook) return true;
                break;
            }
            for (var i = square + -16; (i & 0x88) == 0; i += -16)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) WhiteRook) return true;
                break;
            }
            for (var i = square + -1; (i & 0x88) == 0; i += -1)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) WhiteRook) return true;
                break;
            }
            for (var i = square + 16; (i & 0x88) == 0; i += 16)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) WhiteQueen) return true;
                break;
            }
            for (var i = square + 1; (i & 0x88) == 0; i += 1)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) WhiteQueen) return true;
                break;
            }
            for (var i = square + -16; (i & 0x88) == 0; i += -16)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) WhiteQueen) return true;
                break;
            }
            for (var i = square + -1; (i & 0x88) == 0; i += -1)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) WhiteQueen) return true;
                break;
            }
            for (var i = square + 17; (i & 0x88) == 0; i += 17)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) WhiteQueen) return true;
                break;
            }
            for (var i = square + -15; (i & 0x88) == 0; i += -15)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) WhiteQueen) return true;
                break;
            }
            for (var i = square + -17; (i & 0x88) == 0; i += -17)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) WhiteQueen) return true;
                break;
            }
            for (var i = square + 15; (i & 0x88) == 0; i += 15)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) WhiteQueen) return true;
                break;
            }
            {
                var sq = square - 16;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) WhiteKing)
                        return true;
            }
            {
                var sq = square - 17;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) WhiteKing)
                        return true;
            }
            {
                var sq = square - 1;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) WhiteKing)
                        return true;
            }
            {
                var sq = square - -15;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) WhiteKing)
                        return true;
            }
            {
                var sq = square - -16;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) WhiteKing)
                        return true;
            }
            {
                var sq = square - -17;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) WhiteKing)
                        return true;
            }
            {
                var sq = square - -1;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) WhiteKing)
                        return true;
            }
            {
                var sq = square - 15;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) WhiteKing)
                        return true;
            }
            return false;
        }
        public static bool IsSquareAttackedByBlack(this byte[] cells, int square)
        {
            {
                var sq = square - -15;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) BlackPawn)
                        return true;
            }
            {
                var sq = square - -17;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) BlackPawn)
                        return true;
            }
            for (var i = square + 17; (i & 0x88) == 0; i += 17)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) BlackBishop) return true;
                break;
            }
            for (var i = square + -15; (i & 0x88) == 0; i += -15)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) BlackBishop) return true;
                break;
            }
            for (var i = square + -17; (i & 0x88) == 0; i += -17)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) BlackBishop) return true;
                break;
            }
            for (var i = square + 15; (i & 0x88) == 0; i += 15)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) BlackBishop) return true;
                break;
            }
            {
                var sq = square - 33;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) BlackKnight)
                        return true;
            }
            {
                var sq = square - 31;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) BlackKnight)
                        return true;
            }
            {
                var sq = square - -31;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) BlackKnight)
                        return true;
            }
            {
                var sq = square - -33;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) BlackKnight)
                        return true;
            }
            {
                var sq = square - 18;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) BlackKnight)
                        return true;
            }
            {
                var sq = square - 14;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) BlackKnight)
                        return true;
            }
            {
                var sq = square - -14;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) BlackKnight)
                        return true;
            }
            {
                var sq = square - -18;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) BlackKnight)
                        return true;
            }
            for (var i = square + 16; (i & 0x88) == 0; i += 16)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) BlackRook) return true;
                break;
            }
            for (var i = square + 1; (i & 0x88) == 0; i += 1)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) BlackRook) return true;
                break;
            }
            for (var i = square + -16; (i & 0x88) == 0; i += -16)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) BlackRook) return true;
                break;
            }
            for (var i = square + -1; (i & 0x88) == 0; i += -1)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) BlackRook) return true;
                break;
            }
            for (var i = square + 16; (i & 0x88) == 0; i += 16)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) BlackQueen) return true;
                break;
            }
            for (var i = square + 1; (i & 0x88) == 0; i += 1)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) BlackQueen) return true;
                break;
            }
            for (var i = square + -16; (i & 0x88) == 0; i += -16)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) BlackQueen) return true;
                break;
            }
            for (var i = square + -1; (i & 0x88) == 0; i += -1)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) BlackQueen) return true;
                break;
            }
            for (var i = square + 17; (i & 0x88) == 0; i += 17)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) BlackQueen) return true;
                break;
            }
            for (var i = square + -15; (i & 0x88) == 0; i += -15)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) BlackQueen) return true;
                break;
            }
            for (var i = square + -17; (i & 0x88) == 0; i += -17)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) BlackQueen) return true;
                break;
            }
            for (var i = square + 15; (i & 0x88) == 0; i += 15)
            {
                var piece = cells[i];
                if (piece == 0) continue;
                if (piece == (byte) BlackQueen) return true;
                break;
            }
            {
                var sq = square - 16;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) BlackKing)
                        return true;
            }
            {
                var sq = square - 17;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) BlackKing)
                        return true;
            }
            {
                var sq = square - 1;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) BlackKing)
                        return true;
            }
            {
                var sq = square - -15;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) BlackKing)
                        return true;
            }
            {
                var sq = square - -16;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) BlackKing)
                        return true;
            }
            {
                var sq = square - -17;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) BlackKing)
                        return true;
            }
            {
                var sq = square - -1;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) BlackKing)
                        return true;
            }
            {
                var sq = square - 15;
                if ((sq & 0x88) == 0)
                    if (cells[sq] == (byte) BlackKing)
                        return true;
            }
            return false;
        }
    }
}