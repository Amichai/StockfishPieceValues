using ChessKit.ChessLogic.Primitives;

namespace ChessKit.ChessLogic
{
    /// <summary>Represents move after validation</summary>
    public abstract class AnalyzedMove
    {
        /// <summary>The move that was checked for the legality</summary>
        public Move Move { get; }

        /// <summary>The position in which the move was checked</summary>
        public Position OriginalPosition { get; }

        internal AnalyzedMove(MoveAnnotations annotations, Position originalPosition, Move move)
        {
            Annotations = annotations;
            OriginalPosition = originalPosition;
            Move = move;
        }

        /// <summary>Annotations (capture, promotion attempt, etc.) to the move</summary>
        internal MoveAnnotations Annotations { get; }

        /// <summary>The castling, if the move was castling attempt, -or- None</summary>
        public Castlings Castling => Castlings.All & (Castlings)Annotations;

        /// <summary>Warnings to the move</summary>
        public MoveWarnings Warnings => MoveWarnings.All & (MoveWarnings)Annotations;
        /// <summary>Info to the move</summary>
        public MoveInfo Info => MoveInfo.All & (MoveInfo)Annotations;
        /// <summary>The piece type that was moved</summary>
        public PieceType Piece => PieceType.All & (PieceType)Annotations;

    }
}