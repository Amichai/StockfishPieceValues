/* This code is auto-generated! 
 * It is strongly adviced not to change it manually! */
using System.Collections.Generic;
using ChessKit.ChessLogic.Primitives;
using static ChessKit.ChessLogic.Primitives.MoveAnnotations;

namespace ChessKit.ChessLogic.Algorithms
{
    static partial class MoveGeneration
    {
        public static void GenerateMoves(byte[] cells, 
			 int whiteKingSquare, int blackKingSquare, Piece piece, int fromSquare,
             int? enPassantFile, Castlings availableCastlings, List<GeneratedMove> collector)
        {
            switch (piece)
            {
                #region ' White Pawn '
                case Piece.WhitePawn:
                    GenerateWhitePawnMoves(cells, whiteKingSquare, fromSquare, enPassantFile, collector);
                    break;
                #endregion

                #region ' White Bishop '
                case Piece.WhiteBishop:
                    for (var to = fromSquare + 17; (to & 0x88) == 0; to += 17)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteBishop;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Bishop));
                            cells[fromSquare] = (byte)Piece.WhiteBishop;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteBishop;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Bishop | Capture));
                            cells[fromSquare] = (byte)Piece.WhiteBishop;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + -15; (to & 0x88) == 0; to += -15)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteBishop;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Bishop));
                            cells[fromSquare] = (byte)Piece.WhiteBishop;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteBishop;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Bishop | Capture));
                            cells[fromSquare] = (byte)Piece.WhiteBishop;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + -17; (to & 0x88) == 0; to += -17)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteBishop;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Bishop));
                            cells[fromSquare] = (byte)Piece.WhiteBishop;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteBishop;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Bishop | Capture));
                            cells[fromSquare] = (byte)Piece.WhiteBishop;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + 15; (to & 0x88) == 0; to += 15)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteBishop;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Bishop));
                            cells[fromSquare] = (byte)Piece.WhiteBishop;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteBishop;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Bishop | Capture));
                            cells[fromSquare] = (byte)Piece.WhiteBishop;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    break;
                #endregion

                #region ' White Knight '
                case Piece.WhiteKnight:
                    {
                        var to = fromSquare + 33;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.WhiteKnight;
                                if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.WhiteKnight;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.WhiteKnight;
                                if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight | Capture));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.WhiteKnight;
                            }
                        }
                    }
                    {
                        var to = fromSquare + 31;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.WhiteKnight;
                                if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.WhiteKnight;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.WhiteKnight;
                                if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight | Capture));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.WhiteKnight;
                            }
                        }
                    }
                    {
                        var to = fromSquare + -31;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.WhiteKnight;
                                if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.WhiteKnight;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.WhiteKnight;
                                if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight | Capture));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.WhiteKnight;
                            }
                        }
                    }
                    {
                        var to = fromSquare + -33;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.WhiteKnight;
                                if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.WhiteKnight;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.WhiteKnight;
                                if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight | Capture));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.WhiteKnight;
                            }
                        }
                    }
                    {
                        var to = fromSquare + 18;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.WhiteKnight;
                                if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.WhiteKnight;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.WhiteKnight;
                                if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight | Capture));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.WhiteKnight;
                            }
                        }
                    }
                    {
                        var to = fromSquare + 14;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.WhiteKnight;
                                if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.WhiteKnight;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.WhiteKnight;
                                if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight | Capture));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.WhiteKnight;
                            }
                        }
                    }
                    {
                        var to = fromSquare + -14;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.WhiteKnight;
                                if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.WhiteKnight;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.WhiteKnight;
                                if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight | Capture));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.WhiteKnight;
                            }
                        }
                    }
                    {
                        var to = fromSquare + -18;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.WhiteKnight;
                                if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.WhiteKnight;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.WhiteKnight;
                                if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight | Capture));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.WhiteKnight;
                            }
                        }
                    }
                    break;
                #endregion

                #region ' White Rook '
                case Piece.WhiteRook:
                    for (var to = fromSquare + 16; (to & 0x88) == 0; to += 16)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteRook;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Rook));
                            cells[fromSquare] = (byte)Piece.WhiteRook;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteRook;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Rook | Capture));
                            cells[fromSquare] = (byte)Piece.WhiteRook;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + 1; (to & 0x88) == 0; to += 1)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteRook;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Rook));
                            cells[fromSquare] = (byte)Piece.WhiteRook;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteRook;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Rook | Capture));
                            cells[fromSquare] = (byte)Piece.WhiteRook;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + -16; (to & 0x88) == 0; to += -16)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteRook;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Rook));
                            cells[fromSquare] = (byte)Piece.WhiteRook;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteRook;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Rook | Capture));
                            cells[fromSquare] = (byte)Piece.WhiteRook;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + -1; (to & 0x88) == 0; to += -1)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteRook;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Rook));
                            cells[fromSquare] = (byte)Piece.WhiteRook;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteRook;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Rook | Capture));
                            cells[fromSquare] = (byte)Piece.WhiteRook;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    break;
                #endregion

                #region ' White Queen '
                case Piece.WhiteQueen:
                    for (var to = fromSquare + 16; (to & 0x88) == 0; to += 16)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteQueen;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen));
                            cells[fromSquare] = (byte)Piece.WhiteQueen;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteQueen;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen | Capture));
                            cells[fromSquare] = (byte)Piece.WhiteQueen;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + 1; (to & 0x88) == 0; to += 1)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteQueen;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen));
                            cells[fromSquare] = (byte)Piece.WhiteQueen;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteQueen;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen | Capture));
                            cells[fromSquare] = (byte)Piece.WhiteQueen;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + -16; (to & 0x88) == 0; to += -16)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteQueen;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen));
                            cells[fromSquare] = (byte)Piece.WhiteQueen;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteQueen;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen | Capture));
                            cells[fromSquare] = (byte)Piece.WhiteQueen;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + -1; (to & 0x88) == 0; to += -1)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteQueen;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen));
                            cells[fromSquare] = (byte)Piece.WhiteQueen;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteQueen;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen | Capture));
                            cells[fromSquare] = (byte)Piece.WhiteQueen;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + 17; (to & 0x88) == 0; to += 17)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteQueen;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen));
                            cells[fromSquare] = (byte)Piece.WhiteQueen;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteQueen;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen | Capture));
                            cells[fromSquare] = (byte)Piece.WhiteQueen;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + -15; (to & 0x88) == 0; to += -15)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteQueen;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen));
                            cells[fromSquare] = (byte)Piece.WhiteQueen;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteQueen;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen | Capture));
                            cells[fromSquare] = (byte)Piece.WhiteQueen;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + -17; (to & 0x88) == 0; to += -17)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteQueen;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen));
                            cells[fromSquare] = (byte)Piece.WhiteQueen;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteQueen;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen | Capture));
                            cells[fromSquare] = (byte)Piece.WhiteQueen;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + 15; (to & 0x88) == 0; to += 15)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteQueen;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen));
                            cells[fromSquare] = (byte)Piece.WhiteQueen;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.WhiteQueen;
                            if (!cells.IsSquareAttackedByBlack(whiteKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen | Capture));
                            cells[fromSquare] = (byte)Piece.WhiteQueen;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    break;
                #endregion

                #region ' White King '
                case Piece.WhiteKing:
                    {
                        var to = fromSquare + 16;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByBlack(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King));
                                cells[fromSquare] = (byte)Piece.WhiteKing;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByBlack(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King | Capture));
                                cells[fromSquare] = (byte)Piece.WhiteKing;
                            }
                        }
                    }
                    {
                        var to = fromSquare + 17;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByBlack(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King));
                                cells[fromSquare] = (byte)Piece.WhiteKing;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByBlack(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King | Capture));
                                cells[fromSquare] = (byte)Piece.WhiteKing;
                            }
                        }
                    }
                    {
                        var to = fromSquare + 1;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByBlack(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King));
                                cells[fromSquare] = (byte)Piece.WhiteKing;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByBlack(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King | Capture));
                                cells[fromSquare] = (byte)Piece.WhiteKing;
                            }
                        }
                    }
                    {
                        var to = fromSquare + -15;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByBlack(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King));
                                cells[fromSquare] = (byte)Piece.WhiteKing;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByBlack(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King | Capture));
                                cells[fromSquare] = (byte)Piece.WhiteKing;
                            }
                        }
                    }
                    {
                        var to = fromSquare + -16;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByBlack(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King));
                                cells[fromSquare] = (byte)Piece.WhiteKing;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByBlack(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King | Capture));
                                cells[fromSquare] = (byte)Piece.WhiteKing;
                            }
                        }
                    }
                    {
                        var to = fromSquare + -17;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByBlack(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King));
                                cells[fromSquare] = (byte)Piece.WhiteKing;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByBlack(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King | Capture));
                                cells[fromSquare] = (byte)Piece.WhiteKing;
                            }
                        }
                    }
                    {
                        var to = fromSquare + -1;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByBlack(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King));
                                cells[fromSquare] = (byte)Piece.WhiteKing;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByBlack(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King | Capture));
                                cells[fromSquare] = (byte)Piece.WhiteKing;
                            }
                        }
                    }
                    {
                        var to = fromSquare + 15;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByBlack(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King));
                                cells[fromSquare] = (byte)Piece.WhiteKing;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.White)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByBlack(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King | Capture));
                                cells[fromSquare] = (byte)Piece.WhiteKing;
                            }
                        }
                    }
                    GenerateWhiteCastlingMoves(cells, fromSquare, availableCastlings, collector);
                    break;
                #endregion

                #region ' Black Pawn '
                case Piece.BlackPawn:
                    GenerateBlackPawnMoves(cells, blackKingSquare, fromSquare, enPassantFile, collector);
                    break;
                #endregion

                #region ' Black Bishop '
                case Piece.BlackBishop:
                    for (var to = fromSquare + 17; (to & 0x88) == 0; to += 17)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackBishop;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Bishop));
                            cells[fromSquare] = (byte)Piece.BlackBishop;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackBishop;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Bishop | Capture));
                            cells[fromSquare] = (byte)Piece.BlackBishop;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + -15; (to & 0x88) == 0; to += -15)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackBishop;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Bishop));
                            cells[fromSquare] = (byte)Piece.BlackBishop;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackBishop;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Bishop | Capture));
                            cells[fromSquare] = (byte)Piece.BlackBishop;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + -17; (to & 0x88) == 0; to += -17)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackBishop;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Bishop));
                            cells[fromSquare] = (byte)Piece.BlackBishop;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackBishop;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Bishop | Capture));
                            cells[fromSquare] = (byte)Piece.BlackBishop;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + 15; (to & 0x88) == 0; to += 15)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackBishop;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Bishop));
                            cells[fromSquare] = (byte)Piece.BlackBishop;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackBishop;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Bishop | Capture));
                            cells[fromSquare] = (byte)Piece.BlackBishop;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    break;
                #endregion

                #region ' Black Knight '
                case Piece.BlackKnight:
                    {
                        var to = fromSquare + 33;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.BlackKnight;
                                if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.BlackKnight;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.BlackKnight;
                                if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight | Capture));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.BlackKnight;
                            }
                        }
                    }
                    {
                        var to = fromSquare + 31;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.BlackKnight;
                                if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.BlackKnight;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.BlackKnight;
                                if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight | Capture));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.BlackKnight;
                            }
                        }
                    }
                    {
                        var to = fromSquare + -31;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.BlackKnight;
                                if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.BlackKnight;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.BlackKnight;
                                if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight | Capture));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.BlackKnight;
                            }
                        }
                    }
                    {
                        var to = fromSquare + -33;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.BlackKnight;
                                if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.BlackKnight;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.BlackKnight;
                                if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight | Capture));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.BlackKnight;
                            }
                        }
                    }
                    {
                        var to = fromSquare + 18;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.BlackKnight;
                                if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.BlackKnight;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.BlackKnight;
                                if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight | Capture));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.BlackKnight;
                            }
                        }
                    }
                    {
                        var to = fromSquare + 14;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.BlackKnight;
                                if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.BlackKnight;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.BlackKnight;
                                if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight | Capture));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.BlackKnight;
                            }
                        }
                    }
                    {
                        var to = fromSquare + -14;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.BlackKnight;
                                if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.BlackKnight;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.BlackKnight;
                                if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight | Capture));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.BlackKnight;
                            }
                        }
                    }
                    {
                        var to = fromSquare + -18;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.BlackKnight;
                                if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.BlackKnight;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                cells[to] = (byte)Piece.BlackKnight;
                                if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                    collector.Add(new GeneratedMove(fromSquare, to, Knight | Capture));
                                cells[to] = toPiece;
                                cells[fromSquare] = (byte)Piece.BlackKnight;
                            }
                        }
                    }
                    break;
                #endregion

                #region ' Black Rook '
                case Piece.BlackRook:
                    for (var to = fromSquare + 16; (to & 0x88) == 0; to += 16)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackRook;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Rook));
                            cells[fromSquare] = (byte)Piece.BlackRook;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackRook;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Rook | Capture));
                            cells[fromSquare] = (byte)Piece.BlackRook;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + 1; (to & 0x88) == 0; to += 1)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackRook;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Rook));
                            cells[fromSquare] = (byte)Piece.BlackRook;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackRook;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Rook | Capture));
                            cells[fromSquare] = (byte)Piece.BlackRook;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + -16; (to & 0x88) == 0; to += -16)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackRook;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Rook));
                            cells[fromSquare] = (byte)Piece.BlackRook;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackRook;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Rook | Capture));
                            cells[fromSquare] = (byte)Piece.BlackRook;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + -1; (to & 0x88) == 0; to += -1)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackRook;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Rook));
                            cells[fromSquare] = (byte)Piece.BlackRook;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackRook;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Rook | Capture));
                            cells[fromSquare] = (byte)Piece.BlackRook;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    break;
                #endregion

                #region ' Black Queen '
                case Piece.BlackQueen:
                    for (var to = fromSquare + 16; (to & 0x88) == 0; to += 16)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackQueen;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen));
                            cells[fromSquare] = (byte)Piece.BlackQueen;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackQueen;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen | Capture));
                            cells[fromSquare] = (byte)Piece.BlackQueen;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + 1; (to & 0x88) == 0; to += 1)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackQueen;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen));
                            cells[fromSquare] = (byte)Piece.BlackQueen;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackQueen;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen | Capture));
                            cells[fromSquare] = (byte)Piece.BlackQueen;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + -16; (to & 0x88) == 0; to += -16)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackQueen;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen));
                            cells[fromSquare] = (byte)Piece.BlackQueen;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackQueen;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen | Capture));
                            cells[fromSquare] = (byte)Piece.BlackQueen;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + -1; (to & 0x88) == 0; to += -1)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackQueen;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen));
                            cells[fromSquare] = (byte)Piece.BlackQueen;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackQueen;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen | Capture));
                            cells[fromSquare] = (byte)Piece.BlackQueen;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + 17; (to & 0x88) == 0; to += 17)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackQueen;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen));
                            cells[fromSquare] = (byte)Piece.BlackQueen;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackQueen;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen | Capture));
                            cells[fromSquare] = (byte)Piece.BlackQueen;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + -15; (to & 0x88) == 0; to += -15)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackQueen;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen));
                            cells[fromSquare] = (byte)Piece.BlackQueen;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackQueen;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen | Capture));
                            cells[fromSquare] = (byte)Piece.BlackQueen;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + -17; (to & 0x88) == 0; to += -17)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackQueen;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen));
                            cells[fromSquare] = (byte)Piece.BlackQueen;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackQueen;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen | Capture));
                            cells[fromSquare] = (byte)Piece.BlackQueen;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    for (var to = fromSquare + 15; (to & 0x88) == 0; to += 15)
                    {
                        var toPiece = cells[to];
                        if (toPiece == 0)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackQueen;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen));
                            cells[fromSquare] = (byte)Piece.BlackQueen;
                            cells[to] = toPiece;
                        }
                        else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                        {
                            cells[fromSquare] = (byte)Piece.EmptyCell;
                            cells[to] = (byte)Piece.BlackQueen;
                            if (!cells.IsSquareAttackedByWhite(blackKingSquare))
                                collector.Add(new GeneratedMove(fromSquare, to, Queen | Capture));
                            cells[fromSquare] = (byte)Piece.BlackQueen;
                            cells[to] = toPiece;
                            break;
                        }
                        else break;
                    }
                    break;
                #endregion

                #region ' Black King '
                case Piece.BlackKing:
                    {
                        var to = fromSquare + 16;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByWhite(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King));
                                cells[fromSquare] = (byte)Piece.BlackKing;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByWhite(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King | Capture));
                                cells[fromSquare] = (byte)Piece.BlackKing;
                            }
                        }
                    }
                    {
                        var to = fromSquare + 17;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByWhite(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King));
                                cells[fromSquare] = (byte)Piece.BlackKing;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByWhite(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King | Capture));
                                cells[fromSquare] = (byte)Piece.BlackKing;
                            }
                        }
                    }
                    {
                        var to = fromSquare + 1;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByWhite(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King));
                                cells[fromSquare] = (byte)Piece.BlackKing;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByWhite(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King | Capture));
                                cells[fromSquare] = (byte)Piece.BlackKing;
                            }
                        }
                    }
                    {
                        var to = fromSquare + -15;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByWhite(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King));
                                cells[fromSquare] = (byte)Piece.BlackKing;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByWhite(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King | Capture));
                                cells[fromSquare] = (byte)Piece.BlackKing;
                            }
                        }
                    }
                    {
                        var to = fromSquare + -16;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByWhite(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King));
                                cells[fromSquare] = (byte)Piece.BlackKing;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByWhite(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King | Capture));
                                cells[fromSquare] = (byte)Piece.BlackKing;
                            }
                        }
                    }
                    {
                        var to = fromSquare + -17;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByWhite(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King));
                                cells[fromSquare] = (byte)Piece.BlackKing;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByWhite(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King | Capture));
                                cells[fromSquare] = (byte)Piece.BlackKing;
                            }
                        }
                    }
                    {
                        var to = fromSquare + -1;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByWhite(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King));
                                cells[fromSquare] = (byte)Piece.BlackKing;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByWhite(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King | Capture));
                                cells[fromSquare] = (byte)Piece.BlackKing;
                            }
                        }
                    }
                    {
                        var to = fromSquare + 15;
                        if ((to & 0x88) == 0)
                        {
                            var toPiece = cells[to];
                            if (toPiece == 0)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByWhite(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King));
                                cells[fromSquare] = (byte)Piece.BlackKing;
                            }
                            else if ((Color)(toPiece & (byte)Color.Black) != Color.Black)
                            {
                                cells[fromSquare] = (byte)Piece.EmptyCell;
                                if (!cells.IsSquareAttackedByWhite(to))
                                    collector.Add(new GeneratedMove(fromSquare, to, King | Capture));
                                cells[fromSquare] = (byte)Piece.BlackKing;
                            }
                        }
                    }
                    GenerateBlackCastlingMoves(cells, fromSquare, availableCastlings, collector);
                    break;
                #endregion

            }
        }
    }
}