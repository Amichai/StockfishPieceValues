using System;

namespace ChessKit.ChessLogic.Primitives
{
    /// <summary> Represents different piece types </summary>
    public enum PieceType
    {
        None   = 0,
        Pawn   = 0x02,
        Bishop = 0x04,
        Knight = 0x08,
        Rook   = 0x10,
        Queen  = 0x20,
        King   = 0x40,

        All = Pawn
            | Bishop
            | Knight
            | Rook
            | Queen
            | King
    }
}