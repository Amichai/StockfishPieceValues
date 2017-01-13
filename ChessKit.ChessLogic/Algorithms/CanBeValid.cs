/* This code is auto-generated! 
 * It is strongly adviced not to change it manually! */
using ChessKit.ChessLogic.Primitives;

namespace ChessKit.ChessLogic.Algorithms
{
    static class CanBeValid
    {
        public static bool CanBeValidMove(byte[] cells, Piece piece, int fromSquare, int toSquare)
        {
            var dx = toSquare - fromSquare;
            switch (piece)
            {
                #region ' White Pawn '

                case Piece.WhitePawn:
                    switch (dx)
                    {
                        case 16:
                            return cells[toSquare] == 0;
                        case 17:
                            return true;
                        case 15:
                            return true;
                        case 32:
                            return cells[toSquare] == 0;
                    }
                    return false;

                #endregion

                #region ' White Bishop '

                case Piece.WhiteBishop:
                    if (dx % 17 == 0)
                    {
                        var steps = dx / 17;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + 17; (i & 0x88) == 0; i += 17)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % -15 == 0)
                    {
                        var steps = dx / -15;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + -15; (i & 0x88) == 0; i += -15)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % -17 == 0)
                    {
                        var steps = dx / -17;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + -17; (i & 0x88) == 0; i += -17)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % 15 == 0)
                    {
                        var steps = dx / 15;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + 15; (i & 0x88) == 0; i += 15)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    return false;

                #endregion

                #region ' White Knight '

                case Piece.WhiteKnight:
                    switch (dx)
                    {
                        case 33:
                            return true;
                        case 31:
                            return true;
                        case -31:
                            return true;
                        case -33:
                            return true;
                        case 18:
                            return true;
                        case 14:
                            return true;
                        case -14:
                            return true;
                        case -18:
                            return true;
                    }
                    return false;

                #endregion

                #region ' White Rook '

