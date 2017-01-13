using System;

namespace ChessKit.ChessLogic.Primitives
{
    /// <summary>Critical errors that can be noticed about the move during
    /// the legality check</summary>
    [Flags]
    public enum MoveErrors
    {
        None = 0,

        /// <summary> Your king can be captured the next move </summary>
        MoveToCheck = 0x00008000,

        /// <summary> Your move originates in the empty cell </summary>
        EmptyCell = 0x00010000,

        /// <summary> It's not your turn to move (not your piece to move) </summary>
        WrongSideToMove = 0x00020000,

        /// <summary> You can't castle because the King or the Rook had moved </summary>
        HasNoCastling = 0x00040000,

        /// <summary> The move destinates in the cell occupied by the piece of your own </summary>
        ToOccupiedCell = 0x00080000,

        /// <summary> You can't capture en passant because it's been a while since
        /// the opponent's pawn moved </summary>
        HasNoEnPassant = 0x00100000,

        /// <summary> Your sliding or castling move jumps over other pieces,
        /// only knights can do that </summary>
        DoesNotJump = 0x00200000,

        /// <summary> Pawn can't move the way it can capture </summary>
        OnlyCapturesThisWay = 0x00400000,

        /// <summary> Pawn can't capture the way it moves </summary>
        DoesNotCaptureThisWay = 0x00800000,

        /// <summary> You can't castle if the square, the King transits through
        /// is under attack right now </summary>
        CastleThroughCheck = 0x01000000,

        /// <summary> The piece doesn't move that way (e.g. bishop cannot move a1-a2) </summary>
        DoesNotMoveThisWay = 0x02000000,

        /// <summary> You can't casle if your king is under check right now </summary>
        CastleFromCheck = 0x04000000,

        All = MoveToCheck
              | EmptyCell
              | WrongSideToMove
              | HasNoCastling
              | ToOccupiedCell
              | HasNoEnPassant
              | DoesNotJump
              | OnlyCapturesThisWay
              | DoesNotCaptureThisWay
              | CastleThroughCheck
              | DoesNotMoveThisWay
              | CastleFromCheck
    }
}