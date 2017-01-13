using System;

namespace ChessKit.ChessLogic.Primitives
{
    /// <summary>Notes that can be made 
    ///     to the move during the legality check </summary>
    [Flags]
    public enum MoveInfo 
    {
        None = 0,

        /// <summary> It was a pawn move to the last rank </summary>
        Promotion = 0x00000800,

        /// <summary> It captured the opponents piece </summary>
        Capture = 0x00001000,

        /// <summary> It was a pawn move to capture en passant </summary>
        EnPassant = 0x00002000,

        /// <summary> It was the pawn move 2 squares ahead from the original rank </summary>
        DoublePush = 0x00004000,

        All = Promotion
            | Capture
            | EnPassant
            | DoublePush
    }
}