                case Piece.WhiteRook:
                    if (dx % 16 == 0)
                    {
                        var steps = dx / 16;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + 16; (i & 0x88) == 0; i += 16)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % 1 == 0)
                    {
                        var steps = dx / 1;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + 1; (i & 0x88) == 0; i += 1)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % -16 == 0)
                    {
                        var steps = dx / -16;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + -16; (i & 0x88) == 0; i += -16)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % -1 == 0)
                    {
                        var steps = dx / -1;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + -1; (i & 0x88) == 0; i += -1)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    return false;

                #endregion

                #region ' White Queen '

                case Piece.WhiteQueen:
                    if (dx % 16 == 0)
                    {
                        var steps = dx / 16;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + 16; (i & 0x88) == 0; i += 16)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % 1 == 0)
                    {
                        var steps = dx / 1;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + 1; (i & 0x88) == 0; i += 1)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % -16 == 0)
                    {
                        var steps = dx / -16;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + -16; (i & 0x88) == 0; i += -16)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % -1 == 0)
                    {
                        var steps = dx / -1;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + -1; (i & 0x88) == 0; i += -1)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % 17 == 0)
                    {
                        var steps = dx / 17;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + 17; (i & 0x88) == 0; i += 17)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % -15 == 0)
                    {
                        var steps = dx / -15;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + -15; (i & 0x88) == 0; i += -15)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % -17 == 0)
                    {
                        var steps = dx / -17;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + -17; (i & 0x88) == 0; i += -17)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % 15 == 0)
                    {
                        var steps = dx / 15;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + 15; (i & 0x88) == 0; i += 15)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    return false;

                #endregion

                #region ' White King '

                case Piece.WhiteKing:
                    switch (dx)
                    {
                        case 16:
                            return true;
                        case 17:
                            return true;
                        case 1:
                            return true;
                        case -15:
                            return true;
                        case -16:
                            return true;
                        case -17:
                            return true;
                        case -1:
                            return true;
                        case 15:
                            return true;
                        case 2:
                            return cells[toSquare] == 0;
                        case -2:
                            return cells[toSquare] == 0;
                    }
                    return false;

                #endregion

                #region ' Black Pawn '

                case Piece.BlackPawn:
                    switch (dx)
                    {
                        case -16:
                            return cells[toSquare] == 0;
                        case -15:
                            return true;
                        case -17:
                            return true;
                        case -32:
                            return cells[toSquare] == 0;
                    }
                    return false;

                #endregion

                #region ' Black Bishop '

                case Piece.BlackBishop:
                    if (dx % 17 == 0)
                    {
                        var steps = dx / 17;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + 17; (i & 0x88) == 0; i += 17)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % -15 == 0)
                    {
                        var steps = dx / -15;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + -15; (i & 0x88) == 0; i += -15)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % -17 == 0)
                    {
                        var steps = dx / -17;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + -17; (i & 0x88) == 0; i += -17)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % 15 == 0)
                    {
                        var steps = dx / 15;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + 15; (i & 0x88) == 0; i += 15)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    return false;

                #endregion

                #region ' Black Knight '

                case Piece.BlackKnight:
                    switch (dx)
                    {
                        case 33:
                            return true;
                        case 31:
                            return true;
                        case -31:
                            return true;
                        case -33:
                            return true;
                        case 18:
                            return true;
                        case 14:
                            return true;
                        case -14:
                            return true;
                        case -18:
                            return true;
                    }
                    return false;

                #endregion

                #region ' Black Rook '

                case Piece.BlackRook:
                    if (dx % 16 == 0)
                    {
                        var steps = dx / 16;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + 16; (i & 0x88) == 0; i += 16)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % 1 == 0)
                    {
                        var steps = dx / 1;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + 1; (i & 0x88) == 0; i += 1)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % -16 == 0)
                    {
                        var steps = dx / -16;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + -16; (i & 0x88) == 0; i += -16)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % -1 == 0)
                    {
                        var steps = dx / -1;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + -1; (i & 0x88) == 0; i += -1)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    return false;

                #endregion

                #region ' Black Queen '

                case Piece.BlackQueen:
                    if (dx % 16 == 0)
                    {
                        var steps = dx / 16;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + 16; (i & 0x88) == 0; i += 16)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % 1 == 0)
                    {
                        var steps = dx / 1;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + 1; (i & 0x88) == 0; i += 1)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % -16 == 0)
                    {
                        var steps = dx / -16;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + -16; (i & 0x88) == 0; i += -16)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % -1 == 0)
                    {
                        var steps = dx / -1;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + -1; (i & 0x88) == 0; i += -1)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % 17 == 0)
                    {
                        var steps = dx / 17;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + 17; (i & 0x88) == 0; i += 17)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % -15 == 0)
                    {
                        var steps = dx / -15;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + -15; (i & 0x88) == 0; i += -15)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % -17 == 0)
                    {
                        var steps = dx / -17;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + -17; (i & 0x88) == 0; i += -17)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    if (dx % 15 == 0)
                    {
                        var steps = dx / 15;
                        if (steps >= 0 && steps < 8)
                            for (var i = fromSquare + 15; (i & 0x88) == 0; i += 15)
                                if (i == toSquare) return true;
                                else if (cells[i] != 0) return false;
                    }
                    return false;

                #endregion

                #region ' Black King '

                case Piece.BlackKing:
                    switch (dx)
                    {
                        case 16:
                            return true;
                        case 17:
                            return true;
                        case 1:
                            return true;
                        case -15:
                            return true;
                        case -16:
                            return true;
                        case -17:
                            return true;
                        case -1:
                            return true;
                        case 15:
                            return true;
                        case 2:
                            return cells[toSquare] == 0;
                        case -2:
                            return cells[toSquare] == 0;
                    }
                    return false;

                #endregion

                default:
                    return false;
            }
        }
    }
}