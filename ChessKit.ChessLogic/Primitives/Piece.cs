using System;
using static ChessKit.ChessLogic.Primitives.Color;
using static ChessKit.ChessLogic.Primitives.PieceType;

namespace ChessKit.ChessLogic.Primitives
{
    /// <summary>Represents pieces on the board (color + type) </summary>
    [Flags]
    public enum Piece : byte
    {
        EmptyCell,
        
        WhitePawn   = White | Pawn,
        WhiteBishop = White | Bishop,
        WhiteKnight = White | Knight,
        WhiteRook   = White | Rook,
        WhiteQueen  = White | Queen,
        WhiteKing   = White | King,
        
        BlackPawn   = Black | Pawn,
        BlackBishop = Black | Bishop,
        BlackKnight = Black | Knight,
        BlackRook   = Black | Rook,
        BlackQueen  = Black | Queen,
        BlackKing   = Black | King
    }
}                                                    