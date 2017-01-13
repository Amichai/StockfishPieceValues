using ChessKit.ChessLogic.Primitives;

namespace ChessKit.ChessLogic
{
    /// <summary>Represents an illegal move as returned by the legality check</summary>
    public sealed class IllegalMove : AnalyzedMove
    {
        /// <summary>Errors to the move</summary>
        public MoveErrors Errors => MoveErrors.All & (MoveErrors)Annotations;

        internal IllegalMove(Move move, Position originalPosition, MoveAnnotations annotations)
            : base(annotations, originalPosition, move)
        {
        }
    }
}