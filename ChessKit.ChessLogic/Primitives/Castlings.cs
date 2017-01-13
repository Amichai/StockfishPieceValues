using System;

// ReSharper disable InconsistentNaming

namespace ChessKit.ChessLogic.Primitives
{
    /// <summary> Represents different castling options 
    ///   that can be available to players </summary>
    [Flags]
    public enum Castlings
    {
        None = 0,

        /// <summary> Black's kingside castling </summary>  
        BK = 0x080,

        /// <summary> Black's queenside castling </summary>
        BQ = 0x100,

        /// <summary> Whites's kingside castling </summary>
        WK = 0x200,

        /// <summary> Whites's queenside castling </summary>
        WQ = 0x400,

        White = WK | WQ,
        Black = BK | BQ,

        All = BK | BQ | WK | WQ
    }
}