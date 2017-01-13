using System;

namespace ChessKit.ChessLogic.Primitives
{
    /// <summary> Represents different outcomes 
    /// to the position a move can have </summary>
    [Flags]
    public enum GameStates
    {
        None = 0,

        /// <summary>The last move gives check</summary>
        Check = 0x01,

        /// <summary>The last move gives check and mate</summary>
        Mate = 0x02,

        /// <summary>All existing draw outcomes</summary>
        Draw = 0x04,

        /// <summary>Draw by threefold repetition</summary>
        Repetition = 0x08,

        /// <summary>Draw by not capturing or moving pawn for 50 moves</summary>
        FiftyMoveRule = 0x10,

        /// <summary>Draw by not leaving the opponent any legal moves</summary>
        Stalemate = 0x20,

        /// <summary>Draw by both sides not having enough material to give mate</summary>
        InsufficientMaterial = 0x40
    }
}