using System;

namespace ChessKit.ChessLogic.Primitives
{
    /// <summary>Non-critical error that can be noticed about the move during
    /// the legality check</summary>
    [Flags]
    public enum MoveWarnings
    {
        None = 0,

        /// <summary>It was annotated as Promotion but no PromoteTo
        /// piece type was assigned. Queens was used by default</summary>
        MissingPromotionHint = 0x08000000,

        /// <summary>It was not a promotion move, but PromoteTo
        /// contained non-empty piece type, that was ignored</summary>
        PromotionHintIsNotNeeded = 0x10000000,

        All = MissingPromotionHint
            | PromotionHintIsNotNeeded
    }
}